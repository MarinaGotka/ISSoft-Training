using NUnit.Framework;
using GMail_FinalTask.PageObject;

namespace GMail_FinalTask.Tests
{
    [TestFixture]
    public class AuthorizationTests : BaseTest
    {
        LoginPage loginPage = new LoginPage();
        HomePage homePage = new HomePage();

        [TestCase("seleniumtests10", "060788avavav")]
        public void LoginTest(string username, string password)
        {
            loginPage.Login(username, password);
            Assert.True(homePage.IsLoggedIn(), "User is not logged in");
        }
    }
}
