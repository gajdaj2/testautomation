using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szkolenie.helper
{
    public class WebElementHelper
    {
        public void sendKeys(IWebDriver driver, By by, string tekst)
        {
            driver.FindElement(by).SendKeys(tekst);
        }


        public void waitForElement(IWebDriver driver, By by,string tekst)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.SendKeys(tekst);
        }
    }
}
