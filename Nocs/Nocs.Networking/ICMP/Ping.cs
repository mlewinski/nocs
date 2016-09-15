using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocs.Networking.Model;

namespace Nocs.Networking.ICMP
{
    public class Ping
    {
        public MessageQueue<string> Messages = new MessageQueue<string>();
        public HostInformation Host = new HostInformation();
    }
}
