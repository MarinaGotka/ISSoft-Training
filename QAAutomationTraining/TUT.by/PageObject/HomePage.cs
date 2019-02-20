namespace TUT.by.PageObject
{
    public class HomePage : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='authorize']/div/a")]
        WebElement LoginButton;

        [FindsBy(How = How.CssSelector, Using = "span.uname")]
        WebElement UsernameAfterlogin;

        [FindsBy(How = How.XPath, Using = "//*[@id='authorize']//a[contains(@href, 'logout')]")]
        WebElement LogoutButton;


        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void LogInClick() => LoginButton.Click();

        public bool IsAt() => LoginButton.Displayed;

        public void Logout()
        {
            UsernameAfterlogin.Click();
            LogoutButton.Click();
        }
    }
}