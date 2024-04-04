using NUnit.Framework;
using OpenQA.Selenium;

public class NavigatePage
{
    private readonly IWebDriver driver;
    private readonly string baseUrl;

    /// <summary>
    /// Constructor for NavigatePage.
    /// Initializes a new instance of the NavigatePage class.
    /// </summary>
    /// <param name="driver">The WebDriver instance to use for navigation.</param>
    /// <param name="baseUrl">The base URL of the application for constructing full URLs.</param>
    public NavigatePage(IWebDriver driver, string baseUrl)
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
    /// Asserts that the current URL matches the expected URL constructed from the base URL and the provided path.
    /// </summary>
    /// <param name="expectedPath">The path expected to be part of the current URL.</param>
    public void AssertCurrentPage(string expectedPath)
    {
        // Assert that the current URL is as expected.
        Assert.That(driver.Url, Is.EqualTo(baseUrl + expectedPath.TrimStart('/')));
    }
}
