﻿namespace WindowsFormsProgramming
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ctxMenuView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPhotoProp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAlbumProp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuScale = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrechToFit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuActualSize = new System.Windows.Forms.ToolStripMenuItem();
            this.menuZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuNext = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPixel = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbpnlFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbpnlImageSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbpnlFileIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbpnlImagePercent = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlPhoto = new System.Windows.Forms.Panel();
            this.toolbarMain = new System.Windows.Forms.ToolStrip();
            this.tbbNew = new System.Windows.Forms.ToolStripButton();
            this.tbbOpen = new System.Windows.Forms.ToolStripButton();
            this.tbbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbNext = new System.Windows.Forms.ToolStripButton();
            this.tbbPrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbPixelData = new System.Windows.Forms.ToolStripButton();
            this.tbbImage = new System.Windows.Forms.ToolStripDropDownButton();
            this.ctxMenuImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolbarMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctxMenuView
            // 
            this.ctxMenuView.Name = "ctxMenuView";
            this.ctxMenuView.Size = new System.Drawing.Size(61, 4);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuView});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(494, 24);
            this.menuMain.TabIndex = 2;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuOpen,
            this.menuSave,
            this.menuSaveAs,
            this.toolStripMenuItem1,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuNew
            // 
            this.menuNew.Name = "menuNew";
            this.menuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuNew.Size = new System.Drawing.Size(146, 22);
            this.menuNew.Text = "&New";
            this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuOpen.Size = new System.Drawing.Size(146, 22);
            this.menuOpen.Text = "&Open";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSave.Size = new System.Drawing.Size(146, 22);
            this.menuSave.Text = "&Save";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(146, 22);
            this.menuSaveAs.Text = "&Save As";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(146, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.ToolTipText = "Exits the application";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            this.menuExit.MouseEnter += new System.EventHandler(this.menuStrip_OnMouseEnter);
            this.menuExit.MouseLeave += new System.EventHandler(this.menuStrip_OnMouseLeave);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd,
            this.menuRemove,
            this.toolStripMenuItem3,
            this.menuPhotoProp,
            this.menuAlbumProp});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 20);
            this.menuEdit.Text = "&Edit";
            this.menuEdit.DropDownOpening += new System.EventHandler(this.menuEdit_DropDownOpening);
            // 
            // menuAdd
            // 
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.menuAdd.Size = new System.Drawing.Size(180, 22);
            this.menuAdd.Text = "&Add";
            this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
            // 
            // menuRemove
            // 
            this.menuRemove.Name = "menuRemove";
            this.menuRemove.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.menuRemove.Size = new System.Drawing.Size(180, 22);
            this.menuRemove.Text = "&Remove";
            this.menuRemove.Click += new System.EventHandler(this.menuRemove_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // menuPhotoProp
            // 
            this.menuPhotoProp.Enabled = false;
            this.menuPhotoProp.Name = "menuPhotoProp";
            this.menuPhotoProp.Size = new System.Drawing.Size(180, 22);
            this.menuPhotoProp.Text = "Photo properties";
            this.menuPhotoProp.Click += new System.EventHandler(this.menuPhotoProp_Click);
            // 
            // menuAlbumProp
            // 
            this.menuAlbumProp.Name = "menuAlbumProp";
            this.menuAlbumProp.Size = new System.Drawing.Size(180, 22);
            this.menuAlbumProp.Text = "Album properties";
            this.menuAlbumProp.Click += new System.EventHandler(this.menuAlbumProp_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuImage,
            this.toolStripMenuItem2,
            this.menuNext,
            this.menuPrevious,
            this.toolStripMenuItem4,
            this.menuPixel});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "&View";
            this.menuView.ToolTipText = "Application view properties";
            this.menuView.DropDownOpening += new System.EventHandler(this.menuView_DropDownOpening);
            this.menuView.MouseEnter += new System.EventHandler(this.menuStrip_OnMouseEnter);
            this.menuView.MouseLeave += new System.EventHandler(this.menuStrip_OnMouseLeave);
            // 
            // menuImage
            // 
            this.menuImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuScale,
            this.menuStrechToFit,
            this.menuActualSize,
            this.menuZoom});
            this.menuImage.Name = "menuImage";
            this.menuImage.Size = new System.Drawing.Size(192, 22);
            this.menuImage.Text = "&Image";
            this.menuImage.ToolTipText = "Adjust image display mode";
            this.menuImage.DropDownOpening += new System.EventHandler(this.menuImage_Popup);
            this.menuImage.MouseEnter += new System.EventHandler(this.menuStrip_OnMouseEnter);
            this.menuImage.MouseLeave += new System.EventHandler(this.menuStrip_OnMouseLeave);
            // 
            // menuScale
            // 
            this.menuScale.Name = "menuScale";
            this.menuScale.Size = new System.Drawing.Size(180, 22);
            this.menuScale.Text = "Scale to fit";
            this.menuScale.Click += new System.EventHandler(this.menuImage_ChildClick);
            // 
            // menuStrechToFit
            // 
            this.menuStrechToFit.Name = "menuStrechToFit";
            this.menuStrechToFit.Size = new System.Drawing.Size(180, 22);
            this.menuStrechToFit.Text = "Stretch to fit";
            this.menuStrechToFit.Click += new System.EventHandler(this.menuImage_ChildClick);
            // 
            // menuActualSize
            // 
            this.menuActualSize.Name = "menuActualSize";
            this.menuActualSize.Size = new System.Drawing.Size(180, 22);
            this.menuActualSize.Text = "Actual size";
            this.menuActualSize.Click += new System.EventHandler(this.menuImage_ChildClick);
            // 
            // menuZoom
            // 
            this.menuZoom.Name = "menuZoom";
            this.menuZoom.Size = new System.Drawing.Size(180, 22);
            this.menuZoom.Text = "Zoom";
            this.menuZoom.Click += new System.EventHandler(this.menuImage_ChildClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(189, 6);
            // 
            // menuNext
            // 
            this.menuNext.Name = "menuNext";
            this.menuNext.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.menuNext.Size = new System.Drawing.Size(192, 22);
            this.menuNext.Text = "&Next";
            this.menuNext.Click += new System.EventHandler(this.menuNext_Click);
            // 
            // menuPrevious
            // 
            this.menuPrevious.Name = "menuPrevious";
            this.menuPrevious.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.menuPrevious.Size = new System.Drawing.Size(192, 22);
            this.menuPrevious.Text = "&Previous";
            this.menuPrevious.Click += new System.EventHandler(this.menuPrevious_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(189, 6);
            // 
            // menuPixel
            // 
            this.menuPixel.Name = "menuPixel";
            this.menuPixel.Size = new System.Drawing.Size(192, 22);
            this.menuPixel.Text = "Pixel data";
            this.menuPixel.Click += new System.EventHandler(this.menuPixel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbpnlFileName,
            this.sbpnlImageSize,
            this.sbpnlFileIndex,
            this.sbpnlImagePercent});
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(494, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "Ready";
            // 
            // sbpnlFileName
            // 
            this.sbpnlFileName.AutoSize = false;
            this.sbpnlFileName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbpnlFileName.Name = "sbpnlFileName";
            this.sbpnlFileName.Size = new System.Drawing.Size(199, 17);
            this.sbpnlFileName.Spring = true;
            this.sbpnlFileName.Text = "Ready";
            this.sbpnlFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sbpnlFileName.ToolTipText = "Image file name";
            // 
            // sbpnlImageSize
            // 
            this.sbpnlImageSize.AutoSize = false;
            this.sbpnlImageSize.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sbpnlImageSize.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.sbpnlImageSize.Name = "sbpnlImageSize";
            this.sbpnlImageSize.Size = new System.Drawing.Size(95, 17);
            this.sbpnlImageSize.Text = "600x900";
            this.sbpnlImageSize.ToolTipText = "Image Size";
            // 
            // sbpnlFileIndex
            // 
            this.sbpnlFileIndex.AutoSize = false;
            this.sbpnlFileIndex.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sbpnlFileIndex.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.sbpnlFileIndex.Name = "sbpnlFileIndex";
            this.sbpnlFileIndex.Size = new System.Drawing.Size(55, 17);
            this.sbpnlFileIndex.Text = "1/2";
            // 
            // sbpnlImagePercent
            // 
            this.sbpnlImagePercent.AutoSize = false;
            this.sbpnlImagePercent.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sbpnlImagePercent.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.sbpnlImagePercent.Name = "sbpnlImagePercent";
            this.sbpnlImagePercent.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.sbpnlImagePercent.Size = new System.Drawing.Size(130, 17);
            this.sbpnlImagePercent.Text = "asdasdasd";
            this.sbpnlImagePercent.ToolTipText = "Percent of image shown";
            this.sbpnlImagePercent.Paint += new System.Windows.Forms.PaintEventHandler(this.sbpnlImagePercent_Paint);
            // 
            // pnlPhoto
            // 
            this.pnlPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPhoto.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pnlPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhoto.Location = new System.Drawing.Point(0, 49);
            this.pnlPhoto.Name = "pnlPhoto";
            this.pnlPhoto.Size = new System.Drawing.Size(494, 420);
            this.pnlPhoto.TabIndex = 4;
            this.pnlPhoto.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPhoto_Paint);
            this.pnlPhoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlPhoto_MouseMove);
            // 
            // toolbarMain
            // 
            this.toolbarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbNew,
            this.tbbOpen,
            this.tbbSave,
            this.toolStripSeparator1,
            this.tbbNext,
            this.tbbPrevious,
            this.toolStripSeparator2,
            this.tbbImage,
            this.toolStripSeparator3,
            this.tbbPixelData});
            this.toolbarMain.Location = new System.Drawing.Point(0, 24);
            this.toolbarMain.Name = "toolbarMain";
            this.toolbarMain.Size = new System.Drawing.Size(494, 25);
            this.toolbarMain.TabIndex = 5;
            this.toolbarMain.Text = "toolStrip1";
            // 
            // tbbNew
            // 
            this.tbbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbNew.Image = ((System.Drawing.Image)(resources.GetObject("tbbNew.Image")));
            this.tbbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbNew.Name = "tbbNew";
            this.tbbNew.Size = new System.Drawing.Size(23, 22);
            this.tbbNew.Text = "toolStripButton1";
            this.tbbNew.ToolTipText = "New album";
            this.tbbNew.Click += new System.EventHandler(this.toolbarButton_Click);
            // 
            // tbbOpen
            // 
            this.tbbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tbbOpen.Image")));
            this.tbbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbOpen.Name = "tbbOpen";
            this.tbbOpen.Size = new System.Drawing.Size(23, 22);
            this.tbbOpen.Text = "toolStripButton1";
            this.tbbOpen.ToolTipText = "Open album";
            this.tbbOpen.Click += new System.EventHandler(this.toolbarButton_Click);
            // 
            // tbbSave
            // 
            this.tbbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbSave.Image = ((System.Drawing.Image)(resources.GetObject("tbbSave.Image")));
            this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSave.Name = "tbbSave";
            this.tbbSave.Size = new System.Drawing.Size(23, 22);
            this.tbbSave.Text = "toolStripButton1";
            this.tbbSave.ToolTipText = "Save album";
            this.tbbSave.Click += new System.EventHandler(this.toolbarButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbNext
            // 
            this.tbbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbNext.Image = ((System.Drawing.Image)(resources.GetObject("tbbNext.Image")));
            this.tbbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbNext.Name = "tbbNext";
            this.tbbNext.Size = new System.Drawing.Size(23, 22);
            this.tbbNext.Text = "toolStripButton1";
            this.tbbNext.ToolTipText = "Previous photo";
            this.tbbNext.Click += new System.EventHandler(this.toolbarButton_Click);
            // 
            // tbbPrevious
            // 
            this.tbbPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbPrevious.Image = ((System.Drawing.Image)(resources.GetObject("tbbPrevious.Image")));
            this.tbbPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPrevious.Name = "tbbPrevious";
            this.tbbPrevious.Size = new System.Drawing.Size(23, 22);
            this.tbbPrevious.Text = "toolStripButton1";
            this.tbbPrevious.ToolTipText = "Next photo";
            this.tbbPrevious.Click += new System.EventHandler(this.toolbarButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbPixelData
            // 
            this.tbbPixelData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbPixelData.Image = ((System.Drawing.Image)(resources.GetObject("tbbPixelData.Image")));
            this.tbbPixelData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPixelData.Name = "tbbPixelData";
            this.tbbPixelData.Size = new System.Drawing.Size(23, 22);
            this.tbbPixelData.Text = "toolStripButton1";
            this.tbbPixelData.ToolTipText = "Pixel data";
            this.tbbPixelData.Click += new System.EventHandler(this.toolbarButton_Click);
            // 
            // tbbImage
            // 
            this.tbbImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbImage.DropDown = this.ctxMenuImage;
            this.tbbImage.Image = ((System.Drawing.Image)(resources.GetObject("tbbImage.Image")));
            this.tbbImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbImage.Name = "tbbImage";
            this.tbbImage.Size = new System.Drawing.Size(29, 22);
            this.tbbImage.Text = "toolStripDropDownButton1";
            this.tbbImage.ToolTipText = "Image size";
            // 
            // ctxMenuImage
            // 
            this.ctxMenuImage.Name = "ctxMenuImage";
            this.ctxMenuImage.Size = new System.Drawing.Size(181, 26);
            this.ctxMenuImage.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuImage_Opening);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 491);
            this.ContextMenuStrip = this.ctxMenuView;
            this.Controls.Add(this.pnlPhoto);
            this.Controls.Add(this.toolbarMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.MinimumSize = new System.Drawing.Size(510, 530);
            this.Name = "MainForm";
            this.Text = "My photos";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolbarMain.ResumeLayout(false);
            this.toolbarMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuImage;
        private System.Windows.Forms.ToolStripMenuItem menuStrechToFit;
        private System.Windows.Forms.ToolStripMenuItem menuActualSize;
        private System.Windows.Forms.ToolStripMenuItem menuZoom;
        private System.Windows.Forms.ContextMenuStrip ctxMenuView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbpnlFileName;
        private System.Windows.Forms.ToolStripStatusLabel sbpnlImageSize;
        private System.Windows.Forms.ToolStripStatusLabel sbpnlImagePercent;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuNext;
        private System.Windows.Forms.ToolStripMenuItem menuPrevious;
        private System.Windows.Forms.ToolStripStatusLabel sbpnlFileIndex;
        private System.Windows.Forms.ToolStripMenuItem menuScale;
        private System.Windows.Forms.Panel pnlPhoto;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuPhotoProp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuPixel;
        private System.Windows.Forms.ToolStripMenuItem menuAlbumProp;
        private System.Windows.Forms.ToolStrip toolbarMain;
        private System.Windows.Forms.ToolStripButton tbbNew;
        private System.Windows.Forms.ToolStripButton tbbOpen;
        private System.Windows.Forms.ToolStripButton tbbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbbNext;
        private System.Windows.Forms.ToolStripButton tbbPrevious;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tbbPixelData;
        private System.Windows.Forms.ToolStripDropDownButton tbbImage;
        private System.Windows.Forms.ContextMenuStrip ctxMenuImage;
    }
}

