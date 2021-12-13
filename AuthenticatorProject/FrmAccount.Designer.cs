
namespace AuthenticatorProject {
    partial class FrmAccount {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccount));
            this.PicAccount = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtAlgorithm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtLoginURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtServerID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicAccount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicAccount
            // 
            this.PicAccount.Location = new System.Drawing.Point(193, 10);
            this.PicAccount.Name = "PicAccount";
            this.PicAccount.Size = new System.Drawing.Size(64, 64);
            this.PicAccount.TabIndex = 8;
            this.PicAccount.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtAlgorithm);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtNotes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtLoginURL);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtServerID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 246);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Information";
            // 
            // TxtAlgorithm
            // 
            this.TxtAlgorithm.Location = new System.Drawing.Point(100, 90);
            this.TxtAlgorithm.Name = "TxtAlgorithm";
            this.TxtAlgorithm.ReadOnly = true;
            this.TxtAlgorithm.Size = new System.Drawing.Size(323, 20);
            this.TxtAlgorithm.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Private Key:";
            // 
            // TxtNotes
            // 
            this.TxtNotes.AcceptsReturn = true;
            this.TxtNotes.AcceptsTab = true;
            this.TxtNotes.Location = new System.Drawing.Point(100, 150);
            this.TxtNotes.Multiline = true;
            this.TxtNotes.Name = "TxtNotes";
            this.TxtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtNotes.Size = new System.Drawing.Size(323, 86);
            this.TxtNotes.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Notes:";
            // 
            // TxtLoginURL
            // 
            this.TxtLoginURL.Location = new System.Drawing.Point(100, 120);
            this.TxtLoginURL.Name = "TxtLoginURL";
            this.TxtLoginURL.Size = new System.Drawing.Size(323, 20);
            this.TxtLoginURL.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 120);
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
            this.TxtServerID.Size = new System.Drawing.Size(323, 20);
            this.TxtServerID.TabIndex = 1;
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
            this.TxtEmail.Size = new System.Drawing.Size(323, 20);
            this.TxtEmail.TabIndex = 0;
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
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(142, 339);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 5;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(228, 339);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmAccount
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(451, 372);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PicAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAccount";
            this.ShowInTaskbar = false;
            this.Text = "Account Information";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAccount_FormClosing);
            this.Load += new System.EventHandler(this.FrmAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicAccount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PicAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtLoginURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtServerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox TxtAlgorithm;
        private System.Windows.Forms.Label label5;
    }
}