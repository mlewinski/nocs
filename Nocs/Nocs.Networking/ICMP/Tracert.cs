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
        Nocs.Networking.ICMP.Ping _pinger = new Ping();
        private Route _route;

        public Route Route => _route;

        public HostInformation this[int index]
        {
            get
            {
                return _route[index];
            }
        }

        public Tracert()
        {
             _route = new Route();
        }

        public HostInformation GetHop(HostInformation target, int n, int timeout=10000)
        {
            _pinger.Host = target;
            _pinger.AddReplyToMessageQueue(n,timeout);
            List<PingReplyData> messages = _pinger.Messages.ToList();
            return new HostInformation() {Address = messages[(n>messages.Count)?n:messages.Count-1].Address, Hostname = String.Empty};
        }

        public void GetRoute(HostInformation target, int maxTtl, int timeout = 10000)
        {
            _pinger.Host = target;
            int n = 1;
            PingReplyData reply = _pinger.Send(n,timeout);
            while (!Equals(reply.Address, target.Address))
            {
                n++;
                _route.AddHop(new HostInformation() {Address = reply.Address});
                if (n > maxTtl) throw new ArgumentOutOfRangeException(nameof(maxTtl), "TTL exceeded maximum TTL given");
                reply = _pinger.Send(n, timeout);
            }
        }

    }
}
