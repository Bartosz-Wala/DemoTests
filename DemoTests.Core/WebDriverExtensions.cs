using OpenQA.Selenium;
using System.Reflection;

namespace DemoTests.Core
{
    public static class WebDriverExtensions
    {
        public static Screenshot TakeScreenshot(this IWebDriver driver)
        {
            ITakesScreenshot driverAs = GetDriverAs<ITakesScreenshot>(driver);
            if (driverAs == null)
            {
                IHasCapabilities hasCapabilities = driver as IHasCapabilities;

                if (hasCapabilities == null)
                {
                    throw new WebDriverException("Driver does not implement ITakesScreenshot or IHasCapabilities");
                }

                if (!hasCapabilities.Capabilities.HasCapability(CapabilityType.TakesScreenshot) || !(bool)hasCapabilities.Capabilities.GetCapability(CapabilityType.TakesScreenshot))
                {
                    throw new WebDriverException("Driver capabilities do not support taking screenshots");
                }

                MethodInfo method = driver.GetType().GetMethod("Execute", BindingFlags.Instance | BindingFlags.NonPublic);

                var parameters = new object[2]
                {
                    DriverCommand.Screenshot,
                    null,
                };

                Response response = method.Invoke(driver, parameters) as Response;

                if (response == null)
                {
                    throw new WebDriverException("Unexpected failure getting screenshot; response was not in the proper format.");
                }

                string base64EncodedScreenshot = response.Value.ToString();
                return new Screenshot(base64EncodedScreenshot);
            }

            return driverAs.GetScreenshot();
        }

        public static void ScrollPageToBottom(this IWebDriver webDriver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public static object ExecuteJavaScript(this IWebDriver driver, string script, params object[] args)
        {
            var result = ExecuteJavaScriptInternal(driver, script, args);
            CommonWaits.UntilDocumentReadyStateCompleteJavaScript(driver);
            return result;
        }

        public static object ExecuteJavaScript(this IWebDriver driver, string script)
        {
            return ExecuteJavaScriptInternal(driver, script, new object[0]);
        }

        public static T ExecuteJavaScript<T>(this IWebDriver driver, string script, params object[] args)
        {
            object obj = ExecuteJavaScriptInternal(driver, script, args);
            T result = default;
            Type typeFromHandle = typeof(T);
            if (obj == null)
            {
                if (typeFromHandle.IsValueType && Nullable.GetUnderlyingType(typeFromHandle) == null)
                {
                    throw new WebDriverException("Script returned null, but desired type is a value type");
                }

                return result;
            }

            if (!typeFromHandle.IsInstanceOfType(obj))
            {
                throw new WebDriverException("Script returned a value, but the result could not be cast to the desired type");
            }

            return (T)obj;
        }

        private static object ExecuteJavaScriptInternal(IWebDriver driver, string script, object[] args)
        {
            IJavaScriptExecutor driverAs = GetDriverAs<IJavaScriptExecutor>(driver);
            if (driverAs == null)
            {
                throw new WebDriverException("Driver does not implement IJavaScriptExecutor");
            }

            return driverAs.ExecuteScript(script, args);
        }

        private static T GetDriverAs<T>(IWebDriver driver)
            where T : class
        {
            T val = driver as T;
            if (val == null)
            {
                IWrapsDriver wrapsDriver = driver as IWrapsDriver;
                while (val == null && wrapsDriver != null)
                {
                    val = wrapsDriver.WrappedDriver as T;
                    wrapsDriver = wrapsDriver.WrappedDriver as IWrapsDriver;
                }
            }

            return val;
        }
    }
}
