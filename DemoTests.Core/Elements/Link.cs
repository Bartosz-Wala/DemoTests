using OpenQA.Selenium;

namespace DemoTests.Core.Elements
{
    public class Link : BaseElement
    {
        public Link(IWebDriver webDriver, By locator) : base(webDriver, locator)
        {
        }

        public Link(IWebDriver webDriver, IWebElement webElement) : base(webDriver, webElement)
        {
        }
    }
}