using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TUT.by
{
    [TestFixture]
    public class Tests
    {
        private readonly string Username = "seleniumtests@tut.by";
        private readonly string Password = "123456789zxcvbn";
        private readonly string UserNameAfterLogin = "Selenium Test";

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
        public void LoginTutByTest()
        {
            HomePage.LogInClick();
            LoginPopUp.Login(Username, Password);

            Assert.True(LoginPopUp.LoginAs(UserNameAfterLogin));
        }
    }
}
