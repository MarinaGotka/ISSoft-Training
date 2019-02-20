using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TUT.@by.PageObject.Popup;

namespace TUT.by.PageObject
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='authorize']/div/a")]
        private IWebElement LoginButton;

        [FindsBy(How = How.CssSelector, Using = "span.uname")]
        private IWebElement UsernameAfterlogin;

        [FindsBy(How = How.XPath, Using = "//*[@id='authorize']//a[contains(@href, 'logout')]")]
        private IWebElement LogoutButton;

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public LoginPopUp LogInClick()
        {
            LoginButton.Click();

            LoginPopUp loginPopUp = new LoginPopUp(driver);
            PageFactory.InitElements(driver, loginPopUp);
            return loginPopUp;
        }

        public bool IsAt() => LoginButton.Displayed;

        public HomePage Logout()
        {
            UsernameAfterlogin.Click();
            LogoutButton.Click();

            return this;
        }
    }
}