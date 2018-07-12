using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace VIT2._4G
{
    internal class Log
    {
        private static readonly string Path = Application.UserAppDataPath + "\\";

        public readonly StreamWriter Str;

        public Log(bool enable)
        {
            this.Str = new StreamWriter(File.Open(Path + Environment.UserName + ".log", FileMode.Append));

            if (enable)
            {
                AllocConsole();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(
                    "I was called with --console argument.\n"
                    + "Now you can see my logs while I am creating them.\n\n");
                Console.ResetColor();
                this.Create("The working directory is " + Environment.CurrentDirectory);
                this.Create("Logs are being stored in " + Path);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Enable console for logging
        /// </summary>

        #region Console Enabling dll crap

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        #endregion

        public void Create(string data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(DateTime.Now + @":");
            this.Str.Write(DateTime.Now);
            Console.ResetColor();
            Console.WriteLine(" {0}", data);
            this.Str.WriteLine(": {0}", data);
        }

        public void Highlight(string data, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(DateTime.Now + ":");
            this.Str.Write(DateTime.Now);
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(" {0}", data);
            this.Str.WriteLine(": {0}", data);
            Console.ResetColor();
        }
    }
}