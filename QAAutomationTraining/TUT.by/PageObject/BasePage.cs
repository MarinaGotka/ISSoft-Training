using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TUT.by.PageObject
{
    public class BasePage
    {
        private readonly IClock clock = new SystemClock();
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitUntilDisplayed(By locator)
        {
            //Polling frequency 500 ms is added 
            var element = new WebDriverWait(clock, driver, TimeSpan.FromSeconds(15), TimeSpan.FromMilliseconds(500)).Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(locator);

                    return elementToBeDisplayed.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
    }
}
