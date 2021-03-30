using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Szkolenie.helper;

namespace Szkolenie.test.pages
{
    public class HomePage : BasePage
    {
        private By username = By.Name("userName");
        private By password = By.Name("password");
        private By btSubmit = By.Name("submit");


        public HomePage(IWebDriver driver) : base(driver)
        {
            helper = new WebElementHelper();
        }

        public LandingPage Login(string name, string pass)
        {
            log.Info("Before send key user");
            helper.sendKeys(driver, username, name);
            log.Info("After send key user");
            log.Info("Before send key Password");
            //driver.FindElement(username).SendKeys(name);
            helper.waitForElement(driver, password, pass);
            //driver.FindElement(password).SendKeys(pass);
            driver.FindElement(btSubmit).Click();

            return new LandingPage(driver);
        }




    }

}
