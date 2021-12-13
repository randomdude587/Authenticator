
namespace AuthenticatorProject {
    partial class FrmValueInput {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmValueInput));
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LblQuestion = new System.Windows.Forms.Label();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.CboValue = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(205, 67);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(80, 25);
            this.BtnOk.TabIndex = 3;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(291, 67);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblQuestion
            // 
            this.LblQuestion.Location = new System.Drawing.Point(14, 13);
            this.LblQuestion.Name = "LblQuestion";
            this.LblQuestion.Size = new System.Drawing.Size(548, 19);
            this.LblQuestion.TabIndex = 2;
            this.LblQuestion.Text = "Question";
            // 
            // TxtValue
            // 
            this.TxtValue.Location = new System.Drawing.Point(15, 35);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(547, 20);
            this.TxtValue.TabIndex = 1;
            // 
            // CboValue
            // 
            this.CboValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboValue.FormattingEnabled = true;
            this.CboValue.Location = new System.Drawing.Point(15, 48);
            this.CboValue.Name = "CboValue";
            this.CboValue.Size = new System.Drawing.Size(547, 21);
            this.CboValue.TabIndex = 2;
            // 
            // FrmValueInput
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(576, 104);
            this.Controls.Add(this.CboValue);
            this.Controls.Add(this.TxtValue);
            this.Controls.Add(this.LblQuestion);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmValueInput";
            this.Text = "Title";
            this.Load += new System.EventHandler(this.FrmValueInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label LblQuestion;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.ComboBox CboValue;
    }
}