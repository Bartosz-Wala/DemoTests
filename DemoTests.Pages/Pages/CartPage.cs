using DemoTests.Core.Elements;
using OpenQA.Selenium;

namespace DemoTests.Pages.Pages
{
    public class CartPage : PageComponents
    {
        private readonly Button firstProductLabelButton;
        private readonly Button backToProductListButton;
        public CartPage(IWebDriver driver) : base(driver)
        {
            firstProductLabelButton = new Button(Driver, By.XPath("//div[@class='cart_list']/div[3]/div[2]/a"));
            backToProductListButton = new Button(Driver, By.CssSelector("#continue-shopping"));
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
    }
}
