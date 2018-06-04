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
        private int _index;
        private string _origCaption;
        private DateTime _origDateTaken;
        private string _origPhotographer;
        private bool _modifiedTxtNotes;
        private bool _hasChanged;

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
            _index = album.CurrentPosition;
            ResetSettings();
            SetOriginalValues();
        }

        #endregion

        #region Properties

        public bool HasChanged => _hasChanged;

        #endregion

        #region Overrides

        protected override void ResetSettings()
        {
            Photograph photo = _album[_index];

            if (cmbPhotographer.Items.Count == 0)
            {
                cmbPhotographer.BeginUpdate();
                cmbPhotographer.Items.Clear();
                cmbPhotographer.Items.Add("Unknown");

                foreach (Photograph ph in _album)
                {
                    if (ph.Photographer != null && !cmbPhotographer.Items.Contains(ph.Photographer))
                    {
                        cmbPhotographer.Items.Add(ph.Photographer);
                    }
                }

                cmbPhotographer.EndUpdate();
            }

            if (photo != null)
            {
                txtPhotoFile.Text = photo.FileName;
                txtCaption.Text = photo.Caption;
                dtpDateTaken.Value = photo.DateTaken;
                txtNote.Text = photo.Notes;
                cmbPhotographer.SelectedItem = photo.Photographer;
            }

            btnNext.Enabled = _index != _album.Count - 1;
            btnPrev.Enabled = _index != 0;
        }

        protected override bool SaveSettings()
        {

            if (!NewControlValues())
                return true;

            Photograph photo = _album[_index];

            if (photo != null)
            {
                photo.Caption = txtCaption.Text;
                photo.DateTaken = dtpDateTaken.Value;
                photo.Photographer = cmbPhotographer.Text;
                photo.Notes = txtNote.Text;
                _hasChanged = true;
            }

            return true;
        }

        #endregion

        #region Methods

        protected bool NewControlValues()
        {
            bool result = _origCaption != txtCaption.Text ||
                          _origPhotographer != cmbPhotographer.Text ||
                          _origDateTaken != dtpDateTaken.Value ||
                          _modifiedTxtNotes;

            return result;
        }

        private void SetOriginalValues()
        {
            Photograph photo = _album[_index];

            if (photo != null)
            {
                _origCaption = photo.Caption;
                _origDateTaken = photo.DateTaken;
                _origPhotographer = photo.Photographer;
                _modifiedTxtNotes = false;
            }
        }

        #endregion

        #region Event handlers

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveSettings();

            if (_index < _album.Count - 1)
            {
                _index++;
                ResetSettings();
                SetOriginalValues();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SaveSettings();

            if (_index > 0)
            {
                _index--;
                ResetSettings();
                SetOriginalValues();
            }
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            _modifiedTxtNotes = txtNote.Focused;
        }

        private void txtCaption_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            e.Handled = !(Char.IsLetterOrDigit(c) || Char.IsControl(c) || Char.IsWhiteSpace(c));
        }

        private void txtCaption_TextChanged(object sender, EventArgs e)
        {
            this.Text = String.Format("{0} - Photo Properties", txtCaption.Text);
        }

        private void cmbPhotographer_Validated(object sender, EventArgs e)
        {
            var photographer = cmbPhotographer.Text;

            if (!cmbPhotographer.Items.Contains(photographer))
            {
                _album[_index].Photographer = photographer;
                cmbPhotographer.Items.Add(photographer);
            }

            cmbPhotographer.SelectedItem = photographer;

        }

        private void cmbPhotographer_TextChanged(object sender, EventArgs e)
        {
            var txt = cmbPhotographer.Text;
            var index = cmbPhotographer.FindString(txt);

            if (index >= 0)
            {
                var newTxt = cmbPhotographer.Items[index].ToString();
                cmbPhotographer.Text = newTxt;

                cmbPhotographer.SelectionStart = txt.Length;
                cmbPhotographer.SelectionLength = newTxt.Length - txt.Length;

            }

            cmbPhotographer.DroppedDown = true;
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
