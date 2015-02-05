using WebLetoBank.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using NLog;

namespace WebLetoBank.Tests
{    
 
    [TestFixture]
    public class TestBase
    {
        public TestContext TestContext { get; set; }

        public static Logger Log;
        //public const string BaseUrl = "https://mtest.ekassir.com:4443/personalcabinet/api/v1";
        public const string BaseUrl = "https://mtest.ekassir.com:4443/personalcabinet2/api/v1";
        //private const string BaseUrl = "https://sb2.ekassir.com/personalcabinet/api/v1";
        //private const string BaseUrl = "https://mobile.letobank.ru/personalcabinet/api/v1";
        public const string Password = "Qwerty";        
        
        [SetUp]
        public void TestInitialize()
        {
            Browser.Start();
        }

        [TearDown]
        public void TestCleanup()
        {
            Browser.Quit();
        }
    }
    
}
