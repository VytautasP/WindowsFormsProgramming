using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsProgramming
{
    public partial class CaptionDlg : Form
    {
        public CaptionDlg()
        {
            InitializeComponent();
        }

        public string ImageLabel
        {
            set => lblImage.Text = value;
        }

        public string Caption
        {
            get => lblCaption.Text;
            set => lblCaption.Text = value;
        }
    }
}
