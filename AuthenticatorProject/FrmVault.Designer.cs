
namespace AuthenticatorProject {
    partial class FrmVault {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVault));
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.CboPath = new System.Windows.Forms.ComboBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.NewFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblStrength = new System.Windows.Forms.Label();
            this.CboUsbSecurityKeys = new System.Windows.Forms.ComboBox();
            this.BtnUSBKey = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnYubikey = new System.Windows.Forms.Button();
            this.TxtYubikeyResponse = new System.Windows.Forms.TextBox();
            this.BtnPassword = new System.Windows.Forms.Button();
            this.TxtKeyFile = new System.Windows.Forms.TextBox();
            this.TxtPasscode = new System.Windows.Forms.TextBox();
            this.BtnKeySelection = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenKeyDialog = new System.Windows.Forms.OpenFileDialog();
            this.TimerRefreshSecurityKeys = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("BtnBrowse.Image")));
            this.BtnBrowse.Location = new System.Drawing.Point(116, 15);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(33, 33);
            this.BtnBrowse.TabIndex = 1;
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // CboPath
            // 
            this.CboPath.AllowDrop = true;
            this.CboPath.FormattingEnabled = true;
            this.CboPath.Location = new System.Drawing.Point(155, 20);
            this.CboPath.Name = "CboPath";
            this.CboPath.Size = new System.Drawing.Size(408, 21);
            this.CboPath.TabIndex = 2;
            this.CboPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.CboPath_DragDrop);
            this.CboPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.CboPath_DragEnter);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(211, 249);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 9;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(297, 249);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.DefaultExt = "vault";
            this.OpenFileDialog.Filter = "Vault Files|*.vault";
            this.OpenFileDialog.Title = "Open Existing Vault";
            // 
            // NewFileDialog
            // 
            this.NewFileDialog.DefaultExt = "vault";
            this.NewFileDialog.Filter = "Vault Files|*.vault";
            this.NewFileDialog.Title = "New Vault Location";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblStrength);
            this.groupBox1.Controls.Add(this.CboUsbSecurityKeys);
            this.groupBox1.Controls.Add(this.BtnUSBKey);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.BtnYubikey);
            this.groupBox1.Controls.Add(this.TxtYubikeyResponse);
            this.groupBox1.Controls.Add(this.BtnPassword);
            this.groupBox1.Controls.Add(this.TxtKeyFile);
            this.groupBox1.Controls.Add(this.TxtPasscode);
            this.groupBox1.Controls.Add(this.BtnKeySelection);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(11, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 183);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Access Controls";
            // 
            // LblStrength
            // 
            this.LblStrength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStrength.ForeColor = System.Drawing.Color.White;
            this.LblStrength.Location = new System.Drawing.Point(453, 27);
            this.LblStrength.Name = "LblStrength";
            this.LblStrength.Size = new System.Drawing.Size(99, 20);
            this.LblStrength.TabIndex = 15;
            this.LblStrength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CboUsbSecurityKeys
            // 
            this.CboUsbSecurityKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboUsbSecurityKeys.FormattingEnabled = true;
            this.CboUsbSecurityKeys.Location = new System.Drawing.Point(144, 107);
            this.CboUsbSecurityKeys.Name = "CboUsbSecurityKeys";
            this.CboUsbSecurityKeys.Size = new System.Drawing.Size(408, 21);
            this.CboUsbSecurityKeys.TabIndex = 8;
            // 
            // BtnUSBKey
            // 
            this.BtnUSBKey.Image = ((System.Drawing.Image)(resources.GetObject("BtnUSBKey.Image")));
            this.BtnUSBKey.Location = new System.Drawing.Point(105, 100);
            this.BtnUSBKey.Name = "BtnUSBKey";
            this.BtnUSBKey.Size = new System.Drawing.Size(33, 33);
            this.BtnUSBKey.TabIndex = 7;
            this.BtnUSBKey.UseVisualStyleBackColor = true;
            this.BtnUSBKey.Click += new System.EventHandler(this.BtnUSBKey_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "USB Security Key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Yubikey:";
            // 
            // BtnYubikey
            // 
            this.BtnYubikey.Image = ((System.Drawing.Image)(resources.GetObject("BtnYubikey.Image")));
            this.BtnYubikey.Location = new System.Drawing.Point(105, 140);
            this.BtnYubikey.Name = "BtnYubikey";
            this.BtnYubikey.Size = new System.Drawing.Size(33, 33);
            this.BtnYubikey.TabIndex = 9;
            this.BtnYubikey.UseVisualStyleBackColor = true;
            this.BtnYubikey.Click += new System.EventHandler(this.BtnYubikey_Click);
            // 
            // TxtYubikeyResponse
            // 
            this.TxtYubikeyResponse.Location = new System.Drawing.Point(144, 147);
            this.TxtYubikeyResponse.Name = "TxtYubikeyResponse";
            this.TxtYubikeyResponse.Size = new System.Drawing.Size(408, 20);
            this.TxtYubikeyResponse.TabIndex = 9;
            this.TxtYubikeyResponse.TabStop = false;
            this.TxtYubikeyResponse.UseSystemPasswordChar = true;
            // 
            // BtnPassword
            // 
            this.BtnPassword.Image = ((System.Drawing.Image)(resources.GetObject("BtnPassword.Image")));
            this.BtnPassword.Location = new System.Drawing.Point(105, 20);
            this.BtnPassword.Name = "BtnPassword";
            this.BtnPassword.Size = new System.Drawing.Size(33, 33);
            this.BtnPassword.TabIndex = 3;
            this.BtnPassword.UseVisualStyleBackColor = true;
            this.BtnPassword.Click += new System.EventHandler(this.BtnPassword_Click);
            // 
            // TxtKeyFile
            // 
            this.TxtKeyFile.AllowDrop = true;
            this.TxtKeyFile.Location = new System.Drawing.Point(144, 67);
            this.TxtKeyFile.Name = "TxtKeyFile";
            this.TxtKeyFile.Size = new System.Drawing.Size(408, 20);
            this.TxtKeyFile.TabIndex = 6;
            this.TxtKeyFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtKeyFile_DragDrop);
            this.TxtKeyFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.TxtKeyFile_DragEnter);
            // 
            // TxtPasscode
            // 
            this.TxtPasscode.AllowDrop = true;
            this.TxtPasscode.Location = new System.Drawing.Point(144, 27);
            this.TxtPasscode.Name = "TxtPasscode";
            this.TxtPasscode.Size = new System.Drawing.Size(302, 20);
            this.TxtPasscode.TabIndex = 4;
            this.TxtPasscode.UseSystemPasswordChar = true;
            this.TxtPasscode.TextChanged += new System.EventHandler(this.TxtPasscode_TextChanged);
            this.TxtPasscode.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtPasscode_DragDrop);
            this.TxtPasscode.DragEnter += new System.Windows.Forms.DragEventHandler(this.TxtPasscode_DragEnter);
            // 
            // BtnKeySelection
            // 
            this.BtnKeySelection.Image = ((System.Drawing.Image)(resources.GetObject("BtnKeySelection.Image")));
            this.BtnKeySelection.Location = new System.Drawing.Point(105, 60);
            this.BtnKeySelection.Name = "BtnKeySelection";
            this.BtnKeySelection.Size = new System.Drawing.Size(33, 33);
            this.BtnKeySelection.TabIndex = 5;
            this.BtnKeySelection.UseVisualStyleBackColor = true;
            this.BtnKeySelection.Click += new System.EventHandler(this.BtnKeySelection_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Key File:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vault File:";
            // 
            // OpenKeyDialog
            // 
            this.OpenKeyDialog.Filter = "All Files|*.*";
            this.OpenKeyDialog.Title = "Select Key File for Vault";
            // 
            // TimerRefreshSecurityKeys
            // 
            this.TimerRefreshSecurityKeys.Enabled = true;
            this.TimerRefreshSecurityKeys.Interval = 1000;
            this.TimerRefreshSecurityKeys.Tick += new System.EventHandler(this.TimerRefreshSecurityKeys_Tick);
            // 
            // FrmVault
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(589, 284);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.CboPath);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVault";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmVault_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.ComboBox CboPath;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog NewFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtKeyFile;
        private System.Windows.Forms.TextBox TxtPasscode;
        private System.Windows.Forms.Button BtnKeySelection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog OpenKeyDialog;
        private System.Windows.Forms.Button BtnPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnYubikey;
        private System.Windows.Forms.TextBox TxtYubikeyResponse;
        private System.Windows.Forms.Button BtnUSBKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CboUsbSecurityKeys;
        private System.Windows.Forms.Timer TimerRefreshSecurityKeys;
        private System.Windows.Forms.Label LblStrength;
    }
}