using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using WebLetoBank.Utilities;

namespace WebLetoBank.Tests
{
    [TestFixture]
 
    public class SbErorrsTests : TestBase
    {
        public static Logger Log;
        private const string BaseUrl = "https://sb2.ekassir.com/personalcabinet/api/v1";
        private const string SbUsername = "testuser";
        private const string SbPassword = "password";
        private const string SelfScreen = @"SBself.jpg";
        private const string ContractsScreen = @"SBcontracts.jpg";
        private const string ContractScreen = @"SBcontract.jpg";
        private const string ContractPaymentsscheduleScreen = @"SBcontractschedule.jpg";
        private const string ContractServicesScreen = @"SBcontractservices.jpg";
        private const string TimelineScreen = @"SBtimeline.jpg";
        private const string ContractTimelineScreen = @"SBcontracttimeline.jpg";
        private string _sbJson;

        [Test]
        public void _01_SelfPageTest()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace("SB: Navigate to authentication page");
            Browser.Navigate(BaseUrl + "/self");
            Log.Trace("SB: Making log in");
            AuthPageHelper.Authentication(SbUsername, SbPassword);
            Log.Trace("SB: Getting JSON /self");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("SB: Making screenshot in case of error");
                Browser.SaveScreenshot(SelfScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }

        [Test]
        public void ContractsPageTest()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace("SB: Navigate to contracts");
            Browser.Navigate(BaseUrl + "/banking/contracts");
            Log.Trace("SB: Getting JSON /banking/contracts");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("SB: Making screenshot in case of error");
                Browser.SaveScreenshot(ContractsScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }

        [Test]
        public void ContractPageTest()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace("SB: Navigate to credit \"Тест кредит 6\"");
            Browser.Navigate(BaseUrl + "/banking/contracts/loan4");
            Log.Trace("SB: Getting JSON /banking/contracts/loan4");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("SB: Making screenshot in case of error");
                Browser.SaveScreenshot(ContractScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }

        [Test]
        public void PaymentsSchedulePageTest()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace("SB: Navigate to credit's paymentsschedule ");
            Browser.Navigate(BaseUrl + "/banking/contracts/loan4/paymentsschedule");
            Log.Trace("SB: Getting JSON /banking/contracts/loan4/paymentsschedule");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("SB: Making screenshot in case of error");
                Browser.SaveScreenshot(ContractPaymentsscheduleScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }

        [Test]
        public void ContractServicesPageTest()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace("SB: Navigate to contract services ");
            Browser.Navigate(BaseUrl + "/banking/contracts/loan4/services");
            Log.Trace("SB: Getting JSON /banking/contracts/loan4/services");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("SB: Making screenshot in case of error /banking/contracts/loan4/services");
                Browser.SaveScreenshot(ContractServicesScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }

        [Test]
        public void CommonTimelinePageTest()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace("SB: Navigate to timeline ");
            Browser.Navigate(BaseUrl + "/timeline");
            Log.Trace("SB: Getting JSON /timeline");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("SB: Making screenshot in case of error /timeline");
                Browser.SaveScreenshot(TimelineScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }

        [Test]
        public void ContractTimelinePageTest()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace("SB: Navigate to contract timeline ");
            Browser.Navigate(BaseUrl + "/banking/contracts/loan4/timeline");
            Log.Trace("SB: Getting JSON /banking/contracts/loan4/timeline");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("SB: Making screenshot in case of error /banking/contracts/loan4/timeline");
                Browser.SaveScreenshot(ContractTimelineScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }
    }
}
