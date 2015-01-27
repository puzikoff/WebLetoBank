using WebLetoBank.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebLetoBank.Tests
{    
 
    [TestFixture]
    public class TestBase
    {
        public TestContext TestContext { get; set; }
        
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
