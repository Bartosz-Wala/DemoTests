using DemoTests.Pages.Pages;

namespace DemoTests.Tests.Tests
{
    internal class CheckoutPageTests : SaucedemoBaseTest
    {
        [Test]
        public void PurchaseProduct()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.AddFirstProductToCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            CheckoutPage checkoutPage = cartPage.GoToCheckoutPage();

            checkoutPage
                .FillFirstName()
                .FillLastName()
                .FillPostalCode()
                .ContinuePurchase()
                .EndPurchase();

            Assert.IsTrue(checkoutPage.IsPurchaseFinished());
        }
        [Test]
        public void PurchaseProductEmptyData()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.AddFirstProductToCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            CheckoutPage checkoutPage = cartPage.GoToCheckoutPage();

            checkoutPage.ContinuePurchase();

            Assert.IsTrue(checkoutPage.GetError().Contains("Error: First Name is required"));
        }
        [Test]
        public void PurchaseProductEmptyLastName()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.AddFirstProductToCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            CheckoutPage checkoutPage = cartPage.GoToCheckoutPage();

            checkoutPage
                .FillFirstName()
                .FillPostalCode()
                .ContinuePurchase();

            Assert.IsTrue(checkoutPage.GetError().Contains("Error: Last Name is required"));
        }
        [Test]
        public void PurchaseProductEmptyPostalCode()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.AddFirstProductToCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            CheckoutPage checkoutPage = cartPage.GoToCheckoutPage();

            checkoutPage
                .FillFirstName()
                .FillLastName()
                .ContinuePurchase();

            Assert.IsTrue(checkoutPage.GetError().Contains("Error: Postal Code is required"));
        }
        [Test]
        public void BackToCartFromCheckout()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.AddFirstProductToCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            CheckoutPage checkoutPage = cartPage.GoToCheckoutPage();

            checkoutPage.BackFromCheckout();

            Assert.IsTrue(cartPage.IsProductAddedToCart());
        }
        [Test]
        public void CancelPurchaseProduct()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.AddFirstProductToCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            CheckoutPage checkoutPage = cartPage.GoToCheckoutPage();

            checkoutPage
                .FillFirstName()
                .FillLastName()
                .FillPostalCode()
                .ContinuePurchase()
                .CancelPurchase();

            Assert.IsTrue(productsListPage.CheckIsImageLoaded());
        }
        [Test]
        public void OpenProductFromPurchaseProduct()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.AddFirstProductToCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            CheckoutPage checkoutPage = cartPage.GoToCheckoutPage();

            checkoutPage
                .FillFirstName()
                .FillLastName()
                .FillPostalCode()
                .ContinuePurchase();

                ProductPage productPage = checkoutPage.OpenFirstProduct();

            Assert.IsTrue(productPage.IsProductImageLoaded());
        }
    }
}
