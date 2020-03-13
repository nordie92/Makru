using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public static class InputDetection
    {
        private static IKeyboardMouseEvents m_Events;
        public delegate void InputDetectionHandler(CommandType inputType, Keys key, int x, int y, bool mouseWheelDirection, bool rightMouseButton);
        public static event InputDetectionHandler InputDetected;
        private static List<Keys> m_keysDown = new List<Keys>();
        private static bool m_detectMouseMove = false;
        public static int MouseMoveInterval = 250;
        private static DateTime m_lastMouseMove = DateTime.Now;
        private static List<Shortcut> m_shortcuts = new List<Shortcut>();

        public static void EnableMouseMoveDetection(bool enable)
        {
            if (enable)
                m_Events.MouseMove += M_Events_MouseMove;
            else
                m_Events.MouseMove -= M_Events_MouseMove;
        }

        public static void RegistarteShortcut(Shortcut shortcut)
        {
            m_shortcuts.Add(shortcut);
        }

        public static void RemoveShortcut(Shortcut shortcut)
        {
            m_shortcuts.Remove(shortcut);
        }

        public static void SubscribeGlobal()
        {
            Unsubscribe();
            Subscribe(Hook.GlobalEvents());
        }

        private static void Subscribe(IKeyboardMouseEvents events)
        {
            m_Events = events;

            m_Events.KeyDown += OnKeyDown;
            m_Events.KeyUp += OnKeyUp;

            m_Events.MouseDown += OnMouseDown;
            m_Events.MouseUp += OnMouseUp;

            m_Events.MouseWheel += HookManager_MouseWheel;
        }

        public static void Unsubscribe()
        {
            if (m_Events == null) return;

            m_Events.KeyDown -= OnKeyDown;
            m_Events.KeyUp -= OnKeyUp;

            m_Events.MouseDown -= OnMouseDown;
            m_Events.MouseUp -= OnMouseUp;
            if (m_detectMouseMove)
                m_Events.MouseMove -= M_Events_MouseMove;

            m_Events.MouseWheel -= HookManager_MouseWheel;

            m_Events.Dispose();
            m_Events = null;
        }

        private static void OnMouseDown(object sender, MouseEventArgs e)
        {
            ActivateEvent(CommandType.MouseDown, Keys.None, e.X, e.Y, false, (e.Button == MouseButtons.Right));
        }

        private static void OnMouseUp(object sender, MouseEventArgs e)
        {
            ActivateEvent(CommandType.MouseUp, Keys.None, e.X, e.Y, false, (e.Button == MouseButtons.Right));
        }

        private static void M_Events_MouseMove(object sender, MouseEventArgs e)
        {
            if (DateTime.Now >= m_lastMouseMove.AddMilliseconds(MouseMoveInterval))
            {
                ActivateEvent(CommandType.MouseMove, Keys.None, e.X, e.Y, false, false);
                m_lastMouseMove = DateTime.Now;
            }
        }

        private static void HookManager_MouseWheel(object sender, MouseEventArgs e)
        {
            ActivateEvent(CommandType.MouseWheel, Keys.None, e.X, e.Y, (e.Delta > 0 ? true : false), false);
        }

        private static void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!KeyIsDownAlready(e.KeyCode))
            {
                m_keysDown.Add(e.KeyCode);
                ActivateEvent(CommandType.KeyDown, e.KeyCode, 0, 0, false, false);
            }
        }

        private static void OnKeyUp(object sender, KeyEventArgs e)
        {
            ActivateEvent(CommandType.KeyUp, e.KeyCode, 0, 0, false, false);
            m_keysDown.Remove(e.KeyCode);
        }

        private static bool KeyIsDownAlready(Keys key)
        {
            bool isDown = false;

            for (int i = 0; i < m_keysDown.Count && !isDown; i++)
            {
                isDown = m_keysDown[i] == key;
            }

            return isDown;
        }

        private static void ActivateEvent(CommandType commandType, Keys key, int x, int y, bool wheelDirection, bool rightMouseButton)
        {
            //activate shortcuts
            if (commandType == CommandType.KeyDown)
            {
                foreach (Shortcut sc in m_shortcuts)
                {
                    bool shortcutKeysPressed = sc.Keys.Count > 0;
                    for (int i = 0; i < sc.Keys.Count && shortcutKeysPressed; i++)
                        shortcutKeysPressed = m_keysDown.Contains(sc.Keys[i]);
                    if (shortcutKeysPressed)
                        sc.TriggerShortcut();
                }
            }

            InputDetected?.Invoke(commandType, key, x, y, wheelDirection, rightMouseButton);
        }
    }
}
