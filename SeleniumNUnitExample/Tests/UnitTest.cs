using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumNUnitExample.Tests.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample.Tests
{
    [TestFixture]
    public class GoogleSearchTest
    {
        private IWebDriver driver;
        GoogleHomePage googleHomePage;

        public GoogleSearchTest()
        {

        }

        [SetUp]
        public void SetUp()
        {
            string path = @"T:\הנדסת תוכנה\שנה ב\קבוצה ב\תלמידות\מירי קרלנשטיין\פיתוח אוטומציה\GoogleSearchTest";

            driver = new ChromeDriver(path + @"\drivers\");
            driver.Manage().Window.Maximize();
            googleHomePage = new GoogleHomePage(driver);
            
        }

        [Test]
        public void TestGoogleSearch()
        {
            //step1: Navigate to google
            googleHomePage.NavigateTo("https://WWW.Google.com");

            //step1: Verify the title of the page.
            ClassicAssert.AreEqual("Google", driver.Title);

            //step3: Find and interact with web elements (search box, search button).
            //step4: Submit the search and wait for the results.
            googleHomePage.Search("APjFqb", "Selenium WebDriver");

            //step5: 
            System.Threading.Thread.Sleep(3000);
            ClassicAssert.IsTrue(driver.Title.Contains("Selenium WebDriver"));

            //step6: Verify that search results are displayed.
            IWebElement results = driver.FindElement(By.Id("search"));
            ClassicAssert.IsTrue(results.Displayed);

            //step7: Click on the first result link.
            IWebElement firstResult = driver.FindElement(By.CssSelector("h3"));
            firstResult.Click();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

    }
}