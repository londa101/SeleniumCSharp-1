using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using NUnit.Framework;
using log4net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace SeleniumWorks
{
    // [TestClass]
    [TestFixture]
    public class EnhancedLogin02
    {
        String browserType = "Firefox";
        static String file = "LoginData.csv";
        // static String file = "LoginTestData.txt";
        IWebDriver driver;
        ILog logfile = utilities.Log.StartLogger("DDTwithDataProvider");

        // [TestMethod]
        [Test, TestCaseSource("logindata")]
        public void CSVTest(String email, String password)
        {
            logfile.Info("Executing test: " + email + " and " + password);

            // These are the test elements
            driver.FindElement(By.Name("ctl00$MainContent$txtUserName")).SendKeys(email);
            driver.FindElement(By.Name("ctl00$MainContent$txtPassword")).SendKeys(password);

            logfile.Info("Clicking login");

            utilities.Capture.snap(driver, "LOGINTEST-" + email + "01");
            driver.FindElement(By.Id("MainContent_btnLogin")).Click();
            utilities.Capture.snap(driver, "LOGINTEST-" + email + "02");

            logfile.Info("Asserting the test result");

            // Assertion
            String confirmation = driver.FindElement(By.Id("conf_message")).Text;
            Console.WriteLine(confirmation);
            StringAssert.Contains("success", confirmation);
         
        }

        // DataProvider
        static List<String[]> logindata = utilities.CSV.getData(file);


        [SetUp]
        public void SetUp()
        {
            // Initialize some settings
            logfile.Info("Starting the test");
            driver = utilities.DriverFactory.newBrowser(browserType);
            driver.Navigate().GoToUrl("http://sdettraining.com/trguitransactions/AccountManagement.aspx");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
