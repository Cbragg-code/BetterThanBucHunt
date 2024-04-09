using NUnit.Framework;
using OpenQA.Selenium;

namespace BucStop.Tests
{
    public class TestActions
    {
        private readonly IWebDriver driver;
        private readonly string baseUrl;

        /// <summary>
        /// Constructor for TestActions.
        /// Initializes a new instance of the TestActions class.
        /// </summary>
        /// <param name="driver">The WebDriver instance to use for navigation.</param>
        /// <param name="baseUrl">The base URL of the application for constructing full URLs.</param>
        public TestActions(IWebDriver driver, string baseUrl)
        {
            this.driver = driver;
            this.baseUrl = baseUrl;
        }

        /// <summary>
        /// Navigates to the specified path relative to the base URL.
        /// </summary>
        /// <param name="path">The path to navigate to, appended to the base URL.</param>
        public void NavigateTo(string path)
        {
            // Click the link that contains the specified path.
            driver.FindElement(By.XPath($"//a[contains(@href, '{path}')]")).Click();
        }

        /// <summary>
        /// Performs the login action by entering the provided email into the email form and submitting the form.
        /// </summary>
        /// <param name="email">The email address to be used for logging into the application.</param>
        public void PerformLogin(string email)
        {
            var emailForm = driver.FindElement(By.Id("email"));
            emailForm.SendKeys(email); // Enter the email into the email form.
            emailForm.Submit(); // Submit the login form.
        }

        /// <summary>
        /// Asserts that the current URL matches the expected URL constructed from the base URL and the provided path.
        /// </summary>
        /// <param name="expectedPath">The path expected to be part of the current URL.</param>
        public void AssertCurrentPage(string expectedPath)
        {
            // Assert that the current URL is as expected.
            Assert.That(driver.Url, Is.EqualTo(baseUrl + expectedPath.TrimStart('/')));
        }
    }
}