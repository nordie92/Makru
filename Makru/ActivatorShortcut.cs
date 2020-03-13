using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    class ActivatorShortcut : Activator
    {
        private Shortcut m_shortcut;
        public Shortcut Shortcut
        {
            get { return m_shortcut; }
            set
            {
                Text = "Shortcut \"";
                for (int i = 0; i < value.Keys.Count; i++)
                {
                    Text += (i > 0 ? " + " : "") + value.Keys[i].ToString();
                }
                Text += "\"";

                m_shortcut = value;
            }
        }
        public bool LoopexEcution;
        private Macro m_makro;

        public ActivatorShortcut(Shortcut shortcut, bool loopexecution, Macro makro)
        {
            Shortcut = shortcut;
            LoopexEcution = loopexecution;
            m_makro = makro;

            m_shortcut.ShortcutPressed += M_shortcut_ShortcutPressed;
            InputDetection.RegistarteShortcut(m_shortcut);

            Text = "Shortcut \"";
            for (int i = 0; i < m_shortcut.Keys.Count; i++)
            {
                Text += (i > 0 ? " + " : "") + m_shortcut.Keys[i].ToString();
            }
            Text += "\"";

            ImageKey = "key";
            SelectedImageKey = "key";
            Name = "activator";
        }

        public static void RemoveEvents(TreeNode rootNode)
        {
            if (rootNode.GetType() == typeof(ActivatorShortcut))
            {
                InputDetection.RemoveShortcut((rootNode as ActivatorShortcut).Shortcut);
            }
            else
            {
                foreach (TreeNode tn2 in rootNode.Nodes)
                {
                    RemoveEvents(tn2);
                }
            }
        }

        private void M_shortcut_ShortcutPressed()
        {
            if (m_makro.ThreadWorking())
                m_makro.StopReplayThread();
            else
                m_makro.StartReplayThread(LoopexEcution);
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"activatorShortcut\",";
            strReturn += "\"keys\": [";
            for (int i = 0; i < m_shortcut.Keys.Count; i++)
                strReturn += (i > 0 ? "," : "") + "\"" + m_shortcut.Keys[i].ToString() + "\"";
            strReturn += "],";
            strReturn += "\"loop\": " + (LoopexEcution ? "true" : "false") + "";
            strReturn += "}";
            return strReturn;
        }
    }
}
