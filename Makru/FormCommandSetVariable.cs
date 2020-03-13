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
    public partial class FormCommandSetVariable : Form
    {
        public Variable Variable { get; internal set; }
        public Output Output { get; internal set; }
        private Macro m_macro;

        public FormCommandSetVariable(string variableName, Output output, Macro macro)
        {
            InitializeComponent();

            m_macro = macro;
            Output = output;

            foreach (Variable v in macro.Variables)
                cbVariable.Items.Add(v.Name);
            cbVariable.Text = variableName;

            llOutput.Text = (output != null ? output.GetText() : "Output");
        }

        private void llOutput_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormOutput frm = new FormOutput(Output, m_macro);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Output = frm.Output;
                llOutput.Text = Output.GetText();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbVariable.Text.Length > 0)
            {
                Variable foundVariable = null;
                for (int i = 0; i < m_macro.Variables.Count && foundVariable == null; i++)
                {
                    if (m_macro.Variables[i].Name == cbVariable.Text)
                    {
                        foundVariable = m_macro.Variables[i];
                    }
                }

                if (foundVariable != null)
                {
                    Variable = foundVariable;
                }
                else
                {
                    Variable = new Variable(cbVariable.Text, "");
                    m_macro.Variables.Add(Variable);
                }
            }

            DialogResult = DialogResult.OK;
        }
    }
}
