using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spp6
{
    static class Log
    {
        public static void Show(string LogInfo)
        {
            Program._mainForm.AddLogInfo(LogInfo + Environment.NewLine);
        }
    }
}
