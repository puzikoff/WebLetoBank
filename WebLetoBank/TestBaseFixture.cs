using WebLetoBank.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using NLog;

namespace WebLetoBank.Tests
{
    [TestFixture]
    public class TestBaseFixture
    {
        public static Logger Log;
        //public const string BaseUrl = "https://mtest.ekassir.com:4443/personalcabinet/api/v1";      //MTEST 
        //public const string BaseUrl = "https://mtest.ekassir.com:4443/personalcabinet2/api/v1";   //MTEST2
        public const string BaseUrl = "https://sb2.ekassir.com/personalcabinet/api/v1";           //SB
        //public const string BaseUrl = "https://mobile.letobank.ru/personalcabinet/api/v1";        //PROD
        //public const string BaseUrl = "https://mobile.letobank.ru/personalcabinet2/api/v1";       //PROD2
        //private const string username = "u23340";                                                   //MTEST, MTEST2 username
        //private const string password = "Qwerty";                                                   //MTEST, MTEST2 password
        private const string username = "testuser";                                               //SB username
        private const string password = "qwe123";                                                 //SB password
        //public const string contract = "10020328";                                                  //MTEST, MTEST2 contract
        //public const string eventId = "2014122610020328_20141226";                                  //MTEST, MTEST2 eventId
        public const string contract = "loan4";                                                   //SB contract
        public const string eventId = "20140706loan4_2";                                          //SB eventId     

        public TestContext TestContext { get; set; }

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
           

        [TestFixtureTearDown]
        public void TestCleanup()
        {
            Browser.Quit();
        }
    }
}
