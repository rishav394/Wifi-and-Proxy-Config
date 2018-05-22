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

        Log _log = new Log(true);

               
        #region Placeholder's crap
        /// <summary>
        /// SendMessage import
        /// Specifically used in this case for setting placeholder text for text controls
        /// </summary>
        /// <param name="hWnd">IntPtr</param>
        /// <param name="msg">int</param>
        /// <param name="wParam">int</param>
        /// <param name="lParam">[MarshalAs(UnmanagedType.LPWStr)]string</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        #endregion

        #region Making the Panel1 movable crap

        /// <summary>
        /// From codeproject. This shit makes a borderless from movable.
        /// </summary>

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        /// <summary>
        /// Required datas with default values
        /// </summary>
        private string proxy_address;
        private string ipadd;
        private string subnet;
        private string gateway;
        private string dns;
        private bool isDHCPEnabled;
        private bool isProxyEnabled;


        private string _wifi;            // = "[00000011] Realtek RTL8188EE 802.11 bgn Wi-Fi Adapter";
        private bool isFirstRun=true;
        private bool allgood = true;
        
        public Form1()
        {
            InitializeComponent();

            Select_wifi_chipset();

            apply_button.ForeColor = Color.FromArgb(100,100,100);

            _improvise();

        }

        private void Select_wifi_chipset()
        {

            foreach (ManagementObject monew in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                chipset_selector.Items.Add(monew["Caption"]);
                if (monew["Caption"].ToString().Contains("Wi-Fi"))
                {
                    chipset_selector.SelectedIndex = chipset_selector.Items.Count - 1;
                    _wifi = monew["Caption"].ToString();
                }
            }
        }

        private void _improvise()
        {
            allgood = Get_current_data();
            if (allgood)
            {
                apply_button.ForeColor = Color.White;

                Update_current_data();             //We are connected to a wifi and have a valid address

                /// <summary>
                /// Sets placeholder text for text controls
                /// </summary>
                try
                {
                    SendMessage(address_textbox.Handle, EM_SETCUEBANNER, 0, proxy_address.Split(':')[0]);
                    SendMessage(port_textbox.Handle, EM_SETCUEBANNER, 0, proxy_address.Split(':')[1]);
                }
                catch
                {
                    SendMessage(address_textbox.Handle, EM_SETCUEBANNER, 0, "none");
                    SendMessage(port_textbox.Handle, EM_SETCUEBANNER, 0, "none");
                }
                SendMessage(ip_textbox.Handle, EM_SETCUEBANNER, 0, ipadd);
                SendMessage(subnet_textbox.Handle, EM_SETCUEBANNER, 0, subnet);
                SendMessage(gateway_textbox.Handle, EM_SETCUEBANNER, 0, gateway);
                SendMessage(dns_textbox.Handle, EM_SETCUEBANNER, 0, dns);
            }
            
        }

        #region Alternate SetIP
        //private void Set_ip()
        //{
        //    ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        //    ManagementObjectCollection moc = mc.GetInstances();

        //    foreach (ManagementObject mo in moc)
        //    {
        //        try
        //        {

        //            if (mo["Caption"].Equals("[00000011] Realtek RTL8188EE 802.11 bgn Wi-Fi Adapter"))
        //            {
        //                MessageBox.Show(ipadd+"Setting");
        //                ManagementBaseObject newIP =
        //                    mo.GetMethodParameters("EnableStatic");
        //                ManagementBaseObject newGate =
        //                    mo.GetMethodParameters("SetGateways");
        //                ManagementBaseObject newDNS =
        //                    mo.GetMethodParameters("SetDNSServerSearchOrder");

        //                newGate["DefaultIPGateway"] = new string[] { gateway };
        //                newGate["GatewayCostMetric"] = new int[] { 1 };

        //                newIP["IPAddress"] = ipadd.Split(',') ;
        //                newIP["SubnetMask"] = new string[] { subnet };


        //                newDNS["DNSServerSearchOrder"] = dns.Split(',');


        //                ManagementBaseObject setIP = mo.InvokeMethod(
        //                    "EnableStatic", newIP, null);
        //                ManagementBaseObject setGateways = mo.InvokeMethod(
        //                    "SetGateways", newGate, null);
        //                ManagementBaseObject setDNS = mo.InvokeMethod(
        //                    "SetDNSServerSearchOrder", newDNS, null);

        //                break;
        //            }
        //        }
        //        catch(Exception ep)
        //        {
        //            MessageBox.Show(ep.ToString(), "Fatal error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }

        //    }
        //    Get_current_data();
        //    Update_current_data();
        //}

        #endregion

        public void Set_ip()
        {
            _log.Create("Testing for isDHCPEnabled?");
            if(!isDHCPEnabled)
            {
                _log.Create("No it is not. Setting static IP");
                foreach (ManagementObject objMO in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        ManagementBaseObject newIP = objMO.GetMethodParameters("EnableStatic");
                        newIP["IPAddress"] = new string[] { ipadd };
                        newIP["SubnetMask"] = new string[] { subnet };
                        
                        ManagementBaseObject newGate= objMO.GetMethodParameters("SetGateways");
                        newGate["DefaultIPGateway"] = new string[] { gateway };
                        newGate["GatewayCostMetric"] = new int[] { 1 };

                        ManagementBaseObject newDNS = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        newDNS["DNSServerSearchOrder"] = dns.Split(',');


                        _log.Create(objMO.InvokeMethod("EnableStatic", newIP, null).ToString());
                        _log.Create(objMO.InvokeMethod("SetGateways", newGate, null).ToString());
                        _log.Create(objMO.InvokeMethod("SetDNSServerSearchOrder", newDNS, null).ToString());
                        
                    }
                }
                return;
            }
            _log.Create("Yes DHCP is enabled. IP already set Dynamically.");
        }

        private void Update_current_data()      // Into Current info group box
        {
            DHCP_checkbox.Checked = isDHCPEnabled;
            proxy_checkbox.Checked = isProxyEnabled;

            Disable_IP_textboxes(isDHCPEnabled);
            Disable_Proxy_textboxes(isProxyEnabled);

            current_ip_sol.Text = ipadd;
            current_dns_sol.Text = dns;
            current_subnet_sol.Text = subnet;
            current_gateway_sol.Text = gateway;
            current_proxy_sol.Text = isProxyEnabled?proxy_address:"Disabled";

        }

        private bool Get_current_data()
        {
            Getproxy();
            return (Get_ip());       //returns false if an exception was throws earlier and we are not collected to a wifi with aproper address
        }

        private void Getproxy()
        {
            _log.Create("Getting proxy");
            isProxyEnabled = IEproxy.ProxyEnabled;
            _log.Create(IEproxy.ProxyEnabled.ToString()+" => is the proxyEnabled");
            proxy_address = IEproxy.ProxyServer;
        }

        private void Setproxy()
        {
            if (proxy_checkbox.Checked)
            {
                _log.Create("Setting proxy from input as "+proxy_address);
                IEproxy.ProxyEnabled = true;
                IEproxy.ProxyServer = proxy_address;
            }
            else
            {
                _log.Create("User wants to remove proxy. This case is not similar to IP one " +
                    "as we are not calling a new function `No_proxy` in the checkbox changed event. All" +
                    " the changes are happening only after onApplyButton Click event");
                IEproxy.ProxyEnabled = false;
            }
        }

        
        #region Old method of IP extraction
        /*
         * An old method
        public void GetLocalIPv4andSubnet(NetworkInterfaceType _type)
        {
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation unicastIPAddressInformation in item.GetIPProperties().UnicastAddresses)
                    {
                        if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipadd = unicastIPAddressInformation.Address.ToString();
                            subnet = unicastIPAddressInformation.IPv4Mask.ToString();
                            gateway = unicastIPAddressInformation.SuffixOrigin.ToString();
                            return;
                        }
                    }
                }
            }
            throw new ArgumentException(string.Format("Can't find subnetmask for IP address '{0}'", address));

        }
        */
        #endregion

        public bool Get_ip()
        {
            try
            {

                foreach (ManagementObject mo in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
                {
                    
                    if (mo["Caption"].Equals(_wifi))
                    {
                        isDHCPEnabled = (bool)mo.Properties["DHCPEnabled"].Value;
                        ipadd = ((string[])mo["IPAddress"])[0];
                        subnet = ((string[])mo["IPSubnet"])[0];
                        gateway = ((string[])mo["DefaultIPGateway"])[0];
                        dns = ((string[])mo["DNSServerSearchOrder"])[0];
                        break;
                    }

                }
            }
            catch
            {
                switch(custom_messagebox.Display("You are not connected to the specified chipset or " +
                    "your IP address is invalid. The data processed IS UTTER CRAP.",
                    "Connection Error", MessageBoxButtons.AbortRetryIgnore))
                {
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Retry:_improvise();
                        break;
                    case DialogResult.None:
                    case DialogResult.Abort:
                    default:
                        Environment.Exit(1);
                        break;
                }
                
                return false;
            }
            return true;
        }


   
        private void Button_mini_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void Button_close_Click(object sender, EventArgs e) => Application.Exit();

        private void Button_close_MouseEnter(object sender, EventArgs e) => button_close.BackColor = Color.Red;

        private void Button_close_MouseLeave(object sender, EventArgs e) => button_close.BackColor = Color.Black;


        private void DHCP_checkbox_OnChange(object sender, EventArgs e)
        {
            Disable_IP_textboxes(DHCP_checkbox.Checked);
            if (DHCP_checkbox.Checked)
            {
                Automatic_IP();
            }
            isDHCPEnabled = DHCP_checkbox.Checked;
        }

        private void Automatic_IP()
        {

            object response_ip = null;
            foreach (ManagementObject motemp in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                if (motemp["Caption"].Equals(_wifi))
                {
                    response_ip = motemp.InvokeMethod("EnableDHCP", null);
                    _log.Create(response_ip.ToString() + " => Response from Enable DHCP");
                    ManagementBaseObject newDNS = motemp.GetMethodParameters("SetDNSServerSearchOrder");
                    newDNS["DNSServerSearchOrder"] = null;
                    _log.Create(motemp.InvokeMethod("SetDNSServerSearchOrder", newDNS, null).ToString());

                    break;
                }
            }

            Get_ip();
            Update_current_data();
            if(response_ip.ToString().Equals("0"))
            {
                _log.Create("DHCP enabled");
                custom_messagebox.Display("IP will be set automatically.", "Done!");
            }
            else
            {
                _log.Create("Something fucked up. The response from Enable DHCP is not 0 and is " 
                    + response_ip.ToString() + " instead. Check Documentation for what it stands for.");
                custom_messagebox.Display("I guess something went wrong. Please report this issue.", "Uhh!");
            }
        }

        private void Disable_IP_textboxes(bool v)
        {
            v = !v;
            dns_textbox.Enabled = v;
            gateway_textbox.Enabled = v;
            subnet_textbox.Enabled = v;
            ip_textbox.Enabled = v;
            label4.ForeColor = v ? (Color.FromArgb(255, 255, 255)) : (Color.FromArgb(100, 100, 100));
            label5.ForeColor = v ? (Color.FromArgb(255, 255, 255)) : (Color.FromArgb(100, 100, 100));
            label6.ForeColor = v ? (Color.FromArgb(255, 255, 255)) : (Color.FromArgb(100, 100, 100));
            label7.ForeColor = v ? (Color.FromArgb(255, 255, 255)) : (Color.FromArgb(100, 100, 100));
        }

        private void Proxy_checkbox_OnChange(object sender, EventArgs e)
        {
            Disable_Proxy_textboxes(proxy_checkbox.Checked);
        }

        private void Disable_Proxy_textboxes(bool v)
        {
            address_textbox.Enabled = v;
            port_textbox.Enabled = v;
            port_label.ForeColor = v ? (Color.FromArgb(255, 255, 255)) : (Color.FromArgb(100, 100, 100));
            address_label.ForeColor = v ? (Color.FromArgb(255, 255, 255)) : (Color.FromArgb(100, 100, 100));
        }

        #region Error sign display wnen invalid stuff
        private void Ip_textbox_TextChanged(object sender, EventArgs e)
        {
            if (ValidateIPv4(ip_textbox.Text))
            {
                pictureBox1.Visible = false;
            }
            else
            {
                pictureBox1.Visible = true;
            }
        }

        private void Subnet_textbox_TextChanged(object sender, EventArgs e)
        {
            if (ValidateIPv4(subnet_textbox.Text))
            {
                pictureBox2.Visible = false;
            }
            else
            {
                pictureBox2.Visible = true;
            }
        }

        private void Gateway_textbox_TextChanged(object sender, EventArgs e)
        {
            if (ValidateIPv4(gateway_textbox.Text))
            {
                pictureBox3.Visible = false;
            }
            else
            {
                pictureBox3.Visible = true;
            }
        }

        private void Dns_textbox_TextChanged(object sender, EventArgs e)
        {
            if (ValidateIPv4(dns_textbox.Text))
            {
                pictureBox4.Visible = false;
            }
            else
            {
                pictureBox4.Visible = true;
            }
        }
        #endregion

        public bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return true;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }


            return splitValues.All(r => byte.TryParse(r, out byte tempForParsing));
        }

        private void PictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox1, "Invalid");
        }

        private void Cancel_button_Click(object sender, EventArgs e) => Application.Exit();

        private void Apply_button_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Visible || pictureBox2.Visible || pictureBox3.Visible || pictureBox4.Visible || !allgood)
            {
                return;
            }
            ipadd = (ip_textbox.Text.Length > 0 ? ip_textbox.Text : current_ip_sol.Text);
            subnet = (subnet_textbox.Text.Length > 0 ? subnet_textbox.Text : current_subnet_sol.Text);
            gateway = (gateway_textbox.Text.Length > 0 ? gateway_textbox.Text : current_gateway_sol.Text);
            dns = (dns_textbox.Text.Length > 0 ? dns_textbox.Text : current_dns_sol.Text);
            proxy_address = address_textbox.Text + ":" + port_textbox.Text;
            _log.Create(proxy_address + " is being set.");
            Setproxy();
            Getproxy();
            Set_ip();
            Get_ip();
            Update_current_data();
            custom_messagebox.Display("Task Complete","Yippie!");
        }

        private void Chipset_selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFirstRun)
            {
                isFirstRun = false;
                return;
            }
            _wifi = chipset_selector.Text;
            label9.Focus();
            _improvise();
        }


        private void Remove_focus(object sender, EventArgs e) => label9.Focus();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void proxy_groupbox_Enter(object sender, EventArgs e)
        {

        }
    }
}
