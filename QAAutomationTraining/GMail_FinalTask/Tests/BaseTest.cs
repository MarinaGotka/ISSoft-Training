using System;
using GMail_FinalTask.WebDriver;

namespace GMail_FinalTask.Tests
{
    public class BaseTest : IDisposable
    {
        public BaseTest()
        {
            DriverFactory.GetDriver().Manage().Cookies.DeleteAllCookies();
            DriverFactory.GetDriver().Navigate().GoToUrl("https://www.gmail.com");
        }

        public void Dispose()
        {
            DriverFactory.CloseBrowser();
        }
    }
}
