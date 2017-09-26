using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using NUnit.Framework;

namespace SeleniumWorks
{
    // [TestClass]
    [TestFixture]
    public class EnhancedLogin01
    {
        String browserType = "Firefox";
        IWebDriver driver;

        // [TestMethod]
        [Test, TestCaseSource("testdata")]
        public void CrossBrowserTesting(String email, String password)
        {
            Console.WriteLine("USER: " + email + " | PASSWORD: " + password);

            // These are the test elements
            driver.FindElement(By.Name("ctl00$MainContent$txtUserName")).SendKeys(email);
            driver.FindElement(By.Name("ctl00$MainContent$txtPassword")).SendKeys(password);

            utilities.Capture.snap(driver, "LOGINTEST-" + email + "01");
            driver.FindElement(By.Id("MainContent_btnLogin")).Click();
            utilities.Capture.snap(driver, "LOGINTEST-" + email + "02");

            // Assertion
            String confirmation = driver.FindElement(By.Id("conf_message")).Text;
            Console.WriteLine(confirmation);
            StringAssert.Contains("success", confirmation);
        }

        static object[] testdata =
        {
            new object[] {"tim@testemail.com", "trpass"},
            new object[] {"rw@testemail.com", "rwpass"},
            new object[] {"jv@testemail.com", "jvpass" },
            new object[] {"sm@testemail.com", "smpass"},
        };


        [SetUp]
        public void SetUp()
        {
            // Initialize some settings
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
