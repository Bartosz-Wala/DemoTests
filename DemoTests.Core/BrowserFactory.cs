using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace DemoTests.Core
{
    public static class BrowserFactory
    {
        public static IWebDriver GetBrowser(BrowserConfig browserConfig) => CreateBrowser(
            browserConfig.BrowserName,
            browserConfig.BrowserParams,
            browserConfig.BrowserUrl
        );
        private static IWebDriver CreateBrowser(string browserName, string[] browserParams, string browserUrl)
        {
            return browserName switch
            {
                "Chrome" => CreateChromeDriver(browserParams),
                "Firefox" => CreateFirefoxDriver(browserParams),
                "Edge" => CreateEdgeDriver(browserParams),
                "Remote" => CreateRemoteDriver(browserParams, browserUrl),
                _ => throw new ArgumentException("Invalid browser option!"),
            };
        }

        private static IWebDriver CreateChromeDriver(string[] browserParams)
        {
            var chromeOptions = new ChromeOptions();

            chromeOptions.AddArguments(browserParams);

            return new ChromeDriver(chromeOptions);
        }

        private static IWebDriver CreateFirefoxDriver(string[] browserParams)
        {
            var firefoxOptions = new FirefoxOptions();

            firefoxOptions.AddArguments(browserParams);

            return new FirefoxDriver(firefoxOptions);
        }

        private static IWebDriver CreateEdgeDriver(string[] browserParams)
        {
            var edgeOptions = new EdgeOptions();

            edgeOptions.AddArguments(browserParams);

            return new EdgeDriver(edgeOptions);
        }

        private static IWebDriver CreateRemoteDriver(string[] browserParams, string browserUrl)
        {
            var browserOptions = new ChromeOptions();

            browserOptions.AddArguments(browserParams);

            return new RemoteWebDriver(new Uri(browserUrl), browserOptions.ToCapabilities());
        }
    }
}
