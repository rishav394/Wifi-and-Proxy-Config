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
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(
            IntPtr hWnd,
            int msg,
            int wParam,
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

        private string proxyAddress;

        private string ipAdd;

        private string subNet;

        private string gateway;

        private string dns;

        private bool isDhcpEnabled;

        private bool isProxyEnabled;

        private string ourTargetChipSet;

        private readonly bool isFirstRun;

        private bool allGood = true;

        private bool ipCheckboxDisturbed;

        private bool proxyCheckboxDisturbed;

        #endregion

        public Form1()
        {
            this.InitializeComponent();

            this.SelectWifiChipset();

            this.apply_button.ForeColor = Color.FromArgb(100, 100, 100);

            this.Improvise();

            this.isFirstRun = false;
        }

        private void SelectWifiChipset()
        {
            var noMore = false;
            foreach (ManagementBaseObject o in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                var monew = (ManagementObject)o;
                this.chipset_selector.Items.Add(monew["Caption"]);

                if ((bool)monew["IPEnabled"])
                {
                    this._log.Create("Okay I found a IP Enabled Device");
                    this.chipset_selector.Items[this.chipset_selector.Items.Count - 1] += "\t♥";
                    if (!noMore)
                    {
                        this._log.Create("Hmm let me check if the NIC is a WiFi adapter");
                        noMore = monew["Caption"].ToString().Contains("Wi-Fi");
                        this.chipset_selector.SelectedIndex = this.chipset_selector.Items.Count - 1;
                        this.ourTargetChipSet = monew["Caption"].ToString();
                        if (noMore)
                        {
                            this._log.Highlight("Hurrah Wi-Fi was found. `nomore` = true now", ConsoleColor.Cyan);
                        }
                    }
                }
            }
        }

        private void Improvise()
        {
            this._log.Create("Improvise called.");
            this._log.Create("Calling Get_current_data()");
            this.allGood = this.GetCurrentData();
            this._log.Create("allGood => " + this.allGood);
            if (!this.allGood)
            {
                return;
            }

            this._log.Create("Making button White");
            this.apply_button.ForeColor = Color.White;

            this._log.Create("We are connected to a wifi and have a valid address. Sending data for being updated. ");
            this.UpdateCurrentData();

            this._log.Create("Setting Placeholders");
            try
            {
                SendMessage(this.address_textbox.Handle, EM_SETCUEBANNER, 0, this.proxyAddress.Split(':')[0]);
                SendMessage(this.port_textbox.Handle, EM_SETCUEBANNER, 0, this.proxyAddress.Split(':')[1]);
            }
            catch
            {
                SendMessage(this.address_textbox.Handle, EM_SETCUEBANNER, 0, "none");
                SendMessage(this.port_textbox.Handle, EM_SETCUEBANNER, 0, "none");
            }

            SendMessage(this.ip_textbox.Handle, EM_SETCUEBANNER, 0, this.ipAdd);
            SendMessage(this.subnet_textbox.Handle, EM_SETCUEBANNER, 0, this.subNet);
            SendMessage(this.gateway_textbox.Handle, EM_SETCUEBANNER, 0, this.gateway);
            SendMessage(this.dns_textbox.Handle, EM_SETCUEBANNER, 0, this.dns);
        }

        /// <summary>
        ///     Placing information into current_groupBox
        /// </summary>
        private void UpdateCurrentData()
        {
            this._log.Create("Updating data into current groupBox");
            this.DHCP_checkbox.Checked = this.isDhcpEnabled;
            this.proxy_checkbox.Checked = this.isProxyEnabled;

            this.DisableIpTextboxes(this.isDhcpEnabled);
            this.DisableProxyTextboxes(this.isProxyEnabled);

            this.current_ip_sol.Text = this.ipAdd;
            this.current_dns_sol.Text = this.dns;
            this.current_subnet_sol.Text = this.subNet;
            this.current_gateway_sol.Text = this.gateway;
            this.current_proxy_sol.Text = this.isProxyEnabled ? this.proxyAddress : "Disabled";

            this._log.Create("Done!");
        }

        /// <summary>
        ///     Calling both GetIp and GetProxy
        /// </summary>
        /// <returns>returns false if an exception was throws earlier and we are not collected to a wifi with a proper address</returns>
        private bool GetCurrentData()
        {
            this.GetProxy();
            return this.GetIp();
        }

        private void GetProxy()
        {
            this._log.Create("Getting proxy");
            this.isProxyEnabled = Eproxy.ProxyEnabled;
            this._log.Create(Eproxy.ProxyEnabled + " => is the proxyEnabled");
            this.proxyAddress = Eproxy.ProxyServer;
        }

        private void SetProxy()
        {
            if (this.proxy_checkbox.Checked)
            {
                this._log.Create("Setting proxy from input as " + this.proxyAddress);
                Eproxy.ProxyEnabled = true;
                Eproxy.ProxyServer = this.proxyAddress;
            }
            else
            {
                this._log.Create(
                    "User wants to remove proxy completely. (If not already disabled) \n"
                    + "We dont touch the proxy values. Just setting the EnableProxy => False");
                Eproxy.ProxyEnabled = false;
            }
        }

        private bool GetIp()
        {
            this._log.Create("Beginning to extract IP");
            try
            {
                foreach (ManagementBaseObject o in
                    new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
                {
                    var mo = (ManagementObject)o;
                    if (mo["Caption"].Equals(this.ourTargetChipSet))
                    {
                        this._log.Create("Got a match for NIC with " + this.ourTargetChipSet);
                        this.isDhcpEnabled = (bool)mo.Properties["DHCPEnabled"].Value;
                        this.ipAdd = ((string[])mo["IPAddress"])[0];
                        this.subNet = ((string[])mo["IPSubnet"])[0];
                        this.gateway = ((string[])mo["DefaultIPGateway"])[0];

                        // TODO: Need a better way.
                        {
                            while (true)
                            {
                                try
                                {
                                    this.dns = ((string[])mo["DNSServerSearchOrder"])[0];
                                }
                                catch (Exception e)
                                {
                                    this._log.Highlight(e.ToString(), ConsoleColor.Red);
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
                    "You are not connected to the specified chip set or "
                    + "your IP address is invalid. The data processed IS UTTER CRAP.",
                    "Connection Error",
                    MessageBoxButtons.AbortRetryIgnore))
                {
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Retry:
                        this.GetIp();
                        break;
                    default:
                        this.timer1.Enabled = true;
                        break;
                }

                this._log.Create("Okay something went wrong and we displayed the Not connected custom_messagebox");
                return false;
            }

            this._log.Create("IP extraction was all good");
            return true;
        }

        private void SetIp()
        {
            this._log.Create("Testing for isDHCPEnabled?");
            this._log.Create("No it is not. Setting static IP");
            try
            {
                foreach (ManagementBaseObject o in
                    new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
                {
                    var objMo = (ManagementObject)o;
                    if (!objMo["Caption"].Equals(this.ourTargetChipSet))
                    {
                        continue;
                    }

                    this._log.Create("Matched with " + this.ourTargetChipSet);

                    ManagementBaseObject newIp = objMo.GetMethodParameters("EnableStatic");
                    newIp["IPAddress"] = new[] { this.ipAdd };
                    newIp["SubnetMask"] = new[] { this.subNet };

                    ManagementBaseObject newGate = objMo.GetMethodParameters("SetGateways");
                    newGate["DefaultIPGateway"] = new[] { this.gateway };
                    newGate["GatewayCostMetric"] = new[] { 1 };

                    ManagementBaseObject newDns = objMo.GetMethodParameters("SetDNSServerSearchOrder");
                    newDns["DNSServerSearchOrder"] = this.dns.Split(',');

                    this._log.Create(objMo.InvokeMethod("EnableStatic", newIp, null)?.ToString());
                    this._log.Create(objMo.InvokeMethod("SetGateways", newGate, null)?.ToString());
                    this._log.Create(objMo.InvokeMethod("SetDNSServerSearchOrder", newDns, null)?.ToString());

                    break;
                }
            }
            catch (Exception exception)
            {
                this._log.Highlight(exception.ToString(), ConsoleColor.Red);
                var dialogResult = CustomMessagebox.Display(exception.ToString(), "Unable to set IP", MessageBoxButtons.AbortRetryIgnore);
                switch (dialogResult)
                {
                    case DialogResult.Retry:
                        this.SetIp();
                        break;
                    case DialogResult.Ignore:
                        break;
                    default:
                        this.timer1.Enabled = true;
                        break;
                }
            }
        }

        private void ButtonMiniClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }

        private void ButtonCloseMouseEnter(object sender, EventArgs e)
        {
            this.button_close.BackColor = Color.Red;
        }

        private void ButtonCloseMouseLeave(object sender, EventArgs e)
        {
            this.button_close.BackColor = Color.Black;
        }

        private void AutomaticIp()
        {
            object responseIp = null;
            foreach (ManagementBaseObject o in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                var moTemp = (ManagementObject)o;
                if (moTemp["Caption"].Equals(this.ourTargetChipSet))
                {
                    responseIp = moTemp.InvokeMethod("EnableDHCP", null);
                    this._log.Create(responseIp + " => Response from Enable DHCP");
                    ManagementBaseObject newDns = moTemp.GetMethodParameters("SetDNSServerSearchOrder");
                    newDns["DNSServerSearchOrder"] = null;
                    this._log.Create(moTemp.InvokeMethod("SetDNSServerSearchOrder", newDns, null)?.ToString());

                    break;
                }
            }

            if (responseIp != null && responseIp.ToString().Equals("0"))
            {
                this._log.Create("DHCP enabled");
                CustomMessagebox.Display("IP will be set automatically.", "Done!");
            }
            else
            {
                if (responseIp != null)
                {
                    this._log.Create(
                        "Something fucked up. The response from Enable DHCP is not 0 and is " + responseIp
                                                                                              + " instead. Check Documentation for what it stands for.");
                }

                CustomMessagebox.Display("I guess something went wrong. Please report this issue.", "Uhh!");
            }
        }

        private void DHCP_checkbox_OnChange(object sender, EventArgs e)
        {
            this.ipCheckboxDisturbed = true;
            this.DisableIpTextboxes(this.DHCP_checkbox.Checked);
            this.isDhcpEnabled = this.DHCP_checkbox.Checked;
        }

        private void Proxy_checkbox_OnChange(object sender, EventArgs e)
        {
            this.proxyCheckboxDisturbed = true;
            this.DisableProxyTextboxes(this.proxy_checkbox.Checked);
        }

        private void DisableIpTextboxes(bool v)
        {
            v = !v;
            this.dns_textbox.Enabled = v;
            this.gateway_textbox.Enabled = v;
            this.subnet_textbox.Enabled = v;
            this.ip_textbox.Enabled = v;
            this.label4.ForeColor = v ? Color.FromArgb(255, 255, 255) : Color.FromArgb(100, 100, 100);
            this.label5.ForeColor = v ? Color.FromArgb(255, 255, 255) : Color.FromArgb(100, 100, 100);
            this.label6.ForeColor = v ? Color.FromArgb(255, 255, 255) : Color.FromArgb(100, 100, 100);
            this.label7.ForeColor = v ? Color.FromArgb(255, 255, 255) : Color.FromArgb(100, 100, 100);
        }

        private void DisableProxyTextboxes(bool v)
        {
            this.address_textbox.Enabled = v;
            this.port_textbox.Enabled = v;
            this.port_label.ForeColor = v ? Color.FromArgb(255, 255, 255) : Color.FromArgb(100, 100, 100);
            this.address_label.ForeColor = v ? Color.FromArgb(255, 255, 255) : Color.FromArgb(100, 100, 100);
        }

        #region Error sign display wnen invalid stuff

        private void IpTextboxTextChanged(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = !this.ValidateIPv4(((TextBox)sender).Text);
        }

        private void SubnetTextboxTextChanged(object sender, EventArgs e)
        {
            this.pictureBox2.Visible = !this.ValidateIPv4(((TextBox)sender).Text);
        }

        private void GatewayTextboxTextChanged(object sender, EventArgs e)
        {
            this.pictureBox3.Visible = !this.ValidateIPv4(((TextBox)sender).Text);
        }

        private void DnsTextboxTextChanged(object sender, EventArgs e)
        {
            this.pictureBox4.Visible = !this.ValidateIPv4(((TextBox)sender).Text);
        }

        #endregion

        private bool ValidateIPv4(string ipString)
        {
            if (string.IsNullOrWhiteSpace(ipString))
            {
                return true;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            return splitValues.All(r => byte.TryParse(r, out byte _));
        }

        private void Panel1MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        ///     Must be set for all error pictures. Need to know how to get the calling control name to replace with pictureBox1
        ///     here.
        ///     Update: https://stackoverflow.com/questions/2681949/get-name-of-control-calling-method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxMouseHover(object sender, EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip((Control)sender, "Invalid");
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }

        private void ApplyButtonClick(object sender, EventArgs e)
        {
            this._log.Create("OKAY finalizing things. Apply button was clicked");
            if (this.ipCheckboxDisturbed)
            {
                this._log.Create("ip_checkbox_disturbed => True");
                if (this.isDhcpEnabled)
                {
                    this._log.Create("DHCP checkbox was clicked. Automatic IP is being called...");
                    this.AutomaticIp();
                }
                else
                {
                    this._log.Create("DHCP checkbox was not enabled. Trying to set IP manually.");

                    if (this.pictureBox1.Visible || this.pictureBox2.Visible || this.pictureBox3.Visible || this.pictureBox4.Visible
                        || !this.allGood)
                    {
                        this._log.Create("Something is Invalid or get_data returned false (not all good). ");
                        CustomMessagebox.Display("Please correct the errors above and try again.");
                        return;
                    }

                    this.ipAdd = this.ip_textbox.Text.Length > 0 ? this.ip_textbox.Text : this.current_ip_sol.Text;
                    this.subNet = this.subnet_textbox.Text.Length > 0 ? this.subnet_textbox.Text : this.current_subnet_sol.Text;
                    this.gateway = this.gateway_textbox.Text.Length > 0 ? this.gateway_textbox.Text : this.current_gateway_sol.Text;
                    this.dns = this.dns_textbox.Text.Length > 0 ? this.dns_textbox.Text : this.current_dns_sol.Text;

                    this.SetIp();
                }
            }

            if (this.proxyCheckboxDisturbed)
            {
                this._log.Create("proxy_checkbox_disturbed => True");

                this.proxyAddress = this.address_textbox.Text.Length > 0 && this.port_textbox.Text.Length > 0
                                        ? this.address_textbox.Text + ":" + this.port_textbox.Text
                                        : Eproxy.ProxyServer;

                this._log.Create("proxy_address => " + this.proxyAddress);
                this._log.Create("I guess everything was good. Sending for proxy completion");
                this.SetProxy();
            }

            this._log.Create("Sending for Proxy fetching");
            this.GetProxy();
            this._log.Create("Sending for IP fetching");
            this.GetIp();
            this._log.Create("Sending for Data Updating");
            this.UpdateCurrentData();
            CustomMessagebox.Display("Task Complete", "Yippie!");
        }

        private void ChipsetSelectorSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isFirstRun)
            {
                return;
            }

            this.ourTargetChipSet = this.chipset_selector.Text;
            this.label9.Focus();
            this.Improvise();
        }

        private void RemoveFocus(object sender, EventArgs e)
        {
            this.label9.Focus();
        }

        private void Form1FormClosing(object sender, FormClosingEventArgs e)
        {
            this._log.Str.WriteLine("-------------------------------------------------------\n\n\n");
            this._log.Str.Dispose();
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            this.Opacity -= .07;
            if (this.Opacity <= .07)
            {
                this.Close();
            }
        }
    }
}