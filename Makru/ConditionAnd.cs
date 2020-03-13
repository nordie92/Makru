using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    class ConditionAnd : Condition
    {
        public Condition Condition1 { get; set; }
        public Condition Condition2 { get; set; }
        private LinkLabel m_ll1 = new LinkLabel();
        private LinkLabel m_ll2 = new LinkLabel();
        private Macro m_macro;

        public override event OnConditionChangedEvent OnConditionChanged;

        public ConditionAnd(Macro macro)
        {
            m_macro = macro;

            CreateUI();
        }

        public ConditionAnd(Condition condition1, Condition condition2, Macro macro)
        {
            Condition1 = condition1;
            Condition2 = condition2;
            m_macro = macro;

            CreateUI();
        }

        private void CreateUI()
        {
            Height = 84;
            Width = 271;

            m_ll1.Text = (Condition1 != null ? Condition1.GetText() : "Bedingung");
            m_ll1.Top = 0;
            m_ll1.Left = 0;
            m_ll1.Height = Height;
            m_ll1.Width = 90;
            m_ll1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            m_ll1.Click += Ll1_Click;
            Controls.Add(m_ll1);

            Label pl = new Label();
            pl.Text = "und";
            pl.Top = 0;
            pl.Left = 90;
            pl.Height = Height;
            pl.Width = 90;
            pl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Controls.Add(pl);

            m_ll2.Text = (Condition2 != null ? Condition1.GetText() : "Bedingung");
            m_ll2.Top = 0;
            m_ll2.Left = 180;
            m_ll2.Height = Height;
            m_ll2.Width = 90;
            m_ll2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            m_ll2.Click += Ll2_Click;
            Controls.Add(m_ll2);
        }

        private void Ll1_Click(object sender, EventArgs e)
        {
            FormCondition frm = new FormCondition(m_macro);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Condition1 = frm.Condition;
                Condition1.OnConditionChanged += Condition1_OnConditionChanged;
                m_ll1.Text = (Condition1 != null ? Condition1.GetText() : "Bedingung");
                OnConditionChanged(this, new ConditionChangedArgs());
            }
        }

        private void Ll2_Click(object sender, EventArgs e)
        {
            FormCondition frm = new FormCondition(m_macro);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Condition2 = frm.Condition;
                Condition2.OnConditionChanged += Condition2_OnConditionChanged;
                m_ll2.Text = (Condition2 != null ? Condition2.GetText() : "Bedingung");
                OnConditionChanged(this, new ConditionChangedArgs());
            }
        }

        private void Condition1_OnConditionChanged(object sender, ConditionChangedArgs e)
        {
            m_ll1.Text = Condition1.GetText();
        }

        private void Condition2_OnConditionChanged(object sender, ConditionChangedArgs e)
        {
            m_ll2.Text = Condition2.GetText();
        }

        public override bool GetResult()
        {
            bool result1 = (Condition1 != null ? Condition1.GetResult() : false);
            bool result2 = (Condition2 != null ? Condition2.GetResult() : false);

            Macros.AddLog("Play: Bedingung: Und: " + (result1 && result2));

            return result1 && result2;
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"conditionAnd\",";
            strReturn += "\"condition1\": " + Condition1.JSON();
            strReturn += "\"condition2\": " + Condition2.JSON();
            strReturn += "}";
            return strReturn;
        }

        public override string GetText()
        {
            string con1 = (Condition1 != null ? Condition1.GetText() : "Bedingung");
            string con2 = (Condition2 != null ? Condition2.GetText() : "Bedingung");

            return "(" + con1 + " und " + con2 + ")";
        }
    }
}
