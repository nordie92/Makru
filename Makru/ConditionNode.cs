using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    class ConditionNode : TreeNode
    {
        private Condition m_condition;
        public Condition Condition
        {
            get
            {
                return m_condition;
            }
            set
            {
                m_condition = value;
                Text = m_condition.GetText();
            }
        }

        public ConditionNode()
        {
            ImageIndex = 6;
            SelectedImageIndex = 6;
            Text = "Bedingung";
            Name = "condition";
        }

        public ConditionNode(Condition condition)
        {
            m_condition = condition;

            ImageIndex = 6;
            SelectedImageIndex = 6;
            Text = condition.GetText();
            Name = "condition";
        }
    }
}
