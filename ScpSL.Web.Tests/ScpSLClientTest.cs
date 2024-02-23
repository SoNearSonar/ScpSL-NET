using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScpSL.Web.Models;
using System;
using System.Net.Http;

namespace ScpSL.Web.Tests
{
    [TestClass]
    public class ScpSLClientTest
    {
        [TestMethod]
        public void TestGetIPAddress_ReturnsIPAddress()
        {
            ScpSLClient client = new ScpSLClient();
            string IPAddress = client.GetIPAddress().Result;
            Assert.IsNotNull(IPAddress);
        }

        [TestMethod]
        public void TestGetServerInfo_NoApiKey_ReturnsException()
        {
            ScpSLClient client = new ScpSLClient()
            {
                ID = 1,
                AddIsOnline = true,
                AddPastebin = true,
                AddVersion = true
            };

            try
            {
                ServerInfo servers = client.GetServerInfo().Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }

        [TestMethod]
        public void TestGetFullServerInfo_NoApiKey_ReturnsException()
        {
            ScpSLClient client = new ScpSLClient()
            {
                ID = 1,
                AddIsOnline = true,
                AddPastebin = true,
                AddVersion = true
            };

            try
            {
                FullServerInfo servers = client.GetFullServerInfo().Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }

        [TestMethod]
        public void TestGet3rdPartyServerInfo_NoApiKey_ReturnsException()
        {
            ScpSLClient client = new ScpSLClient()
            {
                ID = 1,
                AddIsOnline = true,
                AddPastebin = true,
                AddVersion = true
            };

            try
            {
                ServerInfo servers = client.Get3rdPartyServerInfo("https://api.scpsecretlab.pl/serverinfo").Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }
    }
}
