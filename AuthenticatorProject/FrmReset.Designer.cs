
namespace AuthenticatorProject {
    partial class FrmReset {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReset));
            this.PicAccount = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CboImplementations = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtLoginURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtServerID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PicReset = new System.Windows.Forms.PictureBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.GrpCertificate = new System.Windows.Forms.GroupBox();
            this.ChkCertificate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicAccount)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicReset)).BeginInit();
            this.GrpCertificate.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicAccount
            // 
            this.PicAccount.Location = new System.Drawing.Point(160, 11);
            this.PicAccount.Name = "PicAccount";
            this.PicAccount.Size = new System.Drawing.Size(64, 64);
            this.PicAccount.TabIndex = 10;
            this.PicAccount.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CboImplementations);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtLoginURL);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtServerID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 154);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Information";
            // 
            // CboImplementations
            // 
            this.CboImplementations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboImplementations.FormattingEnabled = true;
            this.CboImplementations.ItemHeight = 13;
            this.CboImplementations.Location = new System.Drawing.Point(100, 120);
            this.CboImplementations.Margin = new System.Windows.Forms.Padding(2);
            this.CboImplementations.Name = "CboImplementations";
            this.CboImplementations.Size = new System.Drawing.Size(250, 21);
            this.CboImplementations.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Algorithm:";
            // 
            // TxtLoginURL
            // 
            this.TxtLoginURL.Location = new System.Drawing.Point(100, 90);
            this.TxtLoginURL.Name = "TxtLoginURL";
            this.TxtLoginURL.ReadOnly = true;
            this.TxtLoginURL.Size = new System.Drawing.Size(250, 20);
            this.TxtLoginURL.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Login URL:";
            // 
            // TxtServerID
            // 
            this.TxtServerID.Location = new System.Drawing.Point(100, 60);
            this.TxtServerID.Name = "TxtServerID";
            this.TxtServerID.ReadOnly = true;
            this.TxtServerID.Size = new System.Drawing.Size(250, 20);
            this.TxtServerID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server ID:";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(100, 30);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.ReadOnly = true;
            this.TxtEmail.Size = new System.Drawing.Size(250, 20);
            this.TxtEmail.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email:";
            // 
            // PicReset
            // 
            this.PicReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicReset.ErrorImage = ((System.Drawing.Image)(resources.GetObject("PicReset.ErrorImage")));
            this.PicReset.Image = ((System.Drawing.Image)(resources.GetObject("PicReset.Image")));
            this.PicReset.Location = new System.Drawing.Point(163, 303);
            this.PicReset.Name = "PicReset";
            this.PicReset.Size = new System.Drawing.Size(64, 64);
            this.PicReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicReset.TabIndex = 15;
            this.PicReset.TabStop = false;
            this.PicReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicReset_MouseDown);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(111, 376);
            this.BtnOK.Margin = new System.Windows.Forms.Padding(2);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 6;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(200, 376);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // GrpCertificate
            // 
            this.GrpCertificate.Controls.Add(this.ChkCertificate);
            this.GrpCertificate.Location = new System.Drawing.Point(10, 241);
            this.GrpCertificate.Name = "GrpCertificate";
            this.GrpCertificate.Size = new System.Drawing.Size(368, 51);
            this.GrpCertificate.TabIndex = 38;
            this.GrpCertificate.TabStop = false;
            this.GrpCertificate.Text = "Certificate Access";
            // 
            // ChkCertificate
            // 
            this.ChkCertificate.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkCertificate.AutoSize = true;
            this.ChkCertificate.Image = ((System.Drawing.Image)(resources.GetObject("ChkCertificate.Image")));
            this.ChkCertificate.Location = new System.Drawing.Point(8, 14);
            this.ChkCertificate.Name = "ChkCertificate";
            this.ChkCertificate.Size = new System.Drawing.Size(31, 31);
            this.ChkCertificate.TabIndex = 5;
            this.ChkCertificate.UseVisualStyleBackColor = true;
            this.ChkCertificate.CheckedChanged += new System.EventHandler(this.ChkCertificate_CheckedChanged);
            // 
            // FrmReset
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(390, 410);
            this.Controls.Add(this.GrpCertificate);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.PicReset);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PicAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReset";
            this.ShowInTaskbar = false;
            this.Text = "Reset Key to Account";
            this.Load += new System.EventHandler(this.FrmReset_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicAccount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicReset)).EndInit();
            this.GrpCertificate.ResumeLayout(false);
            this.GrpCertificate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtLoginURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtServerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox PicReset;
        private System.Windows.Forms.ComboBox CboImplementations;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox GrpCertificate;
        private System.Windows.Forms.CheckBox ChkCertificate;
    }
}