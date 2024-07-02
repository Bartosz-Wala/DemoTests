using DemoTests.Core.Elements;
using OpenQA.Selenium;

namespace DemoTests.Pages.Pages
{
    public class ProductPage : PageComponents
    {
        private readonly Button addToCartButton;
        public ProductPage(IWebDriver driver) : base(driver)
        {
            addToCartButton = new Button(Driver, By.CssSelector("#add-to-cart"));
        }
        public ProductPage AddProductToCart()
        {
            addToCartButton.Click();

            return this;
        }
        public bool IsProductPageLoaded()
        {
            addToCartButton.WaitForDisplay();

            return addToCartButton.IsDisplayed();
        }
    }
}
