namespace TUT.by.PageObject.Popup
{
    public class LoginPopUp : BasePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "input[name = 'login']")]
        WebElement UsernameField;

        [FindsBy(How = How.XPath, Using = "//input[@name = 'password']")]
        WebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//input[contains(@type, 'submit')]")]
        WebElement LoginButton;

        [FindsBy(How = How.CssSelector, Using = "span.uname")]
        WebElement UsernameAfterlogin;


        public LoginPopUp(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void Login(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }

        public bool LoginAs(string username)
        {
            WaitUntilDisplayed(UsernameAfterlogin); //Method with explicit waiter

            return UsernameAfterlogin.Text.Equals(username);
        }
    }
}