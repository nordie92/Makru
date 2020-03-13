using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makru
{
    class CommandSetVariable : Command
    {
        private Variable m_variable;
        public Variable Variable
        {
            get
            {
                return m_variable;
            }
            set
            {
                m_variable = m_macro.GetVariableByName((value != null ? value.Name : ""));
                Text = "Set Variable \"" + (m_variable != null ? m_variable.Name : "Variable") + "\" = (" + (m_output != null ? m_output.GetText() : "Output") + ")";
            }
        }
        private Output m_output;
        public Output Output
        {
            get
            {
                return m_output;
            }
            set
            {
                m_output = value;
                Text = "Set Variable \"" + (m_variable != null ? m_variable.Name : "Variable") + "\" = (" + (m_output != null ? m_output.GetText() : "Output") + ")";
            }
        }
        private Macro m_macro;

        public CommandSetVariable(Variable variable, Output output, Macro macro)
        {
            m_variable = variable;
            m_output = output;
            m_macro = macro;

            Text = "Set Variable \"" + (variable != null ? variable.Name : "Variable") + "\" = (" + (output != null ? output.GetText() : "Output") + ")";
            ImageKey = "variable";
            SelectedImageKey = "variable";
            Name = "command";
        }

        public override void ExecuteCommand()
        {
            Variable v = m_macro.GetVariableByName(m_variable.Name);
            Variable variableOutput = m_output.GetOutput();
            if (variableOutput != null && v != null)
            {
                v.Value = variableOutput.Value;
            }
            else
            {
                v = null;
            }
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"setVariable\",";
            strReturn += "\"variable\": \"" + (m_variable != null ? m_variable.Name : "") + "\",";
            strReturn += "\"output\": " + (m_output != null ? m_output.JSON() : "");
            strReturn += "}";
            return strReturn;
        }
    }
}
