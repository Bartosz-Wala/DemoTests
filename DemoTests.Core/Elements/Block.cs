using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoTests.Core.Elements
{
    public class Block : BaseElement
    {
        private string SnapshotText { get; set; }

        public Block(IWebDriver webDriver, By locator) : base(webDriver, locator)
        {
        }

        public Block(IWebDriver webDriver, IWebElement webElement) : base(webDriver, webElement)
        {
        }

        public void SaveSnapshot()
        {
            SnapshotText = GetSnapshot();
        }

        public void UntilSnapshotChanged()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10))
                .Until((IWebDriver driver) =>
                {
                    var currentSnapshotValue = GetSnapshot();
                    return SnapshotText != currentSnapshotValue;
                });
        }

        protected string GetSnapshot()
        {
            return GetElement().Text;
        }
    }
}
