using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AssertMainPageTitle()
        {
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";
            
            //Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));

        }
        [Test]
        public void Test_AssertAbautUsTitle()
        {
            
            var zaNasElement = driver.FindElement(By.CssSelector("ul.nav-list:nth-child(2) > li:nth-child(1) > a:nth-child(1) > span:nth-child(1)"));
            zaNasElement.Click();

            string expectedTitle = "За нас - Софтуерен университет";

            //Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));

        }
        [Test]
        public void Test_Login_Invalid_UserNameEndPassword()
        {
           
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();

            //Locate username field by ID
            //var usernameField = driver.FindElement(By.Id("username"));

            //Locate username field by TagName
            var usernmameField_ByName = driver.FindElement(By.Name("username"));
            var usernmameField_CSSSelector = driver.FindElement(By.CssSelector("#username"));

            //IWebElement usernameField = driver.FindElement(By.Id("username"));

            usernmameField_CSSSelector.Click();
            usernmameField_CSSSelector.SendKeys("user1");
            
            //driver.FindElement(By.Id("username")).SendKeys("user1");
            driver.FindElement(By.Id("password-input")).SendKeys("user1");
            driver.FindElement(By.CssSelector(".login-page-form-content-remember-me-checkbox > span:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));
            driver.Close();
        }
    }
}
