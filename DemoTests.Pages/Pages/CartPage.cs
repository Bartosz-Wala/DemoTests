using DemoTests.Core.Elements;
using OpenQA.Selenium;

namespace DemoTests.Pages.Pages
{
    public class CartPage : PageComponents
    {
        private readonly Button firstProductLabelButton;
        public CartPage(IWebDriver driver) : base(driver)
        {
            firstProductLabelButton = new Button(Driver, By.XPath("//div[@class='cart_list']/div[3]/div[2]/a"));
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
    }
}
