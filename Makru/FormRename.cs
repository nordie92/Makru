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
    public partial class FormRename : Form
    {
        public new string Name;

        public FormRename(string name)
        {
            InitializeComponent();

            tbName.Text = name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Name = tbName.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
