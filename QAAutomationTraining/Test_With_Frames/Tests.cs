using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Test_With_Frames
{
    [TestFixture]
    internal class Tests
    {
        private readonly string PartOfText = "Hello ";
        private readonly string PartOfTextWithBoldFont = "world!";

        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/iframe");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10); // Implicit waiter for WebDriver. 
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void EnterTextWithDifferentFontTest()
        {
            Frame frame = new Frame(driver);
            frame.ClearTextArea();

            Assert.True(frame.TextAreaIsClear());

            frame.EnterText(PartOfText);

            Assert.True(frame.TextIsEntered(PartOfText));

            frame.SetBoldFont();
            frame.EnterText(PartOfTextWithBoldFont);

            Assert.True(frame.TextIsEntered(PartOfText + PartOfTextWithBoldFont));
            Assert.True(frame.TextIsBold(PartOfTextWithBoldFont));
        }
    }
}
