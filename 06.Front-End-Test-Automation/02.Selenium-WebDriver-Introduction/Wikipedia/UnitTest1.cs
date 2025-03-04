using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Cretae chrome drive and open chrome browser
            WebDriver driver = new ChromeDriver();


            //Navigate to url
            driver.Navigate().GoToUrl("https://wikipedia.org");

            Console.WriteLine("Main page title: " + driver.Title);

            //locate the search input
            IWebElement searchBox = driver.FindElement(By.Id("searchInput"));

            //type Quality Assurance in the input
            searchBox.SendKeys("Quality Assurance" + Keys.Enter);

            //Print page title
            Console.WriteLine("Title after search: " + driver.Title);

            //Close the browser
            driver.Quit();
        }
    }
}