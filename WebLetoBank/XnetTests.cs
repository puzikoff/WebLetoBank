using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xNet.Net;
using NUnit.Framework;

namespace WebLetoBank.Tests
{
    [TestFixture]
    public class XnetTests
    {
        [Test]
        public void FirstTest()
        {
            using (var request = new HttpRequest())
            {
                request.UserAgent = HttpHelper.RandomFirefoxUserAgent();
                HttpResponse response = request.Get("google.ru");
                string content = response.ToString();
                Console.WriteLine(content);
            }
        }
    }
}
