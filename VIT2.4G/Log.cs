using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VIT2._4G
{
    class Log
    {
        public Log(bool enable)
        {
            if(enable)
            {
                AllocConsole();
                Create("The working direcotry is "+Environment.CurrentDirectory);
            }
        }
        
        /// <summary>
        /// Enable console for logging
        /// </summary>
        #region Console Enabling dll crap
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        #endregion

        public void Create(string data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(DateTime.Now);
            Console.ResetColor();
            Console.WriteLine(" {0}",data);
        }

    }
}
