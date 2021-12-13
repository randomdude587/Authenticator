
namespace AuthenticatorProject {
    partial class FrmPIN {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPIN));
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LblQuestion = new System.Windows.Forms.Label();
            this.TxtPasscode = new System.Windows.Forms.TextBox();
            this.BtnDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(142, 72);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 3;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(228, 72);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblQuestion
            // 
            this.LblQuestion.AutoSize = true;
            this.LblQuestion.Location = new System.Drawing.Point(12, 22);
            this.LblQuestion.Name = "LblQuestion";
            this.LblQuestion.Size = new System.Drawing.Size(175, 13);
            this.LblQuestion.TabIndex = 8;
            this.LblQuestion.Text = "Enter the PIN code for the Yubikey:";
            // 
            // TxtPasscode
            // 
            this.TxtPasscode.Location = new System.Drawing.Point(11, 37);
            this.TxtPasscode.Margin = new System.Windows.Forms.Padding(2);
            this.TxtPasscode.Name = "TxtPasscode";
            this.TxtPasscode.Size = new System.Drawing.Size(334, 20);
            this.TxtPasscode.TabIndex = 1;
            // 
            // BtnDefault
            // 
            this.BtnDefault.Location = new System.Drawing.Point(350, 34);
            this.BtnDefault.Name = "BtnDefault";
            this.BtnDefault.Size = new System.Drawing.Size(80, 25);
            this.BtnDefault.TabIndex = 2;
            this.BtnDefault.Text = "Default";
            this.BtnDefault.UseVisualStyleBackColor = true;
            this.BtnDefault.Click += new System.EventHandler(this.BtnDefault_Click);
            // 
            // FrmPIN
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(451, 107);
            this.Controls.Add(this.BtnDefault);
            this.Controls.Add(this.TxtPasscode);
            this.Controls.Add(this.LblQuestion);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPIN";
            this.Text = "Credentials Required for this Action";
            this.Activated += new System.EventHandler(this.FrmPIN_Activated);
            this.Load += new System.EventHandler(this.FrmPIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label LblQuestion;
        private System.Windows.Forms.TextBox TxtPasscode;
        private System.Windows.Forms.Button BtnDefault;
    }
}