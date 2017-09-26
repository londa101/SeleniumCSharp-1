using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWorks.utilities
{
    class DriverFactory
    {
        // this method will take a browser parameter and return a appropriate driver
        public static IWebDriver newBrowser(String browserType)
        {
            IWebDriver driver;
            if (browserType.ToUpper().Equals("CHROME"))
            {
                driver = new ChromeDriver();
            }
            else if (browserType.ToUpper().Equals("FIREFOX"))
            {
                driver = new FirefoxDriver();
            }
            else if (browserType.ToUpper().Equals("IE"))
            {
                driver = new InternetExplorerDriver();
            }
            else
            {
                driver = new ChromeDriver();
            }
            Console.Write("Using browser: " + browserType);
            return driver;
        }
    }
}
