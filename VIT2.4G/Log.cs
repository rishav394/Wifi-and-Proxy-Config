﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VIT2._4G
{
    internal class Log
    {
        private static readonly string Path = Application.UserAppDataPath + "\\";

        public readonly StreamWriter Str;

        public Log(bool enable)
        {
            Str = new StreamWriter(File.Open(Path + Environment.UserName + ".log", FileMode.Append));

            if (!enable)
            {
                return;
            }

            AllocConsole();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(
                "I was called with --console argument.\n"
                + "Now you can see my logs while I am creatDotSettingsing them.\n\n");
            Console.ResetColor();
            Create("The working directory is " + Environment.CurrentDirectory);
            Create("Logs are being stored in " + Path);
            Console.WriteLine();
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
            Str.Write(DateTime.Now);
            Console.ResetColor();
            Console.WriteLine($" {data}");
            Str.WriteLine(": {0}", data);
        }

        public void Highlight(string data, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(DateTime.Now + @":");
            Str.Write(DateTime.Now);
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(" {0}", data);
            Str.WriteLine(": {0}", data);
            Console.ResetColor();
        }
    }
}