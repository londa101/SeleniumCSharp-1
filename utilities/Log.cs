using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWorks.utilities
{
    class Log
    {
        public static ILog StartLogger(string testName)
        {
            log4net.Config.XmlConfigurator.Configure();
            return LogManager.GetLogger(testName);
        }

    }
}
