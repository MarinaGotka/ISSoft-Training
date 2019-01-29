using OpenQA.Selenium;

namespace TUT.by
{
    public static class LoginPopUp
    {
        private static readonly By UsernameField = By.CssSelector("input[name = 'login']");
        private static readonly By PasswordField = By.XPath("//input[@name = 'password']");
        private static readonly By LoginButton = By.XPath("//input[contains(@type, 'submit')]");
        private static readonly By UsernameAfterlogin = By.CssSelector("span.uname");
        private static readonly By LogoutButton = By.XPath("//*[@id='authorize']//a[contains(@href, 'logout')]");

        public static void Login(string username, string password)
        {
            HomePage.driver.FindElement(UsernameField).SendKeys(username);
            HomePage.driver.FindElement(PasswordField).SendKeys(password);
            HomePage.driver.FindElement(LoginButton).Click();
        }

        public static bool LoginAs(string username) => HomePage.driver.FindElement(UsernameAfterlogin).Text.Equals(username);

        public static void Logout()
        {
            HomePage.driver.FindElement(UsernameAfterlogin).Click();
            HomePage.driver.FindElement(LogoutButton).Click();
        }
    }
}
