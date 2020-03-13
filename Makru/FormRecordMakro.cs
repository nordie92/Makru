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
    public partial class FormRecordMakro : Form
    {
        private TreeNode m_node;
        private DateTime m_lastCommandTime = DateTime.MinValue;
        private bool m_recording = false;

        public FormRecordMakro(TreeNode node)
        {
            InitializeComponent();

            m_node = node;
        }

        public void RecordMacro()
        {
            InputDetection.InputDetected += InputDetection_InputDetected1;
            InputDetection.MouseMoveInterval = (int)nudMouseMoveInterval.Value;
            InputDetection.EnableMouseMoveDetection(cbMouseMoveRecord.Checked);

            m_lastCommandTime = DateTime.MinValue;
        }

        public void StopRecordMacro()
        {
            InputDetection.InputDetected -= InputDetection_InputDetected1;
            InputDetection.EnableMouseMoveDetection(false);

            for (int i = 0; i < 4 && m_node.Nodes.Count - 1 >= 0; i++)
            {
                m_node.Nodes.RemoveAt(m_node.Nodes.Count - 1);
            }
        }

        private void InputDetection_InputDetected1(CommandType inputType, Keys key, int x, int y, bool mouseWheelDirection, bool rightMouseButton)
        {
            if (m_lastCommandTime != DateTime.MinValue)
            {
                CommandWait cw = new CommandWait((int)(DateTime.Now - m_lastCommandTime).TotalMilliseconds, Macro.GetMacroByChild(m_node));
                cw.Duration = Math.Max(cw.Duration, 30);
                m_node.Nodes.Add(cw);
            }

            CommandInput ci = new CommandInput(inputType, key, x, y, mouseWheelDirection, rightMouseButton, Macro.GetMacroByChild(m_node));
            m_node.Nodes.Add(ci);

            m_lastCommandTime = DateTime.Now;
        }

        private void btnStopRecord_Click(object sender, EventArgs e)
        {
            if (m_recording)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                RecordMacro();
                m_recording = true;
                btnRecord.Text = "Aufnahme stoppen";
            }
        }

        private void cbMouseMoveRecord_CheckedChanged(object sender, EventArgs e)
        {
            nudMouseMoveInterval.Enabled = cbMouseMoveRecord.Checked;
        }

        private void FormRecordMakro_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopRecordMacro();
            m_recording = false;
            btnRecord.Text = "Aufnahme starten";
        }
    }
}
