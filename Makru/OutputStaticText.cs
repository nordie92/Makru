using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    class OutputStaticText : Output
    {
        private TextBox m_tbStaticText;

        public OutputStaticText(string staticText)
        {
            Height = 84;
            Width = 271;

            m_tbStaticText = new TextBox();
            m_tbStaticText.Text = staticText;
            m_tbStaticText.Top = Height / 2 - m_tbStaticText.Height / 2;
            m_tbStaticText.Left = Width / 4;
            m_tbStaticText.Width = Width / 2;
            Controls.Add(m_tbStaticText);
        }

        public override Variable GetOutput()
        {
            return new Variable("temp", m_tbStaticText.Text);
        }

        public override string GetText()
        {
            return "\"" + m_tbStaticText.Text + "\"";
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"outputStaticText\",";
            strReturn += "\"value\": \"" + m_tbStaticText.Text + "\"";
            strReturn += "}";
            return strReturn;
        }
    }
}
