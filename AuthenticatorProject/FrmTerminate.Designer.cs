
namespace AuthenticatorProject {
    partial class FrmTerminate {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTerminate));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtServerID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PicTermination = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTermination)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtServerID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 82);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Termination";
            // 
            // TxtServerID
            // 
            this.TxtServerID.Location = new System.Drawing.Point(11, 50);
            this.TxtServerID.Name = "TxtServerID";
            this.TxtServerID.ReadOnly = true;
            this.TxtServerID.Size = new System.Drawing.Size(391, 20);
            this.TxtServerID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "This will terminate the account:";
            // 
            // PicTermination
            // 
            this.PicTermination.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicTermination.Image = ((System.Drawing.Image)(resources.GetObject("PicTermination.Image")));
            this.PicTermination.Location = new System.Drawing.Point(180, 100);
            this.PicTermination.Name = "PicTermination";
            this.PicTermination.Size = new System.Drawing.Size(64, 64);
            this.PicTermination.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTermination.TabIndex = 2;
            this.PicTermination.TabStop = false;
            this.PicTermination.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.PicTermination_QueryContinueDrag);
            this.PicTermination.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicTermination_MouseDown);
            // 
            // FrmTerminate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 174);
            this.Controls.Add(this.PicTermination);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTerminate";
            this.ShowInTaskbar = false;
            this.Text = "Account Termination";
            this.Load += new System.EventHandler(this.FrmTerminate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTermination)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtServerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicTermination;
    }
}