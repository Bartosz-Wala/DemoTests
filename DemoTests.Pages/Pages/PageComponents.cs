using DemoTests.Core.Elements;
using OpenQA.Selenium;

namespace DemoTests.Pages.Pages
{
    public class PageComponents : SaucedemoPage<PageComponents>
    {
        private readonly Button cartButton;
        private readonly Label cartButtonBadge;
        public PageComponents(IWebDriver driver) : base(driver)
        {
            cartButton = new Button(Driver, By.CssSelector(".shopping_cart_link"));
            cartButtonBadge = new Label(Driver, By.CssSelector(".shopping_cart_badge"));
        }
        public bool IsAccountLogged()
        {
            cartButton.WaitForDisplay();

            return cartButton.IsDisplayed();
        }
        public bool IsCartButtonBadgeLoaded()
        {
            cartButtonBadge.WaitForDisplay();

            return cartButtonBadge.IsDisplayed();
        }
        public bool IsCartButtonBadgeHided()
        {
            return cartButtonBadge.WaitForDeleteElement();
        }
        public CartPage OpenCartPage()
        {
            cartButton.Click();

            return new CartPage(Driver);
        }
    }
}
