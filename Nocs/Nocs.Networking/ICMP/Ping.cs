using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Nocs.Networking.Model;

namespace Nocs.Networking.ICMP
{
    /// <summary>
    /// Wrapper for System.Net.NetworkInformation.Ping class implementing message query
    /// </summary>
    public class Ping
    {
        public MessageQueue<PingReplyData> Messages;
        public HostInformation Host;
        System.Net.NetworkInformation.Ping _pinger = new System.Net.NetworkInformation.Ping();

        /// <summary>
        /// Initializes messages and host information with new object (default values : IPAddress 127.0.0.1, hostname localhost)
        /// </summary>
        public Ping()
        {
            this.Messages = new MessageQueue<PingReplyData>();
            this.Host = new HostInformation();
        }

        /// <summary>
        /// Initializes host infomation with given host data
        /// </summary>
        /// <param name="host">Object containing information about host to be pinged</param>
        public Ping(HostInformation host)
        {
            this.Host = host;
            this.Messages=new MessageQueue<PingReplyData>();
        }

        /// <summary>
        /// Initializes host information with given host data and custom message queue
        /// </summary>
        /// <param name="host">Object containing information about host to be pinged</param>
        /// <param name="messageQueue">Message queue where messages will be put</param>
        public Ping(HostInformation host, MessageQueue<PingReplyData> messageQueue)
        {
            this.Host = host;
            this.Messages = messageQueue;
        }

        /// <summary>
        /// Send echo message sequentially and put results into message queue
        /// </summary>
        /// <param name="ttl">Time-to-live. Determines number of hops after which request expires</param>
        /// <param name="timeout">Maximum acceptable connection timeout</param>
        public void Send(int ttl, int timeout)
        {
            PingOptions pingOptions = new PingOptions(ttl, false);
            var buffer = Encoding.ASCII.GetBytes(ttl.ToString());
            var reply = _pinger.Send(Host.Address, timeout, buffer, pingOptions);
            if (reply != null)
            {
                PingReplyData replyData = new PingReplyData();
                replyData.Address = reply.Address;
                replyData.BufferSize = reply.Buffer.Length;
                replyData.DontFragment = reply.Options.DontFragment;
                replyData.Ttl = reply.Options.Ttl;
                replyData.RoundTripTime = reply.RoundtripTime;
                replyData.Status = reply.Status;
                replyData.Timeout = timeout;
                Messages.Add(replyData);
            }
        }
    }
}
