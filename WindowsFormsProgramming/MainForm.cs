﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsProgramming.Controls.Helpers;
using Extensions.PhotoAlbum;

namespace WindowsFormsProgramming
{
    public partial class MainForm : Form
    {

        #region Fields

        protected PhotoAlbum _album;
        protected bool _albumChanged = false;

        private PixelDlg _dlgPixel = null;
        private int _pixelDlgIndex;

        private enum DisplayMode
        {
            ScaleToFit = 0,
            StretchImage = 1,
            Normal = 2
        };

        private DisplayMode _selectedMode = DisplayMode.ScaleToFit;

        #endregion

        #region Constructors

        public MainForm()
        {
            InitializeComponent();
            InitContextViewMenu();
            InitToolbarButtons();

            menuNew_Click(this, EventArgs.Empty);
            menuImage_ChildClick(menuScale, EventArgs.Empty);
        }

        #endregion

        #region Properties



        #endregion

        #region Event handlers

        #region menuEdit

        private void menuEdit_DropDownOpening(object sender, EventArgs e)
        {
            menuPhotoProp.Enabled = _album.Count > 0;
        }

        private void menuAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Add photos to the album";
            dlg.Multiselect = true;
            dlg.Filter = ".JPG(.jpg)|*.jpg|.PNG(.png)|*.png|All files(*.*)|*.*";
            dlg.CheckFileExists = true;
            dlg.InitialDirectory = Environment.CurrentDirectory;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] fileNames = dlg.FileNames;

                    sbpnlFileName.Text = $"Loading {fileNames.Length} files";

