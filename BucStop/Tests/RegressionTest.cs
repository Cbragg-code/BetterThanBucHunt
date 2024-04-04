using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BucStop.Tests
{
    /// <summary>
    /// Contains regression tests for the BucStop application.
    /// </summary>
    [TestFixture]
    public class RegressionTest
    {
        private IWebDriver driver;
        private NavigatePage navigatePage;
        private readonly string baseUrl = "https://localhost:7182/";

        /// <summary>
        /// Setup method to initialize the WebDriver and NavigatePage before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Run Chrome in headless mode for testing.
            options.AddArgument("--ignore-certificate-errors"); // Ignore SSL certificate errors.
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(baseUrl); // Navigate to the base URL of the application.
            navigatePage = new NavigatePage(driver, baseUrl); // Initialize NavigatePage object.
        }

        /// <summary>
        /// Tear down method to quit the WebDriver after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test, Order(1)]
        public void Login()
        {
            var loginPage = new LoginPage(driver);
            navigatePage.NavigateTo("Account/Login");
            loginPage.PerformLogin("Test@etsu.edu");
            navigatePage.AssertCurrentPage("");
        }

        public void Games()
        {
            navigatePage.NavigateTo("Games");
            navigatePage.AssertCurrentPage("Games");
        }

        [Test, Order(3)]
        public void AUP()
        {
            navigatePage.NavigateTo("Home/AUP");
            navigatePage.AssertCurrentPage("Home/AUP");
        }

        [Test, Order(4)]
        public void GameCriteria()
        {
            navigatePage.NavigateTo("Home/GameCriteria");
            navigatePage.AssertCurrentPage("Home/GameCriteria");
        }

        [Test, Order(5)]
        public void About()
        {
            navigatePage.NavigateTo("Home/About");
            navigatePage.AssertCurrentPage("Home/About");
        }
    }
}
