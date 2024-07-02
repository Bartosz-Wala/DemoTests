using System.Globalization;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DemoTests.Core
{
    public static class CommonWaits
    {
        public static void UntilHasClass(IWebDriver driver, By e, string className, int waitInSeconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds))
                .Until(d => d.FindElement(e).GetAttribute("class").Contains(className));
        }

        public static void UntilHasNoClass(IWebDriver driver, By e, string className, int waitInSeconds = 15)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds))
                .Until(d => !d.FindElement(e).GetAttribute("class").Contains(className));
        }

        public static void UntilIsVisible(IWebDriver driver, By e, int waitInSeconds = 15)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds))
                .Until(ExpectedConditions.ElementIsVisible(e));
        }

        public static void UntilHasAttributeValue(IWebDriver driver, By e, string attributeName, string attributeValue, int waitInSeconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds))
                .Until(d => d.FindElement(e).GetAttribute(attributeName).Contains(attributeValue));
        }

        public static void UntilIsInvisible(IWebDriver driver, By e, int waitInSeconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds))
                .Until(ExpectedConditions.InvisibilityOfElementLocated(e));
        }

        public static void UntilSelectionStateToBe(IWebDriver driver, By e, bool selected, int waitInSeconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds))
                .Until(ExpectedConditions.ElementSelectionStateToBe(e, selected));
        }

        public static void UntilToBeClickable(IWebDriver driver, By e, int waitInSeconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds))
                .Until(ExpectedConditions.ElementToBeClickable(e));
        }

        public static void UntilDriverFindElement(IWebDriver driver, By e, int waitInSeconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds))
                .Until(d => d.FindElement(e));
        }

        public static void UntilExists(IWebDriver driver, By e, int waitInSeconds = 35)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds))
                 .Until(ExpectedConditions.ElementExists(e));
        }

        public static void UntilDocumentReadyStateCompleteJavaScript(IWebDriver driver, int waitInSeconds = 15)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                .Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void UntilElementsCountExpected(IWebDriver driver, By e, int expectedCount, int waitInSeconds = 15)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds))
                .Until(d => d.FindElements(e).Count >= expectedCount);
        }

        public static bool WaitToNotDisplayElement(IWebDriver driver, By e, int waitInSeconds = 1)
        {
            Thread.Sleep(5000);

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(e));
                Console.WriteLine("totu");
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return true;
            }
        }

        public static void UntilElementIsFound(IWebDriver driver, By e, int waitInSeconds = 25)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            IWebElement searchResult = fluentWait.Until(d => d.FindElement(e));
        }

        public static void WaitUntilSmoothScrollPosition(IWebDriver driver, int positionOfScroll)
        {
            driver.ExecuteJavaScript("return jQuery(window).scrollTop()");
            var javaScriptExecutor = driver as IJavaScriptExecutor;

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => int.Parse(javaScriptExecutor.ExecuteScript("return jQuery(window).scrollTop()").ToString()) > positionOfScroll);
        }

        public static void WaitUntilCaptchaIsClickable(IWebDriver driver, By e, By e2, int waitInSeconds = 25)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(40)).Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(e));
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(ExpectedConditions.ElementToBeClickable(e2));
        }

        public static void WaitUntilElementIsSelected(IWebDriver driver, By e, int waitInSeconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(ExpectedConditions.ElementToBeSelected(e));
        }

        public static void WaitUntil(IWebDriver driver, By e, string text, int waitInSeconds = 25)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(ExpectedConditions.TextToBePresentInElementLocated(e, text));
        }

        public static void WaitUntilElementIsLocated(IWebDriver driver, By e, int waitInSeconds = 25)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(e));
        }

        public static void WaitUntilElementBecomeStale(IWebDriver driver, By e, int waitInSeconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(ExpectedConditions.StalenessOf(driver.FindElement(e)));
        }

        public static IAlert WaitForAlertPresence(IWebDriver driver, int waitInSeconds = 30)
        {
            IAlert alert = new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(ExpectedConditions.AlertIsPresent());
            return alert;
        }

        public static void WaitUntilFrameIsAvailableAndSwitchToIt(IWebDriver driver, By e, int waitInSeconds = 25)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(e));
        }

        public static void WaitUntilSecondWindowIsOpened(IWebDriver driver, int waitInSeconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(d => d.WindowHandles.Count == 2);
        }

        public static void WaitUntilAnotherWindowIsOpened(IWebDriver driver, int windowNumber, int waitInSeconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(d => d.WindowHandles.Count == windowNumber);
        }

        public static void WaitUntilElementIsNotVisible(IWebDriver driver, By e, int waitInSeconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(d => d.FindElements(e).Count == 0);
        }

        public static void WaitUntilOptionIndexWillLoad(IWebDriver driver, SelectElement selectElement, int index, int waitInSeconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(d => selectElement.Options.Count >= index + 1);
        }

        public static void WaitUntilOptionValueWillLoad(IWebDriver driver, SelectElement selectElement, string value, int waitInSeconds = 30)
        {
            StringBuilder stringBuilder = new StringBuilder(".//option[@value = ");
            stringBuilder.Append(EscapeQuotes(value));
            stringBuilder.Append(']');

            var optionXPath = stringBuilder.ToString();

            new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(d =>
                selectElement.WrappedElement.FindElements(By.XPath(optionXPath)).Any());
        }

        private static string EscapeQuotes(string toEscape)
        {
            if (toEscape.IndexOf("\"", StringComparison.OrdinalIgnoreCase) > -1 && toEscape.IndexOf("'", StringComparison.OrdinalIgnoreCase) > -1)
            {
                bool flag = false;
                if (toEscape.LastIndexOf("\"", StringComparison.OrdinalIgnoreCase) == toEscape.Length - 1)
                {
                    flag = true;
                }

                List<string> list = new List<string>(toEscape.Split('"'));
                if (flag && string.IsNullOrEmpty(list[list.Count - 1]))
                {
                    list.RemoveAt(list.Count - 1);
                }

                StringBuilder stringBuilder = new StringBuilder("concat(");
                for (int i = 0; i < list.Count; i++)
                {
                    stringBuilder.Append("\"").Append(list[i]).Append("\"");
                    if (i == list.Count - 1)
                    {
                        if (flag)
                        {
                            stringBuilder.Append(", '\"')");
                        }
                        else
                        {
                            stringBuilder.Append(")");
                        }
                    }
                    else
                    {
                        stringBuilder.Append(", '\"', ");
                    }
                }

                return stringBuilder.ToString();
            }

            if (toEscape.IndexOf("\"", StringComparison.OrdinalIgnoreCase) > -1)
            {
                return string.Format(CultureInfo.InvariantCulture, "'{0}'", toEscape);
            }

            return string.Format(CultureInfo.InvariantCulture, "\"{0}\"", toEscape);
        }
    }
}
