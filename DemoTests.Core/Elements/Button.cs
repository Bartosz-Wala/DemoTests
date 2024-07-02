using OpenQA.Selenium;

namespace DemoTests.Core.Elements
{
    public class Button : BaseElement
    {
        public Button(IWebDriver webDriver, By locator) : base(webDriver, locator)
        {
        }

        public Button(IWebDriver webDriver, IWebElement webElement) : base(webDriver, webElement)
        {
        }
    }
}
