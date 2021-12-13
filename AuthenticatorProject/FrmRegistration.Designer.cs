
namespace AuthenticatorProject {
    partial class FrmRegistration {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistration));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtLoginURL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PicServer = new System.Windows.Forms.PictureBox();
            this.TxtServerID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CboImplementations = new System.Windows.Forms.ComboBox();
            this.ChkCertificate = new System.Windows.Forms.CheckBox();
            this.CboProfiles = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnPrevious = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.PicRegistration = new System.Windows.Forms.PictureBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PanelParameters = new System.Windows.Forms.Panel();
            this.PicUnknown = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicServer)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicRegistration)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicUnknown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtLoginURL);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.PicServer);
            this.groupBox1.Controls.Add(this.TxtServerID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Information";
            // 
            // TxtLoginURL
            // 
            this.TxtLoginURL.Location = new System.Drawing.Point(185, 51);
            this.TxtLoginURL.Name = "TxtLoginURL";
            this.TxtLoginURL.ReadOnly = true;
            this.TxtLoginURL.Size = new System.Drawing.Size(549, 20);
            this.TxtLoginURL.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Login URL:";
            // 
            // PicServer
            // 
            this.PicServer.Location = new System.Drawing.Point(13, 19);
            this.PicServer.Name = "PicServer";
            this.PicServer.Size = new System.Drawing.Size(64, 64);
            this.PicServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicServer.TabIndex = 2;
            this.PicServer.TabStop = false;
            // 
            // TxtServerID
            // 
            this.TxtServerID.Location = new System.Drawing.Point(185, 28);
            this.TxtServerID.Name = "TxtServerID";
            this.TxtServerID.ReadOnly = true;
            this.TxtServerID.Size = new System.Drawing.Size(549, 20);
            this.TxtServerID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CboImplementations);
            this.groupBox2.Controls.Add(this.ChkCertificate);
            this.groupBox2.Controls.Add(this.CboProfiles);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.BtnNext);
            this.groupBox2.Controls.Add(this.BtnPrevious);
            this.groupBox2.Location = new System.Drawing.Point(12, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(741, 58);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Provide Registration Details";
            // 
            // CboImplementations
            // 
            this.CboImplementations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboImplementations.FormattingEnabled = true;
            this.CboImplementations.Location = new System.Drawing.Point(447, 21);
            this.CboImplementations.Name = "CboImplementations";
            this.CboImplementations.Size = new System.Drawing.Size(250, 21);
            this.CboImplementations.TabIndex = 4;
            // 
            // ChkCertificate
            // 
            this.ChkCertificate.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkCertificate.AutoSize = true;
            this.ChkCertificate.Image = ((System.Drawing.Image)(resources.GetObject("ChkCertificate.Image")));
            this.ChkCertificate.Location = new System.Drawing.Point(703, 15);
            this.ChkCertificate.Name = "ChkCertificate";
            this.ChkCertificate.Size = new System.Drawing.Size(31, 31);
            this.ChkCertificate.TabIndex = 5;
            this.ChkCertificate.UseVisualStyleBackColor = true;
            this.ChkCertificate.CheckedChanged += new System.EventHandler(this.FetchCertificate);
            // 
            // CboProfiles
            // 
            this.CboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboProfiles.Enabled = false;
            this.CboProfiles.FormattingEnabled = true;
            this.CboProfiles.Location = new System.Drawing.Point(81, 21);
            this.CboProfiles.Name = "CboProfiles";
            this.CboProfiles.Size = new System.Drawing.Size(250, 21);
            this.CboProfiles.TabIndex = 1;
            this.CboProfiles.SelectedIndexChanged += new System.EventHandler(this.CboProfiles_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "From Profile:";
            // 
            // BtnNext
            // 
            this.BtnNext.Enabled = false;
            this.BtnNext.Image = ((System.Drawing.Image)(resources.GetObject("BtnNext.Image")));
            this.BtnNext.Location = new System.Drawing.Point(367, 19);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(24, 24);
            this.BtnNext.TabIndex = 3;
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.Enabled = false;
            this.BtnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrevious.Image")));
            this.BtnPrevious.Location = new System.Drawing.Point(337, 19);
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(24, 24);
            this.BtnPrevious.TabIndex = 2;
            this.BtnPrevious.UseVisualStyleBackColor = true;
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // ToolTip
            // 
            this.ToolTip.ToolTipTitle = "Required";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.DefaultExt = "png";
            this.OpenFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            // 
            // PicRegistration
            // 
            this.PicRegistration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicRegistration.ErrorImage = ((System.Drawing.Image)(resources.GetObject("PicRegistration.ErrorImage")));
            this.PicRegistration.Image = ((System.Drawing.Image)(resources.GetObject("PicRegistration.Image")));
            this.PicRegistration.Location = new System.Drawing.Point(350, 376);
            this.PicRegistration.Name = "PicRegistration";
            this.PicRegistration.Size = new System.Drawing.Size(64, 64);
            this.PicRegistration.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicRegistration.TabIndex = 2;
            this.PicRegistration.TabStop = false;
            this.PicRegistration.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.PicRegistration_QueryContinueDrag);
            this.PicRegistration.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicRegistration_MouseDown);
            // 
            // BtnOK
            // 
            this.BtnOK.Enabled = false;
            this.BtnOK.Location = new System.Drawing.Point(299, 453);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 6;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(385, 453);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PanelParameters);
            this.groupBox3.Location = new System.Drawing.Point(13, 179);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(740, 185);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Information";
            // 
            // PanelParameters
            // 
            this.PanelParameters.AutoScroll = true;
            this.PanelParameters.Location = new System.Drawing.Point(8, 18);
            this.PanelParameters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PanelParameters.Name = "PanelParameters";
            this.PanelParameters.Size = new System.Drawing.Size(726, 162);
            this.PanelParameters.TabIndex = 7;
            // 
            // PicUnknown
            // 
            this.PicUnknown.Image = ((System.Drawing.Image)(resources.GetObject("PicUnknown.Image")));
            this.PicUnknown.Location = new System.Drawing.Point(511, 392);
            this.PicUnknown.Name = "PicUnknown";
            this.PicUnknown.Size = new System.Drawing.Size(48, 48);
            this.PicUnknown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicUnknown.TabIndex = 36;
            this.PicUnknown.TabStop = false;
            this.PicUnknown.Visible = false;
            // 
            // FrmRegistration
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(765, 488);
            this.Controls.Add(this.PicUnknown);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.PicRegistration);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegistration";
            this.ShowInTaskbar = false;
            this.Text = "User Registration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegistration_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegistration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicServer)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicRegistration)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicUnknown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox PicServer;
        private System.Windows.Forms.TextBox TxtServerID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CboProfiles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnPrevious;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.PictureBox PicRegistration;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.TextBox TxtLoginURL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel PanelParameters;
        private System.Windows.Forms.PictureBox PicUnknown;
        private System.Windows.Forms.ComboBox CboImplementations;
        private System.Windows.Forms.CheckBox ChkCertificate;
    }
}