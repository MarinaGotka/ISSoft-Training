using System.Threading;
using OpenQA.Selenium;

namespace Test_With_Frames
{
    public class Frame
    {
        private readonly By TextArea = By.XPath("//*[@id='tinymce']/p");
        private readonly By BoldButton = By.XPath("//div[@aria-label='Bold']/button");
        private readonly By TextWithBoldFont = By.XPath("//body[@class='mce-content-body ']/p/strong");
        private readonly IWebDriver driver;

        public Frame(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClearTextArea()
        {
            Thread.Sleep(2000);
            driver.FindElement(TextArea).Clear();
        }

        public bool TextAreaIsClear()
        {
           return driver.FindElement(TextArea).Text.Equals(string.Empty);
        }

        public void EnterText(string text) => driver.FindElement(TextArea).SendKeys(text);

        public bool TextIsEntered(string text) => driver.FindElement(TextArea).Text.Equals(text);

        public bool TextIsBold(string text) => driver.FindElement(TextWithBoldFont).Text.Equals(text);

        public void SetBoldFont() => driver.FindElement(BoldButton).Click();
    }
}
