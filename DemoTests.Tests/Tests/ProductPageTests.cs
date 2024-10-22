using DemoTests.Pages.Pages;

namespace DemoTests.Tests.Tests
{
    internal class ProductPageTests : SaucedemoBaseTest
    {
        [Test]
        public void BackToProductListsFromProductPage()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            ProductPage productPage = productsListPage.OpenRandomProductPage();

            productPage.BackToProductListPage();

            Assert.IsTrue(productsListPage.CheckIsListLoaded());
        }
        [Test]
        public void AddProductToCartFromPage()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            ProductPage productPage = productsListPage.OpenRandomProductPage();

            productPage.AddProductToCart();

            CartPage cartPage = productPage.OpenCartPage();

            Assert.IsTrue(cartPage.IsProductAddedToCart());
        }
        [Test]
        public void RemoveProductFromPage()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            ProductPage productPage = productsListPage.OpenRandomProductPage();

            productPage.AddProductToCart();

            Assert.IsTrue(productPage.IsCartButtonBadgeLoaded());

            productPage.RemoveProductFromCart();

            CartPage cartPage = productPage.OpenCartPage();

            Assert.IsTrue(cartPage.IsCartEmpty());
        }
        [Test]
        public void IsProductImageLoaded()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            ProductPage productPage = productsListPage.OpenRandomProductPage();

            Assert.IsTrue(productPage.IsProductImageLoaded());
        }
    }
}
