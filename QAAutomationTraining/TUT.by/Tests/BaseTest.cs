using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TUT.by.Tests
{
    public class BaseTest
    {
        private readonly string Url = "https://www.tut.by/";
        private readonly string Username = "marinagotka";
        private readonly string Key = "649d181d-8da4-48f7-97ed-9d63e8084057";
        public IWebDriver driver;
        public string os;
        public string browser;
        public string version;

        public BaseTest(string os, string browser, string version)
        {
            this.os = os;
            this.browser = browser;
            this.version = version;
        }

        [SetUp]
        public void SetUp()
        {
            string uri = "http://{0}:{1}" + "@ondemand.eu-central-1.saucelabs.com:80/wd/hub";
            var Options = GetOptions(os,browser,version);
            driver = new RemoteWebDriver(new Uri(string.Format(uri,Username,Key)), Options.ToCapabilities(), TimeSpan.FromSeconds(25000));
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15); // Implicit waiter for WebDriver. 
            TakeScreenshot();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        public void TakeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(Path.Combine(Environment.CurrentDirectory, "Screenshot " + TestContext.CurrentContext.Test.MethodName.ToString()), ScreenshotImageFormat.Jpeg);
        }

        private DriverOptions GetOptions(string os, string browserName, string version)
        {
            switch (browserName)
            {
                case "Microsoft Edge":
                    driver = new EdgeDriver();
                    EdgeOptions OptionsEdge = new EdgeOptions();
                    OptionsEdge.PlatformName = os;
                    OptionsEdge.BrowserVersion = version;
                    return OptionsEdge;

                case "Mozilla Firefox":
                    driver = new FirefoxDriver();
                    FirefoxOptions OptionsFirefox = new FirefoxOptions();
                    OptionsFirefox.PlatformName = os;
                    OptionsFirefox.BrowserVersion = version;
                    return OptionsFirefox;

                case "Google Chrome":
                    driver = new ChromeDriver();
                    ChromeOptions OptionsChrome = new ChromeOptions();
                    OptionsChrome.PlatformName = os;
                    OptionsChrome.BrowserVersion = version;
                    return OptionsChrome;
                default:
                    throw new NoSuchElementException("Driver is absent");
            }
        }
    }
}
