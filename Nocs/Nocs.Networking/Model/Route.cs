using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocs.Networking.Model
{
    public class Route
    {
        public List<HostInformation> Hops;

        public HostInformation this[int index]
        {
            get { return Hops[index]; }
        }

        public void AddHop(HostInformation hop)
        {
            this.Hops.Add(hop);
        }

        public void Clear()
        {
            this.Hops.Clear();
        }
    }
}
