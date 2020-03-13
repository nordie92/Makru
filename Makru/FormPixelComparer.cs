using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public partial class FormPixelComparer : Form
    {
        public FormPixelComparer()
        {
            InitializeComponent();
        }

        private void btnChoosePicker_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                plColor.BackColor = cd.Color;
            }
        }
    }
}
