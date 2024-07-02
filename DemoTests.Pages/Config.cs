using Microsoft.Extensions.Configuration;
using DemoTests.Core;

namespace DemoTests.Pages
{
    public class Config
    {
        public static readonly string BrowserName = Configuration["browserName"];
        public static readonly string[] BrowserParams = Configuration.GetSection("browserParams")?.GetChildren()?.Select(x => x.Value)?.ToArray();
        public static readonly string BrowserUrl = Configuration["browserUrl"];

        public static readonly string websiteBaseUrl = Configuration["websiteBaseUrl"];
        public static readonly string userLogin = Configuration["userLogin"];
        public static readonly string userPassword = Configuration["userPassword"];

        private static IConfiguration configuration;

        public static IConfiguration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    var appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.test.json");
                    var builder = new ConfigurationBuilder()
                        .AddJsonFile(appSettingsPath)
                        .AddUserSecrets(typeof(Config).Assembly);

                    configuration = builder?.Build() ?? throw new SystemException("Configuration was not loaded");
                }

                return configuration;
            }
        }

        public static BrowserConfig GetBrowserConfig() => new BrowserConfig(BrowserName, BrowserParams, BrowserUrl);
    }
}
