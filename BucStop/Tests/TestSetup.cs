using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BucStop.Tests
{
    public class TestSetup
    {
        protected IWebDriver driver;
        protected readonly string baseUrl = "https://localhost:7182/"; // Or externalize this configuration

        [SetUp]
        public virtual void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--ignore-certificate-errors");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(baseUrl);
        }

        [TearDown]
        public virtual void TearDown()
        {
            driver.Quit();
        }
    }
}
