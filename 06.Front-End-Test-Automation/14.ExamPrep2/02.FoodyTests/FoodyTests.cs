using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FoodyTests
{
    public class FoodyTests
    {
        private IWebDriver driver;
        private readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/";

        private string lastCreatedFoodTitle;
        private string lastCreatedFoodDescription;
        private Random random;



        [OneTimeSetUp]
        public void Setup()
        {
            random = new Random();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Navigate().GoToUrl(BaseUrl+"User/Login");
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeys("RositsaTesten");
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("testen123");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

        }

        [Test, Order(1)]
        public void AddFoodWithInvalidDataTest()
        {
            string invalidFoodName = "";
            string invalidFoodDescription = "";
            driver.Navigate().GoToUrl(BaseUrl + "Food/Add");
            driver.FindElement(By.XPath("//input[@id='name']")).SendKeys(invalidFoodName);
            driver.FindElement(By.XPath("//input[@id='description']")).SendKeys(invalidFoodDescription);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var errorMessage = driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li")).Text;

            Assert.That(driver.Url, Is.EqualTo(BaseUrl + "Food/Add"));
            Assert.That(errorMessage.Trim(), Is.EqualTo("Unable to add this food revue!"));
        }

        [Test, Order(2)]
        public void AddRandomFoodTest()
        {
            lastCreatedFoodTitle = "name_" + random.Next(999, 9999).ToString();
            lastCreatedFoodDescription = "description_" + random.Next(999, 9999).ToString();
            driver.Navigate().GoToUrl(BaseUrl + "Food/Add");
            driver.FindElement(By.XPath("//input[@id='name']")).SendKeys(lastCreatedFoodTitle);
            driver.FindElement(By.XPath("//input[@id='description']")).SendKeys(lastCreatedFoodDescription);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();        

            // explicit wait  
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //var homePageElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()='FOODY']")));

            Assert.That(driver.Url, Is.EqualTo(BaseUrl));
            Assert.That(driver.Title, Is.EqualTo("Home Page - Foody.WebApp"));

            var lastCreatedFood = driver.FindElement(By.XPath("(//h2[contains(@class,'display-4')])[last()]")).Text;
            Assert.That(lastCreatedFood, Is.EqualTo(lastCreatedFoodTitle));
        }

        [Test, Order(3)]
        public void EditLastAddedFoodTest()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var editedTitle = "Edited";

            var lastFoodEditButton = driver.FindElement(By.XPath("(//div[contains(@class,'p-5')])[last()]//a[text()='Edit']"));         

            Actions actions = new Actions(driver);
            actions.MoveToElement(lastFoodEditButton).Perform();
            lastFoodEditButton.Click();

            driver.FindElement(By.Id("name")).SendKeys(editedTitle);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var lastCreatedFoodNameText = driver.FindElement(By.XPath("(//h2[contains(@class,'display-4')])[last()]")).Text;
            Assert.That(lastCreatedFoodNameText, Is.EqualTo(lastCreatedFoodTitle));

            Console.WriteLine("The title remains unchanges due to unimplemented functionality");
        }

        [Test, Order(4)]
        public void SearchForFoodTest()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            driver.FindElement(By.XPath("//input[@name='keyword']")).SendKeys(lastCreatedFoodTitle);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.UrlContains($"keyword={lastCreatedFoodTitle}"));

            var allFoodContainers = driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']"));
            Assert.That(allFoodContainers.Count(), Is.EqualTo(1));

            var lastCreatedFoodNameText = driver.FindElement(By.XPath("(//h2[contains(@class,'display-4')])[last()]")).Text;
            Assert.That(lastCreatedFoodNameText, Is.EqualTo(lastCreatedFoodTitle));
        }

        [Test, Order(5)]
        public void DeleteLastCreatedFood()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var initialCount= driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']")).Count;
            var lastFoodContainer = driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(lastFoodContainer).Perform();

            Assert.That(lastFoodContainer.Enabled, Is.True);
            Assert.That(lastFoodContainer.Displayed, Is.True);
            driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//a[text()='Delete']")).Click();


            var countcountAfterDeletion = driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']")).Count;
            Assert.That(countcountAfterDeletion, Is.EqualTo(initialCount - 1));

        }

        [Test, Order(6)]
        public void SearchForDeletedFood() 
        {
            driver.Navigate().GoToUrl(BaseUrl);

            driver.FindElement(By.XPath("//input[@name='keyword']")).SendKeys(lastCreatedFoodTitle);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//img[@alt='empty plate picture']")));

            var noResultMessage = driver.FindElement(By.XPath("//h2[@class='display-4']")).Text;
            var addFoodButton = driver.FindElement(By.XPath("//a[text()='Add food']"));

            Assert.That(noResultMessage, Is.EqualTo("There are no foods :("));
            Assert.That(addFoodButton.Displayed, Is.True);
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}