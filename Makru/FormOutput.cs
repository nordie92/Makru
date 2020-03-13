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
    public partial class FormOutput : Form
    {
        public Output Output { get; internal set; }
        private Macro m_macro;

        public FormOutput(Output output, Macro macro)
        {
            InitializeComponent();

            Output = output;
            m_macro = macro;

            ShowCondition();
            cbOutputType.SelectedIndexChanged += cbOutputType_SelectedIndexChanged;
        }

        private void ShowCondition()
        {
            if (Output == null)
            {
                cbOutputType.SelectedIndex = 0;
                plOutput.Controls.Clear();
                Output = new OutputOCR();
                plOutput.Controls.Add(Output);
            }
            else if (Output.GetType() == typeof(OutputOCR))
            {
                cbOutputType.SelectedIndex = 0;
                plOutput.Controls.Clear();
                plOutput.Controls.Add(Output);
            }
            else if (Output.GetType() == typeof(OutputVariable))
            {
                cbOutputType.SelectedIndex = 1;
                plOutput.Controls.Clear();
                plOutput.Controls.Add(Output);
            }
            else if (Output.GetType() == typeof(OutputStaticText))
            {
                cbOutputType.SelectedIndex = 2;
                plOutput.Controls.Clear();
                plOutput.Controls.Add(Output);
            }
            else if (Output.GetType() == typeof(OutputAddition))
            {
                cbOutputType.SelectedIndex = 3;
                plOutput.Controls.Clear();
                plOutput.Controls.Add(Output);
            }
            else if (Output.GetType() == typeof(OutputSubstract))
            {
                cbOutputType.SelectedIndex = 4;
                plOutput.Controls.Clear();
                plOutput.Controls.Add(Output);
            }
            else if (Output.GetType() == typeof(OutputMultiply))
            {
                cbOutputType.SelectedIndex = 5;
                plOutput.Controls.Clear();
                plOutput.Controls.Add(Output);
            }
            else if (Output.GetType() == typeof(OutputDivide))
            {
                cbOutputType.SelectedIndex = 6;
                plOutput.Controls.Clear();
                plOutput.Controls.Add(Output);
            }
        }

        private void cbOutputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            plOutput.Controls.Clear();
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    Output = new OutputOCR();
                    break;
                case 1:
                    Output = new OutputVariable("", m_macro);
                    break;
                case 2:
                    Output = new OutputStaticText("");
                    break;
                case 3:
                    Output = new OutputAddition(null, null, m_macro);
                    break;
                case 4:
                    Output = new OutputSubstract(null, null, m_macro);
                    break;
                case 5:
                    Output = new OutputMultiply(null, null, m_macro);
                    break;
                case 6:
                    Output = new OutputDivide(null, null, m_macro);
                    break;
            }
            plOutput.Controls.Add(Output);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
