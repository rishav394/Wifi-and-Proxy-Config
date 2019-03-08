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

        [DllImport("user32.dll",
            CharSet = CharSet.Auto)]
        private static extern int SendMessage(
            IntPtr hWnd,
            int msg,
            int wParam,
            [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private const int EmSetcuebanner = 0x1501;

        #endregion

        #region Making the Panel1 movable crap

        /// <summary>
        ///     From codeproject. This shit makes a border-less from movable.
        /// </summary>
        private const int WmNclbuttondown = 0xA1;

        private const int HtCaption = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
            int msg,
            int wParam,
            int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        #endregion

        #region  Variables

        private string _proxyAddress;

        private string _ipAdd;

        private string _subNet;

        private string _gateway;

        private string _dns;

        private bool _isDhcpEnabled;

        private bool _isProxyEnabled;

        private string _ourTargetChipSet;

        private readonly bool _isFirstRun;

        private bool _allGood = true;

        private bool _ipCheckboxDisturbed;

        private bool _proxyCheckboxDisturbed;

        #endregion

        public Form1()
        {
            InitializeComponent();

            SelectWifiChipset();

            apply_button.ForeColor = Color.FromArgb(100,
                100,
                100);

            Improvise();

            _isFirstRun = false;
        }

        private void SelectWifiChipset()
        {
            var noMore = false;
            foreach (var o in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
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
                        noMore = monew["Caption"]
                            .ToString()
                            .Contains("Wi-Fi");
                        chipset_selector.SelectedIndex = chipset_selector.Items.Count - 1;
                        _ourTargetChipSet = monew["Caption"]
                            .ToString();
                        if (noMore)
                            _log.Highlight("Hurrah Wi-Fi was found. `nomore` = true now",
                                ConsoleColor.Cyan);
                    }
                }
            }
        }

        private void Improvise()
        {
            _log.Create("Improvise called.");
            _log.Create("Calling Get_current_data()");
            _allGood = GetCurrentData();
            _log.Create("allGood => " + _allGood);
            if (!_allGood) return;

            _log.Create("Making button White");
            apply_button.ForeColor = Color.White;

            _log.Create("We are connected to a wifi and have a valid address. Sending data for being updated. ");
            UpdateCurrentData();

            _log.Create("Setting Placeholders");
            try
            {
                SendMessage(address_textbox.Handle,
                    EmSetcuebanner,
                    0,
                    _proxyAddress.Split(':')[0]);
                SendMessage(port_textbox.Handle,
                    EmSetcuebanner,
                    0,
                    _proxyAddress.Split(':')[1]);
            }
            catch
            {
                SendMessage(address_textbox.Handle,
                    EmSetcuebanner,
                    0,
                    "none");
                SendMessage(port_textbox.Handle,
                    EmSetcuebanner,
                    0,
                    "none");
            }

            SendMessage(ip_textbox.Handle,
                EmSetcuebanner,
                0,
                _ipAdd);
            SendMessage(subnet_textbox.Handle,
                EmSetcuebanner,
                0,
                _subNet);
            SendMessage(gateway_textbox.Handle,
                EmSetcuebanner,
                0,
                _gateway);
            SendMessage(dns_textbox.Handle,
                EmSetcuebanner,
                0,
                _dns);
        }

        /// <summary>
        ///     Placing information into current_groupBox
        /// </summary>
        private void UpdateCurrentData()
        {
            _log.Create("Updating data into current groupBox");
            DHCP_checkbox.Checked = _isDhcpEnabled;
            proxy_checkbox.Checked = _isProxyEnabled;

            DisableIpTextboxes(_isDhcpEnabled);
            DisableProxyTextboxes(_isProxyEnabled);

            current_ip_sol.Text = _ipAdd;
            current_dns_sol.Text = _dns;
            current_subnet_sol.Text = _subNet;
            current_gateway_sol.Text = _gateway;
            current_proxy_sol.Text = _isProxyEnabled
                ? _proxyAddress
                : "Disabled";

            _log.Create("Done!");
        }

        /// <summary>
        ///     Calling both GetIp and GetProxy
        /// </summary>
        /// <returns>returns false if an exception was throws earlier and we are not collected to a wifi with a proper address</returns>
        private bool GetCurrentData()
        {
            GetProxy();
            return GetIp();
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
                _log.Create(
                    "User wants to remove proxy completely. (If not already disabled) \n" +
                    "We dont touch the proxy values. Just setting the EnableProxy => False");
                Eproxy.ProxyEnabled = false;
            }
        }

        private bool GetIp()
        {
            _log.Create("Beginning to extract IP");
            try
            {
                foreach (var o in
                    new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
                {
                    var mo = (ManagementObject) o;
                    if (mo["Caption"]
                        .Equals(_ourTargetChipSet))
                    {
                        _log.Create("Got a match for NIC with " + _ourTargetChipSet);
                        _isDhcpEnabled = (bool) mo.Properties["DHCPEnabled"]
                            .Value;
                        _ipAdd = ((string[]) mo["IPAddress"])[0];
                        _subNet = ((string[]) mo["IPSubnet"])[0];
                        _gateway = ((string[]) mo["DefaultIPGateway"])[0];

                        // TODO: Need a better way.
                        {
                            while (true)
                            {
                                try
                                {
                                    _dns = ((string[]) mo["DNSServerSearchOrder"])[0];
                                }
                                catch (Exception e)
                                {
                                    _log.Highlight(e.ToString(),
                                        ConsoleColor.Red);
                                }

                                break;
                            }
                        }

                        break;
                    }
                }
            }
            catch
            {
                switch (CustomMessagebox.Display(
                    "You are not connected to the specified chip set or " +
                    "your IP address is invalid. The data processed IS UTTER CRAP.",
                    "Connection Error",
                    MessageBoxButtons.AbortRetryIgnore))
                {
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Retry:
                        GetIp();
                        break;
                    default:
                        timer1.Enabled = true;
                        break;
                }

                _log.Create("Okay something went wrong and we displayed the Not connected custom_messagebox");
                return false;
            }

            _log.Create("IP extraction was all good");
            return true;
        }

        private void SetIp()
        {
            _log.Create("Testing for isDHCPEnabled?");
            _log.Create("No it is not. Setting static IP");
            try
            {
                foreach (var o in
                    new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
                {
                    var objMo = (ManagementObject) o;
                    if (!objMo["Caption"]
                        .Equals(_ourTargetChipSet))
                        continue;

                    _log.Create("Matched with " + _ourTargetChipSet);

                    var newIp = objMo.GetMethodParameters("EnableStatic");
                    newIp["IPAddress"] = new[]
                    {
                        _ipAdd
                    };
                    if (_subNet != null)
                        newIp["SubnetMask"] = new[]
                        {
                            _subNet
                        };

                    var newGate = objMo.GetMethodParameters("SetGateways");
                    newGate["DefaultIPGateway"] = new[]
                    {
                        _gateway
                    };
                    newGate["GatewayCostMetric"] = new[]
                    {
                        1
                    };

                    var newDns = objMo.GetMethodParameters("SetDNSServerSearchOrder");
                    newDns["DNSServerSearchOrder"] = _dns.Split(',');

                    _log.Create(objMo.InvokeMethod("EnableStatic",
                            newIp,
                            null)
                        ?.ToString());
                    _log.Create(objMo.InvokeMethod("SetGateways",
                            newGate,
                            null)
                        ?.ToString());
                    _log.Create(objMo.InvokeMethod("SetDNSServerSearchOrder",
                            newDns,
                            null)
                        ?.ToString());

                    break;
                }
            }
            catch (Exception exception)
            {
                _log.Highlight(exception.ToString(),
                    ConsoleColor.Red);
                var dialogResult = CustomMessagebox.Display(exception.ToString(),
                    "Unable to set IP",
                    MessageBoxButtons.AbortRetryIgnore);
                switch (dialogResult)
                {
                    case DialogResult.Retry:
                        SetIp();
                        break;
                    case DialogResult.Ignore:
                        break;
                    default:
                        timer1.Enabled = true;
                        break;
                }
            }
        }

        private void ButtonMiniClick(object sender,
            EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ButtonCloseClick(object sender,
            EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void ButtonCloseMouseEnter(object sender,
            EventArgs e)
        {
            button_close.BackColor = Color.Red;
        }

        private void ButtonCloseMouseLeave(object sender,
            EventArgs e)
        {
            button_close.BackColor = Color.Black;
        }

        private void AutomaticIp()
        {
            object responseIp = null;
            foreach (var o in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                var moTemp = (ManagementObject) o;
                if (moTemp["Caption"]
                    .Equals(_ourTargetChipSet))
                {
                    responseIp = moTemp.InvokeMethod("EnableDHCP",
                        null);
                    _log.Create(responseIp + " => Response from Enable DHCP");
                    var newDns = moTemp.GetMethodParameters("SetDNSServerSearchOrder");
                    newDns["DNSServerSearchOrder"] = null;
                    _log.Create(moTemp.InvokeMethod("SetDNSServerSearchOrder",
                            newDns,
                            null)
                        ?.ToString());

                    break;
                }
            }

            if (responseIp?.ToString()
                    .Equals("0") ==
                true)
            {
                _log.Create("DHCP enabled");
                CustomMessagebox.Display("IP will be set automatically.",
                    "Done!");
            }
            else
            {
                if (responseIp != null)
                    _log.Create(
                        "Something fucked up. The response from Enable DHCP is not 0 and is " +
                        responseIp +
                        " instead. Check Documentation for what it stands for.");

                CustomMessagebox.Display("I guess something went wrong. Please report this issue.",
                    "Uhh!");
            }
        }

        private void DHCP_checkbox_OnChange(object sender,
            EventArgs e)
        {
            _ipCheckboxDisturbed = true;
            DisableIpTextboxes(DHCP_checkbox.Checked);
            _isDhcpEnabled = DHCP_checkbox.Checked;
        }

        private void Proxy_checkbox_OnChange(object sender,
            EventArgs e)
        {
            _proxyCheckboxDisturbed = true;
            DisableProxyTextboxes(proxy_checkbox.Checked);
        }

        private void DisableIpTextboxes(bool v)
        {
            v = !v;
            dns_textbox.Enabled = v;
            gateway_textbox.Enabled = v;
            subnet_textbox.Enabled = v;
            ip_textbox.Enabled = v;
            label4.ForeColor = v
                ? Color.FromArgb(255,
                    255,
                    255)
                : Color.FromArgb(100,
                    100,
                    100);
            label5.ForeColor = v
                ? Color.FromArgb(255,
                    255,
                    255)
                : Color.FromArgb(100,
                    100,
                    100);
            label6.ForeColor = v
                ? Color.FromArgb(255,
                    255,
                    255)
                : Color.FromArgb(100,
                    100,
                    100);
            label7.ForeColor = v
                ? Color.FromArgb(255,
                    255,
                    255)
                : Color.FromArgb(100,
                    100,
                    100);
        }

        private void DisableProxyTextboxes(bool v)
        {
            address_textbox.Enabled = v;
            port_textbox.Enabled = v;
            port_label.ForeColor = v
                ? Color.FromArgb(255,
                    255,
                    255)
                : Color.FromArgb(100,
                    100,
                    100);
            address_label.ForeColor = v
                ? Color.FromArgb(255,
                    255,
                    255)
                : Color.FromArgb(100,
                    100,
                    100);
        }

        #region Error sign display wnen invalid stuff

        private void IpTextboxTextChanged(object sender,
            EventArgs e)
        {
            pictureBox1.Visible = !ValidateIPv4(((TextBox) sender).Text);
        }

        private void SubnetTextboxTextChanged(object sender,
            EventArgs e)
        {
            pictureBox2.Visible = !ValidateIPv4(((TextBox) sender).Text);
        }

        private void GatewayTextboxTextChanged(object sender,
            EventArgs e)
        {
            pictureBox3.Visible = !ValidateIPv4(((TextBox) sender).Text);
        }

        private void DnsTextboxTextChanged(object sender,
            EventArgs e)
        {
            pictureBox4.Visible = !ValidateIPv4(((TextBox) sender).Text);
        }

        #endregion

        private bool ValidateIPv4(string ipString)
        {
            if (string.IsNullOrWhiteSpace(ipString)) return true;

            var splitValues = ipString.Split('.');
            if (splitValues.Length != 4) return false;

            return splitValues.All(r => byte.TryParse(r,
                out _));
        }

        private void Panel1MouseDown(object sender,
            MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle,
                    WmNclbuttondown,
                    HtCaption,
                    0);
            }
        }

        /// <summary>
        ///     Must be set for all error pictures. Need to know how to get the calling control name to replace with pictureBox1
        ///     here.
        ///     Update: https://stackoverflow.com/questions/2681949/get-name-of-control-calling-method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxMouseHover(object sender,
            EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip((Control) sender,
                "Invalid");
        }

        private void CancelButtonClick(object sender,
            EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void ApplyButtonClick(object sender,
            EventArgs e)
        {
            _log.Create("OKAY finalizing things. Apply button was clicked");
            if (_ipCheckboxDisturbed)
            {
                _log.Create("ip_checkbox_disturbed => True");
                if (_isDhcpEnabled)
                {
                    _log.Create("DHCP checkbox was clicked. Automatic IP is being called...");
                    AutomaticIp();
                }
                else
                {
                    _log.Create("DHCP checkbox was not enabled. Trying to set IP manually.");

                    if (pictureBox1.Visible ||
                        pictureBox2.Visible ||
                        pictureBox3.Visible ||
                        pictureBox4.Visible ||
                        !_allGood)
                    {
                        _log.Create("Something is Invalid or get_data returned false (not all good). ");
                        CustomMessagebox.Display("Please correct the errors above and try again.");
                        return;
                    }

                    _ipAdd = ip_textbox.Text.Length > 0
                        ? ip_textbox.Text
                        : current_ip_sol.Text;
                    _subNet = subnet_textbox.Text.Length > 0
                        ? subnet_textbox.Text
                        : current_subnet_sol.Text;
                    _gateway = gateway_textbox.Text.Length > 0
                        ? gateway_textbox.Text
                        : current_gateway_sol.Text;
                    _dns = dns_textbox.Text.Length > 0
                        ? dns_textbox.Text
                        : current_dns_sol.Text;

                    SetIp();
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
            GetIp();
            _log.Create("Sending for Data Updating");
            UpdateCurrentData();
            CustomMessagebox.Display("Task Complete",
                "Yippie!");
        }

        private void ChipsetSelectorSelectedIndexChanged(object sender,
            EventArgs e)
        {
            if (_isFirstRun) return;

            _ourTargetChipSet = chipset_selector.Text;
            label9.Focus();
            Improvise();
        }

        private void RemoveFocus(object sender,
            EventArgs e)
        {
            label9.Focus();
        }

        private void Form1FormClosing(object sender,
            FormClosingEventArgs e)
        {
            _log.Str.WriteLine("-------------------------------------------------------\n\n\n");
            _log.Str.Dispose();
        }

        private void Timer1Tick(object sender,
            EventArgs e)
        {
            Opacity -= .07;
            if (Opacity <= .07) Close();
        }
    }
}