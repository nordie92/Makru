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
    public partial class FormCommandWait : Form
    {
        public int WaitDuration { get; set; }

        public FormCommandWait(int waitDuration)
        {
            InitializeComponent();

            WaitDuration = waitDuration;
            nudWaitDuration.Value = waitDuration;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WaitDuration = (int)nudWaitDuration.Value;
        }
    }
}
