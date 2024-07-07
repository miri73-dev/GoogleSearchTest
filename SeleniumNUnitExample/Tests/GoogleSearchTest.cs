using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumNUnitExample.Tests.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample.Tests
{
    internal class GoogleSearchTest
    {
        private IWebDriver driver;
        GoogleHomePage googleHomePage;
        GoogleResultsPage googleResultsPage;
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
            googleResultsPage = new GoogleResultsPage(driver);

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
            if (googleResultsPage.ResultsDisplayed())
            {
                ClassicAssert.IsTrue(driver.Title.Contains("Selenium WebDriver"));
            }

            googleResultsPage.FirstAndClick();
            ClassicAssert.IsTrue(driver.Title.Contains("Selenium WebDriver"));
            googleResultsPage.goBack();

        }
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
