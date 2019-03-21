using GMail_FinalTask.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GMail_FinalTask.PageObject
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//span[@class = 'gb_ya gbii']")]
        private readonly IWebElement AccountIcon;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Sign out')]")]
        private readonly IWebElement SignOutButton;

        public bool IsLoggedIn() => AccountIcon.Displayed;

        public void WaitLoadingPage() => WaitUntilDisplayed(AccountIcon);

        public void Logout()
        {
            AccountIcon.Click();
            SignOutButton.Click();
        }

    }
}
