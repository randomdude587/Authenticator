
namespace AuthenticatorProject {
    partial class FrmPassword {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPassword));
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkDisplay = new System.Windows.Forms.CheckBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LblPredictabilityColor = new System.Windows.Forms.Label();
            this.LblEntropyColor = new System.Windows.Forms.Label();
            this.LblPredictability = new System.Windows.Forms.Label();
            this.LblEntropy = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.TxtSpecialCharsAlphabet = new System.Windows.Forms.TextBox();
            this.ChkSpecialChars = new System.Windows.Forms.CheckBox();
            this.ChkDigits = new System.Windows.Forms.CheckBox();
            this.ChkUpperCase = new System.Windows.Forms.CheckBox();
            this.ChkLowerCase = new System.Windows.Forms.CheckBox();
            this.NumPasswordLength = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPasswordLength)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(162, 335);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 11;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(248, 335);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 12;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkDisplay);
            this.groupBox1.Controls.Add(this.TxtPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 59);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Construction of the password";
            // 
            // ChkDisplay
            // 
            this.ChkDisplay.AutoSize = true;
            this.ChkDisplay.Location = new System.Drawing.Point(402, 24);
            this.ChkDisplay.Name = "ChkDisplay";
            this.ChkDisplay.Size = new System.Drawing.Size(60, 17);
            this.ChkDisplay.TabIndex = 2;
            this.ChkDisplay.Text = "Display";
            this.ChkDisplay.UseVisualStyleBackColor = true;
            this.ChkDisplay.CheckedChanged += new System.EventHandler(this.ChkDisplay_CheckedChanged);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(106, 22);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(290, 20);
            this.TxtPassword.TabIndex = 1;
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LblPredictabilityColor);
            this.groupBox3.Controls.Add(this.LblEntropyColor);
            this.groupBox3.Controls.Add(this.LblPredictability);
            this.groupBox3.Controls.Add(this.LblEntropy);
            this.groupBox3.Location = new System.Drawing.Point(5, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(473, 87);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Robustness and predictability";
            // 
            // LblPredictabilityColor
            // 
            this.LblPredictabilityColor.BackColor = System.Drawing.Color.White;
            this.LblPredictabilityColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblPredictabilityColor.Location = new System.Drawing.Point(6, 50);
            this.LblPredictabilityColor.Name = "LblPredictabilityColor";
            this.LblPredictabilityColor.Size = new System.Drawing.Size(85, 20);
            this.LblPredictabilityColor.TabIndex = 4;
            // 
            // LblEntropyColor
            // 
            this.LblEntropyColor.BackColor = System.Drawing.Color.White;
            this.LblEntropyColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblEntropyColor.Location = new System.Drawing.Point(6, 25);
            this.LblEntropyColor.Name = "LblEntropyColor";
            this.LblEntropyColor.Size = new System.Drawing.Size(85, 20);
            this.LblEntropyColor.TabIndex = 3;
            // 
            // LblPredictability
            // 
            this.LblPredictability.Location = new System.Drawing.Point(97, 51);
            this.LblPredictability.Name = "LblPredictability";
            this.LblPredictability.Size = new System.Drawing.Size(355, 23);
            this.LblPredictability.TabIndex = 2;
            this.LblPredictability.Text = "Predictability statement";
            // 
            // LblEntropy
            // 
            this.LblEntropy.Location = new System.Drawing.Point(97, 26);
            this.LblEntropy.Name = "LblEntropy";
            this.LblEntropy.Size = new System.Drawing.Size(355, 25);
            this.LblEntropy.TabIndex = 1;
            this.LblEntropy.Text = "Entropy measurement";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnGenerate);
            this.groupBox4.Controls.Add(this.TxtSpecialCharsAlphabet);
            this.groupBox4.Controls.Add(this.ChkSpecialChars);
            this.groupBox4.Controls.Add(this.ChkDigits);
            this.groupBox4.Controls.Add(this.ChkUpperCase);
            this.groupBox4.Controls.Add(this.ChkLowerCase);
            this.groupBox4.Controls.Add(this.NumPasswordLength);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(5, 168);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(473, 161);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Password Generator";
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Location = new System.Drawing.Point(196, 126);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(80, 25);
            this.BtnGenerate.TabIndex = 10;
            this.BtnGenerate.Text = "Generate";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // TxtSpecialCharsAlphabet
            // 
            this.TxtSpecialCharsAlphabet.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSpecialCharsAlphabet.Location = new System.Drawing.Point(243, 100);
            this.TxtSpecialCharsAlphabet.Name = "TxtSpecialCharsAlphabet";
            this.TxtSpecialCharsAlphabet.Size = new System.Drawing.Size(219, 20);
            this.TxtSpecialCharsAlphabet.TabIndex = 9;
            // 
            // ChkSpecialChars
            // 
            this.ChkSpecialChars.AutoSize = true;
            this.ChkSpecialChars.Location = new System.Drawing.Point(243, 75);
            this.ChkSpecialChars.Name = "ChkSpecialChars";
            this.ChkSpecialChars.Size = new System.Drawing.Size(137, 17);
            this.ChkSpecialChars.TabIndex = 8;
            this.ChkSpecialChars.Text = "Use Special Characters";
            this.ChkSpecialChars.UseVisualStyleBackColor = true;
            // 
            // ChkDigits
            // 
            this.ChkDigits.AutoSize = true;
            this.ChkDigits.Location = new System.Drawing.Point(9, 75);
            this.ChkDigits.Name = "ChkDigits";
            this.ChkDigits.Size = new System.Drawing.Size(98, 17);
            this.ChkDigits.TabIndex = 6;
            this.ChkDigits.Text = "Use Digits (0-9)";
            this.ChkDigits.UseVisualStyleBackColor = true;
            // 
            // ChkUpperCase
            // 
            this.ChkUpperCase.AutoSize = true;
            this.ChkUpperCase.Location = new System.Drawing.Point(243, 50);
            this.ChkUpperCase.Name = "ChkUpperCase";
            this.ChkUpperCase.Size = new System.Drawing.Size(175, 17);
            this.ChkUpperCase.TabIndex = 7;
            this.ChkUpperCase.Text = "Use Upper Case Alphabet (A-Z)";
            this.ChkUpperCase.UseVisualStyleBackColor = true;
            // 
            // ChkLowerCase
            // 
            this.ChkLowerCase.AutoSize = true;
            this.ChkLowerCase.Location = new System.Drawing.Point(9, 50);
            this.ChkLowerCase.Name = "ChkLowerCase";
            this.ChkLowerCase.Size = new System.Drawing.Size(172, 17);
            this.ChkLowerCase.TabIndex = 5;
            this.ChkLowerCase.Text = "Use Lower Case Alphabet (a-z)";
            this.ChkLowerCase.UseVisualStyleBackColor = true;
            // 
            // NumPasswordLength
            // 
            this.NumPasswordLength.Location = new System.Drawing.Point(106, 23);
            this.NumPasswordLength.Name = "NumPasswordLength";
            this.NumPasswordLength.Size = new System.Drawing.Size(82, 20);
            this.NumPasswordLength.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password Length:";
            // 
            // FrmPassword
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(491, 370);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPassword";
            this.ShowInTaskbar = false;
            this.Text = "Password Management Interface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPassword_FormClosing);
            this.Load += new System.EventHandler(this.FrmPassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPasswordLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ChkDisplay;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label LblEntropy;
        private System.Windows.Forms.Label LblPredictability;
        private System.Windows.Forms.Label LblPredictabilityColor;
        private System.Windows.Forms.Label LblEntropyColor;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.TextBox TxtSpecialCharsAlphabet;
        private System.Windows.Forms.CheckBox ChkSpecialChars;
        private System.Windows.Forms.CheckBox ChkDigits;
        private System.Windows.Forms.CheckBox ChkUpperCase;
        private System.Windows.Forms.CheckBox ChkLowerCase;
        private System.Windows.Forms.NumericUpDown NumPasswordLength;
        private System.Windows.Forms.Label label2;
    }
}