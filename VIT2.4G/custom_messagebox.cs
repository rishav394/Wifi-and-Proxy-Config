using System;
using System.Windows.Forms;

namespace VIT2._4G
{
    public partial class CustomMessagebox : Form
    {
        private static DialogResult dr;

        private CustomMessagebox()
        {
            this.InitializeComponent();
        }

        public static DialogResult Display(
            string description,
            string title = "",
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK)
        {
            // First declare an object of the type custom_message-box
            var messageBox = new CustomMessagebox();

            // Not set the labels and the panels accordingly
            if (messageBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                messageBox.panel3.Enabled = true;
                messageBox.panel3.Visible = true;
                System.Media.SystemSounds.Hand.Play();
            }

            messageBox.label1.Text = title;
            messageBox.label2.Text = description;

            // When everything is set display the message box we created above using ShowDialog()
            messageBox.ShowDialog();
            if (dr == DialogResult.OK && messageBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                dr = DialogResult.Ignore;
            }

            return dr;
        }

        private void Button3Click(object sender, EventArgs e)
        {
            dr = DialogResult.OK;
            this.Close();
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

        private void Panel1MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        private void Button1Click(object sender, EventArgs e)
        {
            dr = DialogResult.Abort;
            this.Close();
        }

        private void Button4Click(object sender, EventArgs e)
        {
            dr = DialogResult.Ignore;
            this.Close();
        }

        private void Button5Click(object sender, EventArgs e)
        {
            dr = DialogResult.Retry;
            this.Close();
        }

        private void AbortButtonMouseEnter(object sender, EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip(this.abort_button, "Abort");
        }

        private void IgnoreButtonMouseEnter(object sender, EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip(this.ignore_button, "Ignore");
        }

        private void RetryButtonMouseEnter(object sender, EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip(this.retry_button, "Retry");
        }
    }
}