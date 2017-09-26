using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumWorks.utilities
{
    class CSV
    {
        public static List<String[]> getData(String filename)
        {
            List<String[]> data = new List<String[]>();
            String rootPath = ConfigurationSettings.AppSettings["root_dir"].ToString() + @"data\";
            String file = rootPath + filename;

            StreamReader sr = new StreamReader(file);
            String row;

            while ((row = sr.ReadLine()) != null)
            {
                String[] record = Regex.Split(row, ",");
                data.Add(record);
            }

            sr.Close();

            return data;
        }
    }
}
