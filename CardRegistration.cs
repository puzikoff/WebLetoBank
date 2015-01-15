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
        public static Logger Log;
        private const string BaseUrl = "https://mtest.ekassir.com:4443/personalcabinet/api/v1";
        //private const string BaseUrl = "https://sb2.ekassir.com/personalcabinet/api/v1";
        //private const string BaseUrl = "https://mobile.letobank.ru/personalcabinet/api/v1";       
        private const string Password = "Qwerty";        
        private const string AccessCode = "123456";
        private const string OTR = "334500";
        private const string ProtectCode = "1234";        

        [Test]

        [TestCase("5596623", "4059920012022951")]
        [TestCase("5589895", "4059920012067444")]
        [TestCase("5584009", "4059920012061397")]
        [TestCase("5799519", "4059920012345261")]
        [TestCase("5898964", "4059920012521291")]
        [TestCase("6006507", "4059920012514262")]
        [TestCase("6209928", "4059920013388765")]
        [TestCase("55956", "4059920012243789")]

        public void MtestCardRegistrationTest(string MtestUsername, string MtestCardNumber)
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace(" Navigate to authentication page");
            Browser.Navigate(BaseUrl + "/self");
            Log.Trace(" Filling authentication fields");
            AuthPageHelper.FillAuthenticationFields("u" + MtestUsername, Password);
            Log.Trace(" Click Registration Button ");
            AuthPageHelper.RegistrationButtonClick();
            Log.Trace(" Agree with license terms");
            RegistrationHelper.AcceptTermsButtonClick();
            Log.Trace(" Choose registration with account");
            RegistrationHelper.ChooseRegistrationType("card");
            Log.Trace(" Enter Account Number and access code");
            RegistrationHelper.EnterCardCredentials(MtestCardNumber, AccessCode);
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
            RegistrationHelper.EnterUsername("u" + MtestUsername);
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
