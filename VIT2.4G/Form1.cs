using System;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VIT2._4G
{
    public partial class Form1 : Form
    {
        public static bool EnableLogging = false;
        private readonly Log _log = new Log(EnableLogging);


        #region Placeholder's crap

        /// <summary>
        ///     SendMessage import
        ///     Specifically used in this case for setting placeholder text for text controls
        /// </summary>
        /// <param name="hWnd">IntPtr</param>
        /// <param name="msg">int</param>
        /// <param name="wParam">int</param>
        /// <param name="lParam">[MarshalAs(UnmanagedType.LPWStr)]string</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam,
            [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private const int EM_SETCUEBANNER = 0x1501;

        #endregion

        #region Making the Panel1 movable crap

        /// <summary>
        ///     From codeproject. This shit makes a borderless from movable.
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        #region  Variables

        private string _proxyAddress;
        private string _ipAdd;
        private string _subNet;
        private string _gateway;
        private string _dns;
        private bool _isDhcpEnabled;
        private bool _isProxyEnabled;


        private string _wifi; // "[00000011] Realtek RTL8188EE 802.11 bgn Wi-Fi Adapter"
        private readonly bool _isFirstRun = true;
        private bool _allGood = true;
        private bool _ipCheckboxDisturbed;
        private bool _proxyCheckboxDisturbed;

        #endregion

        public Form1()
        {
            InitializeComponent();

            Select_wifi_chipset();

            apply_button.ForeColor = Color.FromArgb(100, 100, 100);

            _improvise();

            _isFirstRun = false;
        }

        private void Select_wifi_chipset()
        {
            var noMore = false;
            foreach (ManagementBaseObject o in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                var monew = (ManagementObject) o;
                chipset_selector.Items.Add(monew["Caption"]);

                if ((bool) monew["IPEnabled"])
                {
                    _log.Create("Okay I found a IP Enabled Device");
                    chipset_selector.Items[chipset_selector.Items.Count - 1] += "\t♥";
                    if (!noMore)
                    {
                        _log.Create("Hmm let me check if the NIC is a WiFi adapter");
                        noMore = monew["Caption"].ToString().Contains("Wi-Fi");
                        chipset_selector.SelectedIndex = chipset_selector.Items.Count - 1;
                        _wifi = monew["Caption"].ToString();
                        if (noMore) _log.Highlight("Hurrah Wi-Fi was found. `nomore` = true now", ConsoleColor.Cyan);
                    }
                }
            }
        }

        private void _improvise()
        {
            _log.Create("Improvise called.");
            _log.Create("Calling Get_current_data()");
            _allGood = Get_current_data();
            _log.Create("allGood => " + _allGood);
            if (!_allGood) return;
            _log.Create("Making button White");
            apply_button.ForeColor = Color.White;

            _log.Create("We are connected to a wifi and have a valid address. Sending data for being updated. ");
            Update_current_data();

            _log.Create("Setting Placeholders");
            try
            {
                SendMessage(address_textbox.Handle, EM_SETCUEBANNER, 0, _proxyAddress.Split(':')[0]);
                SendMessage(port_textbox.Handle, EM_SETCUEBANNER, 0, _proxyAddress.Split(':')[1]);
            }
            catch
            {
                SendMessage(address_textbox.Handle, EM_SETCUEBANNER, 0, "none");
                SendMessage(port_textbox.Handle, EM_SETCUEBANNER, 0, "none");
            }

            SendMessage(ip_textbox.Handle, EM_SETCUEBANNER, 0, _ipAdd);
            SendMessage(subnet_textbox.Handle, EM_SETCUEBANNER, 0, _subNet);
            SendMessage(gateway_textbox.Handle, EM_SETCUEBANNER, 0, _gateway);
            SendMessage(dns_textbox.Handle, EM_SETCUEBANNER, 0, _dns);
        }

        /// <summary>
        ///     Placing information into current_groupBox
        /// </summary>
        private void Update_current_data()
        {
            _log.Create("Updating data into current groupBox");
            DHCP_checkbox.Checked = _isDhcpEnabled;
            proxy_checkbox.Checked = _isProxyEnabled;

            Disable_IP_textboxes(_isDhcpEnabled);
            Disable_Proxy_textboxes(_isProxyEnabled);

            current_ip_sol.Text = _ipAdd;
            current_dns_sol.Text = _dns;
            current_subnet_sol.Text = _subNet;
            current_gateway_sol.Text = _gateway;
            current_proxy_sol.Text = _isProxyEnabled ? _proxyAddress : "Disabled";

            _log.Create("Done!");
        }

        /// <summary>
        ///     Calling both GetIp and GetProxy
        /// </summary>
        /// <returns>returns false if an exception was throws earlier and we are not collected to a wifi with aproper address</returns>
        private bool Get_current_data()
        {
            GetProxy();
            return Get_ip();
        }

        private void GetProxy()
        {
            _log.Create("Getting proxy");
            _isProxyEnabled = Eproxy.ProxyEnabled;
            _log.Create(Eproxy.ProxyEnabled + " => is the proxyEnabled");
            _proxyAddress = Eproxy.ProxyServer;
        }

        private void SetProxy()
        {
            if (proxy_checkbox.Checked)
            {
                _log.Create("Setting proxy from input as " + _proxyAddress);
                Eproxy.ProxyEnabled = true;
                Eproxy.ProxyServer = _proxyAddress;
            }
            else
            {
                _log.Create("User wants to remove proxy completely. (If not already disabled) \n" +
                            "We dont touch the proxy values. Just setting the EnableProxy => False");
                Eproxy.ProxyEnabled = false;
            }
        }

        private bool Get_ip()
        {
            _log.Create("Beginning to extract IP");
            try
            {
                foreach (ManagementBaseObject o in
                    new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
                {
                    var mo = (ManagementObject) o;
                    if (mo["Caption"].Equals(_wifi))
                    {
                        _log.Create("Got a match for NIC with " + _wifi);
                        _isDhcpEnabled = (bool) mo.Properties["DHCPEnabled"].Value;
                        _ipAdd = ((string[]) mo["IPAddress"])[0];
                        _subNet = ((string[]) mo["IPSubnet"])[0];
                        _gateway = ((string[]) mo["DefaultIPGateway"])[0];
                        _dns = ((string[]) mo["DNSServerSearchOrder"])[0];

                        break;
                    }
                }
            }
            catch
            {
                switch (CustomMessagebox.Display("You are not connected to the specified chip set or " +
                                                 "your IP address is invalid. The data processed IS UTTER CRAP.",
                    "Connection Error", MessageBoxButtons.AbortRetryIgnore))
                {
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Retry:
                        Get_ip();
                        break;
                    default:
                        Environment.Exit(1);
                        break;
                }

                _log.Create("Okay something went wrong and we displayed the Not connected custom_messagebox");
                return false;
            }

            _log.Create("IP extraction was all good");
            return true;
        }

        private void Set_ip()
        {
            _log.Create("Testing for isDHCPEnabled?");
            _log.Create("No it is not. Setting static IP");

            foreach (var o in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                var objMo = (ManagementObject) o;
                if (objMo["Caption"].Equals(_wifi))
                {
                    _log.Create("Matched with " + _wifi);

                    ManagementBaseObject newIp = objMo.GetMethodParameters("EnableStatic");
                    newIp["IPAddress"] = new[] {_ipAdd};
                    newIp["SubnetMask"] = new[] {_subNet};

                    ManagementBaseObject newGate = objMo.GetMethodParameters("SetGateways");
                    newGate["DefaultIPGateway"] = new[] {_gateway};
                    newGate["GatewayCostMetric"] = new[] {1};

                    ManagementBaseObject newDns = objMo.GetMethodParameters("SetDNSServerSearchOrder");
                    newDns["DNSServerSearchOrder"] = _dns.Split(',');


                    _log.Create(objMo.InvokeMethod("EnableStatic", newIp, null)?.ToString());
                    _log.Create(objMo.InvokeMethod("SetGateways", newGate, null)?.ToString());
                    _log.Create(objMo.InvokeMethod("SetDNSServerSearchOrder", newDns, null)?.ToString());

                    break;
                }
            }
        }

        private void Button_mini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Button_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_close_MouseEnter(object sender, EventArgs e)
        {
            button_close.BackColor = Color.Red;
        }

        private void Button_close_MouseLeave(object sender, EventArgs e)
        {
            button_close.BackColor = Color.Black;
        }

        private void Automatic_IP()
        {
            object responseIp = null;
            foreach (ManagementBaseObject o in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                var moTemp = (ManagementObject) o;
                if (moTemp["Caption"].Equals(_wifi))
                {
                    responseIp = moTemp.InvokeMethod("EnableDHCP", null);
                    _log.Create(responseIp + " => Response from Enable DHCP");
                    ManagementBaseObject newDns = moTemp.GetMethodParameters("SetDNSServerSearchOrder");
                    newDns["DNSServerSearchOrder"] = null;
                    _log.Create(moTemp.InvokeMethod("SetDNSServerSearchOrder", newDns, null)?.ToString());

                    break;
                }
            }

            if (responseIp != null && responseIp.ToString().Equals("0"))
            {
                _log.Create("DHCP enabled");
                CustomMessagebox.Display("IP will be set automatically.", "Done!");
            }
            else
            {
                if (responseIp != null)
                    _log.Create("Something fucked up. The response from Enable DHCP is not 0 and is "
                                + responseIp + " instead. Check Documentation for what it stands for.");
                CustomMessagebox.Display("I guess something went wrong. Please report this issue.", "Uhh!");
            }
        }

        private void DHCP_checkbox_OnChange(object sender, EventArgs e)
        {
            _ipCheckboxDisturbed = true;
            Disable_IP_textboxes(DHCP_checkbox.Checked);
            _isDhcpEnabled = DHCP_checkbox.Checked;
        }

        private void Proxy_checkbox_OnChange(object sender, EventArgs e)
        {
            _proxyCheckboxDisturbed = true;
            Disable_Proxy_textboxes(proxy_checkbox.Checked);
        }

        private void Disable_IP_textboxes(bool v)
        {
            v = !v;
            dns_textbox.Enabled = v;
            gateway_textbox.Enabled = v;
            subnet_textbox.Enabled = v;
            ip_textbox.Enabled = v;
            label4.ForeColor = v ? Color.FromArgb(255, 255, 255) : Color.FromArgb(100, 100, 100);
            label5.ForeColor = v ? Color.FromArgb(255, 255, 255) : Color.FromArgb(100, 100, 100);
            label6.ForeColor = v ? Color.FromArgb(255, 255, 255) : Color.FromArgb(100, 100, 100);
            label7.ForeColor = v ? Color.FromArgb(255, 255, 255) : Color.FromArgb(100, 100, 100);
        }

        private void Disable_Proxy_textboxes(bool v)
        {
            address_textbox.Enabled = v;
            port_textbox.Enabled = v;
            port_label.ForeColor = v ? Color.FromArgb(255, 255, 255) : Color.FromArgb(100, 100, 100);
            address_label.ForeColor = v ? Color.FromArgb(255, 255, 255) : Color.FromArgb(100, 100, 100);
        }

        #region Error sign display wnen invalid stuff

        private void Ip_textbox_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = !ValidateIPv4(((TextBox) sender).Text);
        }

        private void Subnet_textbox_TextChanged(object sender, EventArgs e)
        {
            pictureBox2.Visible = !ValidateIPv4(((TextBox) sender).Text);
        }

        private void Gateway_textbox_TextChanged(object sender, EventArgs e)
        {
            pictureBox3.Visible = !ValidateIPv4(((TextBox) sender).Text);
        }

        private void Dns_textbox_TextChanged(object sender, EventArgs e)
        {
            pictureBox4.Visible = !ValidateIPv4(((TextBox) sender).Text);
        }

        #endregion

        public bool ValidateIPv4(string ipString)
        {
            if (string.IsNullOrWhiteSpace(ipString)) return true;

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4) return false;


            return splitValues.All(r => byte.TryParse(r, out byte tempForParsing));
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        ///     Must be set for all error pictures. Need to know how to get the calling control name to replace with pictureBox1
        ///     here.
        ///     Update: https://stackoverflow.com/questions/2681949/get-name-of-control-calling-method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_MouseHover(object sender, EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip((Control) sender, "Invalid");
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Apply_button_Click(object sender, EventArgs e)
        {
            _log.Create("OKAY finalising things. Apply button was clicked");
            if (_ipCheckboxDisturbed)
            {
                _log.Create("ip_checkbox_disturbed => True");
                if (_isDhcpEnabled)
                {
                    _log.Create("DHCP checkbox was clicked. Automatic IP is being called...");
                    Automatic_IP();
                }
                else
                {
                    _log.Create("DHCP checkbox was not enabled. Trying to set IP manually.");

                    if (pictureBox1.Visible || pictureBox2.Visible || pictureBox3.Visible || pictureBox4.Visible ||
                        !_allGood)
                    {
                        _log.Create("Something is Invalid or get_data returned false (not allgood). ");
                        CustomMessagebox.Display("Please correct the errors above and try again.");
                        return;
                    }

                    _ipAdd = ip_textbox.Text.Length > 0 ? ip_textbox.Text : current_ip_sol.Text;
                    _subNet = subnet_textbox.Text.Length > 0 ? subnet_textbox.Text : current_subnet_sol.Text;
                    _gateway = gateway_textbox.Text.Length > 0 ? gateway_textbox.Text : current_gateway_sol.Text;
                    _dns = dns_textbox.Text.Length > 0 ? dns_textbox.Text : current_dns_sol.Text;

                    Set_ip();
                }
            }

            if (_proxyCheckboxDisturbed)
            {
                _log.Create("proxy_checkbox_disturbed => True");

                _proxyAddress = address_textbox.Text.Length > 0 && port_textbox.Text.Length > 0
                    ? address_textbox.Text + ":" + port_textbox.Text
                    : Eproxy.ProxyServer;

                _log.Create("proxy_address => " + _proxyAddress);
                _log.Create("I guess everything was good. Sending for proxy completion");
                SetProxy();
            }

            _log.Create("Sending for Proxy fetching");
            GetProxy();
            _log.Create("Sending for IP fetching");
            Get_ip();
            _log.Create("Sending for Data Updatings");
            Update_current_data();
            CustomMessagebox.Display("Task Complete", "Yippie!");
            _ipCheckboxDisturbed = false;
            _proxyCheckboxDisturbed = false;
        }

        private void Chipset_selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirstRun) return;
            _wifi = chipset_selector.Text;
            label9.Focus();
            _improvise();
        }

        private void Remove_focus(object sender, EventArgs e)
        {
            label9.Focus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _log.Str.WriteLine("-------------------------------------------------------\n\n\n");
            _log.Str.Dispose();
        }
    }
}