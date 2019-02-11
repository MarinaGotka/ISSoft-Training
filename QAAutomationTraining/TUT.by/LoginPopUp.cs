using OpenQA.Selenium;

namespace TUT.by
{
    public class LoginPopUp : BasePage
    {
        private readonly By UsernameField = By.CssSelector("input[name = 'login']");
        private readonly By PasswordField = By.XPath("//input[@name = 'password']");
        private readonly By LoginButton = By.XPath("//input[contains(@type, 'submit')]");
        private readonly By UsernameAfterlogin = By.CssSelector("span.uname");
        private readonly By LogoutButton = By.XPath("//*[@id='authorize']//a[contains(@href, 'logout')]");
        private IWebDriver driver;

        public LoginPopUp(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Login(string username, string password)
        {
            driver.FindElement(UsernameField).SendKeys(username);
            driver.FindElement(PasswordField).SendKeys(password);
            driver.FindElement(LoginButton).Click();
        }

        public bool LoginAs(string username)
        {
            WaitUntilDisplayed(driver, UsernameAfterlogin); //Method with explicit waiter

            return driver.FindElement(UsernameAfterlogin).Text.Equals(username);
        }

        public void Logout()
        {
            driver.FindElement(UsernameAfterlogin).Click();
            driver.FindElement(LogoutButton).Click();
        }
    }
}