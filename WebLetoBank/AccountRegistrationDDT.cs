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
        private const string AccessCode = "123456";
        private const string OTR = "334500";
        private const string ProtectCode = "1234";

        [Test(Description = "Registration Test")]
        [TestCaseSource(typeof(TestDataList),"TestCaseDataList")]

        public void AccountRegistrationDDTest(string CRM, string AccountNumber)
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace(" Navigate to authentication page");
            Browser.Navigate(BaseUrl + "/self");
            Log.Trace(" Filling authentication fields");
            AuthPageHelper.FillAuthenticationFields("u" + CRM, Password);
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
            if (Browser.GetDriver().FindElement(By.XPath("//li")).Displayed)
            {
                IWebElement Error = Browser.GetDriver().FindElement(By.XPath("//li"));
                Log.Error(" " + Error.Text);                
            }
            Browser.WaitReadyState();
            Log.Trace(" Enter SMS code(otp)");
            RegistrationHelper.EnterOTR(OTR);
            Log.Trace(" Click Next. Go to username page");
            RegistrationHelper.NextButtonClick();
            Browser.WaitReadyState();
            if (Browser.GetDriver().FindElement(By.XPath("//li")).Displayed)
            {
                IWebElement Error = Browser.GetDriver().FindElement(By.XPath("//li"));
                Log.Error(" " + Error.Text);                
            }
            Log.Trace(" Enter username: u" + CRM);
            RegistrationHelper.EnterUsername("u" + CRM);
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


