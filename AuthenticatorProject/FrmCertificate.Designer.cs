
namespace AuthenticatorProject {
    partial class FrmCertificate {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCertificate));
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblYubikey = new System.Windows.Forms.Label();
            this.BtnYubikey = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.BtnLoadFile = new System.Windows.Forms.Button();
            this.TxtCertificatePath = new System.Windows.Forms.TextBox();
            this.BtnFileOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtExpiration = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TxtHasPrivate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtFormat = new System.Windows.Forms.TextBox();
            this.TxtThumbprint = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtSerialNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OpenCertificateDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtIssuerNameCanonical = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtSignatureAlgorithm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtIssuer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.GrpSubject = new System.Windows.Forms.GroupBox();
            this.TxtSubjectAlgorithm = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtSubjectCanonical = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtSubjectName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GrpSubject.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Enabled = false;
            this.BtnOK.Location = new System.Drawing.Point(219, 550);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 4;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(305, 550);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblYubikey);
            this.groupBox1.Controls.Add(this.BtnYubikey);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.TxtPassword);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.BtnLoadFile);
            this.groupBox1.Controls.Add(this.TxtCertificatePath);
            this.groupBox1.Controls.Add(this.BtnFileOpen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 120);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import Certificate";
            // 
            // LblYubikey
            // 
            this.LblYubikey.AutoSize = true;
            this.LblYubikey.Location = new System.Drawing.Point(157, 58);
            this.LblYubikey.Name = "LblYubikey";
            this.LblYubikey.Size = new System.Drawing.Size(0, 13);
            this.LblYubikey.TabIndex = 8;
            // 
            // BtnYubikey
            // 
            this.BtnYubikey.Image = ((System.Drawing.Image)(resources.GetObject("BtnYubikey.Image")));
            this.BtnYubikey.Location = new System.Drawing.Point(118, 48);
            this.BtnYubikey.Name = "BtnYubikey";
            this.BtnYubikey.Size = new System.Drawing.Size(33, 33);
            this.BtnYubikey.TabIndex = 2;
            this.BtnYubikey.UseVisualStyleBackColor = true;
            this.BtnYubikey.Click += new System.EventHandler(this.BtnYubikey_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 58);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "From Yubikey:";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(118, 87);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(199, 20);
            this.TxtPassword.TabIndex = 3;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Password:";
            // 
            // BtnLoadFile
            // 
            this.BtnLoadFile.Location = new System.Drawing.Point(494, 19);
            this.BtnLoadFile.Name = "BtnLoadFile";
            this.BtnLoadFile.Size = new System.Drawing.Size(80, 25);
            this.BtnLoadFile.TabIndex = 1;
            this.BtnLoadFile.Text = "Load";
            this.BtnLoadFile.UseVisualStyleBackColor = true;
            this.BtnLoadFile.Click += new System.EventHandler(this.BtnLoadFile_Click);
            // 
            // TxtCertificatePath
            // 
            this.TxtCertificatePath.AllowDrop = true;
            this.TxtCertificatePath.Location = new System.Drawing.Point(157, 22);
            this.TxtCertificatePath.Name = "TxtCertificatePath";
            this.TxtCertificatePath.Size = new System.Drawing.Size(331, 20);
            this.TxtCertificatePath.TabIndex = 0;
            this.TxtCertificatePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtCertificatePath_DragDrop);
            this.TxtCertificatePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.TxtCertificatePath_DragEnter);
            // 
            // BtnFileOpen
            // 
            this.BtnFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("BtnFileOpen.Image")));
            this.BtnFileOpen.Location = new System.Drawing.Point(118, 15);
            this.BtnFileOpen.Name = "BtnFileOpen";
            this.BtnFileOpen.Size = new System.Drawing.Size(33, 33);
            this.BtnFileOpen.TabIndex = 1;
            this.BtnFileOpen.UseVisualStyleBackColor = true;
            this.BtnFileOpen.Click += new System.EventHandler(this.BtnFileOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From File:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtExpiration);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.TxtHasPrivate);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TxtFormat);
            this.groupBox2.Controls.Add(this.TxtThumbprint);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TxtTo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtFrom);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TxtSerialNumber);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TxtVersion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 162);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Certificate Details";
            // 
            // TxtExpiration
            // 
            this.TxtExpiration.Location = new System.Drawing.Point(374, 125);
            this.TxtExpiration.Name = "TxtExpiration";
            this.TxtExpiration.ReadOnly = true;
            this.TxtExpiration.Size = new System.Drawing.Size(199, 20);
            this.TxtExpiration.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(323, 128);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "Expires:";
            // 
            // TxtHasPrivate
            // 
            this.TxtHasPrivate.Location = new System.Drawing.Point(118, 125);
            this.TxtHasPrivate.Name = "TxtHasPrivate";
            this.TxtHasPrivate.ReadOnly = true;
            this.TxtHasPrivate.Size = new System.Drawing.Size(199, 20);
            this.TxtHasPrivate.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 128);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Holds Private Key:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Format:";
            // 
            // TxtFormat
            // 
            this.TxtFormat.Location = new System.Drawing.Point(118, 22);
            this.TxtFormat.Name = "TxtFormat";
            this.TxtFormat.ReadOnly = true;
            this.TxtFormat.Size = new System.Drawing.Size(200, 20);
            this.TxtFormat.TabIndex = 10;
            // 
            // TxtThumbprint
            // 
            this.TxtThumbprint.Location = new System.Drawing.Point(118, 72);
            this.TxtThumbprint.Name = "TxtThumbprint";
            this.TxtThumbprint.ReadOnly = true;
            this.TxtThumbprint.Size = new System.Drawing.Size(456, 20);
            this.TxtThumbprint.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Thumbprint:";
            // 
            // TxtTo
            // 
            this.TxtTo.Location = new System.Drawing.Point(374, 97);
            this.TxtTo.Name = "TxtTo";
            this.TxtTo.ReadOnly = true;
            this.TxtTo.Size = new System.Drawing.Size(200, 20);
            this.TxtTo.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "To:";
            // 
            // TxtFrom
            // 
            this.TxtFrom.Location = new System.Drawing.Point(118, 97);
            this.TxtFrom.Name = "TxtFrom";
            this.TxtFrom.ReadOnly = true;
            this.TxtFrom.Size = new System.Drawing.Size(199, 20);
            this.TxtFrom.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Valid From:";
            // 
            // TxtSerialNumber
            // 
            this.TxtSerialNumber.Location = new System.Drawing.Point(118, 47);
            this.TxtSerialNumber.Name = "TxtSerialNumber";
            this.TxtSerialNumber.ReadOnly = true;
            this.TxtSerialNumber.Size = new System.Drawing.Size(456, 20);
            this.TxtSerialNumber.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Serial Number:";
            // 
            // TxtVersion
            // 
            this.TxtVersion.Location = new System.Drawing.Point(374, 22);
            this.TxtVersion.Name = "TxtVersion";
            this.TxtVersion.ReadOnly = true;
            this.TxtVersion.Size = new System.Drawing.Size(200, 20);
            this.TxtVersion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Version:";
            // 
            // OpenCertificateDialog
            // 
            this.OpenCertificateDialog.DefaultExt = "pfx";
            this.OpenCertificateDialog.Filter = "Personal Information Exchange (.pfx)|*.pfx|PKCS12 (.p12)|*.p12|All Files|*.*";
            this.OpenCertificateDialog.Title = "Select Certificate File";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtIssuerNameCanonical);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.TxtSignatureAlgorithm);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.TxtIssuer);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(12, 306);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(580, 102);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Issuer";
            // 
            // TxtIssuerNameCanonical
            // 
            this.TxtIssuerNameCanonical.Location = new System.Drawing.Point(118, 47);
            this.TxtIssuerNameCanonical.Name = "TxtIssuerNameCanonical";
            this.TxtIssuerNameCanonical.ReadOnly = true;
            this.TxtIssuerNameCanonical.Size = new System.Drawing.Size(456, 20);
            this.TxtIssuerNameCanonical.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Canonical:";
            // 
            // TxtSignatureAlgorithm
            // 
            this.TxtSignatureAlgorithm.Location = new System.Drawing.Point(118, 72);
            this.TxtSignatureAlgorithm.Name = "TxtSignatureAlgorithm";
            this.TxtSignatureAlgorithm.ReadOnly = true;
            this.TxtSignatureAlgorithm.Size = new System.Drawing.Size(456, 20);
            this.TxtSignatureAlgorithm.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Signature Algorithm:";
            // 
            // TxtIssuer
            // 
            this.TxtIssuer.Location = new System.Drawing.Point(118, 22);
            this.TxtIssuer.Name = "TxtIssuer";
            this.TxtIssuer.ReadOnly = true;
            this.TxtIssuer.Size = new System.Drawing.Size(456, 20);
            this.TxtIssuer.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Name:";
            // 
            // GrpSubject
            // 
            this.GrpSubject.Controls.Add(this.TxtSubjectAlgorithm);
            this.GrpSubject.Controls.Add(this.label14);
            this.GrpSubject.Controls.Add(this.TxtSubjectCanonical);
            this.GrpSubject.Controls.Add(this.label13);
            this.GrpSubject.Controls.Add(this.TxtEmail);
            this.GrpSubject.Controls.Add(this.label11);
            this.GrpSubject.Controls.Add(this.TxtSubjectName);
            this.GrpSubject.Controls.Add(this.label10);
            this.GrpSubject.Location = new System.Drawing.Point(12, 414);
            this.GrpSubject.Name = "GrpSubject";
            this.GrpSubject.Size = new System.Drawing.Size(580, 128);
            this.GrpSubject.TabIndex = 5;
            this.GrpSubject.TabStop = false;
            this.GrpSubject.Text = "Subject";
            // 
            // TxtSubjectAlgorithm
            // 
            this.TxtSubjectAlgorithm.Location = new System.Drawing.Point(118, 97);
            this.TxtSubjectAlgorithm.Name = "TxtSubjectAlgorithm";
            this.TxtSubjectAlgorithm.ReadOnly = true;
            this.TxtSubjectAlgorithm.Size = new System.Drawing.Size(456, 20);
            this.TxtSubjectAlgorithm.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Signature Algorithm:";
            // 
            // TxtSubjectCanonical
            // 
            this.TxtSubjectCanonical.Location = new System.Drawing.Point(118, 72);
            this.TxtSubjectCanonical.Name = "TxtSubjectCanonical";
            this.TxtSubjectCanonical.ReadOnly = true;
            this.TxtSubjectCanonical.Size = new System.Drawing.Size(456, 20);
            this.TxtSubjectCanonical.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Canonical:";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(118, 47);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.ReadOnly = true;
            this.TxtEmail.Size = new System.Drawing.Size(456, 20);
            this.TxtEmail.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Email:";
            // 
            // TxtSubjectName
            // 
            this.TxtSubjectName.Location = new System.Drawing.Point(118, 22);
            this.TxtSubjectName.Name = "TxtSubjectName";
            this.TxtSubjectName.ReadOnly = true;
            this.TxtSubjectName.Size = new System.Drawing.Size(456, 20);
            this.TxtSubjectName.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Name:";
            // 
            // FrmCertificate
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(604, 583);
            this.Controls.Add(this.GrpSubject);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCertificate";
            this.Text = "Digital Certificate";
            this.Load += new System.EventHandler(this.FrmCertificate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GrpSubject.ResumeLayout(false);
            this.GrpSubject.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnFileOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnLoadFile;
        private System.Windows.Forms.TextBox TxtCertificatePath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtSerialNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog OpenCertificateDialog;
        private System.Windows.Forms.TextBox TxtTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtThumbprint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtFormat;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtIssuer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtSignatureAlgorithm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox GrpSubject;
        private System.Windows.Forms.TextBox TxtSubjectName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtIssuerNameCanonical;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtSubjectCanonical;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtSubjectAlgorithm;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxtHasPrivate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TxtExpiration;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label LblYubikey;
        private System.Windows.Forms.Button BtnYubikey;
        private System.Windows.Forms.Label label18;
    }
}