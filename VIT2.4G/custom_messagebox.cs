﻿using System;
using System.Windows.Forms;

namespace VIT2._4G
{
    public partial class CustomMessagebox : Form
    {
        private static DialogResult _dr;

        public CustomMessagebox()
        {
            InitializeComponent();
        }
        public static DialogResult Display(string description, string title="", 
            MessageBoxButtons messageBoxButtons=MessageBoxButtons.OK)
        {
            // First declare an object of the type custom_messagebox
            var messageBox = new CustomMessagebox();

            // Not set the lables and the panels accordingly
            if (messageBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                messageBox.panel3.Enabled = true;
                messageBox.panel3.Visible = true;
                System.Media.SystemSounds.Hand.Play();
            }
            messageBox.label1.Text = title;
            messageBox.label2.Text = description;
            
            // When everything is set display the messbox we created above using ShowDialog()
            messageBox.ShowDialog();
            if (_dr == DialogResult.OK && messageBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                _dr = DialogResult.Ignore;
            }
            return _dr;
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            _dr = DialogResult.OK;
            Close();
        }

        #region Making the Panel1 movable

        /// <summary>
        /// From codeproject. This shit makes a border-less from movable.
        /// </summary>

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            _dr = DialogResult.Abort;
            Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            _dr = DialogResult.Ignore;
            Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            _dr = DialogResult.Retry;
            Close();
        }

        private void Abort_button_MouseEnter(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(abort_button, "Abort");
        }

        private void Ignore_button_MouseEnter(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(ignore_button, "Ignore");
        }

        private void Retry_button_MouseEnter(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(retry_button, "Retry");
        }
    }
}
