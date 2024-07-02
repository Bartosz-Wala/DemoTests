using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace DemoTests.Core.Elements
{
    public class SelectInput : BaseElement
    {
        public SelectInput(IWebDriver webDriver, By locator)
            : base(webDriver, locator)
        {
        }

        public void SelectByValue(string text)
        {
            UntilExists();
            UntilClickable();

            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);

            var selectSortOption = new SelectElement(element);

            CommonWaits.WaitUntilOptionValueWillLoad(WebDriver, selectSortOption, text);

            selectSortOption.SelectByValue(text);
        }

        public void SelectByIndex(int index)
        {
            UntilExists();
            UntilClickable();

            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);

            var selectSortOption = new SelectElement(element);

            CommonWaits.WaitUntilOptionIndexWillLoad(WebDriver, selectSortOption, index);

            selectSortOption.SelectByIndex(index);
        }

        public void SelectByText(string text)
        {
            UntilExists();
            UntilClickable();

            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);

            Thread.Sleep(500);

            var selectSortOption = new SelectElement(element);
            selectSortOption.SelectByText(text);
        }

        public IList<IWebElement> GetAllSelectedOptions()
        {
            UntilExists();
            UntilClickable();

            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);

            Thread.Sleep(500);

            var selectSortOption = new SelectElement(element);
            return selectSortOption.AllSelectedOptions;
        }

        public IWebElement GetSelectedOption()
        {
            UntilExists();
            UntilClickable();

            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);

            Thread.Sleep(500);

            var selectSortOption = new SelectElement(element);
            return selectSortOption.SelectedOption;
        }

        public IList<IWebElement> GetOptions()
        {
            UntilExists();
            UntilClickable();

            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);

            Thread.Sleep(500);
            var selectSortOption = new SelectElement(element);
            return selectSortOption.Options;
        }
        public IWebElement SelectRandomOption()
        {
            UntilExists();

            Thread.Sleep(500);

            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);

            var selectSortOption = new SelectElement(element);
            IList<IWebElement> options = selectSortOption.Options;

            int randomSelectedOption = WebElementExtensions.SelectRandomNumberDeclarated(options.Count);

            string changedToString = Convert.ToString(randomSelectedOption);

            SelectByValue(changedToString);

            Console.WriteLine("Selected option with value " + changedToString);

            return selectSortOption.SelectedOption;
        }
        public string SelectRandomOptionAndReturn()
        {
            UntilExists();
            UntilClickable();

            Thread.Sleep(500);

            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);

            var selectSortOption = new SelectElement(element);
            IList<IWebElement> options = selectSortOption.Options;

            int randomSelectedOption = WebElementExtensions.SelectRandomNumberDeclarated(options.Count);

            string changedToString = Convert.ToString(randomSelectedOption);

            SelectByValue(changedToString);

            Console.WriteLine("Selected option with value " + changedToString);

            return changedToString;
        }
        public string SelectRandomOptionAndReturnWithNoFive()
        {
            UntilExists();
            UntilClickable();

            Thread.Sleep(500);

            var element = GetElement();
            element.ScrollToElementCenterOfView(WebDriver);

            var selectSortOption = new SelectElement(element);
            IList<IWebElement> options = selectSortOption.Options;

            int randomSelectedOption = WebElementExtensions.SelectRandomNumberDeclarated(options.Count);

            string changedToString = Convert.ToString(randomSelectedOption);

            if (changedToString == "5")
            {
                changedToString = "1";
            }

            SelectByValue(changedToString);

            Console.WriteLine("Selected option with value " + changedToString);

            return changedToString;
        }
    }
}
