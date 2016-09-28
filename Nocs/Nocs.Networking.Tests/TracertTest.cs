using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nocs.Networking.ICMP;
using Nocs.Networking.Model;

namespace Nocs.Networking.Tests
{
    [TestClass]
    public class TracertTest
    {
        [TestMethod]
        public void IsHopCorrect()
        {
            Tracert tracert = new Tracert();
            HostInformation host = tracert.GetHop(new HostInformation() {Address = IPAddress.Parse("127.0.0.1")}, 1);
            Assert.AreEqual(host.Address, IPAddress.Parse("127.0.0.1"));
        }
    }
}
