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
                    pbxPhoto.Image = new Bitmap(dlg.FileName);
                }
                catch (Exception exception)
                {
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
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item != null)
            {
                _selectedImageMode = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                pbxPhoto.SizeMode = _modeMenuArray[_selectedImageMode];
                pbxPhoto.Invalidate();
            }
        }

        #endregion
    }
}
