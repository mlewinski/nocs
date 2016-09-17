using System;
using System.Collections.Generic;
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
            ping.Send(1, 1);
            Assert.AreNotEqual(ping.Messages.ToList().Count, 0);
        }

        [TestMethod]
        public void IsReplyDataNotEmpty()
        {
            Ping ping = new Ping();
            HostInformation host = new HostInformation() { Address = IPAddress.Parse("127.0.0.1"), Hostname = String.Empty };
            ping.Host = host;
            ping.Send(1, 1);
            PingReplyData rpd = ping.Messages.ToList()[0];
            Assert.IsNotNull(rpd);
            Assert.IsNotNull(rpd.Address);
            Assert.IsNotNull(rpd.BufferSize);
            Assert.IsNotNull(rpd.DontFragment);
            Assert.IsNotNull(rpd.RoundTripTime);
            Assert.IsNotNull(rpd.Status);
            Assert.IsNotNull(rpd.Timeout);
            Assert.IsNotNull(rpd.Ttl);
        }

        [TestMethod]
        public void IsHostinformationFilledWithDefaultData()
        {
            Ping ping = new Ping();
            Assert.AreEqual(ping.Host.Hostname, "localhost");
            Assert.AreEqual(ping.Host.Address, IPAddress.Parse("127.0.0.1"));
        }

        [TestMethod]
        public void IsReplyDataCorrect()
        {
            Ping ping = new Ping();
            HostInformation host = new HostInformation() { Address = IPAddress.Parse("127.0.0.1"), Hostname = String.Empty };
            ping.Host = host;
            ping.Send(1, 1);
            PingReplyData rpd = ping.Messages.ToList()[0];
            Assert.AreEqual(rpd.Address, host.Address);
            Assert.AreEqual(rpd.Timeout, 1);
        }
    }
}
