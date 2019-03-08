using System;
using System.Windows.Forms;

namespace VIT2._4G
{
    public partial class CustomMessagebox : Form
    {
        private static DialogResult _dr;

        private CustomMessagebox()
        {
            InitializeComponent();
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
            if (_dr == DialogResult.OK && messageBoxButtons == MessageBoxButtons.AbortRetryIgnore) _dr = DialogResult.Ignore;

            return _dr;
        }

        private void Button3Click(object sender,
            EventArgs e)
        {
            _dr = DialogResult.OK;
            Close();
        }

        #region Making the Panel1 movable

        /// <summary>
        /// From codeproject. This shit makes a border-less from movable.
        /// </summary>
        private const int WmNclbuttondown = 0xA1;

        private const int HtCaption = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
            int msg,
            int wParam,
            int lParam);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

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

        #endregion

        private void Button1Click(object sender,
            EventArgs e)
        {
            _dr = DialogResult.Abort;
            Close();
        }

        private void Button4Click(object sender,
            EventArgs e)
        {
            _dr = DialogResult.Ignore;
            Close();
        }

        private void Button5Click(object sender,
            EventArgs e)
        {
            _dr = DialogResult.Retry;
            Close();
        }

        private void AbortButtonMouseEnter(object sender,
            EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip(abort_button,
                "Abort");
        }

        private void IgnoreButtonMouseEnter(object sender,
            EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip(ignore_button,
                "Ignore");
        }

        private void RetryButtonMouseEnter(object sender,
            EventArgs e)
        {
            var tt = new ToolTip();
            tt.SetToolTip(retry_button,
                "Retry");
        }
    }
}