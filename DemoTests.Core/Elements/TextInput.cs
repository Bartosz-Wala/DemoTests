using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoTests.Core.Elements
{
    public class TextInput : BaseElement
    {
        public TextInput(IWebDriver webDriver, By locator) : base(webDriver, locator)
        {
        }

        public TextInput(IWebDriver webDriver, IWebElement webElement) : base(webDriver, webElement)
        {
        }

        public void ClearAndFill(string text)
        {
            CommonWaits.UntilExists(WebDriver, UniqueLocator);
            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);
            CommonWaits.UntilToBeClickable(WebDriver, UniqueLocator);
            element.Clear();
            element.SendKeys(text);
        }

        public void Fill(string text, bool scroll = true)
        {
            CommonWaits.UntilExists(WebDriver, UniqueLocator);
            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);
            CommonWaits.UntilToBeClickable(WebDriver, UniqueLocator);
            element.SendKeys(text);
        }
        public void OnlyFill(string text)
        {
            CommonWaits.UntilExists(WebDriver, UniqueLocator);
            var element = GetElement();
            element.SendKeys(text);
        }

        public void PressEnter()
        {
            CommonWaits.UntilExists(WebDriver, UniqueLocator);
            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);
            CommonWaits.UntilToBeClickable(WebDriver, UniqueLocator);
            element.SendKeys(Keys.Enter);
        }

        public void Clear()
        {
            var element = GetElement();
            element.Clear();
        }

        public void FillByAction(string text)
        {
            Actions action = new Actions(WebDriver);
            CommonWaits.UntilExists(WebDriver, UniqueLocator);
            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);
            action.Click(element).SendKeys(text).Build().Perform();
        }

        public void FillByJavaScript(string text)
        {
            CommonWaits.UntilExists(WebDriver, UniqueLocator);
            var element = GetElement();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)WebDriver;

            string script = $"arguments[0].value='{text}';";
            jsExecutor.ExecuteScript(script, element);
        }

        public void ClearByJavaScript()
        {
            CommonWaits.UntilExists(WebDriver, UniqueLocator);
            var element = GetElement();
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            js.ExecuteScript("arguments[0].value = '';", element);
        }

        public string GetTexInputValue()
        {
            var element = GetElement();
            return element.GetAttribute("value");
        }
    }
}
