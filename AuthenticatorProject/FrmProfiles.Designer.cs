
namespace AuthenticatorProject {
    partial class FrmProfiles {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProfiles));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PicUnknown = new System.Windows.Forms.PictureBox();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.TxtOrganization = new System.Windows.Forms.TextBox();
            this.TxtPhoneNumber = new System.Windows.Forms.TextBox();
            this.TxtTitle = new System.Windows.Forms.TextBox();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.PicAvatar = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.OpenAvatarDialog = new System.Windows.Forms.OpenFileDialog();
            this.BtnOK = new System.Windows.Forms.Button();
            this.ToolStripProfiles = new System.Windows.Forms.ToolStrip();
            this.BtnPrevious = new System.Windows.Forms.ToolStripButton();
            this.BtnNext = new System.Windows.Forms.ToolStripButton();
            this.BtnClone = new System.Windows.Forms.ToolStripButton();
            this.BtnAdd = new System.Windows.Forms.ToolStripButton();
            this.BtnDelete = new System.Windows.Forms.ToolStripButton();
            this.BtnImport = new System.Windows.Forms.ToolStripButton();
            this.BtnExport = new System.Windows.Forms.ToolStripButton();
            this.BtnProfiles = new System.Windows.Forms.ToolStripDropDownButton();
            this.TxtProfileName = new System.Windows.Forms.ToolStripTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicUnknown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAvatar)).BeginInit();
            this.ToolStripProfiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PicUnknown);
            this.groupBox1.Controls.Add(this.TxtAddress);
            this.groupBox1.Controls.Add(this.TxtOrganization);
            this.groupBox1.Controls.Add(this.TxtPhoneNumber);
            this.groupBox1.Controls.Add(this.TxtTitle);
            this.groupBox1.Controls.Add(this.TxtLastName);
            this.groupBox1.Controls.Add(this.TxtFirstName);
            this.groupBox1.Controls.Add(this.TxtEmail);
            this.groupBox1.Controls.Add(this.PicAvatar);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 256);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile Parameters";
            // 
            // PicUnknown
            // 
            this.PicUnknown.Image = ((System.Drawing.Image)(resources.GetObject("PicUnknown.Image")));
            this.PicUnknown.Location = new System.Drawing.Point(181, 22);
            this.PicUnknown.Name = "PicUnknown";
            this.PicUnknown.Size = new System.Drawing.Size(48, 48);
            this.PicUnknown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicUnknown.TabIndex = 16;
            this.PicUnknown.TabStop = false;
            this.PicUnknown.Visible = false;
            // 
            // TxtAddress
            // 
            this.TxtAddress.Location = new System.Drawing.Point(100, 179);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(290, 20);
            this.TxtAddress.TabIndex = 5;
            this.TxtAddress.TextChanged += new System.EventHandler(this.TxtAddress_TextChanged);
            // 
            // TxtOrganization
            // 
            this.TxtOrganization.Location = new System.Drawing.Point(100, 228);
            this.TxtOrganization.Name = "TxtOrganization";
            this.TxtOrganization.Size = new System.Drawing.Size(290, 20);
            this.TxtOrganization.TabIndex = 7;
            this.TxtOrganization.TextChanged += new System.EventHandler(this.TxtOrganization_TextChanged);
            // 
            // TxtPhoneNumber
            // 
            this.TxtPhoneNumber.Location = new System.Drawing.Point(100, 154);
            this.TxtPhoneNumber.Name = "TxtPhoneNumber";
            this.TxtPhoneNumber.Size = new System.Drawing.Size(290, 20);
            this.TxtPhoneNumber.TabIndex = 4;
            this.TxtPhoneNumber.TextChanged += new System.EventHandler(this.TxtPhoneNumber_TextChanged);
            // 
            // TxtTitle
            // 
            this.TxtTitle.Location = new System.Drawing.Point(100, 203);
            this.TxtTitle.Name = "TxtTitle";
            this.TxtTitle.Size = new System.Drawing.Size(290, 20);
            this.TxtTitle.TabIndex = 6;
            this.TxtTitle.TextChanged += new System.EventHandler(this.TxtTitle_TextChanged);
            // 
            // TxtLastName
            // 
            this.TxtLastName.Location = new System.Drawing.Point(100, 104);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(290, 20);
            this.TxtLastName.TabIndex = 2;
            this.TxtLastName.TextChanged += new System.EventHandler(this.TxtLastName_TextChanged);
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Location = new System.Drawing.Point(100, 79);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(290, 20);
            this.TxtFirstName.TabIndex = 1;
            this.TxtFirstName.TextChanged += new System.EventHandler(this.TxtFirstName_TextChanged);
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(100, 130);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(290, 20);
            this.TxtEmail.TabIndex = 3;
            this.TxtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.TxtEmail_Validating);
            // 
            // PicAvatar
            // 
            this.PicAvatar.Location = new System.Drawing.Point(100, 19);
            this.PicAvatar.Name = "PicAvatar";
            this.PicAvatar.Size = new System.Drawing.Size(48, 48);
            this.PicAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicAvatar.TabIndex = 15;
            this.PicAvatar.TabStop = false;
            this.PicAvatar.DoubleClick += new System.EventHandler(this.PicAvatar_DoubleClick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Avatar:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Address:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Organization:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Phone Number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Title:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Email:";
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(210, 297);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "Cancel Changes";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // OpenAvatarDialog
            // 
            this.OpenAvatarDialog.DefaultExt = "png";
            this.OpenAvatarDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            this.OpenAvatarDialog.Title = "Open the Image File to use as Avatar";
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(124, 297);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 25);
            this.BtnOK.TabIndex = 8;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // ToolStripProfiles
            // 
            this.ToolStripProfiles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStripProfiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnPrevious,
            this.BtnNext,
            this.BtnClone,
            this.BtnAdd,
            this.BtnDelete,
            this.BtnImport,
            this.BtnExport,
            this.BtnProfiles,
            this.TxtProfileName});
            this.ToolStripProfiles.Location = new System.Drawing.Point(0, 0);
            this.ToolStripProfiles.Name = "ToolStripProfiles";
            this.ToolStripProfiles.Size = new System.Drawing.Size(415, 32);
            this.ToolStripProfiles.TabIndex = 22;
            this.ToolStripProfiles.Text = "toolStrip1";
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrevious.Image")));
            this.BtnPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(29, 29);
            this.BtnPrevious.ToolTipText = "Previous Profile";
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNext.Image = ((System.Drawing.Image)(resources.GetObject("BtnNext.Image")));
            this.BtnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(29, 29);
            this.BtnNext.ToolTipText = "Go to next profile";
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnClone
            // 
            this.BtnClone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnClone.Image = ((System.Drawing.Image)(resources.GetObject("BtnClone.Image")));
            this.BtnClone.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnClone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnClone.Name = "BtnClone";
            this.BtnClone.Size = new System.Drawing.Size(29, 29);
            this.BtnClone.ToolTipText = "Clone the current profile";
            this.BtnClone.Click += new System.EventHandler(this.BtnClone_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdd.Image")));
            this.BtnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(29, 29);
            this.BtnAdd.ToolTipText = "Add a new empty profile";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
            this.BtnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(29, 29);
            this.BtnDelete.ToolTipText = "Delete the current profile";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnImport.Image = ((System.Drawing.Image)(resources.GetObject("BtnImport.Image")));
            this.BtnImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(29, 29);
            this.BtnImport.ToolTipText = "Import profiles from file";
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnExport.Image = ((System.Drawing.Image)(resources.GetObject("BtnExport.Image")));
            this.BtnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(29, 29);
            this.BtnExport.ToolTipText = "Export Profile to File";
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnProfiles
            // 
            this.BtnProfiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnProfiles.Image = ((System.Drawing.Image)(resources.GetObject("BtnProfiles.Image")));
            this.BtnProfiles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnProfiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnProfiles.Name = "BtnProfiles";
            this.BtnProfiles.Size = new System.Drawing.Size(38, 29);
            this.BtnProfiles.ToolTipText = "Select a profile";
            this.BtnProfiles.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.BtnProfiles_DropDownItemClicked);
            // 
            // TxtProfileName
            // 
            this.TxtProfileName.AcceptsReturn = true;
            this.TxtProfileName.Name = "TxtProfileName";
            this.TxtProfileName.Size = new System.Drawing.Size(151, 32);
            this.TxtProfileName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtProfileName_Validating);
            // 
            // FrmProfiles
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(415, 328);
            this.Controls.Add(this.ToolStripProfiles);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProfiles";
            this.Text = "User Profiles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProfiles_FormClosing);
            this.Load += new System.EventHandler(this.FrmProfiles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicUnknown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAvatar)).EndInit();
            this.ToolStripProfiles.ResumeLayout(false);
            this.ToolStripProfiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PicAvatar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TextBox TxtOrganization;
        private System.Windows.Forms.TextBox TxtPhoneNumber;
        private System.Windows.Forms.TextBox TxtTitle;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.OpenFileDialog OpenAvatarDialog;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.ToolStrip ToolStripProfiles;
        private System.Windows.Forms.ToolStripButton BtnPrevious;
        private System.Windows.Forms.ToolStripButton BtnNext;
        private System.Windows.Forms.ToolStripButton BtnClone;
        private System.Windows.Forms.ToolStripButton BtnAdd;
        private System.Windows.Forms.ToolStripButton BtnImport;
        private System.Windows.Forms.ToolStripButton BtnDelete;
        private System.Windows.Forms.ToolStripDropDownButton BtnProfiles;
        private System.Windows.Forms.ToolStripTextBox TxtProfileName;
        private System.Windows.Forms.PictureBox PicUnknown;
        private System.Windows.Forms.ToolStripButton BtnExport;
    }
}