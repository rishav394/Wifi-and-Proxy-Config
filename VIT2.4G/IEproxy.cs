using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace VIT2._4G
{
    class IEproxy
    {

        private static RegistryKey _InternetSettings;                   //Probably used to navigate to the key

        /// <summary>
		/// Open the key where Internet Explorer store's its proxy setting
		/// </summary>
		private static void Navigate()
        {
            _InternetSettings = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
        }

        /// <summary>
		/// Proxy Server name. It can be IP, IP:PORT or a HTTP URL with PORT
		/// </summary>
        public static string ProxyServer
        {
            get
            {
                Navigate();
                string value = _InternetSettings.GetValue("ProxyServer", defaultValue: string.Empty).ToString();
                _InternetSettings.Close();      // If we navigate we weed to close the value after we use the getVlaue method
                return value;
            }
            set
            {
                Navigate();
                _InternetSettings.SetValue("ProxyServer", value);
                _InternetSettings.Close();
            }
        }

        public static bool ProxyEnabled
        {
            get
            {
                Navigate();
                int value = (int)_InternetSettings.GetValue("ProxyEnable", 0);
                _InternetSettings.Close();

                return value > 0;
            }
            set
            {
                Navigate();
                _InternetSettings.SetValue("ProxyEnable", value ? 1 : 0);
                _InternetSettings.Close();
            }
        }


    }
}
