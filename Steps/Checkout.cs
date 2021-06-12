using NUnit.Framework;
using OpenQA.Selenium;
using SauceLabs.Automation.Base;
using SauceLabs.Automation.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SauceLabs.Automation.Steps
{
    [Binding]
    public sealed class Checkout
    {
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;
        private BaseTest _baseTest;

        public Checkout(IWebDriver driver, ScenarioContext scenarioContext, BaseTest baseTest)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _baseTest = baseTest;
        }

        [Given("Product Cards are displayed on the PDP page.")]
        [Then("User is able to view the Product Cards page.")]
        public void VerifyProductCardsPageIsDisplayed()
        {
            ProductCardsPage productCardsPage = new ProductCardsPage(_driver);
            //productCardsPage.ValidateProductCardsPageIsDisplayed();
        }

        [Given("Add to Cart buttons are clickable on the product cards.")]
        public void VerifyAddToCartButtonsDisplayed()
        {

        }

        [When("User clicks Add to Cart button of (.*) card.")]
        public void ClickFirstAddToCartButton(String product)
        {

        }

        [When("User navigate to Basket Page.")]
        public void NavigateToBasketPage()
        {

        }
    }
}
