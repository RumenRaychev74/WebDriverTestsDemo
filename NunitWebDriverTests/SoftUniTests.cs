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
            string expectedTitle = "�������� �� ������������ - ��������� �����������";
            
            //Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));

        }
        [Test]
        public void Test_AssertAbautUsTitle()
        {
            
            var zaNasElement = driver.FindElement(By.CssSelector("ul.nav-list:nth-child(2) > li:nth-child(1) > a:nth-child(1) > span:nth-child(1)"));
            zaNasElement.Click();

            string expectedTitle = "�� ��� - ��������� �����������";

            //Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));

        }
    }
}