using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocs.Networking.Model;

namespace Nocs.Networking.ICMP
{
    public class Tracert
    {
        List<HostInformation> _hops = new List<HostInformation>();
        Nocs.Networking.ICMP.Ping _pinger = new Ping();

        public List<HostInformation> Hops
        {
            get; set;
        }

        public HostInformation GetHop(HostInformation target, int n, int timeout=10000)
        {
            _pinger.Host = target;
            _pinger.Send(n,timeout);
            List<PingReplyData> messages = _pinger.Messages.ToList();
            return new HostInformation() {Address = messages[(n>messages.Count)?n:messages.Count-1].Address, Hostname = String.Empty};
        }

    }
}
