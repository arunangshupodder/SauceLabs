
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace SauceLabs.Automation.Base
{
    class BasePage
    {
        private WebDriverWait _wait;
        private DefaultWait<IWebDriver> _dynamicWait;
        protected IWebDriver Driver { get; set;  }
        
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this._wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
            this._dynamicWait = new DefaultWait<IWebDriver>(this.Driver);
        }

        public bool IsElementDisplayed(By element)
        {
            try
            {
                _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                return true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool IsElementDisplayed(By element, int timeoutDuration)
        {
            try
            {
                _dynamicWait.Timeout = TimeSpan.FromSeconds(timeoutDuration);
                _dynamicWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                return true;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool isAtLeastOneElementDisplayed(By element)
        {
            try
            {
                int attempt = 0;
                while(attempt<10)
                {
                    if (Driver.FindElements(element).Count > 0)
                        return true;
                    else
                    {
                        Thread.Sleep(1000);
                        attempt++;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public IWebElement GetElement(By element)
        {
            if (IsElementDisplayed(element))
            {
                return Driver.FindElement(element);
            }
            else
            {
                return null;
            }
        }

        public IWebElement GetElement(By element, int timeOut)
        {
            if (IsElementDisplayed(element, timeOut))
            {
                return Driver.FindElement(element);
            }
            else
            {
                return null;
            }
        }

        public ReadOnlyCollection<IWebElement> GetElements(By element)
        {
            Console.WriteLine("No. of elements displayed: " + Driver.FindElements(element).Count);
            if (isAtLeastOneElementDisplayed(element))
            {
                return Driver.FindElements(element).Count == 0 ? null : Driver.FindElements(element);
            }
            else
            {
                return null;
            }
        }
    }
}
