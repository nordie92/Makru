using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public class Shortcut
    {
        public List<Keys> Keys { get; set; }
        public delegate void ShortcutPressedHandler();
        public event ShortcutPressedHandler ShortcutPressed;

        public Shortcut(List<Keys> keys)
        {
            Keys = new List<Keys>();
            foreach (Keys k in keys)
            {
                Keys.Add(k);
            }
        }

        public void TriggerShortcut()
        {
            ShortcutPressed();
        }
    }
}
