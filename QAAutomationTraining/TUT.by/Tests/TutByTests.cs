using NUnit.Framework;
using System.Threading;
using NUnit.Framework.Internal;
using TUT.by.PageObject;
using TUT.by.PageObject.Popup;

namespace TUT.by.Tests
{
    [TestFixture]
    public class TutByTests : BaseTest
    {
        private readonly string UserNameAfterLogin = "Selenium Test";

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

        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        public void LogoutTutByTest(string username, string password)
        {
            HomePage homePage = new HomePage(driver);
            LoginPopUp loginPopUp = new LoginPopUp(driver);

            homePage.LogInClick();
            Thread.Sleep(1000); // Explicit wait
            loginPopUp.Login(username, password);

            Assert.True(loginPopUp.LoginAs(UserNameAfterLogin), "Username after login is wrong.");

            homePage.Logout();

            Assert.True(homePage.IsAt(), "Home page isn't opened.");
        }
    }
}
