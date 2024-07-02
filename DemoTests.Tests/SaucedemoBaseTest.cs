using DemoTests.Core;
using DemoTests.Pages;


namespace DemoTests.Tests
{
    public class SaucedemoBaseTest : TestsBase
    {
        protected override BrowserConfig BrowserConfig => Config.GetBrowserConfig();
    }
}
