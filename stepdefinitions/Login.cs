using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumWorks.stepdefinitions
{
    [Binding]
    public sealed class Login
    {
        private IWebDriver driver;

        [Given(@"the user is on the account management page")]
        public void the_user_is_on_the_account_management_page()
        {
            driver = utilities.DriverFactory.newBrowser("Firefox");
            driver.Navigate().GoToUrl("http://sdettraining.com/trguitransactions/AccountManagement.aspx");
        }

        [When(@"the user enters username and password")]
        public void the_user_enters_username_and_password()
        {
            driver.FindElement(By.Id("MainContent_txtUserName")).SendKeys("tim@testemail.com");
            driver.FindElement(By.Id("MainContent_txtPassword")).SendKeys("trpass");
            driver.FindElement(By.Id("MainContent_btnLogin")).Click();
        }

        [Then(@"the user should get a welcome message")]
        public void the_user_should_get_a_welcome_message()
        {
            Assert.True(driver.FindElement(By.Id("conf_message")).Displayed);
            driver.Quit();
        }

    }
}
