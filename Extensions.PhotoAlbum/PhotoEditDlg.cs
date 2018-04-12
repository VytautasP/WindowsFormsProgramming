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
    public partial class PhotoEditDlg : BaseEditDlg
    {
        #region Fields

        private PhotoAlbum _album;

        #endregion

        #region Constructors

        public PhotoEditDlg()
        {
            InitializeComponent();
        }

        public PhotoEditDlg(PhotoAlbum album)
        {
            InitializeComponent();
            _album = album;

            ResetSettings();
        }

        #endregion

        #region Overrides

        protected override void ResetSettings()
        {
            Photograph photo = _album.CurrentPhotograph;

            if (photo != null)
            {
                txtPhotoFile.Text = photo.FileName;
                txtCaption.Text = photo.Caption;
                txtDateTaken.Text = photo.DateTaken.ToString();
                txtPhotographer.Text = photo.Photographer;
                txtNote.Text = photo.Notes;
            }
        }

        protected override bool SaveSettings()
        {
            Photograph photo = _album.CurrentPhotograph;

            if (photo != null)
            {
                photo.Caption = txtCaption.Text;
                photo.Photographer = txtPhotographer.Text;
                photo.Notes = txtNote.Text;
            }

            return true;
        }

        #endregion

        #region Event handlers

        private void txtCaption_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            e.Handled = !(Char.IsLetterOrDigit(c) || Char.IsControl(c) || Char.IsWhiteSpace(c));
        }

        private void txtCaption_TextChanged(object sender, EventArgs e)
        {
            this.Text = String.Format("{0} - Photo Properties", txtCaption.Text);
        }

        #region ctxNote

        private void ctxNote_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = txtNote.CanUndo;
            copyToolStripMenuItem.Enabled = txtNote.SelectionLength > 0;
            cutToolStripMenuItem.Enabled = txtNote.SelectionLength > 0;
            deleteToolStripMenuItem.Enabled = txtNote.SelectionLength > 0;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Undo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Text = txtNote.Text.Remove(txtNote.SelectionStart, txtNote.SelectionLength);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.SelectAll();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Clear();
        }

        #endregion

        #endregion

    }
}
