
namespace AuthenticatorProject {
    partial class FrmYubikey {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYubikey));
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnRefreshDevices = new System.Windows.Forms.Button();
            this.CboYubikeys = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnApplyPrivateKey = new System.Windows.Forms.Button();
            this.OptDefinedKey = new System.Windows.Forms.RadioButton();
            this.OptNewKey = new System.Windows.Forms.RadioButton();
            this.TxtPrivateKey = new System.Windows.Forms.TextBox();
            this.ChkTouch = new System.Windows.Forms.CheckBox();
            this.CboChallengeSlot = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnApplyPassword = new System.Windows.Forms.Button();
            this.OptDefinedPassword = new System.Windows.Forms.RadioButton();
            this.OptNewPassword = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.CboKeyboard = new System.Windows.Forms.ComboBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NumPasswordLength = new System.Windows.Forms.NumericUpDown();
            this.CboPasswordSlot = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CboSlots = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LblResponse = new System.Windows.Forms.Label();
            this.BtnTest = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.TxtChallenge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPasswordLength)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.AddExtension = false;
            this.OpenFileDialog.Title = "Select the ykman.exe File";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnRefreshDevices);
            this.groupBox4.Controls.Add(this.CboYubikeys);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(10, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(510, 65);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Yubikey Devices";
            // 
            // BtnRefreshDevices
            // 
            this.BtnRefreshDevices.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefreshDevices.Image")));
            this.BtnRefreshDevices.Location = new System.Drawing.Point(468, 23);
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
            this.CboYubikeys.Location = new System.Drawing.Point(96, 28);
            this.CboYubikeys.Name = "CboYubikeys";
            this.CboYubikeys.Size = new System.Drawing.Size(366, 21);
            this.CboYubikeys.TabIndex = 1;
            this.CboYubikeys.SelectedIndexChanged += new System.EventHandler(this.CboYubikeys_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Device:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnApplyPrivateKey);
            this.groupBox1.Controls.Add(this.OptDefinedKey);
            this.groupBox1.Controls.Add(this.OptNewKey);
            this.groupBox1.Controls.Add(this.TxtPrivateKey);
            this.groupBox1.Controls.Add(this.ChkTouch);
            this.groupBox1.Controls.Add(this.CboChallengeSlot);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 179);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Challenge-Response Key";
            // 
            // BtnApplyPrivateKey
            // 
            this.BtnApplyPrivateKey.Location = new System.Drawing.Point(210, 146);
            this.BtnApplyPrivateKey.Name = "BtnApplyPrivateKey";
            this.BtnApplyPrivateKey.Size = new System.Drawing.Size(80, 25);
            this.BtnApplyPrivateKey.TabIndex = 15;
            this.BtnApplyPrivateKey.Text = "Apply";
            this.BtnApplyPrivateKey.UseVisualStyleBackColor = true;
            this.BtnApplyPrivateKey.Click += new System.EventHandler(this.BtnApplyPrivateKey_Click);
            // 
            // OptDefinedKey
            // 
            this.OptDefinedKey.AutoSize = true;
            this.OptDefinedKey.Location = new System.Drawing.Point(9, 121);
            this.OptDefinedKey.Name = "OptDefinedKey";
            this.OptDefinedKey.Size = new System.Drawing.Size(144, 17);
            this.OptDefinedKey.TabIndex = 13;
            this.OptDefinedKey.Text = "User Defined Private Key";
            this.OptDefinedKey.UseVisualStyleBackColor = true;
            // 
            // OptNewKey
            // 
            this.OptNewKey.AutoSize = true;
            this.OptNewKey.Checked = true;
            this.OptNewKey.Location = new System.Drawing.Point(9, 90);
            this.OptNewKey.Name = "OptNewKey";
            this.OptNewKey.Size = new System.Drawing.Size(115, 17);
            this.OptNewKey.TabIndex = 12;
            this.OptNewKey.TabStop = true;
            this.OptNewKey.Text = "Generate New Key";
            this.OptNewKey.UseVisualStyleBackColor = true;
            this.OptNewKey.CheckedChanged += new System.EventHandler(this.OptNewKey_CheckedChanged);
            // 
            // TxtPrivateKey
            // 
            this.TxtPrivateKey.Enabled = false;
            this.TxtPrivateKey.Location = new System.Drawing.Point(160, 120);
            this.TxtPrivateKey.Name = "TxtPrivateKey";
            this.TxtPrivateKey.Size = new System.Drawing.Size(336, 20);
            this.TxtPrivateKey.TabIndex = 14;
            // 
            // ChkTouch
            // 
            this.ChkTouch.AutoSize = true;
            this.ChkTouch.Checked = true;
            this.ChkTouch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkTouch.Location = new System.Drawing.Point(9, 60);
            this.ChkTouch.Name = "ChkTouch";
            this.ChkTouch.Size = new System.Drawing.Size(97, 17);
            this.ChkTouch.TabIndex = 11;
            this.ChkTouch.Text = "Require Touch";
            this.ChkTouch.UseVisualStyleBackColor = true;
            // 
            // CboChallengeSlot
            // 
            this.CboChallengeSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboChallengeSlot.FormattingEnabled = true;
            this.CboChallengeSlot.Items.AddRange(new object[] {
            "Slot 1 (Short Press)",
            "Slot 2 (Long Press)"});
            this.CboChallengeSlot.Location = new System.Drawing.Point(94, 24);
            this.CboChallengeSlot.Name = "CboChallengeSlot";
            this.CboChallengeSlot.Size = new System.Drawing.Size(402, 21);
            this.CboChallengeSlot.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Slot:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnApplyPassword);
            this.groupBox2.Controls.Add(this.OptDefinedPassword);
            this.groupBox2.Controls.Add(this.OptNewPassword);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.CboKeyboard);
            this.groupBox2.Controls.Add(this.TxtPassword);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.NumPasswordLength);
            this.groupBox2.Controls.Add(this.CboPasswordSlot);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(10, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 150);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Static Password";
            // 
            // BtnApplyPassword
            // 
            this.BtnApplyPassword.Location = new System.Drawing.Point(212, 115);
            this.BtnApplyPassword.Name = "BtnApplyPassword";
            this.BtnApplyPassword.Size = new System.Drawing.Size(80, 25);
            this.BtnApplyPassword.TabIndex = 9;
            this.BtnApplyPassword.Text = "Apply";
            this.BtnApplyPassword.UseVisualStyleBackColor = true;
            this.BtnApplyPassword.Click += new System.EventHandler(this.BtnApplyPassword_Click);
            // 
            // OptDefinedPassword
            // 
            this.OptDefinedPassword.AutoSize = true;
            this.OptDefinedPassword.Location = new System.Drawing.Point(11, 90);
            this.OptDefinedPassword.Name = "OptDefinedPassword";
            this.OptDefinedPassword.Size = new System.Drawing.Size(136, 17);
            this.OptDefinedPassword.TabIndex = 7;
            this.OptDefinedPassword.Text = "User Defined Password";
            this.OptDefinedPassword.UseVisualStyleBackColor = true;
            // 
            // OptNewPassword
            // 
            this.OptNewPassword.AutoSize = true;
            this.OptNewPassword.Checked = true;
            this.OptNewPassword.Location = new System.Drawing.Point(11, 59);
            this.OptNewPassword.Name = "OptNewPassword";
            this.OptNewPassword.Size = new System.Drawing.Size(143, 17);
            this.OptNewPassword.TabIndex = 4;
            this.OptNewPassword.TabStop = true;
            this.OptNewPassword.Text = "Generate New Password";
            this.OptNewPassword.UseVisualStyleBackColor = true;
            this.OptNewPassword.CheckedChanged += new System.EventHandler(this.OptNewPassword_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(310, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "KeyBoard:";
            // 
            // CboKeyboard
            // 
            this.CboKeyboard.FormattingEnabled = true;
            this.CboKeyboard.Items.AddRange(new object[] {
            "English (US)",
            "ModHex (Safe)"});
            this.CboKeyboard.Location = new System.Drawing.Point(372, 58);
            this.CboKeyboard.Name = "CboKeyboard";
            this.CboKeyboard.Size = new System.Drawing.Size(126, 21);
            this.CboKeyboard.TabIndex = 6;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Enabled = false;
            this.TxtPassword.Location = new System.Drawing.Point(162, 89);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(336, 20);
            this.TxtPassword.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Length:";
            // 
            // NumPasswordLength
            // 
            this.NumPasswordLength.Location = new System.Drawing.Point(217, 59);
            this.NumPasswordLength.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NumPasswordLength.Name = "NumPasswordLength";
            this.NumPasswordLength.Size = new System.Drawing.Size(50, 20);
            this.NumPasswordLength.TabIndex = 5;
            this.NumPasswordLength.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // CboPasswordSlot
            // 
            this.CboPasswordSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboPasswordSlot.FormattingEnabled = true;
            this.CboPasswordSlot.Items.AddRange(new object[] {
            "Slot 1 (Short Press)",
            "Slot 2 (Long Press)"});
            this.CboPasswordSlot.Location = new System.Drawing.Point(96, 21);
            this.CboPasswordSlot.Name = "CboPasswordSlot";
            this.CboPasswordSlot.Size = new System.Drawing.Size(402, 21);
            this.CboPasswordSlot.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select Slot:";
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(182, 590);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 20;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CboSlots);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.LblResponse);
            this.groupBox3.Controls.Add(this.BtnTest);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.BtnGenerate);
            this.groupBox3.Controls.Add(this.TxtChallenge);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(10, 424);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 160);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set Authenticator Challenge";
            // 
            // CboSlots
            // 
            this.CboSlots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboSlots.FormattingEnabled = true;
            this.CboSlots.Items.AddRange(new object[] {
            "Slot 1 (Short Press)",
            "Slot 2 (Long Press)"});
            this.CboSlots.Location = new System.Drawing.Point(94, 59);
            this.CboSlots.Name = "CboSlots";
            this.CboSlots.Size = new System.Drawing.Size(402, 21);
            this.CboSlots.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Submit to:";
            // 
            // LblResponse
            // 
            this.LblResponse.AutoSize = true;
            this.LblResponse.Location = new System.Drawing.Point(50, 126);
            this.LblResponse.Name = "LblResponse";
            this.LblResponse.Size = new System.Drawing.Size(139, 13);
            this.LblResponse.TabIndex = 14;
            this.LblResponse.Text = "Click Button to Perform Test";
            // 
            // BtnTest
            // 
            this.BtnTest.Image = ((System.Drawing.Image)(resources.GetObject("BtnTest.Image")));
            this.BtnTest.Location = new System.Drawing.Point(11, 116);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(33, 33);
            this.BtnTest.TabIndex = 19;
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(295, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Test the settings (response to the challenge will be displayed)";
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Location = new System.Drawing.Point(416, 24);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(80, 25);
            this.BtnGenerate.TabIndex = 17;
            this.BtnGenerate.Text = "Randomize";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // TxtChallenge
            // 
            this.TxtChallenge.Location = new System.Drawing.Point(94, 27);
            this.TxtChallenge.Name = "TxtChallenge";
            this.TxtChallenge.Size = new System.Drawing.Size(316, 20);
            this.TxtChallenge.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Challenge to use:";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(268, 590);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 21;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmYubikey
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 622);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmYubikey";
            this.ShowInTaskbar = false;
            this.Text = "Yubikey Settings";
            this.Load += new System.EventHandler(this.FrmYubikey_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPasswordLength)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox CboYubikeys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ChkTouch;
        private System.Windows.Forms.ComboBox CboChallengeSlot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnRefreshDevices;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NumPasswordLength;
        private System.Windows.Forms.ComboBox CboPasswordSlot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CboKeyboard;
        private System.Windows.Forms.TextBox TxtPrivateKey;
        private System.Windows.Forms.RadioButton OptDefinedKey;
        private System.Windows.Forms.RadioButton OptNewKey;
        private System.Windows.Forms.Button BtnApplyPassword;
        private System.Windows.Forms.RadioButton OptDefinedPassword;
        private System.Windows.Forms.RadioButton OptNewPassword;
        private System.Windows.Forms.Button BtnApplyPrivateKey;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CboSlots;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblResponse;
        private System.Windows.Forms.Button BtnTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.TextBox TxtChallenge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnCancel;
    }
}