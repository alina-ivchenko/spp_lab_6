using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spp6
{
    public delegate void TaskFunction();
    public interface IThreadRool
    {
        void SetMinAmountOFThreads(int amountOfThreads);
        void SetMaxAmountOFThreads(int amountOfThreads);
        bool AddTask(TaskFunction addedTask);
    }
}
