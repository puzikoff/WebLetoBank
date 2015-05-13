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
        //public const string BaseUrl = "https://sb2.ekassir.com/personalcabinet/api/v1";           //SB
        //public const string BaseUrl = "https://mobile.letobank.ru/personalcabinet/api/v1";        //PROD
        public const string BaseUrl = "https://mobile.letobank.ru/personalcabinet2/api/v1";       //PROD2
        //private const string username = "u5869869";                                                   //MTEST, MTEST2 username
        //private const string password = "Qwerty";                                                   //MTEST, MTEST2 password
        private const string username = "karmanoviv";                                                   //PROD, PROD2 username
        private const string password = "qwe123";                                                   //PROD, PROD2 password
        //private const string username = "testuser";                                               //SB username
        //private const string password = "qwe123";                                                 //SB password
        //public const string contractLoan = "13907813";                                                  //MTEST, MTEST2 loan contract
        //public const string contractCard = "13493048";                                                  //MTEST, MTEST2 card contract
        //public const string contractDeposit = "14102492";                                                  //MTEST, MTEST2 deposit contract
        //public const string eventId = "2015030813907813_20150308";                                  //MTEST, MTEST2 eventId
        //public const string contract = "loan4";                                                   //SB contract
        //public const string eventId = "20140706loan4_2";                                          //SB eventId     
        public const string contractCard = "13493048";                                                //PROD, PROD2 card contract
        public const string contractLoan = "13907813";                                                //PROD, PROD2 loan contract
        public const string contractDeposit = "14154321";                                                //PROD, PROD2 deposit contract
        public const string eventId = "2015031913493048_20150319_PS012950_932985";                                  //PROD, PROD2 eventId
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
