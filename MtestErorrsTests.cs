using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using WebLetoBank.Utilities;

namespace WebLetoBank.Tests
{
    [TestFixture]
    public class MtestErorrsTests : TestBase
    {
        public static Logger Log;
        private const string BaseUrl = "https://mtest.ekassir.com:4443/personalcabinet/api/v1";
        private const string MtestUsername = "u266417";
        private const string MtestPassword = "Qwerty";
        private const string Contract = "10524623";
        private const string SelfScreen = @"MTESTself.jpg";
        private const string ContractsScreen = @"MTESTcontracts.jpg";
        private const string ContractScreen = @"MTESTcontract.jpg";
        private const string ContractPaymentsscheduleScreen = @"MTESTcontractschedule.jpg";
        private const string ContractServicesScreen = @"MTESTcontractservices.jpg";
        private const string TimelineScreen = @"MTESTtimeline.jpg";
        private const string ContractTimelineScreen = @"MTESTcontracttimeline.jpg";
        private string _sbJson;

        [Test]
        public void _01_SelfPageTest()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace("MTEST: Navigate to authentication page");
            Browser.Navigate(BaseUrl + "/self");
            Log.Trace("MTEST: Making log in");
            AuthPageHelper.Authentication(MtestUsername, MtestPassword);
            Log.Trace("MTEST: Getting JSON /self");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("MTEST: Making screenshot in case of error /self");
                Browser.SaveScreenshot(SelfScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }

        [Test]
        public void ContractsPageTest()
        {
            Log.Trace("MTEST: Navigate to contracts");
            Browser.Navigate(BaseUrl + "/banking/contracts");
            Log.Trace("MTEST: Getting JSON /banking/contracts");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("MTEST: Making screenshot in case of error /banking/contracts");
                Browser.SaveScreenshot(ContractsScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));

        }

        [Test]
        public void ContractPageTest()
        {
            Log.Trace("MTEST: Navigate to credit");
            Browser.Navigate(BaseUrl + "/banking/contracts/" + Contract);
            Log.Trace("MTEST: Getting JSON /banking/contracts/" + Contract);
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("MTEST: Making screenshot in case of error /banking/contracts/" + Contract);
                Browser.SaveScreenshot(ContractScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }

        [Test]
        public void PaymentsSchedulePageTest()
        {
            Log.Trace("MTEST: Navigate to credit's " + Contract + "paymentsschedule ");
            Browser.Navigate(BaseUrl + "/banking/contracts/" + Contract + "/paymentsschedule");
            Log.Trace("MTEST: Getting JSON /banking/contracts/" + Contract + "/paymentsschedule");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("MTEST: Making screenshot in case of error/banking/contracts/" + Contract +
                          "/paymentsschedule");
                Browser.SaveScreenshot(ContractPaymentsscheduleScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }
  
        [Test]
        public void ContractServicesPageTest()
        {
            Log.Trace("MTEST: Navigate to contract services ");
            Browser.Navigate(BaseUrl + "/banking/contracts/" + Contract + "/services");
            Log.Trace("MTEST: Getting JSON /banking/contracts/" + Contract + "/services");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("MTEST: Making screenshot in case of error /banking/contracts/" + Contract + "/services");
                Browser.SaveScreenshot(ContractServicesScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }

        [Test]
        public void CommonTimelinePageTest()
        {
            Log.Trace("MTEST: Navigate to timeline ");
            Browser.Navigate(BaseUrl + "/timeline");
            Log.Trace("MTEST: Getting JSON /timeline");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("MTEST: Making screenshot in case of error /timeline");
                Browser.SaveScreenshot(TimelineScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }

        [Test]
        public void ContractTimelinePageTest()
        {
            Log.Trace("MTEST: Navigate to contract timeline ");
            Browser.Navigate(BaseUrl + "/banking/contracts/" + Contract + "/timeline");
            Log.Trace("MTEST: Getting JSON /banking/contracts/" + Contract + "/timeline");
            _sbJson = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (_sbJson.StartsWith("{\"errorCode\""))
            {
                Log.Error("MTEST: Making screenshot in case of error /banking/contracts/" + Contract + "/timeline");
                Browser.SaveScreenshot(ContractTimelineScreen);
            }
            Assert.False(_sbJson.StartsWith("{\"errorCode\""));
        }
    }
}

