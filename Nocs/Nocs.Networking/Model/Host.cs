using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nocs.Networking.Model
{
    public class Host
    {
        private HostInformation info;
        public IPAddress Address { get { return info.Address; } set { info.Address = value; } }
        public string Hostname { get { return info.Hostname; } set { info.Hostname = value; } }
        public string Description;
        public Route NetworkRoute;

        public Host()
        {
            info = new HostInformation
            {
                Address = null,
                Hostname = String.Empty
            };
        }

        public Host(IPAddress address) : this()
        {
            info.Address = address;
        }

        public Host(IPAddress address, string hostname) : this(address)
        {
            info.Hostname = hostname;
        }
    }
}
