
namespace AuthenticatorProject {
    partial class FrmUsbSecuritKey {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsbSecuritKey));
            this.BtnOK = new System.Windows.Forms.Button();
            this.GrpDetectedKeys = new System.Windows.Forms.GroupBox();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CboSecurityKeys = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtContainsKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtVolumeLabel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDrive = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtKeyIdentifier = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtNewVolumeLabel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.CboDrives = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GrpDetectedKeys.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(181, 320);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 9;
            this.BtnOK.Text = "Close";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // GrpDetectedKeys
            // 
            this.GrpDetectedKeys.Controls.Add(this.BtnRefresh);
            this.GrpDetectedKeys.Controls.Add(this.label1);
            this.GrpDetectedKeys.Controls.Add(this.CboSecurityKeys);
            this.GrpDetectedKeys.Location = new System.Drawing.Point(8, 6);
            this.GrpDetectedKeys.Name = "GrpDetectedKeys";
            this.GrpDetectedKeys.Size = new System.Drawing.Size(425, 56);
            this.GrpDetectedKeys.TabIndex = 2;
            this.GrpDetectedKeys.TabStop = false;
            this.GrpDetectedKeys.Text = "Detected Security Keys";
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefresh.Image")));
            this.BtnRefresh.Location = new System.Drawing.Point(383, 16);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(30, 30);
            this.BtnRefresh.TabIndex = 2;
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Keys:";
            // 
            // CboSecurityKeys
            // 
            this.CboSecurityKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboSecurityKeys.FormattingEnabled = true;
            this.CboSecurityKeys.Location = new System.Drawing.Point(102, 22);
            this.CboSecurityKeys.Name = "CboSecurityKeys";
            this.CboSecurityKeys.Size = new System.Drawing.Size(275, 21);
            this.CboSecurityKeys.TabIndex = 1;
            this.CboSecurityKeys.SelectedIndexChanged += new System.EventHandler(this.CboSecurityKeys_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtContainsKey);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtVolumeLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtDrive);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 106);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // TxtContainsKey
            // 
            this.TxtContainsKey.Location = new System.Drawing.Point(103, 72);
            this.TxtContainsKey.Name = "TxtContainsKey";
            this.TxtContainsKey.ReadOnly = true;
            this.TxtContainsKey.Size = new System.Drawing.Size(310, 20);
            this.TxtContainsKey.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Identification:";
            // 
            // TxtVolumeLabel
            // 
            this.TxtVolumeLabel.Location = new System.Drawing.Point(103, 47);
            this.TxtVolumeLabel.Name = "TxtVolumeLabel";
            this.TxtVolumeLabel.ReadOnly = true;
            this.TxtVolumeLabel.Size = new System.Drawing.Size(310, 20);
            this.TxtVolumeLabel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Volume Label:";
            // 
            // TxtDrive
            // 
            this.TxtDrive.Location = new System.Drawing.Point(103, 22);
            this.TxtDrive.Name = "TxtDrive";
            this.TxtDrive.ReadOnly = true;
            this.TxtDrive.Size = new System.Drawing.Size(310, 20);
            this.TxtDrive.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Drive Letter:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtKeyIdentifier);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TxtNewVolumeLabel);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.BtnGenerate);
            this.groupBox2.Controls.Add(this.CboDrives);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(7, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 131);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create New Security Key:";
            // 
            // TxtKeyIdentifier
            // 
            this.TxtKeyIdentifier.Location = new System.Drawing.Point(103, 71);
            this.TxtKeyIdentifier.Name = "TxtKeyIdentifier";
            this.TxtKeyIdentifier.Size = new System.Drawing.Size(311, 20);
            this.TxtKeyIdentifier.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Key Identifier:";
            // 
            // TxtNewVolumeLabel
            // 
            this.TxtNewVolumeLabel.Location = new System.Drawing.Point(103, 47);
            this.TxtNewVolumeLabel.Name = "TxtNewVolumeLabel";
            this.TxtNewVolumeLabel.Size = new System.Drawing.Size(311, 20);
            this.TxtNewVolumeLabel.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Apply Label:";
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Location = new System.Drawing.Point(173, 97);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(80, 25);
            this.BtnGenerate.TabIndex = 8;
            this.BtnGenerate.Text = "Generate";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // CboDrives
            // 
            this.CboDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboDrives.FormattingEnabled = true;
            this.CboDrives.Location = new System.Drawing.Point(103, 22);
            this.CboDrives.Name = "CboDrives";
            this.CboDrives.Size = new System.Drawing.Size(311, 21);
            this.CboDrives.TabIndex = 5;
            this.CboDrives.DropDown += new System.EventHandler(this.CboDrives_DropDown);
            this.CboDrives.SelectedIndexChanged += new System.EventHandler(this.CboDrives_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Use Device:";
            // 
            // FrmUsbSecuritKey
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 354);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GrpDetectedKeys);
            this.Controls.Add(this.BtnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUsbSecuritKey";
            this.ShowInTaskbar = false;
            this.Text = "USB Security Key Editor";
            this.Load += new System.EventHandler(this.FrmUsbSecuritKey_Load);
            this.GrpDetectedKeys.ResumeLayout(false);
            this.GrpDetectedKeys.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.GroupBox GrpDetectedKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboSecurityKeys;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtContainsKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtVolumeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDrive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.ComboBox CboDrives;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtNewVolumeLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtKeyIdentifier;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnRefresh;
    }
}