using OpenQA.Selenium;

namespace TUT.by.PageObject
{
    public class HomePage : BasePage
    {
        private readonly By LoginButton = By.XPath("//*[@id='authorize']/div/a");
        private readonly By UsernameAfterlogin = By.CssSelector("span.uname");
        private readonly By LogoutButton = By.XPath("//*[@id='authorize']//a[contains(@href, 'logout')]");
        private IWebDriver driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void LogInClick() => driver.FindElement(LoginButton).Click();

        public bool IsAt() => driver.FindElement(LoginButton).Displayed;

        public void Logout()
        {
            driver.FindElement(UsernameAfterlogin).Click();
            driver.FindElement(LogoutButton).Click();
        }
    }
}