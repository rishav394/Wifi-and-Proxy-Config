namespace VIT2._4G
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chipset_selector = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cancel_button = new System.Windows.Forms.Button();
            this.apply_button = new System.Windows.Forms.Button();
            this.current_groupbox = new System.Windows.Forms.GroupBox();
            this.current_proxy_sol = new System.Windows.Forms.Label();
            this.current_dns_sol = new System.Windows.Forms.Label();
            this.current_gateway_sol = new System.Windows.Forms.Label();
            this.current_subnet_sol = new System.Windows.Forms.Label();
            this.current_ip_sol = new System.Windows.Forms.Label();
            this.current_proxy = new System.Windows.Forms.Label();
            this.current_dns = new System.Windows.Forms.Label();
            this.current_gateway = new System.Windows.Forms.Label();
            this.current_subnet = new System.Windows.Forms.Label();
            this.current_ip = new System.Windows.Forms.Label();
            this.proxy_groupbox = new System.Windows.Forms.GroupBox();
            this.Innet_proxy_groupbox = new System.Windows.Forms.GroupBox();
            this.port_textbox = new System.Windows.Forms.TextBox();
            this.address_textbox = new System.Windows.Forms.TextBox();
            this.port_label = new System.Windows.Forms.Label();
            this.address_label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dns_textbox = new System.Windows.Forms.TextBox();
            this.gateway_textbox = new System.Windows.Forms.TextBox();
            this.subnet_textbox = new System.Windows.Forms.TextBox();
            this.ip_textbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IP_groupbo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.proxy_checkbox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.DHCP_checkbox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_mini = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.current_groupbox.SuspendLayout();
            this.proxy_groupbox.SuspendLayout();
            this.Innet_proxy_groupbox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.IP_groupbo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_mini);
            this.panel1.Controls.Add(this.button_close);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 37);
            this.panel1.TabIndex = 1;
            this.panel1.MouseCaptureChanged += new System.EventHandler(this.Remove_focus);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.5F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "WIFI AND PROXY CONFIG";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.cancel_button);
            this.panel2.Controls.Add(this.apply_button);
            this.panel2.Controls.Add(this.current_groupbox);
            this.panel2.Controls.Add(this.proxy_groupbox);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.IP_groupbo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 656);
            this.panel2.TabIndex = 0;
            this.panel2.Click += new System.EventHandler(this.Remove_focus);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chipset_selector);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(17, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(576, 46);
            this.panel3.TabIndex = 6;
            this.panel3.Click += new System.EventHandler(this.Remove_focus);
            // 
            // chipset_selector
            // 
            this.chipset_selector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chipset_selector.FormattingEnabled = true;
            this.chipset_selector.Location = new System.Drawing.Point(134, 10);
            this.chipset_selector.Name = "chipset_selector";
            this.chipset_selector.Size = new System.Drawing.Size(421, 25);
            this.chipset_selector.TabIndex = 9;
            this.chipset_selector.SelectedIndexChanged += new System.EventHandler(this.Chipset_selector_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Network Card:";
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_button.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.cancel_button.Location = new System.Drawing.Point(492, 610);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(103, 34);
            this.cancel_button.TabIndex = 5;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // apply_button
            // 
            this.apply_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply_button.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.apply_button.Location = new System.Drawing.Point(340, 610);
            this.apply_button.Name = "apply_button";
            this.apply_button.Size = new System.Drawing.Size(145, 34);
            this.apply_button.TabIndex = 4;
            this.apply_button.Text = "Apply Config";
            this.apply_button.UseVisualStyleBackColor = true;
            this.apply_button.Click += new System.EventHandler(this.Apply_button_Click);
            // 
            // current_groupbox
            // 
            this.current_groupbox.Controls.Add(this.current_proxy_sol);
            this.current_groupbox.Controls.Add(this.current_dns_sol);
            this.current_groupbox.Controls.Add(this.current_gateway_sol);
            this.current_groupbox.Controls.Add(this.current_subnet_sol);
            this.current_groupbox.Controls.Add(this.current_ip_sol);
            this.current_groupbox.Controls.Add(this.current_proxy);
            this.current_groupbox.Controls.Add(this.current_dns);
            this.current_groupbox.Controls.Add(this.current_gateway);
            this.current_groupbox.Controls.Add(this.current_subnet);
            this.current_groupbox.Controls.Add(this.current_ip);
            this.current_groupbox.ForeColor = System.Drawing.Color.White;
            this.current_groupbox.Location = new System.Drawing.Point(19, 421);
            this.current_groupbox.Name = "current_groupbox";
            this.current_groupbox.Size = new System.Drawing.Size(576, 179);
            this.current_groupbox.TabIndex = 3;
            this.current_groupbox.TabStop = false;
            this.current_groupbox.Text = "Current Configuration";
            this.current_groupbox.MouseCaptureChanged += new System.EventHandler(this.Remove_focus);
            // 
            // current_proxy_sol
            // 
            this.current_proxy_sol.AutoSize = true;
            this.current_proxy_sol.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.current_proxy_sol.ForeColor = System.Drawing.Color.White;
            this.current_proxy_sol.Location = new System.Drawing.Point(128, 154);
            this.current_proxy_sol.Name = "current_proxy_sol";
            this.current_proxy_sol.Size = new System.Drawing.Size(12, 17);
            this.current_proxy_sol.TabIndex = 4;
            this.current_proxy_sol.Text = " ";
            // 
            // current_dns_sol
            // 
            this.current_dns_sol.AutoSize = true;
            this.current_dns_sol.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.current_dns_sol.ForeColor = System.Drawing.Color.White;
            this.current_dns_sol.Location = new System.Drawing.Point(128, 122);
            this.current_dns_sol.Name = "current_dns_sol";
            this.current_dns_sol.Size = new System.Drawing.Size(12, 17);
            this.current_dns_sol.TabIndex = 3;
            this.current_dns_sol.Text = " ";
            // 
            // current_gateway_sol
            // 
            this.current_gateway_sol.AutoSize = true;
            this.current_gateway_sol.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.current_gateway_sol.ForeColor = System.Drawing.Color.White;
            this.current_gateway_sol.Location = new System.Drawing.Point(128, 89);
            this.current_gateway_sol.Name = "current_gateway_sol";
            this.current_gateway_sol.Size = new System.Drawing.Size(12, 17);
            this.current_gateway_sol.TabIndex = 2;
            this.current_gateway_sol.Text = " ";
            // 
            // current_subnet_sol
            // 
            this.current_subnet_sol.AutoSize = true;
            this.current_subnet_sol.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.current_subnet_sol.ForeColor = System.Drawing.Color.White;
            this.current_subnet_sol.Location = new System.Drawing.Point(128, 61);
            this.current_subnet_sol.Name = "current_subnet_sol";
            this.current_subnet_sol.Size = new System.Drawing.Size(12, 17);
            this.current_subnet_sol.TabIndex = 1;
            this.current_subnet_sol.Text = " ";
            // 
            // current_ip_sol
            // 
            this.current_ip_sol.AutoSize = true;
            this.current_ip_sol.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.current_ip_sol.ForeColor = System.Drawing.Color.White;
            this.current_ip_sol.Location = new System.Drawing.Point(128, 31);
            this.current_ip_sol.Name = "current_ip_sol";
            this.current_ip_sol.Size = new System.Drawing.Size(12, 17);
            this.current_ip_sol.TabIndex = 0;
            this.current_ip_sol.Text = " ";
            // 
            // current_proxy
            // 
            this.current_proxy.AutoSize = true;
            this.current_proxy.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.current_proxy.ForeColor = System.Drawing.Color.White;
            this.current_proxy.Location = new System.Drawing.Point(18, 151);
            this.current_proxy.Name = "current_proxy";
            this.current_proxy.Size = new System.Drawing.Size(45, 17);
            this.current_proxy.TabIndex = 9;
            this.current_proxy.Text = "Proxy:";
            // 
            // current_dns
            // 
            this.current_dns.AutoSize = true;
            this.current_dns.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.current_dns.ForeColor = System.Drawing.Color.White;
            this.current_dns.Location = new System.Drawing.Point(18, 121);
            this.current_dns.Name = "current_dns";
            this.current_dns.Size = new System.Drawing.Size(38, 17);
            this.current_dns.TabIndex = 8;
            this.current_dns.Text = "DNS:";
            // 
            // current_gateway
            // 
            this.current_gateway.AutoSize = true;
            this.current_gateway.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.current_gateway.ForeColor = System.Drawing.Color.White;
            this.current_gateway.Location = new System.Drawing.Point(18, 91);
            this.current_gateway.Name = "current_gateway";
            this.current_gateway.Size = new System.Drawing.Size(72, 17);
            this.current_gateway.TabIndex = 7;
            this.current_gateway.Text = "Gateway:";
            // 
            // current_subnet
            // 
            this.current_subnet.AutoSize = true;
            this.current_subnet.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.current_subnet.ForeColor = System.Drawing.Color.White;
            this.current_subnet.Location = new System.Drawing.Point(18, 61);
            this.current_subnet.Name = "current_subnet";
            this.current_subnet.Size = new System.Drawing.Size(56, 17);
            this.current_subnet.TabIndex = 6;
            this.current_subnet.Text = "Subnet:";
            // 
            // current_ip
            // 
            this.current_ip.AutoSize = true;
            this.current_ip.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.current_ip.ForeColor = System.Drawing.Color.White;
            this.current_ip.Location = new System.Drawing.Point(18, 31);
            this.current_ip.Name = "current_ip";
            this.current_ip.Size = new System.Drawing.Size(23, 17);
            this.current_ip.TabIndex = 5;
            this.current_ip.Text = "IP:";
            // 
            // proxy_groupbox
            // 
            this.proxy_groupbox.Controls.Add(this.Innet_proxy_groupbox);
            this.proxy_groupbox.Controls.Add(this.proxy_checkbox);
            this.proxy_groupbox.Controls.Add(this.label8);
            this.proxy_groupbox.ForeColor = System.Drawing.Color.White;
            this.proxy_groupbox.Location = new System.Drawing.Point(17, 254);
            this.proxy_groupbox.Name = "proxy_groupbox";
            this.proxy_groupbox.Size = new System.Drawing.Size(576, 152);
            this.proxy_groupbox.TabIndex = 1;
            this.proxy_groupbox.TabStop = false;
            this.proxy_groupbox.Text = "Internet Proxy";
            this.proxy_groupbox.Enter += new System.EventHandler(this.proxy_groupbox_Enter);
            this.proxy_groupbox.MouseCaptureChanged += new System.EventHandler(this.Remove_focus);
            // 
            // Innet_proxy_groupbox
            // 
            this.Innet_proxy_groupbox.Controls.Add(this.port_textbox);
            this.Innet_proxy_groupbox.Controls.Add(this.address_textbox);
            this.Innet_proxy_groupbox.Controls.Add(this.port_label);
            this.Innet_proxy_groupbox.Controls.Add(this.address_label);
            this.Innet_proxy_groupbox.ForeColor = System.Drawing.Color.White;
            this.Innet_proxy_groupbox.Location = new System.Drawing.Point(21, 59);
            this.Innet_proxy_groupbox.Name = "Innet_proxy_groupbox";
            this.Innet_proxy_groupbox.Size = new System.Drawing.Size(531, 75);
            this.Innet_proxy_groupbox.TabIndex = 1;
            this.Innet_proxy_groupbox.TabStop = false;
            this.Innet_proxy_groupbox.Text = "Proxy";
            // 
            // port_textbox
            // 
            this.port_textbox.Location = new System.Drawing.Point(413, 29);
            this.port_textbox.Name = "port_textbox";
            this.port_textbox.Size = new System.Drawing.Size(96, 23);
            this.port_textbox.TabIndex = 1;
            // 
            // address_textbox
            // 
            this.address_textbox.Location = new System.Drawing.Point(103, 29);
            this.address_textbox.Name = "address_textbox";
            this.address_textbox.Size = new System.Drawing.Size(232, 23);
            this.address_textbox.TabIndex = 0;
            // 
            // port_label
            // 
            this.port_label.AutoSize = true;
            this.port_label.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.port_label.ForeColor = System.Drawing.Color.White;
            this.port_label.Location = new System.Drawing.Point(355, 35);
            this.port_label.Name = "port_label";
            this.port_label.Size = new System.Drawing.Size(38, 17);
            this.port_label.TabIndex = 3;
            this.port_label.Text = "Port:";
            // 
            // address_label
            // 
            this.address_label.AutoSize = true;
            this.address_label.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.address_label.ForeColor = System.Drawing.Color.White;
            this.address_label.Location = new System.Drawing.Point(22, 35);
            this.address_label.Name = "address_label";
            this.address_label.Size = new System.Drawing.Size(61, 17);
            this.address_label.TabIndex = 2;
            this.address_label.Text = "Address:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(49, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Enable Proxy";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.DHCP_checkbox);
            this.groupBox1.Controls.Add(this.dns_textbox);
            this.groupBox1.Controls.Add(this.gateway_textbox);
            this.groupBox1.Controls.Add(this.subnet_textbox);
            this.groupBox1.Controls.Add(this.ip_textbox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(17, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP Configration";
            this.groupBox1.MouseCaptureChanged += new System.EventHandler(this.Remove_focus);
            // 
            // dns_textbox
            // 
            this.dns_textbox.Location = new System.Drawing.Point(134, 147);
            this.dns_textbox.Name = "dns_textbox";
            this.dns_textbox.Size = new System.Drawing.Size(421, 23);
            this.dns_textbox.TabIndex = 3;
            this.dns_textbox.TextChanged += new System.EventHandler(this.Dns_textbox_TextChanged);
            // 
            // gateway_textbox
            // 
            this.gateway_textbox.Location = new System.Drawing.Point(134, 115);
            this.gateway_textbox.Name = "gateway_textbox";
            this.gateway_textbox.Size = new System.Drawing.Size(421, 23);
            this.gateway_textbox.TabIndex = 2;
            this.gateway_textbox.TextChanged += new System.EventHandler(this.Gateway_textbox_TextChanged);
            // 
            // subnet_textbox
            // 
            this.subnet_textbox.Location = new System.Drawing.Point(134, 82);
            this.subnet_textbox.Name = "subnet_textbox";
            this.subnet_textbox.Size = new System.Drawing.Size(421, 23);
            this.subnet_textbox.TabIndex = 1;
            this.subnet_textbox.TextChanged += new System.EventHandler(this.Subnet_textbox_TextChanged);
            // 
            // ip_textbox
            // 
            this.ip_textbox.Location = new System.Drawing.Point(134, 51);
            this.ip_textbox.Name = "ip_textbox";
            this.ip_textbox.Size = new System.Drawing.Size(421, 23);
            this.ip_textbox.TabIndex = 0;
            this.ip_textbox.TextChanged += new System.EventHandler(this.Ip_textbox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(21, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "DNS:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Gateway:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Subnet:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(21, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(47, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Obtain IP automatically from DHCP";
            // 
            // IP_groupbo
            // 
            this.IP_groupbo.BackColor = System.Drawing.Color.Black;
            this.IP_groupbo.Controls.Add(this.label2);
            this.IP_groupbo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IP_groupbo.ForeColor = System.Drawing.Color.White;
            this.IP_groupbo.Location = new System.Drawing.Point(17, 58);
            this.IP_groupbo.Name = "IP_groupbo";
            this.IP_groupbo.Size = new System.Drawing.Size(576, 180);
            this.IP_groupbo.TabIndex = 0;
            this.IP_groupbo.TabStop = false;
            this.IP_groupbo.Text = "IP Configration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(47, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Obtain IP from DHCP";
            // 
            // proxy_checkbox
            // 
            this.proxy_checkbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.proxy_checkbox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.proxy_checkbox.Checked = true;
            this.proxy_checkbox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.proxy_checkbox.ForeColor = System.Drawing.Color.White;
            this.proxy_checkbox.Location = new System.Drawing.Point(24, 28);
            this.proxy_checkbox.Margin = new System.Windows.Forms.Padding(28, 27, 28, 27);
            this.proxy_checkbox.Name = "proxy_checkbox";
            this.proxy_checkbox.Size = new System.Drawing.Size(20, 20);
            this.proxy_checkbox.TabIndex = 0;
            this.proxy_checkbox.OnChange += new System.EventHandler(this.Proxy_checkbox_OnChange);
            // 
            // DHCP_checkbox
            // 
            this.DHCP_checkbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DHCP_checkbox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.DHCP_checkbox.Checked = false;
            this.DHCP_checkbox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DHCP_checkbox.ForeColor = System.Drawing.Color.White;
            this.DHCP_checkbox.Location = new System.Drawing.Point(21, 22);
            this.DHCP_checkbox.Margin = new System.Windows.Forms.Padding(21, 21, 21, 21);
            this.DHCP_checkbox.Name = "DHCP_checkbox";
            this.DHCP_checkbox.Size = new System.Drawing.Size(20, 20);
            this.DHCP_checkbox.TabIndex = 0;
            this.DHCP_checkbox.OnChange += new System.EventHandler(this.DHCP_checkbox_OnChange);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(96, 147);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(25, 25);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            this.pictureBox4.MouseEnter += new System.EventHandler(this.PictureBox_MouseHover);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(96, 115);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox3.MouseEnter += new System.EventHandler(this.PictureBox_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(96, 83);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.MouseEnter += new System.EventHandler(this.PictureBox_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(96, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.PictureBox_MouseHover);
            // 
            // button_mini
            // 
            this.button_mini.FlatAppearance.BorderSize = 0;
            this.button_mini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_mini.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_mini.Image = global::VIT2._4G.Properties.Resources.icons8_Minus_35px;
            this.button_mini.Location = new System.Drawing.Point(518, 0);
            this.button_mini.Name = "button_mini";
            this.button_mini.Size = new System.Drawing.Size(33, 35);
            this.button_mini.TabIndex = 1;
            this.button_mini.UseVisualStyleBackColor = true;
            this.button_mini.Click += new System.EventHandler(this.Button_mini_Click);
            // 
            // button_close
            // 
            this.button_close.FlatAppearance.BorderSize = 0;
            this.button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_close.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_close.Image = global::VIT2._4G.Properties.Resources.icons8_Multiply_35px;
            this.button_close.Location = new System.Drawing.Point(559, 0);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(45, 35);
            this.button_close.TabIndex = 2;
            this.button_close.Tag = "";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.Button_close_Click);
            this.button_close.MouseEnter += new System.EventHandler(this.Button_close_MouseEnter);
            this.button_close.MouseLeave += new System.EventHandler(this.Button_close_MouseLeave);
            // 
            // Form1
            // 
            this.AcceptButton = this.apply_button;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(607, 693);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.current_groupbox.ResumeLayout(false);
            this.current_groupbox.PerformLayout();
            this.proxy_groupbox.ResumeLayout(false);
            this.proxy_groupbox.PerformLayout();
            this.Innet_proxy_groupbox.ResumeLayout(false);
            this.Innet_proxy_groupbox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.IP_groupbo.ResumeLayout(false);
            this.IP_groupbo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_mini;
        private System.Windows.Forms.GroupBox current_groupbox;
        private System.Windows.Forms.GroupBox proxy_groupbox;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuCheckbox proxy_checkbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox Innet_proxy_groupbox;
        private System.Windows.Forms.TextBox port_textbox;
        private System.Windows.Forms.TextBox address_textbox;
        private System.Windows.Forms.Label port_label;
        private System.Windows.Forms.Label address_label;
        private System.Windows.Forms.Label current_proxy_sol;
        private System.Windows.Forms.Label current_dns_sol;
        private System.Windows.Forms.Label current_gateway_sol;
        private System.Windows.Forms.Label current_subnet_sol;
        private System.Windows.Forms.Label current_ip_sol;
        private System.Windows.Forms.Label current_proxy;
        private System.Windows.Forms.Label current_dns;
        private System.Windows.Forms.Label current_gateway;
        private System.Windows.Forms.Label current_subnet;
        private System.Windows.Forms.Label current_ip;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button apply_button;
        private System.Windows.Forms.GroupBox IP_groupbo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCheckbox DHCP_checkbox;
        private System.Windows.Forms.TextBox dns_textbox;
        private System.Windows.Forms.TextBox gateway_textbox;
        private System.Windows.Forms.TextBox subnet_textbox;
        private System.Windows.Forms.TextBox ip_textbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox chipset_selector;
        private System.Windows.Forms.Label label9;
    }
}

