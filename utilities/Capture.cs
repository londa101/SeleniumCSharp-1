using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWorks.utilities
{
    class Capture
    {
        public static void snap(IWebDriver driver, String filename)
        {
            String rootPath = ConfigurationSettings.AppSettings["root_dir"].ToString() + @"output\";
            Screenshot scrnshot = ((ITakesScreenshot)driver).GetScreenshot();
            scrnshot.SaveAsFile(rootPath + filename + ".jpg", ScreenshotImageFormat.Jpeg);
        }
    }
}
