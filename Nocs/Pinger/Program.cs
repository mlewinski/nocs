using System;
using System.Net;
using Nocs.Networking.ICMP;
using Nocs.Networking.Model;

namespace Nocs.Networking.Tests
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
