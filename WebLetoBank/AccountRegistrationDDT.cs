using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WebLetoBank.Utilities;
using NLog;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebLetoBank.Tests
{
    [TestFixture]
    public class AccountRegistrationDDT : TestBase
    {
        public static Logger Log;
        private const string BaseUrl = "https://mtest.ekassir.com:4443/personalcabinet/api/v1";
        //private const string BaseUrl = "https://sb2.ekassir.com/personalcabinet/api/v1";
        //private const string BaseUrl = "https://mobile.letobank.ru/personalcabinet/api/v1";     
        private const string MtestPassword = "Qwerty";        
        private const string MtestAccessCode = "123456";
        private const string MtestOTR = "334500";
        private const string MtestProtectCode = "1234";

        [Test(Description = "Registration Test")]
        [TestCaseSource("TestCaseDataList")]

        public void ExcelAccountRegistrationTest(string CRM, string AccountNumber)
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace("MTEST: Navigate to authentication page");
            Browser.Navigate(BaseUrl + "/self");
            Log.Trace("MTEST: Filling authentication fields");
            AuthPageHelper.FillAuthenticationFields("u" + CRM, MtestPassword);
            Log.Trace("MTEST: Click Registration Button ");
            AuthPageHelper.RegistrationButtonClick();
            Log.Trace("MTEST: Agree with license terms");
            RegistrationHelper.AcceptTermsButtonClick();
            Log.Trace("MTEST: Choose registration with account");
            RegistrationHelper.ChooseRegistrationType("account");
            Log.Trace("MTEST: Enter Account Number and access code: " + AccountNumber + " " + MtestAccessCode);
            RegistrationHelper.EnterAccountCredentials(AccountNumber, MtestAccessCode);
            Log.Trace("MTEST: Click Next. Go to SMS code page");
            RegistrationHelper.NextButtonClick();
            if (Browser.GetDriver().FindElement(By.XPath("//li")).Displayed)
            {
                IWebElement Error = Browser.GetDriver().FindElement(By.XPath("//li"));
                Log.Error("MTEST: " + Error.Text);                
            }
            Browser.WaitReadyState();
            Log.Trace("MTEST: Enter SMS code(otp)");
            RegistrationHelper.EnterOTR(MtestOTR);
            Log.Trace("MTEST: Click Next. Go to username page");
            RegistrationHelper.NextButtonClick();
            Browser.WaitReadyState();
            if (Browser.GetDriver().FindElement(By.XPath("//li")).Displayed)
            {
                IWebElement Error = Browser.GetDriver().FindElement(By.XPath("//li"));
                Log.Error("MTEST: " + Error.Text);                
            }
            Log.Trace("MTEST: Enter username: u" + CRM);
            RegistrationHelper.EnterUsername("u" + CRM);
            Log.Trace("MTEST: Delete existing username field");
            Browser.ExecuteJavaScript("var logins = document.getElementById('logins')");
            Browser.ExecuteJavaScript("logins.parentNode.removeChild(logins)");
            Log.Trace("MTEST: Click Next. Go to password page");
            RegistrationHelper.NextButtonClick();
            Browser.WaitReadyState();
            Log.Trace("MTEST: Enter and confirm password");
            RegistrationHelper.EnterPassword(MtestPassword, MtestPassword);
            Log.Trace("MTEST: Click Next. Go to protect code page");
            RegistrationHelper.NextButtonClick();
            Browser.WaitReadyState();
            Log.Trace("MTEST: Fill protect code fields");
            RegistrationHelper.EnterProtectCode(MtestProtectCode, MtestProtectCode);
            Log.Trace("MTEST: Click dismiss setting protect code");
            RegistrationHelper.DismissProtectCodeButtonClick();
            Browser.WaitReadyState();
        }

        public IEnumerable<TestCaseData> TestCaseDataList
        {
            get
            {
                List<TestCaseData> testCaseDataList = new ExcelTestDataReader().ReadExcelData(@"TestData.xls");
                foreach (TestCaseData testCaseData in testCaseDataList) {
                    yield return testCaseData; }
            }
        }
    }
   
}


