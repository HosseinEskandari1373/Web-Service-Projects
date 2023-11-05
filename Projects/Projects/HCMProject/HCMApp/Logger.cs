using FormModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMApp
{
    internal static class Logger
    {
        internal static void WriteLine(string str, object obj = null)
        {
            if (obj != null)
                str = string.Format(str, obj);
            if (AppInfo.ServiceMode)
            {
                string[] line = new string[] { $@"{DateTime.Now.ToLongTimeString()} : {str}" };
                File.AppendAllLines($@"{AppInfo.LogPath}\{DateTime.Now.ToString("yyyyMMdd")}.txt", line);
            }
            else
            {
                Console.WriteLine(str);
            }
        }
    }
}
