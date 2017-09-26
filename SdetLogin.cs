using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SeleniumWorks
{
    [TestClass]
    public class SdetLogin
    {
        // This is our "test" method - where we will write our Selenium code
        [TestMethod]
        public void SdetLoginTest()
        {
            // 1. Open the browser (which browser?) using Selenium
            // Instantiate the WebDriver object
            // IWebDriver driver = new ChromeDriver();
            IWebDriver driver = new InternetExplorerDriver();

            // 2. "Launch" the app - go to the web app URL
            driver.Navigate().GoToUrl("http://sdettraining.com/trguitransactions/AccountManagement.aspx");

            // Fill in the data forms: 1) locate the element, 2) perform the action, 3) pass any parameters

            // 3. Enter the username
            driver.FindElement(By.Name("ctl00$MainContent$txtUserName")).SendKeys("tim@testemail.com");

            // 4. Enter the password
            driver.FindElement(By.Name("ctl00$MainContent$txtPassword")).SendKeys("trpass");

            // 5. Click login button
            driver.FindElement(By.Id("MainContent_btnLogin")).Click();


            // 6. Confirmation
            String confirmation = driver.FindElement(By.Id("conf_message")).Text;
            Console.WriteLine(confirmation);

            if (confirmation.Contains("Logged in successfully"))
            {
                Console.WriteLine("TEST PASSED");
            }
            else
            {
                Console.WriteLine("TEST FAILED");
            }

            // Close browser
            driver.Close();
        }
    }
}
