using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using SauceLabs.Automation.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SauceLabs.Automation.Base
{
    [Binding]
    public sealed class BaseTest
    {
        private IObjectContainer _objectContainer;
        protected IWebDriver Driver { get; set; }

        public BaseTest(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void TestSetup()
        {
            DriverFactory driverFactory = new DriverFactory();
            Driver = driverFactory.SetDriver();
            _objectContainer.RegisterInstanceAs(Driver);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Driver.Url = Config.GetApplicationURL();
        }

        [AfterScenario]
        public void TestTeardown()
        {
            //Driver.Close();
        }
    }
}
