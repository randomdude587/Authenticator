
namespace AuthenticatorProject {
    partial class FrmImportProfiles {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportProfiles));
            this.TxtProfileFile = new System.Windows.Forms.TextBox();
            this.BtnProfilesFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.openProfilesDialog = new System.Windows.Forms.OpenFileDialog();
            this.optSkip = new System.Windows.Forms.RadioButton();
            this.optReplace = new System.Windows.Forms.RadioButton();
            this.optCopy = new System.Windows.Forms.RadioButton();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtProfileFile
            // 
            this.TxtProfileFile.AllowDrop = true;
            this.TxtProfileFile.Location = new System.Drawing.Point(136, 17);
            this.TxtProfileFile.Name = "TxtProfileFile";
            this.TxtProfileFile.Size = new System.Drawing.Size(394, 20);
            this.TxtProfileFile.TabIndex = 2;
            this.TxtProfileFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtProfileFile_DragDrop);
            this.TxtProfileFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.TxtProfileFile_DragEnter);
            // 
            // BtnProfilesFile
            // 
            this.BtnProfilesFile.Image = ((System.Drawing.Image)(resources.GetObject("BtnProfilesFile.Image")));
            this.BtnProfilesFile.Location = new System.Drawing.Point(100, 11);
            this.BtnProfilesFile.Name = "BtnProfilesFile";
            this.BtnProfilesFile.Size = new System.Drawing.Size(30, 30);
            this.BtnProfilesFile.TabIndex = 0;
            this.BtnProfilesFile.Text = "...";
            this.BtnProfilesFile.UseVisualStyleBackColor = true;
            this.BtnProfilesFile.Click += new System.EventHandler(this.BtnProfilesFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "User Profiles File:";
            // 
            // openProfilesDialog
            // 
            this.openProfilesDialog.DefaultExt = "xml";
            this.openProfilesDialog.Filter = "XML Files|*.xml|All Files|*.*";
            // 
            // optSkip
            // 
            this.optSkip.AutoSize = true;
            this.optSkip.Checked = true;
            this.optSkip.Location = new System.Drawing.Point(24, 53);
            this.optSkip.Name = "optSkip";
            this.optSkip.Size = new System.Drawing.Size(122, 17);
            this.optSkip.TabIndex = 3;
            this.optSkip.TabStop = true;
            this.optSkip.Text = "Skip Existing Profiles";
            this.optSkip.UseVisualStyleBackColor = true;
            // 
            // optReplace
            // 
            this.optReplace.AutoSize = true;
            this.optReplace.Location = new System.Drawing.Point(24, 76);
            this.optReplace.Name = "optReplace";
            this.optReplace.Size = new System.Drawing.Size(141, 17);
            this.optReplace.TabIndex = 4;
            this.optReplace.Text = "Replace Existing Profiles";
            this.optReplace.UseVisualStyleBackColor = true;
            // 
            // optCopy
            // 
            this.optCopy.AutoSize = true;
            this.optCopy.Location = new System.Drawing.Point(24, 99);
            this.optCopy.Name = "optCopy";
            this.optCopy.Size = new System.Drawing.Size(231, 17);
            this.optCopy.TabIndex = 5;
            this.optCopy.Text = "Copy Existing Profiles Under Different Name";
            this.optCopy.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(189, 126);
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
            this.BtnCancel.Location = new System.Drawing.Point(275, 126);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 25);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmImportProfiles
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(544, 159);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.optCopy);
            this.Controls.Add(this.optReplace);
            this.Controls.Add(this.optSkip);
            this.Controls.Add(this.TxtProfileFile);
            this.Controls.Add(this.BtnProfilesFile);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportProfiles";
            this.ShowInTaskbar = false;
            this.Text = "Import Profiles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmImportProfiles_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtProfileFile;
        private System.Windows.Forms.Button BtnProfilesFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openProfilesDialog;
        private System.Windows.Forms.RadioButton optSkip;
        private System.Windows.Forms.RadioButton optReplace;
        private System.Windows.Forms.RadioButton optCopy;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
    }
}