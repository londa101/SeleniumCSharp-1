using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumWorks.stepdefinitions
{
    [Binding]
    public sealed class ShoppingCartSteps
    {
        IWebDriver driver;

        [Given(@"user is on the ecommerce page")]
        public void GivenUserIsOnTheEcommercePage()
        {
            driver = utilities.DriverFactory.newBrowser("firefox");
            driver.Navigate().GoToUrl("http://sdettraining.com/online/");
        }

        [When(@"user searches for a product")]
        public void WhenUserSearchesForAProduct()
        {
            pages.Search.searchForProduct(driver, "tv");
        }

        [When(@"user adds product to cart")]
        public void WhenUserAddsProductToCart()
        {
            pages.ProductListings.addToCart(driver);
        }

        [Then(@"user should see the product in their cart")]
        public void ThenUserShouldSeeTheProductInTheirCart()
        {
            Thread.Sleep(1000);
            String cart = pages.Cart.getCartData(driver);
            Assert.True(cart.Contains("TV"));
        }

        [Then(@"user should see product results")]
        public void ThenUserShouldSeeProductResults()
        {
            String productListings = pages.ProductListings.getProducts(driver);
            Console.WriteLine(productListings);
            Assert.True(productListings != null);
        }


        [After]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
