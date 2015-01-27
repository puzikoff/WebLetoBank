using WebLetoBank.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebLetoBank.Tests
{
    [TestFixture]
    public class TestBaseFixture
    {
        public TestContext TestContext { get; set; }
           

        [TestFixtureTearDown]
        public void TestCleanup()
        {
            Browser.Quit();
        }
    }
}
