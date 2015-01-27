using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using WebLetoBank.Utilities;
using System;
using System.IO;

namespace WebLetoBank.Tests
{
    [TestFixture]
    public class SecurityTests : TestBaseFixture
    {
        public static Logger Log;
        private const string BaseUrl = "https://mtest.ekassir.com:4443/personalcabinet/api/v1";
        //private const string BaseUrl = "https://sb2.ekassir.com/personalcabinet/api/v1";
        //private const string BaseUrl = "https://mobile.letobank.ru/personalcabinet/api/v1"; 
        private const string username = "u23340";
        private const string password = "Qwerty";
        private const string anotherUserContract = "10020328";        
        private string _json;

        [TestFixtureSetUp]
        public void TestInitialize()
        {
            Log = LogManager.GetCurrentClassLogger();
            Log.Trace(" Starting Web Driver");
            Browser.Start();
            Browser.Navigate(BaseUrl + "/self");
            Log.Trace(" Making log in with credentials: " + username + "/" + password);
            AuthPageHelper.Authentication(username, password);
        }

        [Test]
        public void AnotherUserContractTest()
        {
            Log.Trace(" Navigate to another user credit contract");
            Browser.Navigate(BaseUrl + "/banking/contracts/" + anotherUserContract);            
            if (!Browser.existsElement(By.XPath("//pre")))
            {
                Log.Error(" No JSON");
                Log.Info(" Making screenshot: \\" + FilesPaths.AnotherUserContractPageScreen);
                Browser.SaveScreenshot(FilesPaths.AnotherUserContractPageScreen);
            }            
            _json = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            if (!(_json.StartsWith("{\"errorCode\":0,\"message\":\"Requested contract with id=" + anotherUserContract + " does not belong to the client")))
            {
                Log.Error(_json);
                Log.Info(" Making screenshot: \\" + FilesPaths.AnotherUserContractPageScreen);
                Browser.SaveScreenshot(FilesPaths.AnotherUserContractPageScreen);                              
            }
            Assert.True(_json.StartsWith("{\"errorCode\":0,\"message\":\"Requested contract with id=" + anotherUserContract + " does not belong to the client"));
            Log.Info(" OK");           
          
        }
    }
}
