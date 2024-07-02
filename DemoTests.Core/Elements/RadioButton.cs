using OpenQA.Selenium;

namespace DemoTests.Core.Elements
{
    public class RadioButton : BaseElement
    {
        public RadioButton(IWebDriver webDriver, By locator)
            : base(webDriver, locator)
        {
        }
    }
}