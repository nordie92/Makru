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
    public partial class FormCondition : Form
    {
        public Condition Condition;
        private Macro m_macro;

        public FormCondition(Macro macro)
        {
            InitializeComponent();

            m_macro = macro;

            ShowCondition();
        }

        public FormCondition(Condition condition, Macro macro)
        {
            InitializeComponent();

            m_macro = macro;
            Condition = condition;

            ShowCondition();
        }

        private void ShowCondition()
        {
            cbCondition.SelectedIndexChanged -= cbCondition_SelectedIndexChanged;

            if (Condition == null)
            {
                cbCondition.SelectedIndex = 0;
                Condition = new ConditionAnd(m_macro);
                Condition.OnConditionChanged += ConAnd_OnConditionChanged;
                plCondition.Controls.Add(Condition);
            }
            else if(Condition.GetType() == typeof(ConditionAnd))
            {
                cbCondition.SelectedIndex = 0;
                plCondition.Controls.Clear();
                plCondition.Controls.Add(Condition);
            }
            else if (Condition.GetType() == typeof(ConditionOr))
            {
                cbCondition.SelectedIndex = 1;
                plCondition.Controls.Clear();
                plCondition.Controls.Add(Condition);
            }
            else if (Condition.GetType() == typeof(ConditionWaitFor))
            {
                cbCondition.SelectedIndex = 2;
                plCondition.Controls.Clear();
                plCondition.Controls.Add(Condition);
            }
            else if (Condition.GetType() == typeof(ConditionPixelColor))
            {
                cbCondition.SelectedIndex = 3;
                plCondition.Controls.Clear();
                plCondition.Controls.Add(Condition);
            }
            else if (Condition.GetType() == typeof(ConditionCompareOutputs))
            {
                cbCondition.SelectedIndex = 4;
            }
            else if (Condition.GetType() == typeof(ConditionProcessName))
            {
                cbCondition.SelectedIndex = 5;
            }
            plCondition.Controls.Clear();
            plCondition.Controls.Add(Condition);

            cbCondition.SelectedIndexChanged += cbCondition_SelectedIndexChanged;
        }

        private void ConAnd_OnConditionChanged(object sender, ConditionChangedArgs e)
        {
            Condition = (sender as Condition);
        }

        private void cbCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    plCondition.Controls.Clear();
                    Condition = new ConditionAnd(m_macro);
                    Condition.OnConditionChanged += ConAnd_OnConditionChanged;
                    plCondition.Controls.Add(Condition);
                    break;
                case 1:
                    plCondition.Controls.Clear();
                    Condition = new ConditionOr(m_macro);
                    Condition.OnConditionChanged += ConAnd_OnConditionChanged;
                    plCondition.Controls.Add(Condition);
                    break;
                case 2:
                    plCondition.Controls.Clear();
                    Condition = new ConditionWaitFor(m_macro);
                    Condition.OnConditionChanged += ConAnd_OnConditionChanged;
                    plCondition.Controls.Add(Condition);
                    break;
                case 3:
                    plCondition.Controls.Clear();
                    Condition = new ConditionPixelColor();
                    Condition.OnConditionChanged += ConAnd_OnConditionChanged;
                    plCondition.Controls.Add(Condition);
                    break;
                case 4:
                    plCondition.Controls.Clear();
                    Condition = new ConditionCompareOutputs(null, "", null, m_macro);
                    Condition.OnConditionChanged += ConAnd_OnConditionChanged;
                    plCondition.Controls.Add(Condition);
                    break;
                case 5:
                    plCondition.Controls.Clear();
                    Condition = new ConditionProcessName("", true);
                    Condition.OnConditionChanged += ConAnd_OnConditionChanged;
                    plCondition.Controls.Add(Condition);
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
