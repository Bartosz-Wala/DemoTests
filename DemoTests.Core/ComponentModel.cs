using OpenQA.Selenium;

namespace DemoTests.Core
{
    public class ComponentModel<T> where T : ComponentModel<T>
    {
        protected IWebElement Element { get; private set; }
        protected By UniqueLocator { get; private set; }
        protected IWebDriver WebDriver { get; private set; }

        public ComponentModel(IWebDriver webDriver, By uniqueLocator)
        {
            WebDriver = webDriver;
            UniqueLocator = uniqueLocator;
        }

        public ComponentModel(IWebDriver webDriver, IWebElement webElement)
        {
            WebDriver = webDriver;
            Element = webElement;
        }

        public IWebElement GetElement()
        {
            return Element ?? WebDriver.FindElement(UniqueLocator);
        }
    }
}
