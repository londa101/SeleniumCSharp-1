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
using System.Data;

namespace SeleniumWorks
{
    // [TestClass]
    [TestFixture]
    public class ReadingData
    {
        ILog logfile = utilities.Log.StartLogger("ReadingExcel");

        [Ignore("Not needed")]
        [Test]
        public void ReadingDataSample()
        {
            List<String[]> sampleData = utilities.Database.getData("SELECT * FROM Flights WHERE Price>500");
            foreach (String[] record in sampleData)
            {
                foreach (String field in record)
                {
                    Console.Write(field);
                }
            }

            /*
            DataTable xlData = utilities.Excel.getData("LoginTest.xlsx", "TestData");
            foreach (DataRow record in xlData.Rows)
            {
                String email = record["email"].ToString();
                String password = record["password"].ToString();
                //logfile.Info("Executing test: " + email + " and " + password);
                Console.WriteLine(email + password);
            }
            */
        }

        // [Ignore("We don't need to test Excel anymore")]
        [Test,TestCaseSource("xlTestData")]
        public void TestwithExcel(String email, String password)
        {
            Console.WriteLine(email + " " + password);
        }


        [Test, TestCaseSource("dbTestData")]
        public void TestwithDB(String id, String lenderLoanNumber, String sellerNumber, String financialInsNumber, String date)
        {
            Console.WriteLine(id + " " + lenderLoanNumber + " " + sellerNumber + " " + financialInsNumber + " " + date);
        }

        // DataProvider
        static List<String[]> csvTestData = utilities.CSV.getData("LoginData.csv");
        static List<String[]> xlTestData = utilities.Excel.getData("LoginTest.xlsx", "TestData");
        static List<String[]> dbTestData = utilities.Database.getData("SELECT * FROM MortgageLoanTestData");


        [SetUp]
        public void SetUp()
        {
            // Initialize some settings
            logfile.Info("Starting the test");
        }
    }
}
