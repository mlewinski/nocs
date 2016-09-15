using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocs.Networking.Model
{
    public class MessageQueue<T>
    {
        Queue<T> messages;

        public MessageQueue()
        {
            messages=new Queue<T>();
        } 

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
