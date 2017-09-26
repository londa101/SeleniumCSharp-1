using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWorks.utilities
{
    class Database
    {
        // This function will take a query and return a List<String[]>
        // This function requires the Data and Data.SqlClient package
        public static List<String[]> getData(String query)
        {
            DataTable dt = new DataTable();

            // Connection String
            
            // String server = "sql2k801.discountasp.net";
            // String username = "SQL2008_841902_tr_user";
            // String password = "52645264hrm";
            // String database = "SQL2008_841902_tr";
            
            String server = ConfigurationSettings.AppSettings["db_server"].ToString();
            String username = ConfigurationSettings.AppSettings["db_username"].ToString();
            String password = ConfigurationSettings.AppSettings["db_password"].ToString();
            String database = ConfigurationSettings.AppSettings["db_database"].ToString();

            String connectionString = "server=" + server + ";User=" + username + ";Password=" + password + ";database=" + database + ";";
            Console.WriteLine(connectionString);

            // 1. Connect to Database
            SqlConnection oConn = new SqlConnection(connectionString);

            // 2. Execute query
            SqlCommand oCommand = new SqlCommand(query, oConn);

            // 3. Open the connection
            oConn.Open();

            // 4. Read the data
            SqlDataReader oDataReader = oCommand.ExecuteReader();

            // 5. Fill the Data table
            dt.Load(oDataReader);

            // 6. Return the data as a List<String[]>
            return dt.Rows.Cast<DataRow>().Select(row => dt.Columns.Cast<DataColumn>().Select(col => Convert.ToString(row[col])).ToArray()).ToList();
        }
    }
}
