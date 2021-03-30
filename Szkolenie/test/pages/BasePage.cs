using log4net.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Szkolenie.helper;

namespace Szkolenie.test.pages
{
    public class BasePage
    {
        public IWebDriver driver;
        protected WebElementHelper helper;
        protected Logger logger;
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Manage().Window.Maximize();
            XmlConfigurator.Configure(File.OpenRead("data\\log4net.config"));
        }



        public void Quit()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
