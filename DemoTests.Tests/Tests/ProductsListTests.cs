using DemoTests.Pages.Pages;

namespace DemoTests.Tests.Tests
{
    internal class ProductsListTests : SaucedemoBaseTest
    {
        [Test]
        public void IsProductsListLoaded()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            Assert.IsTrue(productsListPage.CheckIsListLoaded());
        }
        [Test]
        public void IsProductsImageLoaded()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            Assert.IsTrue(productsListPage.CheckIsImageLoaded());
        }
        [Test]
        public void CheckIsCartHaveAddBadge()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.AddFirstProductToCart();

            Assert.IsTrue(productsListPage.IsCartButtonBadgeLoaded());
        }
        [Test]
        public void CheckIsCartHidesAddBadge()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage
                .AddFirstProductToCart()
                .IsCartButtonBadgeLoaded();

            productsListPage
                .RemoveFirstProductFromCart();

            Assert.IsTrue(productsListPage.IsCartButtonBadgeHided());
        }
        [Test]
        public void CheckIsProductAddedToCart()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage.Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage
                .AddFirstProductToCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            Assert.IsTrue(cartPage.IsProductAddedToCart());
        }
        [Test]
        public void CheckDeleteProductCart()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage
                .AddFirstProductToCart()
                .IsCartButtonBadgeLoaded();

            productsListPage
                .RemoveFirstProductFromCart();

            CartPage cartPage = productsListPage.OpenCartPage();

            Assert.IsTrue(cartPage.IsCartEmpty());
        }
        [Test]
        public void CheckRandomProductPage()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            ProductPage productPage = productsListPage.OpenRandomProductPage();

            Assert.IsTrue(productPage.IsProductPageLoaded());
        }
        [Test]
        public void CheckIsSortAZWorks()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.SelectDecleratedSortMethod(0);

            Assert.IsTrue(productsListPage.IsProductNamesAZSorted());
        }
        [Test]
        public void CheckIsSortZAWorks()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.SelectDecleratedSortMethod(1);

            Assert.IsTrue(productsListPage.IsProductNamesZASorted());
        }
        [Test]
        public void CheckIsSortLOHIWorks()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.SelectDecleratedSortMethod(2);

            Assert.IsTrue(productsListPage.IsProductPricesLOHISorted());
        }
        [Test]
        public void CheckIsSortHILOWorks()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate();

            ProductsListPage productsListPage = loginPage.LoginUser();

            productsListPage.SelectDecleratedSortMethod(3);

            Assert.IsTrue(productsListPage.IsProductPricesHOLISorted());
        }
    }
}
