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
    public class MtestCardRegistration : TestBase
    {
        public static Logger Log;
        private const string BaseUrl = "https://mtest.ekassir.com:4443/personalcabinet/api/v1";
        //private const string BaseUrl = "https://sb2.ekassir.com/personalcabinet/api/v1";
        //private const string BaseUrl = "https://mobile.letobank.ru/personalcabinet/api/v1";
        private const string MtestUsername = "u5128307";
        private const string MtestPassword = "Qwerty";
        private const string MtestCardNumber = "4059920012220126";
        private const string MtestAccessCode = "123456";
        private const string MtestOTR = "334500";
        private const string MtestProtectCode = "1234";
        private const string SbIncorrectCardNumber = "555555555555";

        [Test]
        public void MtestCardRegistrationTest()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace("MTEST: Navigate to authentication page");
            Browser.Navigate(BaseUrl + "/self");
            Log.Trace("MTEST: Filling authentication fields");
            AuthPageHelper.FillAuthenticationFields(MtestUsername, MtestPassword);
            Log.Trace("MTEST: Click Registration Button ");
            AuthPageHelper.RegistrationButtonClick();
            Log.Trace("MTEST: Agree with license terms");
            RegistrationHelper.AcceptTermsButtonClick();
            Log.Trace("MTEST: Choose registration with account");
            RegistrationHelper.ChooseRegistrationType("card");
            Log.Trace("MTEST: Enter Account Number and access code");
            RegistrationHelper.EnterCardCredentials(MtestCardNumber, MtestAccessCode);
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
            Log.Trace("MTEST: Enter username");
            RegistrationHelper.EnterUsername(MtestUsername);
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
    }
}
