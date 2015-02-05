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
        private const string anotherUserContract = "13954109";        
        private string _json;
        
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
