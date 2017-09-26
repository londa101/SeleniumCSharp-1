using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

/*
* Test the New Account application
* Goals:
* 1. Know how to find elements using other methods
* 2. Know how to interact with other HTML elements (tags)
* 3. Enhance the program with our C# knowledge
*/

namespace SeleniumWorks
{

    [TestClass]
    public class SdetNewAccount
    {
        String name = "Rachel Williams";
        String email = "rw@testemail.com";
        String phoneNumber = "12345657233";
        String password = "rwpass";
        String gender = "Female";
        String country = "Germany";
        Boolean weeklyEmail = true;
        Boolean monthlyEmail = false;
        Boolean occassionalEmail = false;

        [TestMethod]
        public void SdetNewAccountTest()
        {
            // 1. Open the browser and navigate to AMS page
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://sdettraining.com/trguitransactions/AccountManagement.aspx");

            // 2. Click on Create Account
            driver.FindElement(By.LinkText("Create Account")).Click();

            // 2. Fill out the 
                // How to locate elements
            driver.FindElement(By.Id("MainContent_txtFirstName")).SendKeys(name);
            driver.FindElement(By.Name("ctl00$MainContent$txtEmail")).SendKeys(email);
            driver.FindElement(By.XPath("html/body/form/div[3]/div[2]/div/div[2]/div[3]/div[2]/input")).SendKeys(phoneNumber);
            driver.FindElement(By.CssSelector("input[id='MainContent_txtPassword']")).SendKeys(password);
            driver.FindElement(By.CssSelector("input[name='ctl00$MainContent$txtVerifyPassword']")).SendKeys(password);

            // Radio button:
            if (gender == "Male")
            {
                driver.FindElement(By.Id("MainContent_Male")).Click();
            }
            else if (gender == "Female")
            {
                driver.FindElement(By.CssSelector("input[name='ctl00$MainContent$Gender'][value='Female']")).Click();
            }

            // Drop-down menu: bring in the Selenium.Support namespace
            // new SelectElement(driver.FindElement(By.Id("MainContent_menuCountry"))).SelectByText(country);
            new SelectElement(driver.FindElement(By.Id("MainContent_menuCountry"))).SelectByIndex(3);

            // Checkboxes >> decide if we want it checked, then if we do, determine if it is checked > then click
            if (weeklyEmail)
            {
                if (!driver.FindElement(By.Id("MainContent_checkWeeklyEmail")).Selected)
                {
                    driver.FindElement(By.Id("MainContent_checkWeeklyEmail")).Click();
                }
            }
            else
            {
                if (driver.FindElement(By.Id("MainContent_checkWeeklyEmail")).Selected)
                {
                    driver.FindElement(By.Id("MainContent_checkWeeklyEmail")).Click();
                }
            }

            // Assignment: Finish the other 2 checkboxes, and then complete the test

            // 3. Click submit

            // 4. Grab confirmation


            // 5. Close the browser
            driver.Close();

        }
    }
}
