using NLog;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebLetoBank.Utilities;
using System.Collections.Generic;

namespace WebLetoBank.Tests
{
    [TestFixture]
    public class AccountRegistration : TestBase
    {
        public static Logger Log;
        private const string BaseUrl = "https://mtest.ekassir.com:4443/personalcabinet/api/v1";
        //private const string BaseUrl = "https://sb2.ekassir.com/personalcabinet/api/v1";
        //private const string BaseUrl = "https://mobile.letobank.ru/personalcabinet/api/v1";
        private const string Password = "Qwerty";        
        private const string AccessCode = "123456";
        private const string OTR = "334500";
        private const string ProtectCode = "1234";
       
        [Test]

        [TestCase("40817810200240259336", "u5008556")]
        [TestCase("40817810100240259339", "u5011770")]
        [TestCase("40817810600240259334", "u5008556")]
        [TestCase("40817810500240259340", "u5011779")]
        [TestCase("40817810800240259341", "u5011780")]
        [TestCase("40817810700240259344", "u5011807")]
        [TestCase("40817810500240259353", "u5011607")]
        [TestCase("40817810500240259366", "u5010648")]

        public void MtestAccountRegistrationTest(string AccountNumber, string Username)
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace(" Navigate to authentication page");
            Browser.Navigate(BaseUrl + "/self");
            Log.Trace(" Filling authentication fields");            
            AuthPageHelper.FillAuthenticationFields(Username, Password);
            Log.Trace(" Click Registration Button ");
            AuthPageHelper.RegistrationButtonClick();
            Log.Trace(" Agree with license terms");
            RegistrationHelper.AcceptTermsButtonClick();
            Log.Trace(" Choose registration with account");
            RegistrationHelper.ChooseRegistrationType("account");
            Log.Trace(" Enter Account Number and access code: " + AccountNumber + " " + AccessCode);
            RegistrationHelper.EnterAccountCredentials(AccountNumber, AccessCode);
            Log.Trace(" Click Next. Go to SMS code page");
            RegistrationHelper.NextButtonClick();
            if (Browser.GetDriver().FindElement(By.XPath("//li")).Displayed) {                 
                IWebElement Error = Browser.GetDriver().FindElement(By.XPath("//li"));
                Log.Error(" " + Error.Text);               
            }       
            Browser.WaitReadyState();
            Log.Trace(" Enter SMS code(otp)");
            RegistrationHelper.EnterOTR(OTR);
            Log.Trace(" Click Next. Go to username page");
            RegistrationHelper.NextButtonClick();
            Browser.WaitReadyState();
            if (Browser.GetDriver().FindElement(By.XPath("//li")).Displayed) {
                IWebElement Error = Browser.GetDriver().FindElement(By.XPath("//li"));
                Log.Error(" " + Error.Text);                
            }       
            Log.Trace(" Enter username: " + Username);
            RegistrationHelper.EnterUsername(Username);
            Log.Trace(" Delete existing username field");
            Browser.ExecuteJavaScript("var logins = document.getElementById('logins')");
            Browser.ExecuteJavaScript("logins.parentNode.removeChild(logins)");
            Log.Trace(" Click Next. Go to password page");
            RegistrationHelper.NextButtonClick();            
            Browser.WaitReadyState();
            Log.Trace(" Enter and confirm password");
            RegistrationHelper.EnterPassword(Password, Password);           
            Log.Trace(" Click Next. Go to protect code page");
            RegistrationHelper.NextButtonClick();
            Browser.WaitReadyState();
            Log.Trace(" Fill protect code fields");
            RegistrationHelper.EnterProtectCode(ProtectCode, ProtectCode);
            Log.Trace(" Click dismiss setting protect code");
            RegistrationHelper.DismissProtectCodeButtonClick();
            Browser.WaitReadyState();
        }
     }
}

