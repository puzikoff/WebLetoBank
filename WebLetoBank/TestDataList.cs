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
    }
}
