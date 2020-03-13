using InputManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public class CommandInput : Command
    {
        public CommandType InputType;
        public Keys Key { get; set; }
        public bool IsRightButton;
        public int X;
        public int Y;
        public bool IsMouseWheelUp;
        private int mouseActionDelay = 30;
        private Macro m_macro;

        public CommandInput(CommandType inputType, Keys key, int x, int y, bool mouseWheelDirectionUp, bool rightMouseButton, Macro macro)
        {
            m_macro = macro;

            InputType = inputType;

            switch (inputType)
            {
                case CommandType.KeyDown:
                    Key = key;
                    Text = "Keydown " + Key;
                    break;
                case CommandType.KeyUp:
                    Key = key;
                    Text = "Keyup " + Key;
                    break;
                case CommandType.MouseDown:
                    IsRightButton = rightMouseButton;
                    X = x;
                    Y = y;
                    Text = "MouseDown " + (IsRightButton ? "Rightclick" : "Leftclick") + " at (" + X + "/" + Y + ")";
                    break;
                case CommandType.MouseUp:
                    IsRightButton = rightMouseButton;
                    X = x;
                    Y = y;
                    Text = "MouseUp " + (IsRightButton ? "Rightclick" : "Leftclick") + " at (" + X + "/" + Y + ")";
                    break;
                case CommandType.MouseMove:
                    X = x;
                    Y = y;
                    Text = "MouseMove (" + X + "/" + Y + ")";
                    break;
                case CommandType.MouseWheel:
                    IsMouseWheelUp = mouseWheelDirectionUp;
                    X = x;
                    Y = y;
                    Text = "MouseWheel " + (IsMouseWheelUp ? "Up" : "Down") + " at (" + X + "/" + Y + ")";
                    break;
                default:
                    break;
            }

            ImageKey = "key";
            SelectedImageKey = "key";
            Name = "command";
        }

        private void MouseMove(int x, int y)
        {
            if (m_macro.SettingsMacro.RelativeMouseMove)
            {
                int relX = 0;
                int relY = 0;

                if (m_macro.LastMousePosition.X == -1)
                {
                    m_macro.LastMousePosition = new System.Drawing.Point(x, y);
                }
                else
                {
                    relX = x - m_macro.LastMousePosition.X;
                    relY = y - m_macro.LastMousePosition.Y;

                    m_macro.LastMousePosition = new System.Drawing.Point(x, y);
                }

                Mouse.MoveRelative(relX, relY);

                m_macro.LastMousePosition = new System.Drawing.Point(x, y);
            }
            else
            {
                Mouse.Move(x, y);
            }
        }

        public override void ExecuteCommand()
        {
            if (InputType == CommandType.KeyDown)
            {
                Keyboard.KeyDown(Key);
            }
            else if (InputType == CommandType.KeyUp)
            {
                Keyboard.KeyUp(Key);
            }
            else if (InputType == CommandType.MouseDown)
            {
                MouseMove(X, Y);

                Thread.Sleep(mouseActionDelay);

                if (IsRightButton)
                    Mouse.ButtonDown(Mouse.MouseKeys.Right);
                else
                    Mouse.ButtonDown(Mouse.MouseKeys.Left);
            }
            else if (InputType == CommandType.MouseUp)
            {
                MouseMove(X, Y);

                Thread.Sleep(mouseActionDelay);
                if (IsRightButton)
                    Mouse.ButtonUp(Mouse.MouseKeys.Right);
                else
                    Mouse.ButtonUp(Mouse.MouseKeys.Left);
            }
            else if (InputType == CommandType.MouseMove)
            {
                MouseMove(X, Y);
            }
            else if (InputType == CommandType.MouseWheel)
            {
                Mouse.Move(X, Y);
                if (IsMouseWheelUp)
                    Mouse.Scroll(Mouse.ScrollDirection.Up);
                else
                    Mouse.Scroll(Mouse.ScrollDirection.Down);
            }
            Macros.AddLog("Play: Input \"" + InputType + "\" executed");
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{\"type\": \"" + InputType + "\",";
            switch (InputType)
            {
                case CommandType.KeyDown:
                case CommandType.KeyUp:
                    strReturn += "\"key\": " + "\"" + Key + "\",";
                    strReturn += "\"keyCode\": " + "\"" + (int)Key + "\"";
                    break;
                case CommandType.MouseDown:
                case CommandType.MouseUp:
                    strReturn += "\"button\": " + (IsRightButton ? "\"right\"" : "\"left\"") + ",";
                    strReturn += "\"x\": " + X + ",";
                    strReturn += "\"y\": " + Y;
                    break;
                case CommandType.MouseMove:
                    strReturn += "\"x\": " + X + ",";
                    strReturn += "\"y\": " + Y;
                    break;
                case CommandType.MouseWheel:
                    strReturn += "\"wheelDirection\": " + (IsMouseWheelUp ? "\"up\"" : "\"down\"");
                    break;
                case CommandType.StartProgramm:
                    //ToDo
                    break;
                case CommandType.TakeScreenshoot:
                    //ToDo
                    break;
                default:
                    break;
            }
            strReturn += "}";
            return strReturn;
        }

        public override object Clone()
        {
            return new CommandInput(InputType, Key, X, Y, IsMouseWheelUp, IsRightButton, m_macro);
        }
    }
}
