using DemoTests.Pages.Pages;

namespace DemoTests.Tests.Tests
{
    internal class CartPageTests : SaucedemoBaseTest
    {
        [Test]
        public void BackToProductListsFromCartPage()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            CartPage cartPage = productsListPage.OpenCartPage();

            cartPage.BackToProductListPage();

            Assert.IsTrue(productsListPage.CheckIsListLoaded());
        }
        [Test]
        public void OpenProductPageFromCart()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.AddFirstProductToCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            ProductPage productPage = cartPage.OpenProductPage();

            Assert.IsTrue(productPage.IsProductImageLoaded());
        }
        [Test]
        public void RemoveProductToEmptyCart()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.AddFirstProductToCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            cartPage.RemoveFirstProduct();

            Assert.IsTrue(cartPage.IsCartEmpty());
        }
        [Test]
        public void RemoveOneProductCart()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage
                .AddFirstProductToCart()
                .AddSecondProductToCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            cartPage
                .RemoveFirstProduct()
                .RefreshPage();

            Assert.IsTrue(cartPage.IsProductAddedToCart());
        }
        [Test]
        public void GoToCheckoutEmptyCart()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            CartPage cartPage = productsListPage.OpenCartPage();

            CheckoutPage checkoutPage = cartPage.GoToCheckoutPage();

            Assert.IsTrue(checkoutPage.IsCheckoutPageLoaded());
        }
        [Test]
        public void GoToCheckoutProductCart()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.AddFirstProductToCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            CheckoutPage checkoutPage = cartPage.GoToCheckoutPage();

            Assert.IsTrue(checkoutPage.IsCheckoutPageLoaded());
        }
    }
}
