namespace VIT2._4G
{
    partial class custom_messagebox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(custom_messagebox));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.close_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.retry_button = new System.Windows.Forms.Button();
            this.ignore_button = new System.Windows.Forms.Button();
            this.abort_button = new System.Windows.Forms.Button();
            this.ok_button = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.close_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 31);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // close_button
            // 
            this.close_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Image = global::VIT2._4G.Properties.Resources.icons8_Delete_64px;
            this.close_button.Location = new System.Drawing.Point(378, 3);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(25, 25);
            this.close_button.TabIndex = 0;
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.Button3_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.ok_button);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(409, 149);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.label2.Location = new System.Drawing.Point(126, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 80);
            this.label2.TabIndex = 2;
            this.label2.Text = "bunifuCustomLabel1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::VIT2._4G.Properties.Resources.icons8_Roadblock_96px;
            this.pictureBox1.Location = new System.Drawing.Point(12, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.retry_button);
            this.panel3.Controls.Add(this.ignore_button);
            this.panel3.Controls.Add(this.abort_button);
            this.panel3.Location = new System.Drawing.Point(143, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(259, 72);
            this.panel3.TabIndex = 4;
            this.panel3.Visible = false;
            // 
            // retry_button
            // 
            this.retry_button.FlatAppearance.BorderSize = 0;
            this.retry_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retry_button.Image = global::VIT2._4G.Properties.Resources.icons8_Synchronize_52px;
            this.retry_button.Location = new System.Drawing.Point(188, 10);
            this.retry_button.Name = "retry_button";
            this.retry_button.Size = new System.Drawing.Size(55, 55);
            this.retry_button.TabIndex = 0;
            this.retry_button.Tag = "Retry";
            this.retry_button.UseVisualStyleBackColor = true;
            this.retry_button.Click += new System.EventHandler(this.Button5_Click);
            this.retry_button.MouseHover += new System.EventHandler(this.Retry_button_MouseEnter);
            // 
            // ignore_button
            // 
            this.ignore_button.FlatAppearance.BorderSize = 0;
            this.ignore_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ignore_button.Image = global::VIT2._4G.Properties.Resources.icons8_Ignore_48px;
            this.ignore_button.Location = new System.Drawing.Point(105, 10);
            this.ignore_button.Name = "ignore_button";
            this.ignore_button.Size = new System.Drawing.Size(55, 55);
            this.ignore_button.TabIndex = 0;
            this.ignore_button.Tag = "Ignore";
            this.ignore_button.UseVisualStyleBackColor = true;
            this.ignore_button.Click += new System.EventHandler(this.Button4_Click);
            this.ignore_button.MouseHover += new System.EventHandler(this.Ignore_button_MouseEnter);
            // 
            // abort_button
            // 
            this.abort_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.abort_button.FlatAppearance.BorderSize = 0;
            this.abort_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.abort_button.Image = global::VIT2._4G.Properties.Resources.icons8_Unavailable_48px;
            this.abort_button.Location = new System.Drawing.Point(22, 10);
            this.abort_button.Name = "abort_button";
            this.abort_button.Size = new System.Drawing.Size(55, 55);
            this.abort_button.TabIndex = 0;
            this.abort_button.Tag = "Abort";
            this.abort_button.UseVisualStyleBackColor = true;
            this.abort_button.Click += new System.EventHandler(this.Button1_Click);
            this.abort_button.MouseHover += new System.EventHandler(this.Abort_button_MouseEnter);
            // 
            // ok_button
            // 
            this.ok_button.FlatAppearance.BorderSize = 0;
            this.ok_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok_button.Image = global::VIT2._4G.Properties.Resources.icons8_Ok_Hand_50px;
            this.ok_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok_button.Location = new System.Drawing.Point(212, 83);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(115, 54);
            this.ok_button.TabIndex = 0;
            this.ok_button.Text = "Aight";
            this.ok_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.Button3_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // custom_messagebox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.close_button;
            this.ClientSize = new System.Drawing.Size(409, 180);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "custom_messagebox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "custom_messagebox";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ok_button;
        private Bunifu.Framework.UI.BunifuCustomLabel label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button retry_button;
        private System.Windows.Forms.Button ignore_button;
        private System.Windows.Forms.Button abort_button;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}