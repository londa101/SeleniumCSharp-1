using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWorks.pages
{
    class Cart
    {
        public static void clickCheckout(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("input[name='cmdSubmit'][value='Proceed to Checkout']")).Click();
        }

        public static String getCartData(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/html/body/font/form/table")).Text;
        }
    }
}
