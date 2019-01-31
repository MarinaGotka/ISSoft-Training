using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TUT.by
{
    public class BasePage
    {
        public void WaitUntilDisplayed(IWebDriver driver, By locator)
        {
            var element = new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(condition =>
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
