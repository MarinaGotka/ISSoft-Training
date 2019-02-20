using System;
using System.Threading;

namespace TUT.by.Tests
{
    [TestFixture]
    public class TutByTests
    {
        private readonly string UserNameAfterLogin = "Selenium Test";
        private readonly string Url = "https://www.tut.by/";
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15); // Implicit waiter for WebDriver. 
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        [TestCase("seleniumtests2@tut.by", "123456789zxcvbn")]
        public void LoginTutByTest(string username, string password)
        {
            HomePage homePage = PageFactory.InitElements(driver, HomePage);
            LoginPopUp loginPopUp = PageFactory.InitElements(driver, LoginPopUp);

            homePage.LogInClick();
            Thread.Sleep(1000); // Explicit wait
            loginPopUp.Login(username, password);

            Assert.True(loginPopUp.LoginAs(UserNameAfterLogin), "Username after login is wrong.");
        }

        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        public void LogoutTutByTest(string username, string password)
        {
            HomePage homePage = PageFactory.InitElements(driver, HomePage);
            LoginPopUp loginPopUp = PageFactory.InitElements(driver, LoginPopUp);

            homePage.LogInClick();
            Thread.Sleep(1000); // Explicit wait
            loginPopUp.Login(username, password);

            Assert.True(loginPopUp.LoginAs(UserNameAfterLogin), "Username after login is wrong.");

            homePage.Logout();

            Assert.True(homePage.IsAt(), "Home page isn't opened.");
        }
    }
}
