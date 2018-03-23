namespace WindowsFormsProgramming
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.pbxPhoto = new System.Windows.Forms.PictureBox();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrechToFit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuActualSize = new System.Windows.Forms.ToolStripMenuItem();
            this.menuZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuView = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPhoto)).BeginInit();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxPhoto
            // 
            this.pbxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxPhoto.ContextMenuStrip = this.ctxMenuView;
            this.pbxPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxPhoto.Location = new System.Drawing.Point(0, 24);
            this.pbxPhoto.Name = "pbxPhoto";
            this.pbxPhoto.Size = new System.Drawing.Size(444, 359);
            this.pbxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPhoto.TabIndex = 1;
            this.pbxPhoto.TabStop = false;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuView});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(444, 24);
            this.menuMain.TabIndex = 2;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLoad,
            this.toolStripMenuItem1,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuLoad
            // 
            this.menuLoad.Name = "menuLoad";
            this.menuLoad.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.menuLoad.Size = new System.Drawing.Size(140, 22);
            this.menuLoad.Text = "&Load";
            this.menuLoad.Click += new System.EventHandler(this.menuLoad_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(137, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(140, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuImage});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "&View";
            // 
            // menuImage
            // 
            this.menuImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrechToFit,
            this.menuActualSize,
            this.menuZoom});
            this.menuImage.Name = "menuImage";
            this.menuImage.Size = new System.Drawing.Size(107, 22);
            this.menuImage.Text = "&Image";
            this.menuImage.DropDownOpening += new System.EventHandler(this.menuImage_Popup);
            // 
            // menuStrechToFit
            // 
            this.menuStrechToFit.Name = "menuStrechToFit";
            this.menuStrechToFit.Size = new System.Drawing.Size(139, 22);
            this.menuStrechToFit.Text = "Stretch to fit";
            this.menuStrechToFit.Click += new System.EventHandler(this.menuImage_ChildClick);
            // 
            // menuActualSize
            // 
            this.menuActualSize.Name = "menuActualSize";
            this.menuActualSize.Size = new System.Drawing.Size(139, 22);
            this.menuActualSize.Text = "Actual size";
            this.menuActualSize.Click += new System.EventHandler(this.menuImage_ChildClick);
            // 
            // menuZoom
            // 
            this.menuZoom.Name = "menuZoom";
            this.menuZoom.Size = new System.Drawing.Size(139, 22);
            this.menuZoom.Text = "Zoom";
            this.menuZoom.Click += new System.EventHandler(this.menuImage_ChildClick);
            // 
            // ctxMenuView
            // 
            this.ctxMenuView.Name = "ctxMenuView";
            this.ctxMenuView.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 383);
            this.Controls.Add(this.pbxPhoto);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.MinimumSize = new System.Drawing.Size(460, 422);
            this.Name = "MainForm";
            this.Text = "My photos";
            ((System.ComponentModel.ISupportInitialize)(this.pbxPhoto)).EndInit();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxPhoto;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuImage;
        private System.Windows.Forms.ToolStripMenuItem menuStrechToFit;
        private System.Windows.Forms.ToolStripMenuItem menuActualSize;
        private System.Windows.Forms.ToolStripMenuItem menuZoom;
        private System.Windows.Forms.ContextMenuStrip ctxMenuView;
    }
}

