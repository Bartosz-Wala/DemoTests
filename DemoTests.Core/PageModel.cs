using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoTests.Core
{
    public class PageModel<T> where T : PageModel<T>
    {
        protected IWebDriver Driver { get; private set; }
        public PageModel(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Load a new web page in the current browser window.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public virtual T Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
            return (T)this;
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public string GetTitle()
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Title);
            return Driver.Title;
        }
    }
}
