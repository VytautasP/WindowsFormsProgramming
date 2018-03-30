using System;
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
        private int _selectedImageMode = 0;
        private PictureBoxSizeMode[] _modeMenuArray = new PictureBoxSizeMode[]
        {
            PictureBoxSizeMode.StretchImage,
            PictureBoxSizeMode.Normal,
            PictureBoxSizeMode.Zoom
        }; 

        #endregion

        #region Constructors

        public MainForm()
        {
            InitializeComponent();
            InitContextViewMenu();
            menuNew_Click(this, EventArgs.Empty);
        }

        #endregion

        #region Properties



        #endregion

        #region Event handlers

        #region menuEdit

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

        private void menuRemove_Click(object sender, EventArgs e)
        {
            if (_album.Count > 0)
            {
                _album.RemoveAt(_album.CurrentPosition);
                _albumChanged = true;

                Invalidate();
            }
        }

        #endregion

        #region menuFile

        private void menuSave_Click(object sender, EventArgs e)
        {
            if (_album.FileName == null)
            {
                menuSaveAs_Click(sender, e);
            }
            else
            {
                _album.Save();
                _albumChanged = false;
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
            if (_album != null)
                _album.Dispose();
            _album = new PhotoAlbum();

            SetTitle();

            Invalidate();
        }

        #endregion

        #region menuView

        protected void menuImage_ChildClick(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item)
            {
                _selectedImageMode = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                pbxPhoto.SizeMode = _modeMenuArray[_selectedImageMode];
                pbxPhoto.Invalidate();
                sbpnlImagePercent.Invalidate();
            }
        }

        protected void menuImage_Popup(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem parentMenu)
            {
                bool imageLoaded = pbxPhoto.Image != null;

                foreach (ToolStripMenuItem item in parentMenu.DropDownItems)
                {
                    item.Enabled = imageLoaded;
                    item.Checked = _selectedImageMode ==
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

        #endregion

        #region statusBar Panel

        private void sbpnlImagePercent_Paint(object sender, PaintEventArgs e)
        {
            int percent = 100;

            if (pbxPhoto.Image != null)
            {
                Rectangle dr = pbxPhoto.ClientRectangle;
                int imgWidth = pbxPhoto.Image.Width;
                int imgHeight = pbxPhoto.Image.Height;

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
                pbxPhoto.Image = photo.Image;

                sbpnlFileName.Text = photo.FileName;
                sbpnlImageSize.Text = String.Format("{0:#}x{1:#}", photo.Image.Width, photo.Image.Height);
                sbpnlFileIndex.Text = String.Format("{0:#}/{1:#}", _album.CurrentPosition + 1, _album.Count);
            }
            else
            {
                pbxPhoto.Image = null;
                sbpnlFileName.Text = "No photos in Album";
            }
            base.OnPaint(e);
        }

        #endregion

        #endregion

        #region Methods

        private void InitContextViewMenu()
        {
            foreach (var menuItem in menuView.DropDownItems)
            {
                if (menuItem is ToolStripMenuItem)
                    ctxMenuView.Items.Add(ToolStripMenuItemHelper.CloneToolStripMenuItem((ToolStripMenuItem) menuItem));
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


        #endregion

    }
}
