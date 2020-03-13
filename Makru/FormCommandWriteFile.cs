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
    public partial class FormCommandWriteFile : Form
    {
        public string FileName { get; internal set; }
        public new string Text { get; internal set; }
        public bool AppendFile { get; internal set; }
        private Macro m_macro;

        public FormCommandWriteFile(string fileName, string text, bool append, Macro macro)
        {
            InitializeComponent();

            tbFileName.Text = fileName;
            rbAppendFile.Checked = append;
            rbOverrideFile.Checked = !append;
            rtbText.Text = text;
            foreach (Variable v in macro.Variables)
                cbVariable.Items.Add(v.Name);

            FileName = fileName;
            Text = text;
            AppendFile = append;
            m_macro = macro;
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = ofd.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FileName = tbFileName.Text;
            AppendFile = rbAppendFile.Checked;
            Text = rtbText.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
