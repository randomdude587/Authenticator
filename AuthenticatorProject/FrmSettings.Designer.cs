
namespace AuthenticatorProject {
    partial class FrmSettings {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OptOpenURL = new System.Windows.Forms.RadioButton();
            this.OptShowDetails = new System.Windows.Forms.RadioButton();
            this.ChkTopMost = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChkOpenLast = new System.Windows.Forms.CheckBox();
            this.TxtDirectory = new System.Windows.Forms.TextBox();
            this.BtnDirectory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnDown = new System.Windows.Forms.Button();
            this.BtnUp = new System.Windows.Forms.Button();
            this.LstAlgorithms = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkWarnUnprotected = new System.Windows.Forms.CheckBox();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.OptOpenURL);
            this.groupBox1.Controls.Add(this.OptShowDetails);
            this.groupBox1.Controls.Add(this.ChkTopMost);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Prefences";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Activating an account will:";
            // 
            // OptOpenURL
            // 
            this.OptOpenURL.AutoSize = true;
            this.OptOpenURL.Location = new System.Drawing.Point(177, 72);
            this.OptOpenURL.Name = "OptOpenURL";
            this.OptOpenURL.Size = new System.Drawing.Size(171, 17);
            this.OptOpenURL.TabIndex = 3;
            this.OptOpenURL.Text = "Open Account URL in Browser";
            this.OptOpenURL.UseVisualStyleBackColor = true;
            // 
            // OptShowDetails
            // 
            this.OptShowDetails.AutoSize = true;
            this.OptShowDetails.Location = new System.Drawing.Point(14, 72);
            this.OptShowDetails.Name = "OptShowDetails";
            this.OptShowDetails.Size = new System.Drawing.Size(137, 17);
            this.OptShowDetails.TabIndex = 2;
            this.OptShowDetails.Text = "Display Account Details";
            this.OptShowDetails.UseVisualStyleBackColor = true;
            // 
            // ChkTopMost
            // 
            this.ChkTopMost.AutoSize = true;
            this.ChkTopMost.Location = new System.Drawing.Point(14, 25);
            this.ChkTopMost.Name = "ChkTopMost";
            this.ChkTopMost.Size = new System.Drawing.Size(143, 17);
            this.ChkTopMost.TabIndex = 1;
            this.ChkTopMost.Text = "Keep Application on Top";
            this.ChkTopMost.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChkOpenLast);
            this.groupBox2.Controls.Add(this.TxtDirectory);
            this.groupBox2.Controls.Add(this.BtnDirectory);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vault Preferences";
            // 
            // ChkOpenLast
            // 
            this.ChkOpenLast.AutoSize = true;
            this.ChkOpenLast.Location = new System.Drawing.Point(14, 74);
            this.ChkOpenLast.Name = "ChkOpenLast";
            this.ChkOpenLast.Size = new System.Drawing.Size(195, 17);
            this.ChkOpenLast.TabIndex = 6;
            this.ChkOpenLast.Text = "Automatically Open Last Used Vault";
            this.ChkOpenLast.UseVisualStyleBackColor = true;
            // 
            // TxtDirectory
            // 
            this.TxtDirectory.AllowDrop = true;
            this.TxtDirectory.Location = new System.Drawing.Point(14, 48);
            this.TxtDirectory.Name = "TxtDirectory";
            this.TxtDirectory.Size = new System.Drawing.Size(465, 20);
            this.TxtDirectory.TabIndex = 5;
            this.TxtDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtDirectory_DragDrop);
            this.TxtDirectory.DragEnter += new System.Windows.Forms.DragEventHandler(this.TxtDirectory_DragEnter);
            // 
            // BtnDirectory
            // 
            this.BtnDirectory.Image = ((System.Drawing.Image)(resources.GetObject("BtnDirectory.Image")));
            this.BtnDirectory.Location = new System.Drawing.Point(134, 12);
            this.BtnDirectory.Name = "BtnDirectory";
            this.BtnDirectory.Size = new System.Drawing.Size(30, 30);
            this.BtnDirectory.TabIndex = 4;
            this.BtnDirectory.UseVisualStyleBackColor = true;
            this.BtnDirectory.Click += new System.EventHandler(this.BtnDirectory_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Default Vault Directory:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnDown);
            this.groupBox3.Controls.Add(this.BtnUp);
            this.groupBox3.Controls.Add(this.LstAlgorithms);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.ChkWarnUnprotected);
            this.groupBox3.Location = new System.Drawing.Point(6, 226);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(486, 147);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Security Preferences";
            // 
            // BtnDown
            // 
            this.BtnDown.Image = ((System.Drawing.Image)(resources.GetObject("BtnDown.Image")));
            this.BtnDown.Location = new System.Drawing.Point(191, 106);
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(30, 30);
            this.BtnDown.TabIndex = 9;
            this.BtnDown.UseVisualStyleBackColor = true;
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // BtnUp
            // 
            this.BtnUp.Image = ((System.Drawing.Image)(resources.GetObject("BtnUp.Image")));
            this.BtnUp.Location = new System.Drawing.Point(191, 67);
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(30, 30);
            this.BtnUp.TabIndex = 8;
            this.BtnUp.UseVisualStyleBackColor = true;
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // LstAlgorithms
            // 
            this.LstAlgorithms.FormattingEnabled = true;
            this.LstAlgorithms.Location = new System.Drawing.Point(14, 67);
            this.LstAlgorithms.Name = "LstAlgorithms";
            this.LstAlgorithms.Size = new System.Drawing.Size(171, 69);
            this.LstAlgorithms.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Preferred Digital Signature Algorithm:";
            // 
            // ChkWarnUnprotected
            // 
            this.ChkWarnUnprotected.AutoSize = true;
            this.ChkWarnUnprotected.Location = new System.Drawing.Point(14, 19);
            this.ChkWarnUnprotected.Name = "ChkWarnUnprotected";
            this.ChkWarnUnprotected.Size = new System.Drawing.Size(244, 17);
            this.ChkWarnUnprotected.TabIndex = 7;
            this.ChkWarnUnprotected.Text = "Warn whenever creating an unprotected vault";
            this.ChkWarnUnprotected.UseVisualStyleBackColor = true;
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.Description = "Select Folder";
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(167, 384);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 10;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(253, 384);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmSettings
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(501, 418);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.ShowInTaskbar = false;
            this.Text = "Application Settings";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ChkTopMost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton OptOpenURL;
        private System.Windows.Forms.RadioButton OptShowDetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ChkOpenLast;
        private System.Windows.Forms.TextBox TxtDirectory;
        private System.Windows.Forms.Button BtnDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox LstAlgorithms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkWarnUnprotected;
        private System.Windows.Forms.Button BtnDown;
        private System.Windows.Forms.Button BtnUp;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
    }
}