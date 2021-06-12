using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace SauceLabs.Automation.Utils
{
    class DriverFactory
    {
        private IWebDriver _driver;
        
        private static readonly string DRIVER_PATH = Config.GetProjectRoot() + "Drivers";

        public IWebDriver GetDriver()
        {
            return _driver;
        }

        public IWebDriver SetDriver()
        {
            switch (Config.GetBrowserType().ToLower())
            {
                case "chrome":
                    SetupChromeDriver();
                    break;
                case "firefox":
                    SetupFirefoxDriver();
                    break;
                case "ie":
                    SetupIEDriver();
                    break;
            }
            return GetDriver();
        }

        public void SetupChromeDriver()
        { 
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("");
            _driver = new ChromeDriver(DRIVER_PATH);
        }

        public void SetupFirefoxDriver()
        {

        }

        public void SetupIEDriver()
        {

        }
    }
}
