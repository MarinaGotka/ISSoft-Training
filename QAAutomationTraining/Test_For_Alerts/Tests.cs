using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Test_With_Alerts
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void JsAlertTest()
        {
            AlertPage alertPage = new AlertPage(driver);
            alertPage.ClickForJSAlert();

            Thread.Sleep(4000);
            Assert.True(alertPage.JsAlertIsOKClicked());
        }

        [Test]
        public void JsConfirmTest()
        {
            AlertPage alertPage = new AlertPage(driver);
            alertPage.ClickForJSConfirm();

            Thread.Sleep(4000);
            Assert.True(alertPage.JsConfirmCancelIsClicked());
        }

        [Test]
        public void JsPromptTest()
        {
            const string textForAlert = "text for alert";

            AlertPage alertPage = new AlertPage(driver);
            alertPage.ClickForJSPrompt(textForAlert);

            Thread.Sleep(4000);
            Assert.True(alertPage.JsPromptIsClickedWithText(textForAlert));

        }
    }
}
