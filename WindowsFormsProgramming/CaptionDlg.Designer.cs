namespace WindowsFormsProgramming
{
    partial class CaptionDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbImage = new System.Windows.Forms.Label();
            this.lbCaption = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.TextBox();
            this.lblCaption = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(94, 86);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(175, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbImage
            // 
            this.lbImage.AutoSize = true;
            this.lbImage.Location = new System.Drawing.Point(29, 23);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(36, 13);
            this.lbImage.TabIndex = 2;
            this.lbImage.Text = "Image";
            this.lbImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCaption
            // 
            this.lbCaption.AutoSize = true;
            this.lbCaption.Location = new System.Drawing.Point(29, 52);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(43, 13);
            this.lbCaption.TabIndex = 4;
            this.lbCaption.Text = "Caption";
            this.lbCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblImage
            // 
            this.lblImage.Location = new System.Drawing.Point(75, 23);
            this.lblImage.Name = "lblImage";
            this.lblImage.ReadOnly = true;
            this.lblImage.Size = new System.Drawing.Size(247, 20);
            this.lblImage.TabIndex = 3;
            this.lblImage.Text = "Image file name";
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(75, 49);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(247, 20);
            this.lblCaption.TabIndex = 5;
            this.lblCaption.Text = "Image caption";
            // 
            // CaptionDlg
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(334, 121);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lbCaption);
            this.Controls.Add(this.lbImage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptionDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Caption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbImage;
        private System.Windows.Forms.Label lbCaption;
        private System.Windows.Forms.TextBox lblImage;
        private System.Windows.Forms.TextBox lblCaption;
    }
}