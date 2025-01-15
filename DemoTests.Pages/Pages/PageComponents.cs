using DemoTests.Core.Elements;
using OpenQA.Selenium;

namespace DemoTests.Pages.Pages
{
    public class PageComponents : SaucedemoPage<PageComponents>
    {
        private readonly Button cartButton;
        private readonly Label cartButtonBadge;
        private readonly Label errorLabel;
        public PageComponents(IWebDriver driver) : base(driver)
        {
            cartButton = new Button(Driver, By.CssSelector(".shopping_cart_link"));
            cartButtonBadge = new Label(Driver, By.CssSelector(".shopping_cart_badge"));
            errorLabel = new Label(Driver, By.CssSelector("h3[data-test='error']"));
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
        public string GetError()
        {
            return errorLabel.GetText();
        }
    }
}
