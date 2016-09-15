using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nocs.Networking.ICMP;
using Nocs.Networking.Model;

namespace Nocs.Networking.Tests
{
    [TestClass]
    public class PingTest
    {
        [TestMethod]
        public void IsMessageQueueNotEmpty()
        {
            Ping ping = new Ping();
            HostInformation host = new HostInformation(){Address = IPAddress.Parse("127.0.0.1"), Hostname = String.Empty};
            ping.Host = host;
            ping.Send(1, 1, 1);
            Assert.AreNotEqual(ping.Messages.ToList().Count, 0);
        }
    }
}
