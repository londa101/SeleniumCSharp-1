using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWorks
{
    [TestFixture]
    class EnhancedLogin03
    {
        IWebDriver driver;
        ILog logfile = utilities.Log.StartLogger("LoginTestwithExcel");

        [Test, TestCaseSource("dataSource")]
        public void Login(String email, String password)
        {
            logfile.Info("Testing: " + email + " " + password);
            driver.FindElement(By.Id("MainContent_txtUserName")).SendKeys(email);
            driver.FindElement(By.Id("MainContent_txtPassword")).SendKeys(password);
            
            driver.FindElement(By.Id("MainContent_btnLogin")).Click();
            utilities.Capture.snap(driver, email);

            String pageText = driver.FindElement(By.XPath("/html/body")).Text;
            StringAssert.Contains("success", pageText);
        }

        static List<String[]> dataSource = utilities.Excel.getData("LoginTest.xlsx", "TestData");

        [SetUp]
        public void setUp()
        {
            driver = utilities.DriverFactory.newBrowser("Chrome");
            driver.Navigate().GoToUrl("http://sdettraining.com/trguitransactions/AccountManagement.aspx");
            logfile.Info("Starting test");
        }


        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
