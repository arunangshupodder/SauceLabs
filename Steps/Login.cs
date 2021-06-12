using NUnit.Framework;
using OpenQA.Selenium;
using SauceLabs.Automation.Base;
using SauceLabs.Automation.Pages;
using System;
using TechTalk.SpecFlow;

namespace SauceLabs.Automation.Steps
{
    [Binding]
    public sealed class Login
    {
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;
        private BaseTest _baseTest;

        public Login(IWebDriver driver, ScenarioContext scenarioContext, BaseTest baseTest)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _baseTest = baseTest;
        }

        [Given("Login Page is displayed.")]
        public void VerifyLoginPage()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ValidateLoginPageIsDisplayed();

            _scenarioContext["login"] = loginPage;
        }

        [When("User enters valid credentials in the login page.")]
        public void EnterCredentials()
        {
            LoginPage loginPage = (LoginPage)_scenarioContext["login"];
            loginPage.Login(LoginPage.UserType.StandardUser);
        }

        [Then("User successfully logs into the application.")]
        public void ValidateSuccessfulLogin()
        {
            LoginPage loginPage = (LoginPage)ScenarioContext.Current["login"];
        }
    }
}
