using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GMail_FinalTask.PageObject
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@type = 'email']")]
        private readonly IWebElement UsernameTextField;

        [FindsBy(How = How.XPath, Using = "//input[@type = 'password']")]
        private readonly IWebElement PasswordTextField;

        [FindsBy(How = How.XPath, Using = "//*[contains(@id,'Next')]")]
        private readonly IWebElement NextButton;

        public bool IsAt() => NextButton.Displayed;

        public void Login(string username, string password)
        {
            UsernameTextField.SendKeys(username);
            NextButton.Click();
            PasswordTextField.SendKeys(password);
            NextButton.Click();
            (new HomePage()).WaitLoadingPage();
        }
    }
}
