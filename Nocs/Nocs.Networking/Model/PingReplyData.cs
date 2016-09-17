using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Nocs.Networking.Model
{
    /// <summary>
    /// Wrapper for PingReply implementing returning formatted string message
    /// </summary>
    /// 
    /// TODO: 
    ///     - use extension methods
    public class PingReplyData
    {
        public IPAddress Address;
        public long RoundTripTime;
        public int Ttl;
        public bool DontFragment;
        public long BufferSize;
        public long Timeout;
        public IPStatus Status;

        public override string ToString()
        {
            return $"Pinging {Address.ToString()} with {BufferSize}B of data, TTL={Ttl}, Fragment={DontFragment} : {RoundTripTime} ms, timeout : {Timeout} ms, Result : {Status.ToString()}";
        }
    }
}
