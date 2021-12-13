
namespace AuthenticatorProject {
    partial class FrmSignIn {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSignIn));
            this.PicAccount = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtAlgorithm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtServerID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PicChallenge = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicAccount)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicChallenge)).BeginInit();
            this.SuspendLayout();
            // 
            // PicAccount
            // 
            this.PicAccount.Location = new System.Drawing.Point(163, 11);
            this.PicAccount.Name = "PicAccount";
            this.PicAccount.Size = new System.Drawing.Size(64, 64);
            this.PicAccount.TabIndex = 9;
            this.PicAccount.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtAlgorithm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtServerID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 121);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Information";
            // 
            // TxtAlgorithm
            // 
            this.TxtAlgorithm.Location = new System.Drawing.Point(100, 90);
            this.TxtAlgorithm.Name = "TxtAlgorithm";
            this.TxtAlgorithm.ReadOnly = true;
            this.TxtAlgorithm.Size = new System.Drawing.Size(250, 20);
            this.TxtAlgorithm.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Algorithm:";
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
            // PicChallenge
            // 
            this.PicChallenge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicChallenge.Image = ((System.Drawing.Image)(resources.GetObject("PicChallenge.Image")));
            this.PicChallenge.Location = new System.Drawing.Point(163, 212);
            this.PicChallenge.Name = "PicChallenge";
            this.PicChallenge.Size = new System.Drawing.Size(64, 64);
            this.PicChallenge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicChallenge.TabIndex = 14;
            this.PicChallenge.TabStop = false;
            this.PicChallenge.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.PicChallenge_QueryContinueDrag);
            this.PicChallenge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicChallenge_MouseDown);
            // 
            // FrmSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 287);
            this.Controls.Add(this.PicChallenge);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PicAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSignIn";
            this.ShowInTaskbar = false;
            this.Text = "Sign In to Application";
            this.Load += new System.EventHandler(this.FrmSignIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicAccount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicChallenge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtServerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox PicChallenge;
        private System.Windows.Forms.TextBox TxtAlgorithm;
        private System.Windows.Forms.Label label2;
    }
}