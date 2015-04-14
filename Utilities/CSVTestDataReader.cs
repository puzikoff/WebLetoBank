using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;


namespace WebLetoBank.Utilities
{

    public class CSVTestDataReader
    {
        public List<TestCaseData> ReadCsvData(string csvFilePath)
        {
            
            if (!File.Exists(csvFilePath))
                return null;

            string full = Path.GetFullPath(csvFilePath);
            string file = Path.GetFileName(full);
            string dir = Path.GetDirectoryName(full);

            string connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;"
        + "Data Source=\"" + dir +"\\\";"
        + "Extended Properties=\"text;HDR=No;FMT=TabDelimited()\"";

            

             
            List<TestCaseData> testDataList = new List<TestCaseData>();
            using (OleDbConnection connection = new OleDbConnection(connectionStr))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT F1, F2 FROM " + file, connection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String CRM = reader.GetValue(0).ToString();
                    String AccountNumber = reader.GetValue(1).ToString();
                    if (AccountNumber != "NULL")
                    {
                        TestCaseData testData = new TestCaseData(CRM, AccountNumber);
                        testDataList.Add(testData);
                    }
                }
                reader.Close();
            }

            return testDataList;
        }
    }
}

