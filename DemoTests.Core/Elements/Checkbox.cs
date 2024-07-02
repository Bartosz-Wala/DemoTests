using OpenQA.Selenium;

namespace DemoTests.Core.Elements
{
    public class Checkbox : BaseElement
    {
        public Checkbox(IWebDriver webDriver, By locator)
            : base(webDriver, locator)
        {
        }
    }
}