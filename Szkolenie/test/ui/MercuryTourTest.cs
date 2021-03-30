using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Szkolenie.helper;
using Szkolenie.test.pages;

namespace Szkolenie.test.ui
{

    [TestFixture]
    class MercuryTourTest
    {

        private IWebDriver driver;

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/index.php");
        }


        [Test]
        [Category("Sanity")]
        public void MercuryLoginTest()
        {
            HomePage home = new HomePage(driver);
            LandingPage land = home.Login("kuba", "kuba");
            Helper.Pause();
        }


        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
