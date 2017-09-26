using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWorks
{
    [TestFixture]
    public class ShoppingCart
    {
        IWebDriver driver;
        String product = "tv";

        // Perform end-to-end test of shoppping cart
        [Test]
        public void ShoppingCartTest()
        {
            // 1. Search for product
            pages.Search.searchForProduct(driver, product);

            // 2. Add product to the cart
            pages.ProductListings.addToCart(driver);

            // 3. Checkout
            pages.Cart.clickCheckout(driver);

            // 4. Enter payment, billing, shipping, information
            driver.FindElement(By.CssSelector("input[name='cmdSubmit'][value='Submit Order']")).Click();

            // 5. Confirmation
            String confirmation = driver.FindElement(By.XPath("html/body/font")).Text;
        }

        [SetUp]
        public void SetUp()
        {
            // Prepare the browser and test
            driver = utilities.DriverFactory.newBrowser("Chrome");
            driver.Navigate().GoToUrl("http://sdettraining.com/online/default.asp");
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
