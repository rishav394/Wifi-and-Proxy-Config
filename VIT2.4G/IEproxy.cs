using Microsoft.Win32;

namespace VIT2._4G
{
    internal static class Eproxy
    {
        private static RegistryKey internetSettings; // Probably used to navigate to the key

        /// <summary>
        /// Open the key where Internet Explorer store's its proxy setting
        /// </summary>
        private static void Navigate()
        {
            internetSettings = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
        }

        /// <summary>
        /// Proxy Server name. It can be IP, IP:PORT or a HTTP URL with PORT
        /// </summary>
        public static string ProxyServer
        {
            get
            {
                Navigate();
                string value = internetSettings.GetValue("ProxyServer", defaultValue: string.Empty).ToString();
                internetSettings.Close(); // If we navigate we weed to close the value after we use the getVlaue method
                return value;
            }

            set
            {
                Navigate();
                internetSettings.SetValue("ProxyServer", value);
                internetSettings.Close();
            }
        }

        public static bool ProxyEnabled
        {
            get
            {
                Navigate();
                int value = (int)internetSettings.GetValue("ProxyEnable", 0);
                internetSettings.Close();

                return value > 0;
            }

            set
            {
                Navigate();
                internetSettings.SetValue("ProxyEnable", value ? 1 : 0);
                internetSettings.Close();
            }
        }
    }
}
