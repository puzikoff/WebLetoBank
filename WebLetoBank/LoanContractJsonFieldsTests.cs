using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using WebLetoBank.Utilities;
using System;
using System.IO;
using Newtonsoft.Json.Linq;


namespace WebLetoBank.Tests
{
    [TestFixture]
    public class LoanContractJsonFieldsTests : TestBaseFixture
    {
        private const string contract = "10020328";
        string contractNumberToken;
        private string _json;               

        [Test]
        public void LoanContractJsonFieldsTest()
        {
            Log.Trace(" Navigate to credit contract");
            //Browser.Navigate(BaseUrl + "/banking/contracts/" + contract);
            Browser.Navigate(BaseUrl + "/banking/contracts/");
            Assert.True(Browser.existsElement(By.XPath("//pre")));           
            _json = Browser.GetDriver().FindElement(By.XPath("//pre")).Text;
            Assert.False((_json.StartsWith("{\"errorCode\"")) | (_json.StartsWith("{\"message\"")));
            Log.Info(" Parsing JSON");
            JObject o = JObject.Parse(_json);
            contractNumberToken = (string)o.SelectToken("loanContracts");
            Assert.True(contractNumberToken !=  null);
            Log.Info(" contractNumber: " + contractNumberToken);
            Log.Info(" OK");
        }
    }
}
