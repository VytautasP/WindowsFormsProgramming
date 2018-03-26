using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsProgramming.Controls.Helpers;

namespace WindowsFormsProgramming
{
    public partial class MainForm : Form
    {

        #region Fields

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
            Version ver = new Version(Application.ProductVersion);
            Text = String.Format("My photos. Version {0:#}.{1:#}", ver.Major, ver.Minor);

            InitContextViewMenu();
        }

        #endregion

        #region Properties

        

        #endregion

        #region Event handlers

        private void menuLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = ".JPG(.jpg)|*.jpg|.PNG(.png)|*.png|All files(*.*)|*.*";
            dlg.CheckFileExists = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    toolStripStatusLabel1.Text = "Loading file " + dlg.FileName;

                    pbxPhoto.Image = new Bitmap(dlg.FileName);

                    toolStripStatusLabel1.Text = "Loaded " + dlg.FileName;
                }
                catch (Exception exception)
                {
                    toolStripStatusLabel1.Text = "Unable to load " + dlg.FileName;

                    MessageBox.Show("Unable to load file: " + exception.Message);
                }
                finally
                {
                    dlg.Dispose();
                }
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected void menuImage_ChildClick(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item)
            {
                _selectedImageMode = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                pbxPhoto.SizeMode = _modeMenuArray[_selectedImageMode];
                pbxPhoto.Invalidate();
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

        #endregion

        #region Methods

        private void InitContextViewMenu()
        {
            foreach (ToolStripMenuItem menuItem in menuView.DropDownItems)
            {
                ctxMenuView.Items.Add(ToolStripMenuItemHelper.CloneToolStripMenuItem(menuItem));
            }
        }

        #endregion
    }
}
