using DemoTests.Core.Elements;
using OpenQA.Selenium;

namespace DemoTests.Pages.Pages
{
    public class CheckoutPage : PageComponents
    {
        private readonly TextInput firstNameInput;
        private readonly TextInput lastNameInput;
        private readonly TextInput postalCodeInput;
        private readonly Button continueButton;
        private readonly Button finishButton;
        private readonly Button backToMenuButton;
        private readonly Button cancelButton;
        private readonly Button openFirstProductButton;
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            firstNameInput = new TextInput(Driver, By.CssSelector("#first-name"));
            lastNameInput = new TextInput(Driver, By.CssSelector("#last-name"));
            postalCodeInput = new TextInput(Driver, By.CssSelector("#postal-code"));
            continueButton = new Button(Driver, By.CssSelector("#continue"));
            finishButton = new Button(Driver, By.CssSelector("#finish"));
            backToMenuButton = new Button(Driver, By.CssSelector("#back-to-products"));
            cancelButton = new Button(Driver, By.CssSelector("#cancel"));
            openFirstProductButton = new Button(Driver, By.CssSelector(".inventory_item_name"));
        }
        public bool IsCheckoutPageLoaded()
        {
            firstNameInput.WaitForDisplay();

            return firstNameInput.IsDisplayed();
        }
        public CheckoutPage FillFirstName()
        {
            firstNameInput.Fill("test");

            return new CheckoutPage(Driver);
        }
        public CheckoutPage FillLastName()
        {
            lastNameInput.Fill("test");

            return new CheckoutPage(Driver);
        }
        public CheckoutPage FillPostalCode()
        {
            postalCodeInput.Fill("test");

            return new CheckoutPage(Driver);
        }
        public CheckoutPage ContinuePurchase()
        {
            continueButton.Click();

            return new CheckoutPage(Driver);
        }
        public CheckoutPage EndPurchase()
        {
            finishButton.Click();

            return new CheckoutPage(Driver);
        }
        public bool IsPurchaseFinished()
        {
            backToMenuButton.WaitForDisplay();

            return backToMenuButton.IsDisplayed();
        }
        public CartPage BackFromCheckout()
        {
            cancelButton.Click();

            return new CartPage(Driver);
        }
        public ProductsListPage CancelPurchase()
        {
            cancelButton.Click();

            return new ProductsListPage(Driver);
        }
        public ProductPage OpenFirstProduct()
        {
            openFirstProductButton.Click();

            return new ProductPage(Driver);
        }
    }
}
