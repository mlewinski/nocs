using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocs.Networking.Model
{
    public class Route
    {
        private List<HostInformation> Hops;

        public Route()
        {
            Hops= new List<HostInformation>();
        }

        public HostInformation this[int index] => Hops[index];

        public void AddHop(HostInformation hop)
        {
            this.Hops.Add(hop);
        }

        public void Clear()
        {
            this.Hops.Clear();
        }

        public int Length
        {
            get { return Hops.Count-1; }
        }
    }
}
