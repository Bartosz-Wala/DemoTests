using DemoTests.Core.Elements;
using OpenQA.Selenium;

namespace DemoTests.Pages.Pages
{
    public class CartPage : PageComponents
    {
        private readonly Button firstProductLabelButton;
        private readonly Button backToProductListButton;
        private readonly Button goToCheckoutButton;
        private readonly Button removeFirstProductButton;
        public CartPage(IWebDriver driver) : base(driver)
        {
            firstProductLabelButton = new Button(Driver, By.XPath("//div[@class='cart_list']/div[3]/div[2]/a"));
            backToProductListButton = new Button(Driver, By.CssSelector("#continue-shopping"));
            goToCheckoutButton = new Button(Driver, By.CssSelector("#checkout"));
            removeFirstProductButton = new Button(Driver, By.XPath("//div[@class='cart_list']/div[3]/div[2]/div[2]/button"));
        }
        public bool IsProductAddedToCart()
        {
            firstProductLabelButton.WaitForDisplay();

            return firstProductLabelButton.IsDisplayed();
        }
        public bool IsCartEmpty()
        {
            return firstProductLabelButton.WaitForDeleteElement();
        }
        public ProductsListPage BackToProductListPage()
        {
            backToProductListButton.Click();

            return new ProductsListPage(Driver);
        }
        public ProductPage OpenProductPage()
        {
            firstProductLabelButton.Click();

            return new ProductPage(Driver);
        }
        public CartPage RemoveFirstProduct()
        {
            removeFirstProductButton.Click();

            return this;
        }
        public CheckoutPage GoToCheckoutPage()
        {
            goToCheckoutButton.Click();

            return new CheckoutPage(Driver);
        }
    }
}
