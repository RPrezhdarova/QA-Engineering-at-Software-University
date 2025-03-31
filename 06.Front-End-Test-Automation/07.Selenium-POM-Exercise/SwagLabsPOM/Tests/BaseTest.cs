using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SwagLabsPOM.Pages;

namespace SwagLabsPOM.Tests
{
    public class BaseTest : BaseTestBase
    {
        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
      
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        protected void Login(string username, string password)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var loginPage = new LoginPage(driver);
            loginPage.InputUsername(username);
            loginPage.InputPassword(password);
            loginPage.ClickLoginButton();
        }
    }
}
    
