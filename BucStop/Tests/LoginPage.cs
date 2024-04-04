using OpenQA.Selenium;

/// <summary>
/// Represents the login page and encapsulates the login process.
/// </summary>
public class LoginPage
{
    private readonly IWebDriver driver;

    /// <summary>
    /// Constructor for the LoginPage class.
    /// </summary>
    /// <param name="driver">The WebDriver instance to use.</param>
    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    /// <summary>
    /// Performs login using the provided email.
    /// </summary>
    /// <param name="email">The email to use for logging in.</param>
    public void PerformLogin(string email)
    {
        var emailForm = driver.FindElement(By.Id("email"));
        emailForm.SendKeys(email); // Enter the email into the email form.
        emailForm.Submit(); // Submit the login form.
    }
}
