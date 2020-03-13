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
    public partial class FormCommandReplayMacro : Form
    {
        public string MacroName;

        public FormCommandReplayMacro(string macroName)
        {
            InitializeComponent();

            tbMacroName.Text = macroName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MacroName = tbMacroName.Text;
            DialogResult = DialogResult.OK;
        }

        private void tbMacroName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MacroName = tbMacroName.Text;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
