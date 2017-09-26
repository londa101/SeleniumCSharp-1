using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWorks
{
    [TestClass]
    public class NewAccountIDE
    {
        [TestMethod]
        public void NewAccountTestwithIDE()
        {
            IWebDriver driver;
            string baseURL;
            driver = new FirefoxDriver();
            baseURL = "http://sdetuniversity.com/";
            driver.Navigate().GoToUrl(baseURL + "/projects/");
            driver.FindElement(By.LinkText("Account Management System")).Click();
            driver.FindElement(By.LinkText("Create Account")).Click();
            driver.FindElement(By.Id("MainContent_txtFirstName")).Clear();
            driver.FindElement(By.Id("MainContent_txtFirstName")).SendKeys("Mike Smith");
            driver.FindElement(By.Id("MainContent_txtEmail")).Clear();
            driver.FindElement(By.Id("MainContent_txtEmail")).SendKeys("gw@testemail.com");
            driver.FindElement(By.Id("MainContent_txtHomePhone")).Clear();
            driver.FindElement(By.Id("MainContent_txtHomePhone")).SendKeys("123123491");
            driver.FindElement(By.Id("MainContent_Male")).Click();
            driver.FindElement(By.Id("MainContent_txtPassword")).Clear();
            driver.FindElement(By.Id("MainContent_txtPassword")).SendKeys("gwpass");
            driver.FindElement(By.Id("MainContent_txtVerifyPassword")).Clear();
            driver.FindElement(By.Id("MainContent_txtVerifyPassword")).SendKeys("gwpass");
        }
    }
}
