using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Nocs.Networking.ICMP;
using Nocs.Networking.Model;

namespace Pinger
{
    class Program
    {
        static void Main(string[] args)
        {
            HostInformation host = new HostInformation() { Address = IPAddress.Parse("8.8.8.8"), Hostname = null };
            Ping pinger=new Ping();
            pinger.Host = host;
            pinger.Send(1,120,2);
            foreach (PingReplyData prd in pinger.Messages.ToList())
            {
                Console.WriteLine(prd.ToString());
            }
            Console.ReadLine();
        }
    }
}
