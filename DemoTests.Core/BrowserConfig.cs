namespace DemoTests.Core
{
    public class BrowserConfig
    {
        public string BrowserName { get; }
        public string[] BrowserParams { get; }
        public string BrowserUrl { get; }

        public BrowserConfig(string browserName, string[] browserParams, string browserUrl)
        {
            BrowserName = browserName;
            BrowserParams = browserParams;
            BrowserUrl = browserUrl;
        }
    }
}
