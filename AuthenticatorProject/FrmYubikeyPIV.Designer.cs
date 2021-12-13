
namespace AuthenticatorProject {
    partial class FrmYubikeyPIV {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYubikeyPIV));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CboCertSlots = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnRefreshDevices = new System.Windows.Forms.Button();
            this.CboYubikeys = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtCommonName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtSlotStatus = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtNewCommonName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkCertPIN = new System.Windows.Forms.CheckBox();
            this.ChkCertTouch = new System.Windows.Forms.CheckBox();
            this.BtnApplyCert = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnImport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtCertificatePath = new System.Windows.Forms.TextBox();
            this.BtnFileOpen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OpenCertificateDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CboCertSlots);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.BtnRefreshDevices);
            this.groupBox4.Controls.Add(this.CboYubikeys);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(510, 79);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Certificate Location";
            // 
            // CboCertSlots
            // 
            this.CboCertSlots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboCertSlots.FormattingEnabled = true;
            this.CboCertSlots.Items.AddRange(new object[] {
            "9A (PIV Authentication)",
            "9C (Digital Signature)",
            "9D (Key Management)",
            "9E (Card Authentication)",
            "82 (Retired 1)",
            "83 (Retired 2)",
            "84 (Retired 3)",
            "85 (Retired 4)",
            "86 (Retired 5)",
            "87 (Retired 6)",
            "88 (Retired 7)",
            "89 (Retired 8)",
            "8A (Retired 9)",
            "8B (Retired 10)",
            "8C (Retired 11)",
            "8D (Retired 12)",
            "8E (Retired 13)",
            "8F (Retired 14)",
            "90 (Retired 15)",
            "91 (Retired 16)",
            "92 (Retired 17)",
            "93 (Retired 18)",
            "94 (Retired 19)",
            "95 (Retired 20)"});
            this.CboCertSlots.Location = new System.Drawing.Point(105, 47);
            this.CboCertSlots.Name = "CboCertSlots";
            this.CboCertSlots.Size = new System.Drawing.Size(393, 21);
            this.CboCertSlots.TabIndex = 3;
            this.CboCertSlots.SelectedIndexChanged += new System.EventHandler(this.CboCertSlots_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Select Slot:";
            // 
            // BtnRefreshDevices
            // 
            this.BtnRefreshDevices.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefreshDevices.Image")));
            this.BtnRefreshDevices.Location = new System.Drawing.Point(468, 16);
            this.BtnRefreshDevices.Name = "BtnRefreshDevices";
            this.BtnRefreshDevices.Size = new System.Drawing.Size(30, 30);
            this.BtnRefreshDevices.TabIndex = 2;
            this.BtnRefreshDevices.UseVisualStyleBackColor = true;
            this.BtnRefreshDevices.Click += new System.EventHandler(this.BtnRefreshDevices_Click);
            // 
            // CboYubikeys
            // 
            this.CboYubikeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboYubikeys.FormattingEnabled = true;
            this.CboYubikeys.Location = new System.Drawing.Point(105, 22);
            this.CboYubikeys.Name = "CboYubikeys";
            this.CboYubikeys.Size = new System.Drawing.Size(357, 21);
            this.CboYubikeys.TabIndex = 1;
            this.CboYubikeys.SelectedIndexChanged += new System.EventHandler(this.CboYubikeys_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Device:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtCommonName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TxtSlotStatus);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 79);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Certificate Details";
            // 
            // TxtCommonName
            // 
            this.TxtCommonName.Location = new System.Drawing.Point(105, 47);
            this.TxtCommonName.Name = "TxtCommonName";
            this.TxtCommonName.ReadOnly = true;
            this.TxtCommonName.Size = new System.Drawing.Size(393, 20);
            this.TxtCommonName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Common Name:";
            // 
            // TxtSlotStatus
            // 
            this.TxtSlotStatus.Location = new System.Drawing.Point(105, 22);
            this.TxtSlotStatus.Name = "TxtSlotStatus";
            this.TxtSlotStatus.ReadOnly = true;
            this.TxtSlotStatus.Size = new System.Drawing.Size(393, 20);
            this.TxtSlotStatus.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Implementation:";
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(269, 484);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 15;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(183, 484);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 14;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtNewCommonName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ChkCertPIN);
            this.groupBox1.Controls.Add(this.ChkCertTouch);
            this.groupBox1.Controls.Add(this.BtnApplyCert);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(12, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 136);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate";
            // 
            // TxtNewCommonName
            // 
            this.TxtNewCommonName.Location = new System.Drawing.Point(105, 47);
            this.TxtNewCommonName.Name = "TxtNewCommonName";
            this.TxtNewCommonName.Size = new System.Drawing.Size(393, 20);
            this.TxtNewCommonName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Common Name:";
            // 
            // ChkCertPIN
            // 
            this.ChkCertPIN.AutoSize = true;
            this.ChkCertPIN.Location = new System.Drawing.Point(149, 75);
            this.ChkCertPIN.Name = "ChkCertPIN";
            this.ChkCertPIN.Size = new System.Drawing.Size(89, 17);
            this.ChkCertPIN.TabIndex = 8;
            this.ChkCertPIN.Text = "Requires PIN";
            this.ChkCertPIN.UseVisualStyleBackColor = true;
            // 
            // ChkCertTouch
            // 
            this.ChkCertTouch.AutoSize = true;
            this.ChkCertTouch.Location = new System.Drawing.Point(11, 75);
            this.ChkCertTouch.Name = "ChkCertTouch";
            this.ChkCertTouch.Size = new System.Drawing.Size(102, 17);
            this.ChkCertTouch.TabIndex = 7;
            this.ChkCertTouch.Text = "Requires Touch";
            this.ChkCertTouch.UseVisualStyleBackColor = true;
            // 
            // BtnApplyCert
            // 
            this.BtnApplyCert.Location = new System.Drawing.Point(212, 100);
            this.BtnApplyCert.Name = "BtnApplyCert";
            this.BtnApplyCert.Size = new System.Drawing.Size(80, 25);
            this.BtnApplyCert.TabIndex = 9;
            this.BtnApplyCert.Text = "Overwrite";
            this.BtnApplyCert.UseVisualStyleBackColor = true;
            this.BtnApplyCert.Click += new System.EventHandler(this.BtnApplyCert_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(314, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Overwrite slot with self-signed certificate using ECDSA-NIST256p";
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(212, 114);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(80, 25);
            this.BtnImport.TabIndex = 13;
            this.BtnImport.Text = "Import";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnImport);
            this.groupBox3.Controls.Add(this.TxtPassword);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.TxtCertificatePath);
            this.groupBox3.Controls.Add(this.BtnFileOpen);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(509, 149);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "External PKCS12 Certificate";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(105, 88);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(393, 20);
            this.TxtPassword.TabIndex = 12;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Password:";
            // 
            // TxtCertificatePath
            // 
            this.TxtCertificatePath.AllowDrop = true;
            this.TxtCertificatePath.Location = new System.Drawing.Point(105, 54);
            this.TxtCertificatePath.Name = "TxtCertificatePath";
            this.TxtCertificatePath.Size = new System.Drawing.Size(393, 20);
            this.TxtCertificatePath.TabIndex = 11;
            this.TxtCertificatePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtCertificatePath_DragDrop);
            this.TxtCertificatePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.TxtCertificatePath_DragEnter);
            // 
            // BtnFileOpen
            // 
            this.BtnFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("BtnFileOpen.Image")));
            this.BtnFileOpen.Location = new System.Drawing.Point(66, 47);
            this.BtnFileOpen.Name = "BtnFileOpen";
            this.BtnFileOpen.Size = new System.Drawing.Size(33, 33);
            this.BtnFileOpen.TabIndex = 10;
            this.BtnFileOpen.UseVisualStyleBackColor = true;
            this.BtnFileOpen.Click += new System.EventHandler(this.BtnFileOpen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "From File:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Import external certificate into Yubikey slot";
            // 
            // OpenCertificateDialog
            // 
            this.OpenCertificateDialog.DefaultExt = "pfx";
            this.OpenCertificateDialog.Filter = "Personal Information Exchange (.pfx)|*.pfx|PKCS12 (.p12)|*.p12|All Files|*.*";
            this.OpenCertificateDialog.Title = "Select Certificate File";
            // 
            // FrmYubikeyPIV
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(532, 519);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmYubikeyPIV";
            this.ShowInTaskbar = false;
            this.Text = "Yubikey Certificate Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmYubikeyPIV_FormClosing);
            this.Load += new System.EventHandler(this.FrmYubikeyPIV_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button BtnRefreshDevices;
        private System.Windows.Forms.ComboBox CboYubikeys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtCommonName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtSlotStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.ComboBox CboCertSlots;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ChkCertPIN;
        private System.Windows.Forms.CheckBox ChkCertTouch;
        private System.Windows.Forms.Button BtnApplyCert;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtNewCommonName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtCertificatePath;
        private System.Windows.Forms.Button BtnFileOpen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog OpenCertificateDialog;
    }
}