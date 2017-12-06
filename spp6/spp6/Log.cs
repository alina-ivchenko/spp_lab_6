using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace spp6
{
    static class Log
    {
        private static object fileSyncObject = new object();
        public static void Show(string LogInfo)
        {
            Program._mainForm.AddLogInfo(LogInfo + Environment.NewLine);
        }

        public static void WriteToLogFile(string LogInfo)
        {
            Show(LogInfo);
            lock (fileSyncObject)
                using (var F = new FileStream("musya.log", FileMode.Append))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(LogInfo + '\n');
                    F.Write(array, 0, array.Length);
                }
        }
    }
}
