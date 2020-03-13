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
    public partial class FormActivatorShortcut : Form
    {
        public Shortcut Shortcut { get; set; }
        public bool LoopExecution { get; set; }
        private List<Keys> m_pressedKeys = new List<Keys>();

        public FormActivatorShortcut(Shortcut shortcut, bool loop)
        {
            InitializeComponent();

            Shortcut = shortcut;
            LoopExecution = loop;

            tbShortcut.Text = "";
            for (int i = 0; i < shortcut.Keys.Count; i++)
            {
                tbShortcut.Text += (i > 0 ? " + " : "") + shortcut.Keys[i].ToString();
            }

            cbType.SelectedIndex = (loop ? 1 : 0);

            InputDetection.InputDetected += InputDetection_InputDetected;
        }

        private void InputDetection_InputDetected(CommandType inputType, Keys key, int x, int y, bool mouseWheelDirection, bool rightMouseButton)
        {
            if (inputType == CommandType.KeyDown)
            {
                if (!m_pressedKeys.Contains(key))
                {
                    m_pressedKeys.Add(key);
                }

                if (key != Keys.LControlKey && key != Keys.RControlKey &&
                    key != Keys.LShiftKey && key != Keys.RShiftKey &&
                    key != Keys.LMenu && key != Keys.RMenu)
                {
                    tbShortcut.Text = "";
                    for (int i = 0; i < m_pressedKeys.Count; i++)
                    {
                        tbShortcut.Text += (i > 0 ? " + " : "") + m_pressedKeys[i].ToString();
                    }

                    Shortcut = new Shortcut(m_pressedKeys);
                }
            }
            else if (inputType == CommandType.KeyUp)
            {
                m_pressedKeys.Remove(key);
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            tbShortcut.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Shortcut.Keys.Count == 0)
            {
                MessageBox.Show("Die Eingegebenn Shortcuts sind ungültig", "Fehlerhafte Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoopExecution = (cbType.SelectedIndex == 1 ? true : false);

            DialogResult = DialogResult.OK;
        }
    }
}
