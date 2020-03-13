using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    class OutputVariable : Output
    {
        private ComboBox m_cbVariable;
        private Macro m_macro;
        private string m_variableName;

        public OutputVariable(string variableName, Macro macro)
        {
            m_variableName = variableName;
            m_macro = macro;

            Height = 84;
            Width = 271;

            m_cbVariable = new ComboBox();
            foreach (Variable v in macro.Variables)
                m_cbVariable.Items.Add(v.Name);
            m_cbVariable.Text = variableName;
            m_cbVariable.Top = Height / 2 - m_cbVariable.Height / 2;
            m_cbVariable.Left = Width / 4;
            m_cbVariable.Width = Width / 2;
            Controls.Add(m_cbVariable);
        }

        public override Variable GetOutput()
        {
            return m_macro.GetVariableByName(m_variableName);
        }

        public override string GetText()
        {
            return "Variable: \"" + m_cbVariable.Text + "\"";
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"outputVariable\",";
            strReturn += "\"name\": \"" + m_cbVariable.Text + "\"";
            strReturn += "}";
            return strReturn;
        }
    }
}
