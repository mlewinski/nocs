using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Nocs.Networking.Model;

namespace Nocs.Networking.ICMP
{
    public class Ping
    {
        public MessageQueue<PingReplyData> Messages = new MessageQueue<PingReplyData>();
        public HostInformation Host = new HostInformation();
        System.Net.NetworkInformation.Ping _pinger = new System.Net.NetworkInformation.Ping();

        public void Send(int ttl, int timeout, int count)
        {
            PingOptions pingOptions = new PingOptions(ttl,false);
            byte[] buffer;
            PingReply reply;
            for (int i = 0; i < count; i++)
            {
                buffer = Encoding.ASCII.GetBytes(i.ToString());
                reply = _pinger.Send(Host.Address, timeout, buffer, pingOptions);
                if (reply != null)
                {
                    PingReplyData replyData = new PingReplyData();                    
                        replyData.Address = reply.Address;
                        replyData.BufferSize = reply.Buffer.Length;
                        replyData.DontFragment = reply.Options.DontFragment;
                        replyData.Ttl = reply.Options.Ttl;
                        replyData.RoundTripTime = reply.RoundtripTime;
                        replyData.Status = reply.Status;
                    Messages.Add(replyData);
                }
            }
        }
    }
}
