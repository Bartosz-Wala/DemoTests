using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace DemoTests.Core
{
    public abstract class TestsBase
    {
        protected IWebDriver Driver { get; private set; }
        protected virtual BrowserConfig BrowserConfig { get; }

        [SetUp]
        public virtual void SetUp()
        {
            Driver = BrowserFactory.GetBrowser(BrowserConfig);

            var testName = TestContext.CurrentContext.Test.Name;
            var testClassName = TestContext.CurrentContext.Test.ClassName.Split('.').Last();

            var fullMethodName = $"{testClassName}.{testName}";
            string logMessage = $"Started {fullMethodName}";

            TestContext.Progress.WriteLine(logMessage);
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
                var testName = TestContext.CurrentContext.Test.Name;
                var testClassName = TestContext.CurrentContext.Test.ClassName.Split('.').Last();

                if (testStatus != NUnit.Framework.Interfaces.TestStatus.Passed)
                {
                    SaveScreenshot($"{DateTime.UtcNow:yyMMdd_HHmmss}_{testStatus}_{testClassName}_{testName}");
                }

                Driver.Close();
                Driver.Quit();
            }
        }

        private void SaveScreenshot(string fileName)
        {
            Screenshot screenshot = Driver.TakeScreenshot();
            screenshot.SaveAsFile($".\\Screenshots\\{fileName}.png");
        }
    }
}
