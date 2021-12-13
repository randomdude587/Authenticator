
namespace AuthenticatorProject {
    partial class FrmAbout {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.LblVersion = new System.Windows.Forms.Label();
            this.TxtAbout = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(333, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(232, 218);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 2;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(6, 120);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(45, 13);
            this.LblVersion.TabIndex = 3;
            this.LblVersion.Text = "Version:";
            // 
            // TxtAbout
            // 
            this.TxtAbout.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.TxtAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtAbout.Location = new System.Drawing.Point(9, 12);
            this.TxtAbout.Margin = new System.Windows.Forms.Padding(2);
            this.TxtAbout.Multiline = true;
            this.TxtAbout.Name = "TxtAbout";
            this.TxtAbout.Size = new System.Drawing.Size(319, 95);
            this.TxtAbout.TabIndex = 4;
            this.TxtAbout.Text = resources.GetString("TxtAbout.Text");
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 250);
            this.Controls.Add(this.TxtAbout);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.ShowInTaskbar = false;
            this.Text = "About EasyAuthenticator";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.TextBox TxtAbout;
    }
}