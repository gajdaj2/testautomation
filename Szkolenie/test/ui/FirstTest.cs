using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Szkolenie.helper;

namespace Szkolenie.test.ui
{
    [TestFixture]
    class FirstTest
    {
        [Test]
        public void FirstChromeDriver()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver();
            //IWebElement username = driver.FindElement(By.Name("userName"));
            //Act
            driver.Navigate().GoToUrl("http://www.google.com");
            string pageSource = driver.PageSource;
            driver.Quit();

            
            //Assert
            //Assert.AreEqual("Google", pageTitle);
        }





        //table/tbody/tr[1]/td[position()<last()-1]

        //*[@id="mw-content-text"]/div[1]/table[3]

        [Test]
        public void MultiTest2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://pl.wikipedia.org/wiki/Mariusz_Pudzianowski");
            IReadOnlyCollection<IWebElement> values = driver.FindElements(By.XPath("//table[@class='wikitable'][2]/tbody/tr[position()<last()]/td[1]"));
            var check = values.Count;
            driver.Quit();

        }



        [Test]

        public void MultiTest()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver();

            //Act
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/index.php");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IReadOnlyCollection<IWebElement> link = driver.FindElements(By.XPath("//a"));
            driver.Quit();
            Assert.AreEqual(53, link.Count);

        }


        [Test]
        public void SelectTest()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver();

            //Act
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/index.php");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement flight = driver.FindElement(By.XPath("//a[@href='reservation.php']"));
            flight.Click();
            IWebElement departing = driver.FindElement(By.Name("fromPort"));
            IWebElement radio = driver.FindElement(By.XPath("//input[@value='First']"));
            SelectElement select = new SelectElement(departing);
            select.SelectByIndex(1);
            Helper.Pause();
            select.SelectByText("Acapulco");
            Helper.Pause();
            select.SelectByValue("New York");
            Helper.Pause();
            radio.Click();
            Helper.Pause();
            driver.Quit();
        }





        [Test]
        public void FirstChromeDriverFindElement()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver();
            
            //Act
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/index.php");
            IWebElement username = driver.FindElement(By.Name("userName"));
            username.SendKeys("Kuba");
            IWebElement register = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[2]/table/tbody/tr[2]/td/table/tbody/tr/td[2]/a"));
            register.Click();
            Helper.Pause(4000);
            driver.Navigate().Back();
            Helper.Pause(4000);
            driver.Navigate().Forward();
            Helper.Pause(4000);
            driver.Quit();

            //Assert
            //Assert.AreEqual("Google", pageTitle);
        }

        [Test]
        public void ExpWaitTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/index.php");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            IWebElement flight = driver.FindElement(By.XPath("//a[@href='reservation.php']"));
            flight.Click();
            IWebElement continueSearch = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("findFlights")));
            continueSearch.Click();
            string title = driver.Title;

            driver.Quit();

            Assert.AreEqual("Find a Flight: Mercury Tours:", title);

        } 


    }
}
