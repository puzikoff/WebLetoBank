using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebLetoBank.Utilities;

namespace WebLetoBank.Tests
{
    class TestDataList
    {

         public IEnumerable<TestCaseData> TestCaseDataList
        {
            get
            {
                List<TestCaseData> testCaseDataList = new ExcelTestDataReader().ReadExcelData(@"TestData.xls");
                foreach (TestCaseData testCaseData in testCaseDataList)
                {                     
                    yield return testCaseData;
                }
            }
        }
       /* public IEnumerable<TestCaseData> TestCaseDataList
        {
            get
            {
                List<TestCaseData> testCaseDataList = new CSVTestDataReader().ReadCsvData(@"C:\Users\chepelve\Documents\BitBucket\webleto_selenium_ui_tests\WebLetoBank\bin\Debug\TestData.txt");
                foreach (TestCaseData testCaseData in testCaseDataList)
                {
                    yield return testCaseData;
                }
            }
        }*/

    }
}
