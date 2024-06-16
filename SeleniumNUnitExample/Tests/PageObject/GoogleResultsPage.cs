using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample.Tests.PageObject
{
    internal class GoogleResultsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        ReadOnlyCollection<IWebElement> searchResults;


        public GoogleResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public bool ResultsDisplayed() {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.XPath(".//a"))));
            searchResults = resultsPanel.FindElements(By.XPath(".//a"));
        }
        

    }
}
