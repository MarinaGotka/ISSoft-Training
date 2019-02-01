using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TUT.by
{
    public class BasePage
    {
        private readonly IClock clock = new SystemClock();

        public void WaitUntilDisplayed(IWebDriver driver, By locator)
        {
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
