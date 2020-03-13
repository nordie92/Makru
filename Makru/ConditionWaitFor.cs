using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    class ConditionWaitFor : Condition
    {
        private Condition m_condition;
        private LinkLabel m_llCondition;
        private NumericUpDown m_nudCheckInterval;
        public override event OnConditionChangedEvent OnConditionChanged;
        private Macro m_macro;
        private int m_interval;

        public ConditionWaitFor(Macro macro)
        {
            m_macro = macro;

            CreateUI();
        }

        public ConditionWaitFor(Condition condition, int interval, Macro macro)
        {
            m_condition = condition;
            m_interval = interval;
            m_macro = macro;

            CreateUI();
        }

        private void CreateUI()
        {
            Height = 84;
            Width = 271;

            Label pl = new Label();
            pl.Text = "Warte auf ";
            pl.Top = 0;
            pl.Left = 0;
            pl.Height = Height / 2;
            pl.Width = 90;
            pl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            Controls.Add(pl);

            m_llCondition = new LinkLabel();
            m_llCondition.Text = (m_condition != null ? m_condition.GetText() : "Bedingung");
            m_llCondition.Top = 0;
            m_llCondition.Left = pl.Width;
            m_llCondition.Height = Height / 2;
            m_llCondition.Width = Width - 90;
            m_llCondition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            m_llCondition.Click += Ll1_Click;
            Controls.Add(m_llCondition);

            Label pl2 = new Label();
            pl2.Text = "Prüfe alle";
            pl2.Top = Height / 2;
            pl2.Left = 0;
            pl2.Height = Height / 2;
            pl2.Width = 90;
            pl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            Controls.Add(pl2);

            m_nudCheckInterval = new NumericUpDown();
            m_nudCheckInterval.Minimum = 10;
            m_nudCheckInterval.Maximum = 1000 * 60 * 60 * 24;
            m_nudCheckInterval.Value = m_interval;
            m_nudCheckInterval.Top = Height - (Height / 4 + m_nudCheckInterval.Height / 2);
            m_nudCheckInterval.Left = pl2.Width;
            m_nudCheckInterval.Width = 60;
            Controls.Add(m_nudCheckInterval);

            Label pl3 = new Label();
            pl3.Text = "Millisekunden";
            pl3.Top = Height / 2;
            pl3.Left = m_nudCheckInterval.Width + pl2.Width;
            pl3.Height = Height / 2;
            pl3.Width = (Width - m_nudCheckInterval.Width) - pl2.Width;
            pl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Controls.Add(pl3);
        }

        private void Ll1_Click(object sender, EventArgs e)
        {
            FormCondition frm = (m_condition != null ? new FormCondition(m_condition, m_macro) : new FormCondition(m_macro));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                m_condition = frm.Condition;
                m_condition.OnConditionChanged += M_condition_OnConditionChanged;
                m_llCondition.Text = (m_condition != null ? m_condition.GetText() : "Bedingung");

                if (OnConditionChanged != null)
                    OnConditionChanged(this, new ConditionChangedArgs());
            }
        }

        private void M_condition_OnConditionChanged(object sender, ConditionChangedArgs e)
        {
            m_llCondition.Text = m_condition.GetText();
        }

        public override bool GetResult()
        {
            bool result = false;
            while (!result)
            {
                result = m_condition.GetResult();
                Thread.Sleep((int)m_nudCheckInterval.Value);

                Macros.AddLog("Play: Bedingung: WarteAuf: " + result);
            }

            return result;
        }

        public override string GetText()
        {
            return "Warte auf (" + (m_condition != null ? m_condition.GetText() : "Bedingung") + ")";
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"conditionWaitFor\",";
            strReturn += "\"condition\": " + m_condition.JSON() + ",";
            strReturn += "\"checkInterval\": " + (int)m_nudCheckInterval.Value + "";
            strReturn += "}";
            return strReturn;
        }
    }
}
