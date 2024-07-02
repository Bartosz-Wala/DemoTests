using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace DemoTests.Core
{
    public class BaseElement
    {
        protected By UniqueLocator { get; private set; }

        protected IWebElement Element { get; private set; }

        protected IWebDriver WebDriver { get; private set; }

        public BaseElement(IWebDriver webDriver, By locator)
            : this(webDriver)
        {
            UniqueLocator = locator;
        }

        public BaseElement(IWebDriver webDriver, IWebElement webElement)
            : this(webDriver)
        {
            Element = webElement;
        }

        protected BaseElement(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement GetElement()
        {
            return Element ?? WebDriver.FindElement(UniqueLocator);
        }

        public IList<IWebElement> GetElements()
        {
            return WebDriver.FindElements(UniqueLocator);
        }

        public string GetText()
        {
            UntilExists();
            return GetElement().Text;
        }

        public bool IsExist()
        {
            return WebDriver.FindElements(UniqueLocator).Any();
        }
        public bool IsExisting()
        {
            UntilExists();

            return WebDriver.FindElements(UniqueLocator).Any();
        }

        public bool IsDisplayed()
        {
            UntilExists();
            return GetElement().Displayed;
        }
        public bool IsOnlyDisplayed()
        {
            return GetElement().Displayed;
        }

        public bool IsSelected()
        {
            UntilExists();
            return GetElement().Selected;
        }

        public bool IsEnabled()
        {
            UntilExists();
            return GetElement().Enabled;
        }

        public string GetCSSBackgroundColorValue()
        {
            return GetElement().GetCssValue("background-color");
        }

        public string GetClassAttribute()
        {
            return GetElement().GetAttribute("class");
        }

        public string GetAttributeValue(string name)
        {
            return GetElement().GetAttribute(name);
        }

        public void WaitUntilHasAttributeValue(string attributeName, string attributeValue)
        {
            CommonWaits.UntilHasAttributeValue(WebDriver, UniqueLocator, attributeName, attributeValue);
        }

        public void WaitForDisplay()
        {
            UntilExists();
            CommonWaits.UntilIsVisible(WebDriver, UniqueLocator);
        }

        public void WaitUntilIsInvisible()
        {
            CommonWaits.UntilIsInvisible(WebDriver, UniqueLocator);
        }
        public bool WaitForDeleteElement()
        {
            return CommonWaits.WaitToNotDisplayElement(WebDriver, UniqueLocator);
        }

        public void WaitUntilIsVisible()
        {
            CommonWaits.UntilIsVisible(WebDriver, UniqueLocator);
        }

        public void WaitUntilHasClass(string className)
        {
            CommonWaits.UntilHasClass(WebDriver, UniqueLocator, className);
        }

        public void WaitUntilHasNoClass(string className)
        {
            CommonWaits.UntilHasNoClass(WebDriver, UniqueLocator, className);
        }

        public void WaitUntilToBeClickable()
        {
            CommonWaits.UntilToBeClickable(WebDriver, UniqueLocator);
        }

        public bool NotExists()
        {
            return !WebDriver.FindElements(UniqueLocator).Any();
        }

        public void ClickOnElementUsingJavaScript(bool scrollToCenterOfView = true)
        {
            UntilExists();

            var element = GetElement();

            if (scrollToCenterOfView)
            {
                element.ScrollToElementCenterOfView(WebDriver);
            }
            else
            {
                element.ScrollToElement(WebDriver);
            }

            element.ClickByJavaScript(WebDriver);
        }

        public void ClickByAction()
        {
            UntilExists();
            Actions action = new Actions(WebDriver);

            IWebElement element = GetElement();

            action.MoveToElement(element).KeyDown(Keys.ArrowDown).Click(element).KeyUp(Keys.ArrowDown).Build().Perform();
        }
        public void MoveToElement()
        {
            UntilExists();
            Actions action = new Actions(WebDriver);

            IWebElement element = GetElement();

            action.MoveToElement(element, 0, 40).Perform();
        }
        public void MoveToElementBySelectedRange(int x, int y)
        {
            UntilExists();
            Actions action = new Actions(WebDriver);

            IWebElement element = GetElement();

            action.MoveToElement(element, x, y).Perform();
        }
        public void MoveToElementBy40pxRange()
        {
            UntilExists();
            Actions action = new Actions(WebDriver);

            IWebElement element = GetElement();

            action.MoveToElement(element, 0, 40).Perform();
        }
        public void ClickByActionUp()
        {
            UntilExists();
            Actions action = new Actions(WebDriver);

            IWebElement element = GetElement();

            action.MoveToElement(element).KeyDown(Keys.ArrowUp).Click(element).SendKeys(Keys.Enter).KeyUp(Keys.ArrowUp).Build().Perform();
        }

        public void Click(bool scrollToCenterOfView = true)
        {
            UntilExists();

            IWebElement element = GetElement();

            if (scrollToCenterOfView)
            {
                element.ScrollToElementCenterOfView(WebDriver);
            }
            else
            {
                element.ScrollToElement(WebDriver);
            }

            element.Click();
        }
        public void ScrollToElementByJava()
        {
            UntilExists();

            IWebElement element = GetElement();

            element.ScrtollToElementByJava(WebDriver);
        }

        public void ScrollToElement()
        {
            UntilExists();
            var element = GetElement();
            element.ScrollToElement(WebDriver);
        }

        public void ScrollToElementCenterOfView()
        {
            UntilExists();
            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);
        }

        public void UntilElementIsFound()
        {
            if (UniqueLocator == null)
            {
                return;
            }

            CommonWaits.UntilElementIsFound(WebDriver, UniqueLocator);
        }

        public void UntilCountElementNumberIsExpected(int number)
        {
            CommonWaits.UntilElementsCountExpected(WebDriver, UniqueLocator, number);
        }

        public void UntilDisplay()
        {
            if (UniqueLocator != null)
            {
                new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(UniqueLocator));
            }
            else
            {
                new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30))
                    .Until((IWebDriver driver) => Element.Displayed);
            }
        }

        protected void UntilExists()
        {
            if (UniqueLocator == null)
            {
                return;
            }

            CommonWaits.UntilExists(WebDriver, UniqueLocator);
        }

        protected void UntilClickable()
        {
            if (UniqueLocator == null)
            {
                return;
            }

            CommonWaits.UntilToBeClickable(WebDriver, UniqueLocator);
        }

        public void Hover()
        {
            Actions action = new Actions(WebDriver);
            action.MoveToElement(GetElement()).Perform();
        }
    }
}
