using NUnit.Framework;
using OpenQA.Selenium;
using SauceLabs.Automation.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceLabs.Automation.Pages
{
    class ProductCardsPage : BasePage
    {
        private By productCards = By.CssSelector(".inventory_item");

        public ProductCardsPage(IWebDriver driver) : base(driver)
        {

        }

        public void ValidateProductCardsPageIsDisplayed()
        {
            Assert.IsNotNull(GetElements(productCards), "Product Cards Page is not displayed.");
        }
    }
}
