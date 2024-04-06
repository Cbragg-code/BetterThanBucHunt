using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BucStop.Tests
{
    public class TestSetup
    {
        protected IWebDriver driver;

        protected readonly string baseUrl = "https://localhost:7182/";
        // protected readonly string baseUrl = Environment.GetEnvironmentVariable("SSH_HOST") ?? "https://localhost:7182/";


        /// <summary>
        /// Immediately before each test initialize the driver and options.
        /// </summary>
        [SetUp]
        public virtual void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Make Chrome run without a GUI
            options.AddArgument("--ignore-certificate-errors"); //Ignore any untrusted certificate errors
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(baseUrl);
        }
        /// <summary>
        /// Immediately after each test, close the driver.
        /// </summary>
        [TearDown]
        public virtual void TearDown()
        {
            driver.Quit();
        }
    }
}