                    int index = 0;
                    foreach (var fileName in fileNames)
                    {
                        Photograph p = new Photograph(fileName);
                        index = _album.IndexOf(p);

                        if (index < 0)
                        {
                            _album.Add(p);
                            _albumChanged = true;
                        }
                    }


                }
                catch (Exception exception)
                {
                    sbpnlFileName.Text = "Unable to load " + dlg.FileName;

                    MessageBox.Show("Unable to load file: " + exception.Message);
                }
                finally
                {
                    dlg.Dispose();
                }

                Invalidate();
            }
        }

        private void menuPhotoProp_Click(object sender, EventArgs e)
        {
            if (_album.CurrentPhotograph == null)
                return;

            using (PhotoEditDlg dlg = new PhotoEditDlg(_album))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _albumChanged = dlg.HasChanged;

                    sbpnlFileName.Text = _album.CurrentPhotograph.Caption;
                    statusStrip1.Invalidate();

                    if (_albumChanged)
                        this.Invalidate();
                }
            }

        }

        private void menuAlbumProp_Click(object sender, EventArgs e)
        {
            using (AlbumEditDlg dlg = new AlbumEditDlg(_album))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _albumChanged = true;
                    this.Invalidate();
                }
            }
        }

        private void menuRemove_Click(object sender, EventArgs e)
        {
            if (_album.Count > 0)
            {
                if (MessageBox.Show("Do you want to remove current photo from album?", "Remove photo?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _album.RemoveAt(_album.CurrentPosition);
                    _albumChanged = true;

                    Invalidate();
                }
            }
        }

        #endregion

        #region menuFile

        private void menuOpen_Click(object sender, EventArgs e)
        {
            if (CloseCurrentAlbum() == false)
            {
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Album";
            dlg.Filter = "Album files(*.abm)|*.abm";
            dlg.InitialDirectory = PhotoAlbum.DefaultDir;
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _album.Open(dlg.FileName);
                    _albumChanged = false;

                    Invalidate();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Unable to open file " + dlg.FileName + "\n" + err.Message, "Open file Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dlg.Dispose();

        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            if (_album.FileName == null)
            {
                menuSaveAs_Click(sender, e);
            }
            else
            {
                try
                {
                    _album.Save();
                    _albumChanged = false;
                }
                catch (Exception err)
                {
                    var msg = String.Format(
                        "Unable to save file {0} - {1}\nWould you like to save the album in alternate file", _album.FileName, err.Message);

                    var result = MessageBox.Show(msg, "Save Album Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button2);

                    if(result == DialogResult.Yes)
                        menuSaveAs_Click(sender, e);
                }
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Save Album as";
            sf.DefaultExt = ".abm";
            sf.Filter = "Album files(*.abm)|*.abm|All files(*.*)|*.*";
            sf.InitialDirectory = PhotoAlbum.DefaultDir;
            sf.RestoreDirectory = true;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                _album.FileName = sf.FileName;

                menuSave_Click(sender, e);

                SetTitle();
            }

            sf.Dispose();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuNew_Click(object sender, EventArgs e)
        {

            if (CloseCurrentAlbum() == true)
            {
                Invalidate();
            }
        }

        #endregion

        #region menuView

        private void menuView_DropDownOpening(object sender, EventArgs e)
        {
            if (_dlgPixel != null && _dlgPixel.Visible)
                menuPixel.Text = "Hide Pixel Data";
            else
                menuPixel.Text = "Pixel Data";
        }

        protected void menuImage_ChildClick(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item)
            {

                var parentItem = (ToolStrip)item.Owner;

                _selectedMode = (DisplayMode)parentItem.Items.IndexOf(item);

                sbpnlImagePercent.Invalidate();

                switch (_selectedMode)
                {
                    default:
                    case DisplayMode.ScaleToFit:
                    case DisplayMode.StretchImage:
                        pnlPhoto.AutoScroll = false;
                        SetStyle(ControlStyles.ResizeRedraw, true);
                        break;
                    case DisplayMode.Normal:
                        pnlPhoto.AutoScroll = true;
                        SetStyle(ControlStyles.ResizeRedraw, false);
                        break;
                }
            }
        }

        protected void menuImage_Popup(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem parentMenu)
            {
                bool imageLoaded = _album.Count > 0;

                foreach (ToolStripMenuItem item in parentMenu.DropDownItems)
                {
                    item.Enabled = imageLoaded;
                    item.Checked = (int)_selectedMode ==
                                   (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item) && imageLoaded;
                }
            }
        }

        private void menuNext_Click(object sender, EventArgs e)
        {
            if(_album.CurrentNext())
                Invalidate();
        }

        private void menuPrevious_Click(object sender, EventArgs e)
        {
            if(_album.CurrentPrev())
                Invalidate();
        }

        private void menuPixel_Click(object sender, EventArgs e)
        {
            if (_dlgPixel != null && _dlgPixel.Visible)
            {
                _dlgPixel.Hide();
                return;
            }

            if (_dlgPixel == null || _dlgPixel.IsDisposed)
            {
                _dlgPixel = new PixelDlg();
                _dlgPixel.Owner = this;
            }

            _pixelDlgIndex = _album.CurrentPosition;
            Point p = pnlPhoto.PointToClient(Form.MousePosition);

            UpdatePixelData(p.X, p.Y);

            _dlgPixel.StartPosition = FormStartPosition.Manual;
            Point location = this.Location;
            location.X -= _dlgPixel.Width;
            location.Y += _dlgPixel.Height / 2;

            _dlgPixel.Location = location;
            _dlgPixel.Show();
        }

        #endregion

        #region statusBar Panel

        private void sbpnlImagePercent_Paint(object sender, PaintEventArgs e)
        {
            int percent = 100;
            Photograph photo = _album.CurrentPhotograph;

            if (photo?.Image != null)
            {
                Rectangle dr = pnlPhoto.ClientRectangle;
                int imgWidth = photo.Image.Width;
                int imgHeight = photo.Image.Height;

                percent = 100 * Math.Min(dr.Width, imgWidth) * Math.Min(dr.Height, imgHeight) / (imgWidth * imgHeight);

                Rectangle percentRect = e.ClipRectangle;
                percentRect.Width = e.ClipRectangle.Width * percent / 100;

                e.Graphics.FillRectangle(Brushes.DarkGoldenrod, percentRect);
                e.Graphics.DrawString(percent.ToString() + "%", (sender as ToolStripStatusLabel).Font, Brushes.White, e.ClipRectangle);
            }
        }

        #endregion

        private void menuStrip_OnMouseEnter(object sender, EventArgs e)
        {
            sbpnlFileName.Text = (sender as ToolStripMenuItem)?.ToolTipText;
        }

        private void menuStrip_OnMouseLeave(object sender, EventArgs e)
        {
            sbpnlFileName.Text = "";
        }

        #region MainForm

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_album.Count > 0)
            {
                Photograph photo = _album.CurrentPhotograph;

                sbpnlFileName.Text = _album.CurrentDisplayText;
                sbpnlImageSize.Text = String.Format("{0:#}x{1:#}", photo.Image.Width, photo.Image.Height);
                sbpnlFileIndex.Text = String.Format("{0:#}/{1:#}", _album.CurrentPosition + 1, _album.Count);
            }
            else
            {
                sbpnlFileName.Text = "No photos in Album";
            }

            pnlPhoto.Invalidate();
            statusStrip1.Invalidate();

            base.OnPaint(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = !CloseCurrentAlbum();

            base.OnClosing(e);
        }

        #endregion

        #region Photo panel

        private void pnlPhoto_Paint(object sender, PaintEventArgs e)
        {
            if (_dlgPixel != null && _pixelDlgIndex != _album.CurrentPosition)
            {
                _pixelDlgIndex = _album.CurrentPosition;
                Point p = pnlPhoto.PointToClient(Form.MousePosition);
                UpdatePixelData(p.X, p.Y);
            }

            if (_album.Count > 0)
            {
                Photograph photo = _album.CurrentPhotograph;
                Graphics g = e.Graphics;

                switch (_selectedMode)
                {
                    default:
                    case DisplayMode.ScaleToFit:
                        g.DrawImage(photo.Image, photo.ScaleToFit(pnlPhoto.DisplayRectangle));
                        break;
                    case DisplayMode.StretchImage:
                        g.DrawImage(photo.Image, pnlPhoto.DisplayRectangle);
                        break;
                    case DisplayMode.Normal:
                        g.DrawImage(photo.Image,
                            pnlPhoto.AutoScrollPosition.X,
                            pnlPhoto.AutoScrollPosition.Y,
                            photo.Image.Width,
                            photo.Image.Height);
                        pnlPhoto.AutoScrollMinSize = photo.Image.Size;
                        break;
                }

            }
            else
            {
                e.Graphics.Clear(SystemColors.Control);
            }
        }

        private void pnlPhoto_MouseMove(object sender, MouseEventArgs e)
        {
            UpdatePixelData(e.X, e.Y);
        }

        #endregion

        #region Context Menu Image

        private void ctxMenuImage_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menu = sender as ContextMenuStrip;

            if (menu == null) return;

            bool imageLoaded = _album.Count > 0;

            foreach (ToolStripMenuItem item in menu.Items)
            {
                item.Enabled = imageLoaded;
                item.Checked = (int) _selectedMode ==
                               menu.Items.IndexOf(item) && imageLoaded;
            }


        }

        #endregion

        #endregion

        #region Methods

        private void InitToolbarButtons()
        {
            tbbNew.Tag = menuNew;
            tbbOpen.Tag = menuOpen;
            tbbSave.Tag = menuSave;
            tbbPrevious.Tag = menuPrevious;
            tbbNext.Tag = menuNext;
            tbbImage.Tag = menuImage;
            tbbPixelData.Tag = menuPixel;
        }

        private void InitContextViewMenu()
        {
            foreach (var menuItem in menuView.DropDownItems)
            {
                if (menuItem is ToolStripMenuItem)
                {
                    ctxMenuView.Items.Add(ToolStripMenuItemHelper.CloneToolStripMenuItem((ToolStripMenuItem) menuItem));
                }
            }

            foreach (var item in menuImage.DropDownItems)
            {
                ctxMenuImage.Items.Add(ToolStripMenuItemHelper.CloneToolStripMenuItem((ToolStripMenuItem)item));
            }
        }

        private void SetTitle()
        {
            Version ver = new Version(Application.ProductVersion);

            var title ="";

            if (_album.FileName == null)
            {
                title = String.Format("MyPhotos {0:#}.{1:#}", ver.Major, ver.Minor);
            }
            else
            {
                title = String.Format("{0} - MyPhotos {1:#}.{2:#}", Path.GetFileNameWithoutExtension(_album.FileName),
                    ver.Major, ver.Minor);
            }

            Text = title;
        }

        protected bool CloseCurrentAlbum()
        {
            if (_albumChanged)
            {
                var msg = _album.FileName == null
                    ? "Do you want to save the current album?"
                    : String.Format("Do you want to save changes to {0}", _album.FileName);

                var result = MessageBox.Show(this, msg, "Save album?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if(result == DialogResult.Yes)
                    menuSave_Click(this, EventArgs.Empty);
                else if (result == DialogResult.Cancel)
                    return false;
                
            }

            if (_album != null)
                _album.Dispose();

            _album = new PhotoAlbum();
            SetTitle();
            _albumChanged = false;

            return true;
        }

        protected void UpdatePixelData(int xPos, int yPos)
        {
            if (_dlgPixel == null || !_dlgPixel.Visible)
                return;

            Photograph photo = _album.CurrentPhotograph;

            Rectangle r = pnlPhoto.ClientRectangle;
            if (photo == null || !r.Contains(xPos, yPos))
            {
                _dlgPixel.Text = photo == null ? " " : photo.Caption;
                _dlgPixel.XVal = 0;
                _dlgPixel.YVal = 0;
                _dlgPixel.RedVal = 0;
                _dlgPixel.BlueVal = 0;
                _dlgPixel.GreenVal = 0;
                _dlgPixel.Update();

                return;
            }

            int x = 0, y = 0;
            Bitmap bmp = photo.Image;

            switch (_selectedMode)
            {
                case DisplayMode.Normal:
                    x = xPos;
                    y = yPos;
                    break;
                case DisplayMode.StretchImage:
                    x = xPos * bmp.Width / r.Width;
                    y = yPos * bmp.Height / r.Height;
                    break;
                case DisplayMode.ScaleToFit:
                    Rectangle r2 = photo.ScaleToFit(r);

                    if (!r2.Contains(xPos, yPos))
                        return;

                    x = (xPos - r2.Left) * bmp.Width / r2.Width;
                    y = (yPos - r2.Top) * bmp.Height / r2.Height;

                    break;
            }

            Color c = bmp.GetPixel(x, y);

            _dlgPixel.XVal = x;
            _dlgPixel.YVal = y;
            _dlgPixel.RedVal = c.R;
            _dlgPixel.BlueVal = c.B;
            _dlgPixel.GreenVal = c.G;
            _dlgPixel.Update();

        }

        #endregion

        private void toolbarButton_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = ((ToolStripButton) sender).Tag as ToolStripMenuItem;

            menuItem?.PerformClick();
        }

    }
}
