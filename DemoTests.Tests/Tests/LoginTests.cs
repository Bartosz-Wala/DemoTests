using DemoTests.Pages.Pages;

namespace DemoTests.Tests.Tests
{
    public class LoginTests : SaucedemoBaseTest
    {
        [Test]
        public void ValidDataLoginTest()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate()
                .LoginUser();

            Assert.IsTrue(loginPage.IsAccountLogged());
        }
        [Test]
        public void LoginWithEmptyDataTest()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate()
                .LoginDeclerate("", "");

            Assert.IsTrue(loginPage.GetError().Contains("Username is required"));
        }
        [Test]
        public void EmptyLoginDataTest()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate()
                .LoginDeclerate("", "");

            Assert.IsTrue(loginPage.GetError().Contains("Username is required"));
        }
        [Test]
        public void EmptyPasswordDataTest()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate()
                .LoginDeclerate("standard_user", "");

            Assert.IsTrue(loginPage.GetError().Contains("Password is required"));
        }
        [Test]
        public void InvalidLoginPasswordTest()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate()
                .LoginDeclerate("standard_user", "test");

            Assert.IsTrue(loginPage.GetError().Contains("Username and password do not match any user in this service"));
        }
        [Test]
        public void InvalidLoginInputTest()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate()
                .LoginDeclerate("test", "secret_sauce");

            Assert.IsTrue(loginPage.GetError().Contains("Username and password do not match any user in this service"));
        }
        [Test]
        public void InvalidLoginTest()
        {
            LoginPage loginPage = new LoginPage(Driver);

            loginPage
                .Navigate()
                .LoginDeclerate("test", "test");

            Assert.IsTrue(loginPage.GetError().Contains("Username and password do not match any user in this service"));
        }
    }
}