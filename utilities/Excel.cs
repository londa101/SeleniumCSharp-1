using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWorks.utilities
{
    class Excel
    {
        // This function takes an Excel file and returns a list of String arrays
        // This function uses the System.Data.Common package
        public static List<String[]> getData(String filename, String sheet)
        {
            String rootPath = ConfigurationSettings.AppSettings["root_dir"].ToString() + @"data\";
            String file = rootPath + filename;

            // Install Office System Driver
            // Install https://www.microsoft.com/en-us/download/confirmation.aspx?id=23734

            // Define the connection string
            String driver = @"Provider=Microsoft.ACE.OLEDB.12.0;";
            String dataSource = @"Data Source=" + file + ";";
            String properties = @"Extended Properties='Excel 12.0 Xml;HDR=Yes:IMEX=10;'";
            String connectionString = driver + dataSource + properties;

            // Create connection
            DataTable dt = new DataTable();
            using (OleDbConnection oConn = new OleDbConnection(connectionString))
            {
                // Open connection
                oConn.Open();

                // Write command
                OleDbCommand oCommand = new OleDbCommand();
                oCommand.Connection = oConn;
                oCommand.CommandText = "SELECT * FROM [" + sheet + "$]";

                // Filling the Data Table
                OleDbDataAdapter oDataAdapter = new OleDbDataAdapter(oCommand);
                oDataAdapter.Fill(dt);

                oCommand = null;
                oConn.Close();
            }
            // Convert DataTable to a List<String[]>
            return dt.Rows.Cast<DataRow>().Select(row => dt.Columns.Cast<DataColumn>().Select(col => Convert.ToString(row[col])).ToArray()).ToList();
        }
    }
}
