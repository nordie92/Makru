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
    public partial class FormCommandInput : Form
    {
        public CommandInput CommandInput;
        private Keys m_key = Keys.None;
        private Macro m_macro;

        public FormCommandInput(CommandInput commandInput, Macro macro)
        {
            InitializeComponent();

            CommandInput = commandInput;
            m_macro = macro;

            cbKeyboardMode.SelectedIndex = 0;
            cbMouseButton.SelectedIndex = 0;
            cbMouseMode.SelectedIndex = 0;
            cbMouseWheelDirection.SelectedIndex = 0;

            if (commandInput.InputType == CommandType.MouseDown || commandInput.InputType == CommandType.MouseUp)
            {
                rbSelectMousebutton.Checked = true;
                rbSelectMouseWheel.Checked = false;
                rbSelectKeyboardKey.Checked = false;

                cbMouseButton.SelectedIndex = (commandInput.IsRightButton ? 0 : 1);
                cbMouseMode.SelectedIndex = (commandInput.InputType == CommandType.MouseDown ? 0 : 1);
                nudMouseX.Value = commandInput.X;
                nudMouseY.Value = commandInput.Y;
            }
            else if (commandInput.InputType == CommandType.MouseWheel)
            {
                rbSelectMousebutton.Checked = false;
                rbSelectMouseWheel.Checked = true;
                rbSelectKeyboardKey.Checked = false;

                cbMouseWheelDirection.SelectedIndex = (commandInput.IsMouseWheelUp ? 0 : 1);
            }
            else if (commandInput.InputType == CommandType.KeyDown || commandInput.InputType == CommandType.KeyUp)
            {
                rbSelectMousebutton.Checked = false;
                rbSelectMouseWheel.Checked = false;
                rbSelectKeyboardKey.Checked = true;

                m_key = commandInput.Key;
                lbKeyboardKey.Text = commandInput.Key.ToString();
                cbKeyboardMode.SelectedIndex = (commandInput.InputType == CommandType.KeyDown ? 0 : 1);
            }
        }

        private void commandKind_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelectMousebutton.Checked)
            {
                gbMouseButton.Enabled = true;
                gbMouseWheel.Enabled = false;
                gbKeyboardKey.Enabled = false;
            }
            else if (rbSelectMouseWheel.Checked)
            {
                gbMouseButton.Enabled = false;
                gbMouseWheel.Enabled = true;
                gbKeyboardKey.Enabled = false;
            }
            else if (rbSelectKeyboardKey.Checked)
            {
                gbMouseButton.Enabled = false;
                gbMouseWheel.Enabled = false;
                gbKeyboardKey.Enabled = true;
            }
        }

        private void btnSelectKeyboardKey_Click(object sender, EventArgs e)
        {
            if (btnSelectKeyboardKey.Text == "Wähle Taste")
            {
                btnSelectKeyboardKey.Text = "Drücke gewünschte Taste";
                btnSelectKeyboardKey.KeyDown += BtnSelectKeyboardKey_KeyDown;
            }
        }

        private void BtnSelectKeyboardKey_KeyDown(object sender, KeyEventArgs e)
        {
            m_key = e.KeyCode;
            lbKeyboardKey.Text = e.KeyCode.ToString();
            btnSelectKeyboardKey.KeyDown -= BtnSelectKeyboardKey_KeyDown;
            btnSelectKeyboardKey.Text = "Wähle Taste";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbSelectMousebutton.Checked)
            {
                gbMouseButton.Enabled = true;
                gbMouseWheel.Enabled = false;
                gbKeyboardKey.Enabled = false;

                if (cbMouseMode.SelectedIndex == 0)
                {
                    CommandInput = new CommandInput(
                        CommandType.MouseDown,
                        Keys.None,
                        (int)nudMouseX.Value,
                        (int)nudMouseY.Value,
                        false,
                        (cbMouseButton.SelectedIndex == 0 ? true : false),
                        m_macro
                    );
                }
                else
                {
                    CommandInput = new CommandInput(
                        CommandType.MouseUp,
                        Keys.None,
                        (int)nudMouseX.Value,
                        (int)nudMouseY.Value,
                        false,
                        (cbMouseButton.SelectedIndex == 0 ? true : false),
                        m_macro
                    );
                }
            }
            else if (rbSelectMouseWheel.Checked)
            {
                gbMouseButton.Enabled = false;
                gbMouseWheel.Enabled = true;
                gbKeyboardKey.Enabled = false;

                CommandInput = new CommandInput(
                    CommandType.MouseWheel,
                    Keys.None,
                    (int)nudMouseX.Value,
                    (int)nudMouseY.Value,
                    (cbMouseWheelDirection.SelectedIndex == 0 ? true : false),
                    false,
                    m_macro
                );
            }
            else if (rbSelectKeyboardKey.Checked)
            {
                gbMouseButton.Enabled = false;
                gbMouseWheel.Enabled = false;
                gbKeyboardKey.Enabled = true;

                if (cbKeyboardMode.SelectedIndex == 0)
                {
                    CommandInput = new CommandInput(
                        CommandType.KeyDown,
                        m_key,
                        0,
                        0,
                        false,
                        false,
                        m_macro
                    );
                }
                else
                {
                    CommandInput = new CommandInput(
                        CommandType.KeyUp,
                        m_key,
                        0,
                        0,
                        false,
                        false,
                        m_macro
                    );
                }
            }

            if (rbSelectKeyboardKey.Checked && m_key == Keys.None)
            {
                MessageBox.Show("Es muss eine Taste ausgewählt sein", "Keine Taste gewählt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
