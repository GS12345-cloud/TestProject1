using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Security.Principal;

namespace TestProject1.Test
{
    public class Tests
    {
        const string url = "https://demoqa.com/";

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Url = url;
            const string ElementsBoxXPath = @"//*[@id=\\" + "app" + "\\\"]/div/div/div[2]/div/div[1]/div/div[2]/svg";
            Thread.Sleep(5000);
            IWebElement elementsBox = driver.FindElement(By.XPath(ElementsBoxXPath));
            var title = driver.Title;

            elementsBox.Click();
            Thread.Sleep(10000);
            if (title.Contains("Elements"))
            {
                Console.WriteLine("Passed!");
                Console.ReadKey();
                Assert.Pass();
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}