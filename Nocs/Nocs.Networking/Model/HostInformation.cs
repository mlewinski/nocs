using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nocs.Networking.Model
{
    public class HostInformation
    {
        public IPAddress Address = IPAddress.Parse("127.0.0.1");
        public string Hostname = "localhost";
    }
}
