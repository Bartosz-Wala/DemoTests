using OpenQA.Selenium;

namespace DemoTests.Core.Elements
{
    public class Label : BaseElement
    {
        public Label(IWebDriver webDriver, By locator) : base(webDriver, locator)
        {
        }

        public Label(IWebDriver webDriver, IWebElement webElement) : base(webDriver, webElement)
        {
        }
    }
}