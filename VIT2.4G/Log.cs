using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace VIT2._4G
{
    class Log
    {
        public static string path = Application.UserAppDataPath + "\\";
        public StreamWriter str;

        public Log(bool enable)
        {

            str = new StreamWriter(File.Open(path + Environment.UserName + ".log", FileMode.Append));

            if (enable)
            {
                AllocConsole();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("I was called with --console argument.\n" +
                    "Now you can see my logs while I am creating them.\n\n");
                Console.ResetColor();
                Create("The working directory is " + Environment.CurrentDirectory);
                Create("Logs are being stored in " + path);
                Console.WriteLine();
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
            Console.Write(DateTime.Now + ":");
            str.Write(DateTime.Now);
            Console.ResetColor();
            Console.WriteLine(" {0}", data);
            str.WriteLine(": {0}", data);
         }

        public void Highlight(string data, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(DateTime.Now + ":");
            str.Write(DateTime.Now);
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(" {0}", data);
            str.WriteLine(": {0}", data);
            Console.ResetColor();
        }

    }
}
