using NUnit.Framework;
using OpenQA.Selenium;
using SauceLabs.Automation.Base;
using SauceLabs.Automation.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceLabs.Automation.Pages
{
    class LoginPage : BasePage
    {
        private By usernameTxt = By.Id("user-name");
        private By passwordTxt = By.Id("password");
        private By loginBtn = By.Id("login-button");
        private By swagLabsLogo = By.CssSelector(".login_logo");

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public void ValidateUsernameFieldIsDisplayed()
        {
            Assert.IsNotNull(GetElement(usernameTxt), "The Username field is not displayed.");
        }

        public void ValidatePasswordFieldIsDisplayed()
        {
            Assert.IsNotNull(GetElement(passwordTxt), "The Password field is not displayed.");
        }

        public void ValidateLoginButtonIsDisplayed()
        {
            Assert.IsNotNull(GetElement(loginBtn), "The Login button is not displayed.");
        }

        public void ValidateLoginPageIsDisplayed()
        {
            Assert.IsTrue(Driver.Title.Contains("Swag Labs"), "The Login Page is not displayed.");
            Assert.IsNotNull(GetElement(swagLabsLogo), "The Login Page logo is not displayed.");
        }

        public void Login(UserType userType)
        {
            ValidateUsernameFieldIsDisplayed();
            if (userType == UserType.StandardUser)
            {
                GetElement(usernameTxt).SendKeys(Config.GetStandardUser());
            }
            ValidatePasswordFieldIsDisplayed();
            GetElement(passwordTxt).SendKeys(Config.GetPassword());
            ValidateLoginButtonIsDisplayed();
            GetElement(loginBtn).Click();
        }

        public enum UserType
        {
            StandardUser,
            LockedOutUser,
            ProblemUser
        }
    }
}
