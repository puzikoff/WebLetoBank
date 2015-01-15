using WebLetoBank.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebLetoBank.Tests
{
    [TestFixture]
    public class TestBaseFixture
    {
        public TestContext TestContext { get; set; }

        [TestFixtureSetUp]
        public void TestInitialize()
        {
            Browser.Start();
        }

        [TestFixtureTearDown]
        public void TestCleanup()
        {
            Browser.Quit();
        }
    }
}
