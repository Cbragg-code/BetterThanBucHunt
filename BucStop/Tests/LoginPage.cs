using OpenQA.Selenium;

public class LoginPage
{
    private readonly IWebDriver driver;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void PerformLogin(string email)
    {
        var emailForm = driver.FindElement(By.Id("email"));
        emailForm.SendKeys(email); // Enter the email into the email form.
        emailForm.Submit(); // Submit the login form.
    }
}
