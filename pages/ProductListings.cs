using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWorks.pages
{
    class ProductListings
    {
        public static void addToCart(IWebDriver driver)
        {
            driver.FindElement(By.XPath("html/body/font/table[1]/tbody/tr[1]/td[3]/a/img")).Click();
        }

        public static String getProducts(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/html/body/font/table[1]")).Text;
        }
    }
}
