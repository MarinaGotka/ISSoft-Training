using OpenQA.Selenium;

namespace TUT.by.PageObject.Popup
{
    public class LoginPopUp : BasePage
    {
        private readonly By UsernameField = By.CssSelector("input[name = 'login']");
        private readonly By PasswordField = By.XPath("//input[@name = 'password']");
        private readonly By LoginButton = By.XPath("//input[contains(@type, 'submit')]");
        private readonly By UsernameAfterlogin = By.CssSelector("span.uname");
        private IWebDriver driver;

        public LoginPopUp(IWebDriver driver) : base(driver)
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
            WaitUntilDisplayed(UsernameAfterlogin); //Method with explicit waiter

            return driver.FindElement(UsernameAfterlogin).Text.Equals(username);
        }
    }
}