namespace WindowsFormsProgramming
{
    partial class PixelDlg
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.xVal = new System.Windows.Forms.TextBox();
            this.yVal = new System.Windows.Forms.TextBox();
            this.redVal = new System.Windows.Forms.TextBox();
            this.greenVal = new System.Windows.Forms.TextBox();
            this.blueVal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Red";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Green";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Blue";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(32, 171);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // xVal
            // 
            this.xVal.Location = new System.Drawing.Point(54, 12);
            this.xVal.Name = "xVal";
            this.xVal.ReadOnly = true;
            this.xVal.Size = new System.Drawing.Size(68, 20);
            this.xVal.TabIndex = 6;
            // 
            // yVal
            // 
            this.yVal.Location = new System.Drawing.Point(54, 38);
            this.yVal.Name = "yVal";
            this.yVal.ReadOnly = true;
            this.yVal.Size = new System.Drawing.Size(68, 20);
            this.yVal.TabIndex = 7;
            // 
            // redVal
            // 
            this.redVal.Location = new System.Drawing.Point(53, 79);
            this.redVal.Name = "redVal";
            this.redVal.ReadOnly = true;
            this.redVal.Size = new System.Drawing.Size(68, 20);
            this.redVal.TabIndex = 8;
            // 
            // greenVal
            // 
            this.greenVal.Location = new System.Drawing.Point(54, 105);
            this.greenVal.Name = "greenVal";
            this.greenVal.ReadOnly = true;
            this.greenVal.Size = new System.Drawing.Size(68, 20);
            this.greenVal.TabIndex = 9;
            // 
            // blueVal
            // 
            this.blueVal.Location = new System.Drawing.Point(54, 130);
            this.blueVal.Name = "blueVal";
            this.blueVal.ReadOnly = true;
            this.blueVal.Size = new System.Drawing.Size(68, 20);
            this.blueVal.TabIndex = 10;
            // 
            // PixelDlg
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(142, 206);
            this.Controls.Add(this.blueVal);
            this.Controls.Add(this.greenVal);
            this.Controls.Add(this.redVal);
            this.Controls.Add(this.yVal);
            this.Controls.Add(this.xVal);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PixelDlg";
            this.Text = "Pixel Values";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox xVal;
        private System.Windows.Forms.TextBox yVal;
        private System.Windows.Forms.TextBox redVal;
        private System.Windows.Forms.TextBox greenVal;
        private System.Windows.Forms.TextBox blueVal;
    }
}