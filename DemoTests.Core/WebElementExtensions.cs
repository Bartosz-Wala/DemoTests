using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using DemoTests.Core.Elements;
using System.Xml.Linq;

namespace DemoTests.Core
{
    public static class WebElementExtensions
    {
        public static void ScrollToElement(this IWebElement webElement, IWebDriver webDriver)
        {
            webDriver.ExecuteJavaScript("arguments[0].scrollIntoView({ block: 'end', behavior: 'instant'});", webElement);
        }

        public static void ScrollToElementCenterOfView(this IWebElement webElement, IWebDriver webDriver)
        {
            string scrollElementIntoMiddle = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
                                            + "var elementTop = arguments[0].getBoundingClientRect().top;"
                                            + "window.scrollBy({ left: 0, top: elementTop-(viewPortHeight/2), behavior: 'instant'});";

            webDriver.ExecuteJavaScript(scrollElementIntoMiddle, webElement);
        }

        public static void ClickByJavaScript(this IWebElement webElement, IWebDriver webDriver)
        {
            webDriver.ExecuteJavaScript("arguments[0].click();", webElement);
        }
        public static string SelectRandomNumbersString()
        {
            Random rnd = new Random();

            int randomNumber = rnd.Next(1, 100000000);

            string randomString = randomNumber.ToString("D4");

            Console.WriteLine("I selected numbers: " + randomString);

            return randomString;
        }
        public static string SeleniumNameWithRandom()
        {
            string random = SelectRandomNumbersString();

            string nameRandom = ("Selenium" + random);

            return nameRandom;
        }
        public static string SeleniumTestNameWithRandom()
        {
            string random = SelectRandomNumbersString();

            string nameRandom = ("seleniumtest" + random);

            return nameRandom;
        }
        public static string SeleniumEmailWithRandom()
        {
            string random = SelectRandomNumbersString();

            string emailRandom = ("Selenium" + random + "@fastdelete.pl");

            return emailRandom;
        }
        public static int SelectRandomNumberDeclarated(int maxNumber)
        {
            Random rnd = new Random();

            int randomSmallNumber = rnd.Next(0, maxNumber);

            return randomSmallNumber;
        }
        public static void ChangeBrowserTabToUseSelenium(this IWebDriver driver, int numberOfTab)
        {
            driver.SwitchTo().Window(driver.WindowHandles[numberOfTab]);
        }
        public static void ScrollToSelectedRangeByJava(this IWebDriver driver, string range)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string script = "window.scrollTo(0, " + range + ")";
            js.ExecuteScript(script);
        }
        public static void ScrtollToElementByJava(this IWebElement webElement, IWebDriver webDriver)
        {
            webDriver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", webElement);

        }
        public static void ScrollAllPage(this IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollTo(0, 10000)");
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollTo(0, 30000)");
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollTo(0, 80000)");
            Thread.Sleep(1000);
        }
        public static void UploadPhotoFile(TextInput element)
        {
            element.OnlyFill("\\\\pumsrvss.ad.pumox.com\\TestFiles\\PhotoFile.jpg");
        }
        public static void UploadPDFFile(TextInput element)
        {
            element.OnlyFill("\\\\pumsrvss.ad.pumox.com\\TestFiles\\TextFile.pdf");
        }
        public static void UploadLogoFile(TextInput element)
        {
            element.OnlyFill("\\\\pumsrvss.ad.pumox.com\\TestFiles\\logo.png");
        }
        public static bool CheckListTest(BaseElement firstElement, BaseElement secondElement)
        {
            Thread.Sleep(3000);

            try
            {
                bool fistElementVisibility = firstElement.IsExist();

                if (fistElementVisibility)
                {
                    Console.WriteLine("First element searched");
                    return true;
                }
                else
                {
                    secondElement.IsExist();
                    Console.WriteLine("Second element searched");
                    return true;
                }
            }
            catch (NoSuchElementException)
            {
                secondElement.IsExist();
                Console.WriteLine("Second element searched");
                return true;
            }
        }
    }
}
