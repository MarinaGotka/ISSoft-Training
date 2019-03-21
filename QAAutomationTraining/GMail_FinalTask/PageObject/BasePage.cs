using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using GMail_FinalTask.WebDriver;

namespace GMail_FinalTask.PageObject
{
    public class BasePage
    {
        private readonly IClock clock = new SystemClock();

        public BasePage()
        {
            PageFactory.InitElements(DriverFactory.GetDriver(), this);
        }

        public IWebElement WaitUntilVisible(this By locator, int secondsToWait = 15)
        {
            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(secondsToWait));
            wait.Until(ElementIsVisible(locator));

            return DriverFactory.GetDriver().FindElement(locator);
        }
    }
}
