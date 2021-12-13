
namespace AuthenticatorProject {
    partial class FrmSign {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSign));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtTransaction = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PicSignature = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSignature)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtTransaction);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(315, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Digital Signature Application";
            // 
            // TxtTransaction
            // 
            this.TxtTransaction.Location = new System.Drawing.Point(13, 44);
            this.TxtTransaction.Multiline = true;
            this.TxtTransaction.Name = "TxtTransaction";
            this.TxtTransaction.ReadOnly = true;
            this.TxtTransaction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtTransaction.Size = new System.Drawing.Size(290, 55);
            this.TxtTransaction.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "You are being asked to provide a digital signature:";
            // 
            // PicSignature
            // 
            this.PicSignature.Image = ((System.Drawing.Image)(resources.GetObject("PicSignature.Image")));
            this.PicSignature.Location = new System.Drawing.Point(135, 129);
            this.PicSignature.Margin = new System.Windows.Forms.Padding(2);
            this.PicSignature.Name = "PicSignature";
            this.PicSignature.Size = new System.Drawing.Size(64, 64);
            this.PicSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSignature.TabIndex = 1;
            this.PicSignature.TabStop = false;
            this.PicSignature.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.PicSignature_QueryContinueDrag);
            this.PicSignature.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicSignature_MouseDown);
            // 
            // FrmSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 200);
            this.Controls.Add(this.PicSignature);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSign";
            this.ShowInTaskbar = false;
            this.Text = "Digitally Sign Operation";
            this.Load += new System.EventHandler(this.FrmSign_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSignature)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicSignature;
        private System.Windows.Forms.TextBox TxtTransaction;
    }
}