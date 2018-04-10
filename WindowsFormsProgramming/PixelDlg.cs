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
    public partial class PixelDlg : Form
    {
        public PixelDlg()
        {
            InitializeComponent();
        }

        public int XVal
        {
            set => xVal.Text = value.ToString();
        }

        public int YVal
        {
            set => yVal.Text = value.ToString();
        }

        public int RedVal
        {
            set => redVal.Text = value.ToString();
        }

        public int GreenVal
        {
            set => greenVal.Text = value.ToString();
        }

        public int BlueVal
        {
            set => blueVal.Text = value.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
