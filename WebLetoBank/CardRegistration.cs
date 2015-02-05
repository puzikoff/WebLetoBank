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
    public class CardRegistration : TestBase
    {
        private const string AccessCode = "123456";
        private const string OTR = "334500";
        private const string ProtectCode = "1234";        

        [Test]

       // [TestCase("55956", "4059920012243789")]

        public void CardRegistrationTest(string CRM, string CardNumber)
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
            RegistrationHelper.ChooseRegistrationType("card");
            Log.Trace(" Enter Account Number and access code");
            RegistrationHelper.EnterCardCredentials(CardNumber, AccessCode);
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
            Log.Trace(" Enter username");
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
