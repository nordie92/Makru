using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    class OutputSubstract : Output
    {
        private Output m_output1;
        private Output m_output2;
        private LinkLabel m_llOutput1;
        private LinkLabel m_llOutput2;
        private Macro m_macro;

        public OutputSubstract(Output output1, Output output2, Macro macro)
        {
            m_output1 = output1;
            m_output2 = output2;
            m_macro = macro;

            BuildUI();
        }

        private void BuildUI()
        {
            Height = 84;
            Width = 271;

            m_llOutput1 = new LinkLabel();
            m_llOutput1.Text = (m_output1 != null ? m_output1.GetText() : "Output");
            m_llOutput1.Top = 0;
            m_llOutput1.Left = 0;
            m_llOutput1.Width = 110;
            m_llOutput1.Height = Height;
            m_llOutput1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            m_llOutput1.Click += M_llOutput1_Click;
            Controls.Add(m_llOutput1);

            Label lb1 = new Label();
            lb1.Text = "-";
            lb1.Top = 0;
            lb1.Left = m_llOutput1.Width;
            lb1.Width = 51;
            lb1.Height = Height;
            lb1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Controls.Add(lb1);

            m_llOutput2 = new LinkLabel();
            m_llOutput2.Text = (m_output2 != null ? m_output2.GetText() : "Output");
            m_llOutput2.Top = 0;
            m_llOutput2.Left = 161;
            m_llOutput2.Width = 110;
            m_llOutput2.Height = Height;
            m_llOutput2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            m_llOutput2.Click += M_llOutput2_Click;
            Controls.Add(m_llOutput2);
        }

        private void M_llOutput1_Click(object sender, EventArgs e)
        {
            FormOutput frm = new FormOutput(m_output1, m_macro);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                m_output1 = frm.Output;
                m_llOutput1.Text = "(" + m_output1.GetText() + ")";
            }
        }

        private void M_llOutput2_Click(object sender, EventArgs e)
        {
            FormOutput frm = new FormOutput(m_output2, m_macro);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                m_output2 = frm.Output;
                m_llOutput2.Text = "(" + m_output2.GetText() + ")";
            }
        }

        public override Variable GetOutput()
        {
            Variable v = Variable.Substract(m_output1.GetOutput(), m_output2.GetOutput());
            Macros.AddLog("Play: OutputSubstract: " + (v != null ? v.Value : "0"));
            return v;
        }

        public override string GetText()
        {
            return m_output1.GetText() + " - " + m_output2.GetText();
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"outputSubstract\",";
            strReturn += "\"output1\": " + (m_output1 != null ? m_output1.JSON() : "") + ",";
            strReturn += "\"output2\": " + (m_output2 != null ? m_output2.JSON() : "");
            strReturn += "}";
            return strReturn;
        }
    }
}
