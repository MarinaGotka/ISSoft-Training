using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Test_With_Alerts
{
    [TestFixture]
    public class AlertsTests
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

            Assert.True(alertPage.JsAlertIsOKClicked());
        }

        [Test]
        public void JsConfirmTest()
        {
            AlertPage alertPage = new AlertPage(driver);
            alertPage.ClickForJSConfirm();

            Assert.True(alertPage.JsConfirmCancelIsClicked());
        }

        [Test]
        public void JsPromptTest()
        {
            const string textForAlert = "text for alert";

            AlertPage alertPage = new AlertPage(driver);
            alertPage.ClickForJSPrompt(textForAlert);

            Assert.True(alertPage.JsPromptIsClickedWithText(textForAlert));

        }
    }
}
