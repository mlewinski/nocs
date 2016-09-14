using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocs.Networking.Model
{
    public class MessageQuery<T>
    {
        Queue<T> messages;

        public void Add(T message)
        {
            messages.Enqueue(message);
        }

        public void Clear()
        {
            messages.Clear();
        }

        public List<T> ToList()
        {
            return messages.ToList();
        }
    }
}
