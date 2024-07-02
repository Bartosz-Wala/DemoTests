using DemoTests.Core;
using DemoTests.Pages.Pages;
using OpenQA.Selenium;

namespace DemoTests.Pages
{
    public class SaucedemoPage<T> : PageModel<T> where T : SaucedemoPage<T>
    {
        public SaucedemoPage(IWebDriver driver) : base(driver)
        {

        }
        public LoginPage Navigate()
        {
            base.Navigate(Config.websiteBaseUrl);

            return new LoginPage(Driver);
        }
    }
}
