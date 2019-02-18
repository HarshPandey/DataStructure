using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class TestQueue
    {
        public static void TestQueueFunctions()
        {
            
        }
    }

    public class Queue<E>
    {
        private readonly Stack<E> inbox = new Stack<E>();
        private readonly Stack<E> outbox = new Stack<E>();

        public void queue(E item)
        {
            inbox.Push(item); // TODO here also add the while for copy back from out list
        }

        public E dequeue()
        {
            if (outbox.Count == 0)
            {
                while (inbox.Count != 0)
                {
                    outbox.Push(inbox.Pop());
                }
            }
            return outbox.Pop();
        }
    }
}
