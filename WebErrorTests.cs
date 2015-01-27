using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using WebLetoBank.Utilities;
using System;
using System.IO;

namespace WebLetoBank.Tests
{
    [TestFixture]
    public class WebErrorTests : TestBaseFixture
    {
        public static Logger Log;
        private const string BaseUrl = "https://mtest.ekassir.com:4443/personalcabinet/api/v1";
        //private const string BaseUrl = "https://sb2.ekassir.com/personalcabinet/api/v1";
        //private const string BaseUrl = "https://mobile.letobank.ru/personalcabinet/api/v1"; 
        private const string username = "u23340";
        private const string password = "Qwerty";
        private const string contract = "10020328";
        private const string eventId = "2014122610020328_20141226";      
        private string _json;

        [TestFixtureSetUp]
        public void TestInitialize()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace(" Starting Web Driver");
            Browser.Start();                        
            Browser.Navigate(BaseUrl + "/self");
            Log.Trace(" Making log in");
            AuthPageHelper.Authentication(username, password);           
        }

        [Test]
        public void SelfPageTest()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace(" Navigate to authentication page");
            Browser.Navigate(BaseUrl + "/self");
            //Log.Trace(" Making log in");
            //AuthPageHelper.Authentication(username, password);           
            if (!Browser.existsElement(By.XPath("//pre")))
            {
                Log.Error(" No JSON on dashboard page");
                Log.Info(" Making screenshot " + FilesPaths.SelfPageScreen);
                Browser.SaveScreenshot(FilesPaths.SelfPageScreen);
            }
            Log.Trace(" Getting dashboard JSON ");
            _json = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if ((_json.StartsWith("{\"errorCode\"")) | (_json.StartsWith("{\"message\"")))
            {
                Log.Error(" Error on dashboard page");
                Log.Error(_json);
                Log.Info(" Making screenshot: " + FilesPaths.SelfPageScreen);
                Browser.SaveScreenshot(FilesPaths.SelfPageScreen);                           
            }
            Assert.False(_json.StartsWith("{\"errorCode\""));
            Assert.False(_json.StartsWith("{\"message\""));
            Log.Info(" OK");
        }

        [Test]
        public void ContractsPageTest()
        {
            Log.Trace(" Navigate to all user's contracts page");
            Browser.Navigate(BaseUrl + "/banking/contracts");            
            if (!Browser.existsElement(By.XPath("//pre")))
            {
                Log.Error(" No JSON on user's contracts page");
                Log.Info(" Making screenshot: " + FilesPaths.ContractsPageScreen);
                Browser.SaveScreenshot(FilesPaths.ContractsPageScreen);
            }
            Log.Trace(" Getting user's contracts JSON");
            _json = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if ((_json.StartsWith("{\"errorCode\"")) | (_json.StartsWith("{\"message\"")))
            {
                Log.Error(" Error on user's contracts page");
                Log.Error( _json);
                Log.Info(" Making screenshot: " + FilesPaths.ContractsPageScreen);
                Browser.SaveScreenshot(FilesPaths.ContractsPageScreen);                             
            }
            Assert.False(_json.StartsWith("{\"errorCode\""));
            Assert.False(_json.StartsWith("{\"message\""));
            Log.Info(" OK");
        }

        [Test]
        public void ContractPageTest()
        {
            Log.Trace(" Navigate to credit contract");
            Browser.Navigate(BaseUrl + "/banking/contracts/" + contract);            
            if (!Browser.existsElement(By.XPath("//pre")))
            {
                Log.Error(" No JSON on credit contract page");
                Log.Info(" Making screenshot: " + FilesPaths.ContractPageScreen);
                Browser.SaveScreenshot(FilesPaths.ContractPageScreen);
            }
            Log.Trace(" Getting credit contract JSON: contractNumber " + contract);
            _json = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if ((_json.StartsWith("{\"errorCode\"")) | (_json.StartsWith("{\"message\"")))
            {
                Log.Error(" Error on credit contract page");
                Log.Error(_json);
                Log.Info(" Making screenshot: " + FilesPaths.ContractPageScreen);
                Browser.SaveScreenshot(FilesPaths.ContractPageScreen);               
               
            }
            Assert.False(_json.StartsWith("{\"errorCode\""));
            Assert.False(_json.StartsWith("{\"message\""));
            Log.Info(" OK");
        }

        [Test]
        public void PaymentsSchedulePageTest()
        {
            Log.Trace(" Navigate to credit's payments schedule");
            Browser.Navigate(BaseUrl + "/banking/contracts/" + contract + "/paymentsschedule");            
            if (!Browser.existsElement(By.XPath("//pre")))
            {
                Log.Error(" No JSON on credit's payments schedule page");
                Log.Info(" Making screenshot: " + FilesPaths.PaymentsSchedulePageScreen);
                Browser.SaveScreenshot(FilesPaths.PaymentsSchedulePageScreen);
            }
            Log.Trace(" Getting credit's payments schedule JSON");
            _json = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if ((_json.StartsWith("{\"errorCode\"")) | (_json.StartsWith("{\"message\"")))
            {
                Log.Error(" Error on credit's payments schedule page");
                Log.Error(_json);
                Log.Info(" Making screenshot: " + FilesPaths.PaymentsSchedulePageScreen);
                Browser.SaveScreenshot(FilesPaths.PaymentsSchedulePageScreen);                               
            }
            Assert.False(_json.StartsWith("{\"errorCode\""));
            Assert.False(_json.StartsWith("{\"message\""));
            Log.Info(" OK");
        }

        [Test]
        public void ContractServicesPageTest()
        {
            Log.Trace(" Navigate to contract page and expand services ");
            Browser.Navigate(BaseUrl + "/banking/contracts/" + contract + "?expand=services");            
            if (!Browser.existsElement(By.XPath("//pre")))
            {
                Log.Error(" No JSON on contracts services page");
                Log.Info(" Making scrennshot:");
                Browser.SaveScreenshot(FilesPaths.ContractServicesScreen);
            }
            Log.Trace(" Getting JSON /banking/contracts/" + contract + "?expand=services");            
            _json = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if ((_json.StartsWith("{\"errorCode\"")) | (_json.StartsWith("{\"message\"")))
            {
                Log.Error(" Error on contracts services page");
                Log.Error(_json);
                Log.Error(" Making screenshot:");
                Browser.SaveScreenshot(FilesPaths.ContractServicesScreen);
            }                     
            Assert.False(_json.StartsWith("{\"errorCode\""));
            Assert.False(_json.StartsWith("{\"message\""));
            Log.Info(" OK");
        }

        [Test]
        public void CommonTimelinePageTest()
        {
            Log.Trace(" Navigate to common timeline page ");
            Browser.Navigate(BaseUrl + "/timeline");            
            if (!Browser.existsElement(By.XPath("//pre")))
            {
                Log.Error(" No JSON on common timeline page");
                Log.Info(" Making screenshot: " + FilesPaths.TimelinePageScreen);
                Browser.SaveScreenshot(FilesPaths.TimelinePageScreen);
            }
            Log.Trace(" Getting common timeline JSON");
            _json = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if ((_json.StartsWith("{\"errorCode\"")) | (_json.StartsWith("{\"message\"")))
            {
                Log.Error(" Error on common timeline page");
                Log.Error(_json);
                Log.Info(" Making screenshot: " + FilesPaths.TimelinePageScreen);
                Browser.SaveScreenshot(FilesPaths.TimelinePageScreen);              
            }
            Assert.False(_json.StartsWith("{\"errorCode\""));
            Assert.False(_json.StartsWith("{\"message\""));
            Log.Info(" OK");
        }

        [Test]
        public void CommonTimelineEventPageTest()
        {
            Log.Trace(" Navigate to common timeline event page ");
            Browser.Navigate(BaseUrl + "/timeline/" + eventId);            
            if (!Browser.existsElement(By.XPath("//pre")))
            {
                Log.Error(" No JSON on common timeline event page");
                Log.Info(" Making screenshot: " + FilesPaths.TimelineEventPageScreen);
                Browser.SaveScreenshot(FilesPaths.TimelineEventPageScreen);
            }
            Log.Trace(" Getting common timeline event JSON");
            _json = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if ((_json.StartsWith("{\"errorCode\"")) | (_json.StartsWith("{\"message\"")))
            {
                Log.Error(" Error on common timeline event page");
                Log.Error(_json);
                Log.Info(" Making screenshot: " + FilesPaths.TimelineEventPageScreen);
                Browser.SaveScreenshot(FilesPaths.TimelineEventPageScreen);               
            }
            Assert.False(_json.StartsWith("{\"errorCode\""));
            Assert.False(_json.StartsWith("{\"message\""));
            Log.Info(" OK");
        }
                
        [Test]
        public void ContractTimelinePageTest()
        {
            Log.Trace(" Navigate to contract timeline page ");
            Browser.Navigate(BaseUrl + "/banking/contracts/" + contract + "/timeline");            
            if (!Browser.existsElement(By.XPath("//pre")))
            {
                Log.Error(" No JSON on contract timeline page");
                Log.Info(" Making screenshot: " + FilesPaths.ContractTimelineScreen);
                Browser.SaveScreenshot(FilesPaths.ContractTimelineScreen);
            }
            Log.Trace(" Getting JSON /banking/contracts/" + contract + "/timeline");
            _json = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if ((_json.StartsWith("{\"errorCode\"")) | (_json.StartsWith("{\"message\"")))
            {
                Log.Error(" Error on contract timeline page");
                Log.Error(_json);
                Log.Info(" Making screenshot: " + FilesPaths.ContractTimelineScreen);
                Browser.SaveScreenshot(FilesPaths.ContractTimelineScreen);              
            }
            Assert.False(_json.StartsWith("{\"errorCode\""));
            Assert.False(_json.StartsWith("{\"message\""));
            Log.Info(" OK");
        }

        [Test]
        public void ContractTimelineEventPageTest()
        {
            Log.Trace(" Navigate to contract timeline event page ");
            Browser.Navigate(BaseUrl + "/banking/contracts/" + contract + "/timeline/" + eventId);            
            if ((!Browser.existsElement(By.XPath("//pre"))))
            {
                Log.Error(" No JSON on contract timeline event page");
                Log.Info(" Making screenshot: " + FilesPaths.ContractTimelineEventScreen);
                Browser.SaveScreenshot(FilesPaths.ContractTimelineEventScreen);             
            }
            Log.Trace(" Getting contract timeline event JSON");
            _json = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if ((_json.StartsWith("{\"errorCode\"")) | (_json.StartsWith("{\"message\"")))
            {
                Log.Error(" Error on contract timeline event page");
                Log.Error(_json);              
                Log.Info(" Making screenshot: " + FilesPaths.ContractTimelineEventScreen);
                Browser.SaveScreenshot(FilesPaths.ContractTimelineEventScreen);              
            }                       
            Assert.False(_json.StartsWith("{\"errorCode\""));
            Assert.False(_json.StartsWith("{\"message\""));
            Log.Info(" OK");
        }                
    }
}

