using DemoTests.Core.Elements;
using OpenQA.Selenium;

namespace DemoTests.Pages.Pages
{
    public class LoginPage : PageComponents
    {
        private readonly TextInput loginInput;
        private readonly TextInput passwordInput;
        private readonly Button loginButton;
        private readonly Label errorLoginLabel;
        public LoginPage(IWebDriver driver) : base(driver)
        {
            loginInput = new TextInput(Driver, By.CssSelector("#user-name"));
            passwordInput = new TextInput(Driver, By.CssSelector("#password"));
            loginButton = new Button(Driver, By.CssSelector("#login-button"));
            errorLoginLabel = new Label(Driver, By.CssSelector("h3[data-test='error']"));
        }
        public ProductsListPage LoginUser()
        {
            loginInput.Fill(Config.userLogin);
            passwordInput.Fill(Config.userPassword);
            loginButton.Click();

            return new ProductsListPage(Driver);
        }
        public ProductsListPage LoginDeclerate(string login, string password)
        {
            loginInput.Fill(login);
            passwordInput.Fill(password);
            loginButton.Click();

            return new ProductsListPage(Driver);
        }
        public string GetLoginError()
        {
            return errorLoginLabel.GetText();
        }
    }
}