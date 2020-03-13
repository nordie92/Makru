using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    class ConditionCompareOutputs : Condition
    {
        public Output Output1 { get; internal set; }
        public string ConditionOperator;
        public Output Output2 { get; internal set; }

        private LinkLabel m_llVariable1;
        private LinkLabel m_llVariable2;
        private ComboBox m_cbOperator;
        private Macro m_macro;

        public override event OnConditionChangedEvent OnConditionChanged;

        public ConditionCompareOutputs(Output output1, string conditionOperator, Output output2, Macro macro)
        {
            Text = "Vergleiche Variable";
            Name = "conditionCompareText";

            Output1 = output1;
            ConditionOperator = conditionOperator;
            Output2 = output2;
            m_macro = macro;

            CreateUI();
        }

        private void CreateUI()
        {
            Height = 84;
            Width = 271;

            m_llVariable1 = new LinkLabel();
            m_llVariable1.Text = (Output1 != null ? Output1.GetText() : "Variable1");
            m_llVariable1.Top = 0;
            m_llVariable1.Left = 0;
            m_llVariable1.Height = Height;
            m_llVariable1.Width = 100;
            m_llVariable1.Click += M_llVariable1_Click;
            m_llVariable1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            Controls.Add(m_llVariable1);

            m_cbOperator = new ComboBox();
            m_cbOperator.Items.AddRange(new string[] { "Ist leer", "Ist nicht leer", "Ist gleich", "Ist ungleich", ">=", ">", "<=", "<", "Ist Zahl", "Enthält Text" });
            m_cbOperator.DropDownStyle = ComboBoxStyle.DropDownList;
            m_cbOperator.Top = Height / 2 - m_cbOperator.Height / 2;
            m_cbOperator.Left = m_llVariable1.Width;
            m_cbOperator.Width = 71;
            m_cbOperator.SelectedIndex = (ConditionOperator != "" ? m_cbOperator.Items.IndexOf(ConditionOperator) : 0);
            Controls.Add(m_cbOperator);
            m_cbOperator.SelectedIndexChanged += M_cbOperator_SelectedIndexChanged;

            m_llVariable2 = new LinkLabel();
            m_llVariable2.Text = (Output2 != null ? Output2.GetText() : "Variable2");
            m_llVariable2.Top = 0;
            m_llVariable2.Left = m_cbOperator.Width + m_llVariable1.Width;
            m_llVariable2.Height = Height;
            m_llVariable2.Width = 100;
            m_llVariable2.Click += M_llVariable2_Click;
            m_llVariable2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Controls.Add(m_llVariable2);
        }

        private void M_llVariable1_Click(object sender, EventArgs e)
        {
            FormOutput frm = new FormOutput(Output1, m_macro);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Output1 = frm.Output;
                m_llVariable1.Text = Output1.GetText();
            }
        }

        private void M_llVariable2_Click(object sender, EventArgs e)
        {
            FormOutput frm = new FormOutput(Output2, m_macro);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Output2 = frm.Output;
                m_llVariable2.Text = Output2.GetText();
            }
        }

        private void M_cbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConditionOperator = m_cbOperator.Text;

            switch (m_cbOperator.Text)
            {
                case "Ist leer":
                case "Ist nicht leer":
                case "Ist Zahl":
                    m_llVariable2.Visible = false;
                    break;
                default:
                    m_llVariable2.Visible = true;
                    break;
            }
        }

        public override bool GetResult()
        {
            //check conditions
            bool result = false;
            Variable v1 = Output1.GetOutput();
            Variable v2 = (Output2 != null ? Output2.GetOutput() : null);
            switch (ConditionOperator)
            {
                case "Ist gleich":
                    result = v1.Value == v2.Value;
                    break;
                case "Ist ungleich":
                    result = v1.Value != v2.Value;
                    break;
                case ">":
                    if ((v1.IsFloat || v1.IsInt) && (v2.IsFloat || v2.IsInt))
                        result = float.Parse(v1.Value) > float.Parse(v2.Value);
                    else
                        result = false;
                    break;
                case ">=":
                    if ((v1.IsFloat || v1.IsInt) && (v2.IsFloat || v2.IsInt))
                        result = float.Parse(v1.Value) >= float.Parse(v2.Value);
                    else
                        result = false;
                    break;
                case "<":
                    if ((v1.IsFloat || v1.IsInt) && (v2.IsFloat || v2.IsInt))
                        result = float.Parse(v1.Value) < float.Parse(v2.Value);
                    else
                        result = false;
                    break;
                case "<=":
                    if ((v1.IsFloat || v1.IsInt) && (v2.IsFloat || v2.IsInt))
                        result = float.Parse(v1.Value) <= float.Parse(v2.Value);
                    else
                        result = false;
                    break;
                case "Ist Zahl":
                    result = v1.IsFloat || v1.IsInt;
                    break;
                case "Ist leer":
                    result = v1.IsEmpty;
                    break;
                case "Ist nicht leer":
                    result = !v1.IsEmpty;
                    break;
                case "Enthält Text":
                    if (!v1.IsEmpty)
                        result = v2.Value.Contains(v1.Value) || v1.Value.Contains(v2.Value);
                    else
                        result = false;
                    break;
                default:
                    result = false;
                    break;
            }

            Macros.AddLog("Play: Bedingung: Vergleiche Texte: " + result);

            return result;
        }

        public override string GetText()
        {
            return "Textvergleich " + (Output1 != null ? Output1.GetText() : "Output") + 
                " " + ConditionOperator + " " + 
                (Output2 != null ? Output2.GetText() : "Output");
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"conditionComapeText\",";
            strReturn += "\"output1\": " + (Output1 != null ? Output1.JSON() : "{}") + ",";
            strReturn += "\"conditionOperator\": \"" + ConditionOperator + "\",";
            strReturn += "\"output2\": " + (Output2 != null ? Output2.JSON() : "{}");
            strReturn += "}";
            return strReturn;
        }
    }
}
