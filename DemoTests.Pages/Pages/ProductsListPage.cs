using DemoTests.Core;
using DemoTests.Core.Elements;
using OpenQA.Selenium;

namespace DemoTests.Pages.Pages
{
    public class ProductsListPage : PageComponents
    {
        private readonly Button firstProductButton;
        private readonly Button secondProductButton;
        private readonly Button thirdProductButton;
        private readonly Button firstProductImage;
        private readonly Label firstProductLabel;
        private readonly Label secondProductLabel;
        private readonly Label thirdProductLabel;
        private readonly SelectInput sortMethodSelect;
        private readonly Label firstProductPriceLabel;
        private readonly Label secondProductPriceLabel;
        private readonly Label thirdProductPriceLabel;
        public ProductsListPage(IWebDriver driver) : base(driver)
        {
            firstProductButton = new Button(Driver, By.XPath("//div[@class='inventory_list']/div[1]/div[2]//button"));
            secondProductButton = new Button(Driver, By.XPath("//div[@class='inventory_list']/div[2]/div[2]//button"));
            thirdProductButton = new Button(Driver, By.XPath("//div[@class='inventory_list']/div[3]/div[2]//button"));
            firstProductImage = new Button(Driver, By.XPath("//div[@class='inventory_list']/div[1]//img"));
            firstProductLabel = new Label(Driver, By.XPath("//div[@class='inventory_list']/div[1]/div[2]/div[1]/a"));
            secondProductLabel = new Label(Driver, By.XPath("//div[@class='inventory_list']/div[2]/div[2]/div[1]/a"));
            thirdProductLabel = new Label(Driver, By.XPath("//div[@class='inventory_list']/div[3]/div[2]/div[1]/a"));
            sortMethodSelect = new SelectInput(Driver, By.CssSelector(".product_sort_container"));
            firstProductPriceLabel = new Label(Driver, By.XPath("//div[@class='inventory_list']/div[1]/div[2]/div[2]/div[1]"));
            secondProductPriceLabel = new Label(Driver, By.XPath("//div[@class='inventory_list']/div[2]/div[2]/div[2]/div[1]"));
            thirdProductPriceLabel = new Label(Driver, By.XPath("//div[@class='inventory_list']/div[3]/div[2]/div[2]/div[1]"));
        }
        public bool CheckIsListLoaded()
        {
            firstProductButton.WaitForDisplay();

            secondProductButton.WaitForDisplay();

            thirdProductButton.WaitForDisplay();

            return thirdProductButton.IsDisplayed();
        }
        public bool CheckIsImageLoaded()
        {
            firstProductImage.WaitForDisplay();

            return firstProductImage.IsDisplayed();
        }
        public ProductsListPage AddFirstProductToCart()
        {
            firstProductButton.Click();

            return this;
        }
        public ProductsListPage RemoveFirstProductFromCart()
        {
            firstProductButton.GetText().Equals("Remove");

            firstProductButton.Click();

            return this;
        }
        public ProductPage OpenRandomProductPage()
        {
            int randomSelect = WebElementExtensions.SelectRandomNumberDeclarated(3);

            if (randomSelect == 0) firstProductLabel.Click();
            if (randomSelect == 1) secondProductLabel.Click();
            if (randomSelect == 2) thirdProductLabel.Click();

            return new ProductPage(Driver);
        }
        public ProductsListPage SelectDecleratedSortMethod(int selectIndex)
        {
            sortMethodSelect.SelectByIndex(selectIndex);

            return this;
        }
        public string GetFirstProductName()
        {
            return firstProductLabel.GetText();
        }
        public string GetSecondProductName()
        {
            return secondProductLabel.GetText();
        }
        public string GetThirdProductName()
        {
            return thirdProductLabel.GetText();
        }
        public bool IsProductNamesAZSorted()
        {
            string firstProductName = GetFirstProductName();
            string secondProductName = GetSecondProductName();
            string thirdProductName = GetThirdProductName();

            List<string> productNames = new List<string> { firstProductName, secondProductName, thirdProductName };
            List<string> sortedProductNames = new List<string>(productNames);
            sortedProductNames.Sort();

            for (int i = 0; i < productNames.Count; i++)
            {
                if (productNames[i] != sortedProductNames[i])
                {
                    return false;
                }
            }

            return true;
        }
        public bool IsProductNamesZASorted()
        {
            string firstProductName = GetFirstProductName();
            string secondProductName = GetSecondProductName();
            string thirdProductName = GetThirdProductName();

            List<string> productNames = new List<string> { firstProductName, secondProductName, thirdProductName };
            List<string> sortedProductNames = new List<string>(productNames);
            sortedProductNames.Sort();
            sortedProductNames.Reverse();

            for (int i = 0; i < productNames.Count; i++)
            {
                if (productNames[i] != sortedProductNames[i])
                {
                    return false;
                }
            }

            return true;
        }
        public decimal GetFirstProductPrice()
        {
            string firstProductCostStr = firstProductPriceLabel.GetText().Trim();

            string cleanedCostStr = firstProductCostStr.Replace("$", "").Trim();

            return decimal.Parse(cleanedCostStr, System.Globalization.CultureInfo.InvariantCulture);
        }

        public decimal GetSecondProductPrice()
        {
            string secondProductCostStr = secondProductPriceLabel.GetText().Trim();

            string cleanedCostStr = secondProductCostStr.Replace("$", "").Trim();

            return decimal.Parse(cleanedCostStr, System.Globalization.CultureInfo.InvariantCulture);
        }

        public decimal GetThirdProductPrice()
        {
            string thirdProductCostStr = thirdProductPriceLabel.GetText().Trim();

            string cleanedCostStr = thirdProductCostStr.Replace("$", "").Trim();

            return decimal.Parse(cleanedCostStr, System.Globalization.CultureInfo.InvariantCulture);
        }

        public bool IsProductPricesLOHISorted()
        {
            decimal firstProductCost = GetFirstProductPrice();
            decimal secondProductCost = GetSecondProductPrice();
            decimal thirdProductCost = GetThirdProductPrice();

            List<decimal> productCosts = new List<decimal> { firstProductCost, secondProductCost, thirdProductCost };
            List<decimal> sortedProductCosts = new List<decimal>(productCosts);
            sortedProductCosts.Sort();

            for (int i = 0; i < productCosts.Count; i++)
            {
                if (productCosts[i] != sortedProductCosts[i])
                {
                    return false;
                }
            }

            return true;
        }
        public bool IsProductPricesHOLISorted()
        {
            decimal firstProductCost = GetFirstProductPrice();
            decimal secondProductCost = GetSecondProductPrice();
            decimal thirdProductCost = GetThirdProductPrice();

            List<decimal> productCosts = new List<decimal> { firstProductCost, secondProductCost, thirdProductCost };
            List<decimal> sortedProductCosts = new List<decimal>(productCosts);
            sortedProductCosts.Sort();
            sortedProductCosts.Reverse();

            for (int i = 0; i < productCosts.Count; i++)
            {
                if (productCosts[i] != sortedProductCosts[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
