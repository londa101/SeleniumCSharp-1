using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWorks.pages
{
    class Search
    {
        public static void searchForProduct(IWebDriver driver, String product)
        {
            driver.FindElement(By.Name("txtSearch")).SendKeys(product);
            driver.FindElement(By.Id("Go")).Click();
        }
    }
}
