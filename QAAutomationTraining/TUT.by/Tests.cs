using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace TUT.by
{
    [TestFixture]
    public class Tests
    {
        private readonly string UserNameAfterLogin = "Selenium Test";
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.tut.by/");
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
            HomePage homePage = new HomePage(driver);
            LoginPopUp loginPopUp = new LoginPopUp(driver);

            homePage.LogInClick();
            Thread.Sleep(1000); // Explicit wait
            loginPopUp.Login(username, password);

            Assert.True(loginPopUp.LoginAs(UserNameAfterLogin), "Username after login is wrong.");
        }
    }
}
