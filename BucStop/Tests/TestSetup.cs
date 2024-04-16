using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BucStop.Tests
{
    public class TestSetup
    {
        protected IWebDriver driver;
        protected List<string> baseUrls = new List<string>
        {
            "http://3.142.88.34/",
            "http://18.233.180.198/",
            "https://localhost:7182/"
        };

        protected string baseURL = "";

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


            bool connected = false;
            foreach (var url in baseUrls)
            {
                try
                {
                    driver.Navigate().GoToUrl(url);
                    if (driver.Url.StartsWith(url))
                    {
                        baseURL = url;
                        connected = true;
                        break;
                    }
                }
                catch (WebDriverException ex)
                {
                    Console.WriteLine($"Failed to connect to {url}. Error: {ex.Message}");

                }
            }
            if (!connected)
            {
                throw new InvalidOperationException("Unable to connect to any of the specified URLs.");
            }
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
