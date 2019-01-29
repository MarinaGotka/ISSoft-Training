using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TUT.by
{
    public static class HomePage
    {
        private static readonly By LoginButton = By.XPath("//*[@id='authorize']/div/a");
        public static IWebDriver driver = new ChromeDriver();

        public static void LogInClick() => driver.FindElement(LoginButton).Click();

        public static void GoToUrl(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }
    }
}
