using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScpSL.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ScpSL.Web.Tests
{
    [TestClass]
    public class ScpSLClientTest
    {
        private readonly string _apiKey = "";

        [TestMethod]
        public void TestGetIPAddress_ReturnsIPAddress()
        {
            ScpSLClient client = new ScpSLClient();
            string ipAddress = client.GetIPAddress().Result;
            Assert.IsNotNull(ipAddress);
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
            ScpSLClient client = new ScpSLClient();

            try
            {
                List<FullServerInfo> servers = client.GetFullServerInfo().Result;
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


        [TestMethod]
        public void TestGet3rdPartyServerInfo_WrongURL_ReturnsError()
        {
            ScpSLClient client = new ScpSLClient();

            try
            {
                ServerInfo servers = client.Get3rdPartyServerInfo("https://google.com").Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }

        [TestMethod]
        public void TestGet3rdPartyFullServerInfo_WrongURL_ReturnsError()
        {
            ScpSLClient client = new ScpSLClient();

            try
            {
                List<FullServerInfo> servers = client.Get3rdPartyFullServerInfo("https://google.com").Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }

        [TestMethod]
        public void TestGetFullServerInfo_ApiKey_ReturnsFullServerInfo()
        {
            ScpSLClient client = new ScpSLClient(_apiKey);

            List<FullServerInfo> servers = client.GetFullServerInfo().Result;
            Assert.IsNotNull(servers);
            Assert.IsTrue(servers.Count != 0);
            Assert.IsTrue(servers[0].AccountId != 0);
        }

        [TestMethod]
        public void TestGetFullServerInfo_ApiKey_AddedSettings_ReturnsFullServerInfo()
        {
            ScpSLClient client = new ScpSLClient(_apiKey);

            List<FullServerInfo> servers = client.GetFullServerInfo(true).Result;
            Assert.IsNotNull(servers);
            Assert.IsTrue(servers.Count != 0);
            Assert.IsTrue(servers[0].AccountId == 0);
        }

        [TestMethod]
        public void TestGet3rdPartyFullServerInfo_ReturnsFullServerInfo()
        {
            ScpSLClient client = new ScpSLClient();

            List<FullServerInfo> servers = client.Get3rdPartyFullServerInfo("https://api.scpsecretlab.pl/lobbylist").Result;
            Assert.IsNotNull(servers);
            Assert.IsTrue(servers.Count != 0);
        }
    }
}
