using DemoTests.Core.Elements;
using OpenQA.Selenium;

namespace DemoTests.Pages.Pages
{
    public class ProductPage : PageComponents
    {
        private readonly Button addToCartButton;
        private readonly Button removeFromCartButton;
        private readonly Button backToProductsListPageButton;
        private readonly Button productImage;
        public ProductPage(IWebDriver driver) : base(driver)
        {
            addToCartButton = new Button(Driver, By.CssSelector("#add-to-cart"));
            removeFromCartButton = new Button(Driver, By.CssSelector("#remove"));
            backToProductsListPageButton = new Button(Driver, By.CssSelector("#back-to-products"));
            productImage = new Button(Driver, By.XPath("//div[@class='inventory_details_img_container']/img"));
        }
        public ProductsListPage BackToProductListPage()
        {
            backToProductsListPageButton.Click();

            return new ProductsListPage(Driver);
        }
        public ProductPage AddProductToCart()
        {
            addToCartButton.Click();

            return this;
        }
        public ProductPage RemoveProductFromCart()
        {
            removeFromCartButton.Click();

            return this;
        }
        public bool IsProductPageLoaded()
        {
            addToCartButton.WaitForDisplay();

            return addToCartButton.IsDisplayed();
        }
        public bool IsProductImageLoaded()
        {
            productImage.WaitForDisplay();

            return productImage.IsDisplayed();
        }
    }
}
