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
    public partial class BaseEditDlg : Form
    {
        public BaseEditDlg()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetSettings();
        }

        #endregion

        #region Methods

        protected virtual void ResetSettings()
        {

        }

        protected virtual bool SaveSettings()
        {
            return true;
        }
        #endregion

        #region Overrides

        protected override void OnClosing(CancelEventArgs e)
        {
            if(!e.Cancel && (DialogResult == DialogResult.OK))
            {
                e.Cancel = !SaveSettings();
            }
            base.OnClosing(e);
        }

        #endregion
    }
}
