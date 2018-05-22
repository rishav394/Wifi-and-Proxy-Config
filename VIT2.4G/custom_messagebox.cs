using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIT2._4G
{
    public partial class custom_messagebox : Form
    {
        private static DialogResult dr;
        public custom_messagebox()
        {
            InitializeComponent();

        }
        public static DialogResult Display(string description, string title="", 
            MessageBoxButtons messageBoxButtons=MessageBoxButtons.OK)
        {
            custom_messagebox messageBox = new custom_messagebox();
            if (messageBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                messageBox.panel3.Enabled = true;
                messageBox.panel3.Visible = true;
                System.Media.SystemSounds.Hand.Play();
            }
            messageBox.label1.Text = title;
            messageBox.label2.Text = description;
            messageBox.ShowDialog();
            if (dr == DialogResult.OK && messageBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                dr = DialogResult.Ignore;
            }
            return dr;
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            dr = DialogResult.OK;
            Close();
        }

        #region Making the Panel1 movable

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

        private void Button1_Click(object sender, EventArgs e)
        {
            dr = DialogResult.Abort;
            Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            dr = DialogResult.Ignore;
            Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            dr = DialogResult.Retry;
            Close();
        }

    }
}
