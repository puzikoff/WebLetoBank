using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;


namespace WebLetoBank.Utilities
{

    public class ExcelTestDataReader
    {
      public List<TestCaseData> ReadExcelData(string excelFile)
        {
            string connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
            List <TestCaseData> testDataList = new List<TestCaseData>();
            using (OleDbConnection connection = new OleDbConnection(connectionStr))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT CRMCLientId, Account FROM [Лист1$]", connection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String CRM = reader.GetValue(0).ToString();
                    String AccountNumber = reader.GetValue(1).ToString();
                    TestCaseData testData = new TestCaseData(CRM, AccountNumber);
                    testDataList.Add(testData);                    
                }
                reader.Close();
            }

            return testDataList;
        }
    }
}

