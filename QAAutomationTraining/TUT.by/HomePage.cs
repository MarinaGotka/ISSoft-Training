using OpenQA.Selenium;

namespace TUT.by
{
    public class HomePage : BasePage
    {
        private readonly By LoginButton = By.XPath("//*[@id='authorize']/div/a");
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LogInClick() => driver.FindElement(LoginButton).Click();
    }
}