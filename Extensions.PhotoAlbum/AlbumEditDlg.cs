using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Extensions.PhotoAlbum
{
    public partial class AlbumEditDlg : BaseEditDlg
    {
        private PhotoAlbum.DisplayValEnum _selectedOption;
        private PhotoAlbum _album;

        public AlbumEditDlg()
        {
            InitializeComponent();
        }

        public AlbumEditDlg(PhotoAlbum album)
        {
            InitializeComponent();

            rbtnFileName.Tag = (int) PhotoAlbum.DisplayValEnum.FileName;
            rbtnCaption.Tag = (int) PhotoAlbum.DisplayValEnum.Caption;
            rbtnDate.Tag = (int) PhotoAlbum.DisplayValEnum.Date;
            _album = album;
            ResetSettings();
        }

        #region Overrides

        protected override void ResetSettings()
        {
            txtAlbumFile.Text = _album.FileName;
            txtTitle.Text = _album.Title;

            this.Text = String.Format("{0} - Album properties", txtTitle.Text);
            _selectedOption = _album.DisplayOption;

            switch (_selectedOption)
            {
                default:
                case PhotoAlbum.DisplayValEnum.Caption:
                    rbtnCaption.Checked = true;
                    break;
                case PhotoAlbum.DisplayValEnum.FileName:
                    rbtnFileName.Checked = true;
                    break;
                case PhotoAlbum.DisplayValEnum.Date:
                    rbtnDate.Checked = true;
                    break;
            }

            cbtnPassword.Checked = !String.IsNullOrWhiteSpace(_album.Password);
            txtPassword.Text = _album.Password;
            txtConfirmPassword.Text = _album.Password;
        }

        protected override bool SaveSettings()
        {
            bool valid = ValidPasswords();

            if (valid)
            {
                _album.Title = txtTitle.Text;
                _album.DisplayOption = _selectedOption;

                if (cbtnPassword.Checked)
                    _album.Password = txtPassword.Text;
                else
                    _album.Password = null;
            }

            return valid;
        }

        #endregion
        

        #region Event handlers
        
        private void DisplayOption_click(object sender, EventArgs e)
        {
            if(sender is RadioButton rb)
            {
                _selectedOption = (PhotoAlbum.DisplayValEnum) rb.Tag;
            }
        }

        private void cbtnPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool enable = cbtnPassword.Checked;
            txtPassword.Enabled = enable;
            lblConfirmPwd.Enabled = enable;
            txtConfirmPassword.Enabled = enable;

            if (enable)
                txtPassword.Focus();
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show(this, "The password for the album cannot be blank!", "Invalid password",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        #endregion

        private bool ValidPasswords()
        {
            if (cbtnPassword.Checked && txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show(this, "Passwords do not match!", "Password error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
