using NLog;
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
        public static Logger Log;        
        public List<TestCaseData> ReadExcelData(string excelFile)
        {
            Boolean f = false;         
            Log = LogManager.GetCurrentClassLogger();
            string connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
            List<TestCaseData> testDataList = new List<TestCaseData>();
            using (OleDbConnection connection = new OleDbConnection(connectionStr))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT CRMCLientId, Account FROM [Лист1$]", connection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String CRM = reader.GetValue(0).ToString();
                    String AccountNumber = reader.GetValue(1).ToString();
                    if (AccountNumber != "NULL")
                    {
                        f = false;
                        TestCaseData testData = new TestCaseData(CRM, AccountNumber);                        
                        for (int i = 0; i < testDataList.Count; i++)
                        {                           
                            if (testData.Arguments[1].Equals(testDataList[i].Arguments[1])) { 
                                f = true;                             
                                break; 
                            }                            
                        }
                        if (f == false) {
                            testDataList.Add(testData);         
                        }
                    }
                }
                reader.Close();
             }
           return testDataList;
       }
    }
}


