using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TUT.by
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Init()
        {
            HomePage.GoToUrl("https://www.tut.by/");
        }

        [TearDown]
        public void Dispose()
        {
            LoginPopUp.Logout();
            HomePage.driver.Close();
        }

        [Test]
        public void LoginTutBy()
        {
            string username = "seleniumtests@tut.by";
            string password = "123456789zxcvbn";
            string userNameAfterLogin = "Selenium Test";

            HomePage.LogInClick();
            LoginPopUp.Login(username, password);

            Assert.True(LoginPopUp.LoginAs(userNameAfterLogin));
        }
    }
}
