using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spp6
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;

    class QueueLocked<T> : Queue<T>
    {
        private object sync = new object();

        public new object Dequeue()
        {
            lock (sync)
                return base.Dequeue();
        }
        public new void Enqueue(T value)
        {
            lock (sync)
                base.Enqueue(value);
        }
        public new object Peek()
        {
            lock (sync)
                return base.Peek();
        }
    }

}
