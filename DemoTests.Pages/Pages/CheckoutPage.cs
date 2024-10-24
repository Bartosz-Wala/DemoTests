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
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            firstNameInput = new TextInput(Driver, By.CssSelector("#first-name"));
            lastNameInput = new TextInput(Driver, By.CssSelector("#last-name"));
            postalCodeInput = new TextInput(Driver, By.CssSelector("#postal-code"));
            continueButton = new Button(Driver, By.CssSelector("#continue"));
        }
        public bool IsCheckoutPageLoaded()
        {
            firstNameInput.WaitForDisplay();

            return firstNameInput.IsDisplayed();
        }
    }
}
