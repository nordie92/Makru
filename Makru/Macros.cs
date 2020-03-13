using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    [Serializable]
    class Macros : TreeView
    {
        private static FormLog Log;
        public static Settings Settings;
        private bool m_controlPressed = false;

        public Macros()
        {
            InputDetection.SubscribeGlobal();
        }

        public void Load()
        {
            Settings = new Settings();

            ImageList il = new ImageList();
            il.Images.Add("folder", Makru.Properties.Resources.icon_folder);
            il.Images.Add("makro", Makru.Properties.Resources.icon_makro);
            il.Images.Add("activator", Makru.Properties.Resources.icon_aktivate);
            il.Images.Add("command", Makru.Properties.Resources.icon_command);
            il.Images.Add("wait", Makru.Properties.Resources.icon_wait);
            il.Images.Add("key", Makru.Properties.Resources.icon_key);
            il.Images.Add("variable", Makru.Properties.Resources.icon_variable);
            il.Images.Add("condition", Makru.Properties.Resources.icon_condition);
            il.Images.Add("writeFile", Makru.Properties.Resources.icon_writeFile);
            il.Images.Add("clock", Makru.Properties.Resources.icon_clock);
            ImageList = il;

            Nodes.Add(new Folder("Makros"));

            KeyDown += Makros_KeyDown;
            KeyUp += Makros_KeyUp;
        }

        public List<Macro> GetAllMacros()
        {
            return GetAllMacros(Nodes[0]);
        }

        private List<Macro> GetAllMacros(TreeNode rootNode)
        {
            List<Macro> macros = new List<Macro>();

            if (rootNode.GetType() == typeof(Macro))
            {
                macros.Add((Macro)rootNode);
            }
            else if (rootNode.GetType() == typeof(Folder))
            {
                foreach (TreeNode tn in (rootNode as Folder).Nodes)
                {
                    macros.AddRange(GetAllMacros(tn));
                }
            }

            return macros;
        }

        public static void StartLog()
        {
            if (Log == null)
            {
                Log = new FormLog();
                Log.FormClosed += Log_FormClosed1;
                Log.Show();
                Log.AddLog("Log started");
            }
        }

        private static void Log_FormClosed1(object sender, FormClosedEventArgs e)
        {
            Log.Dispose();
            Log = null;
        }

        public static void StopLog()
        {
            if (Log != null)
            {
                Log.Close();
                Log.Dispose();
                Log = null;
            }
        }

        public static void AddLog(string logText)
        {
            if (Log != null)
            {
                Log.AddLog(logText);
            }
        }

        private void Makros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ActivatorTime.CancelTimers(SelectedNode);
                ActivatorShortcut.RemoveEvents(SelectedNode);

                if (SelectedNode.GetType() == typeof(ActivatorShortcut))
                {
                    SelectedNode.Remove();
                }
                else if (SelectedNode.GetType() == typeof(ActivatorTime))
                {
                    SelectedNode.Remove();
                }
                else if (SelectedNode.Name == "command" || SelectedNode.Name == "activator" || SelectedNode.Name == "condition")
                {
                    SelectedNode.Remove();
                }
                else if (SelectedNode.Name == "makro" || SelectedNode.Name == "folder")
                {
                    DialogResult result = MessageBox.Show("Wollen Sie \"" + SelectedNode.Text + "\" und somit auch alle Unterpunkte wirklich löschen?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Nodes.Remove(SelectedNode);
                    }
                }
            }
            else if (e.KeyCode == Keys.Add)
            {
                if (SelectedNode.GetType() == typeof(CommandWait))
                {
                    CommandWait cw = (CommandWait)SelectedNode;
                    if (cw.Duration + 50 <= 3600000)
                        cw.Duration += 50;
                    else
                        cw.Duration = 3600000;
                }
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                if (SelectedNode.GetType() == typeof(CommandWait))
                {
                    CommandWait cw = (CommandWait)SelectedNode;
                    if (cw.Duration - 50 >= 20)
                        cw.Duration -= 50;
                    else
                        cw.Duration = 20;
                }
            }
            else if (e.KeyCode == Keys.NumPad0)
            {
                if (SelectedNode.GetType() == typeof(CommandWait))
                {
                    CommandWait cw = (CommandWait)SelectedNode;
                    cw.Duration = 40;
                }
            }
            else if (e.KeyCode == Keys.NumPad1)
            {
                if (SelectedNode.GetType() == typeof(CommandWait))
                {
                    CommandWait cw = (CommandWait)SelectedNode;
                    cw.Duration = 100;
                }
            }
            else if (e.KeyCode == Keys.NumPad2)
            {
                if (SelectedNode.GetType() == typeof(CommandWait))
                {
                    CommandWait cw = (CommandWait)SelectedNode;
                    cw.Duration = 200;
                }
            }
            else if (e.KeyCode == Keys.Up && m_controlPressed)
            {
                if (SelectedNode.Name == "command" || SelectedNode.Name == "condition" ||
                    SelectedNode.Name == "activator" || SelectedNode.Name == "makro" || SelectedNode.Name == "folder")
                {
                    int tnIndex = SelectedNode.Index;
                    if (tnIndex - 1 >= 0)
                    {
                        TreeNode parentNode = SelectedNode.Parent;
                        TreeNode tn = SelectedNode;
                        parentNode.Nodes.Remove(tn);
                        parentNode.Nodes.Insert(tnIndex - 1, tn);
                        SelectedNode = tn;
                    }
                }
            }
            else if (e.KeyCode == Keys.Down && m_controlPressed)
            {
                if (SelectedNode.Name == "command" || SelectedNode.Name == "condition" ||
                    SelectedNode.Name == "activator" || SelectedNode.Name == "makro" || SelectedNode.Name == "folder")
                {
                    int tnIndex = SelectedNode.Index;
                    TreeNode parentNode = SelectedNode.Parent;
                    if (tnIndex + 1 <= parentNode.Nodes.Count)
                    {
                        TreeNode tn = SelectedNode;
                        parentNode.Nodes.Remove(tn);
                        parentNode.Nodes.Insert(tnIndex + 1, tn);
                        SelectedNode = tn;
                    }
                }
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                m_controlPressed = true;
            }
        }

        private void Makros_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                m_controlPressed = false;
            }
        }

        public string JSON()
        {
            string jsonString = "";
            jsonString += "{";
            jsonString += "\"settings\": " + Settings.JSON() + ",";
            jsonString += "\"macros\": ";
            jsonString += (Nodes[0] as Folder).JSON();
            jsonString += "}";
            return jsonString;
        }

        public void ReadJSON(string json)
        {
            Nodes.Clear();
            Nodes.Add(new Folder("Makros"));

            dynamic macros = JsonConvert.DeserializeObject(json);

            Settings.ReadJSON(macros.settings);

            foreach (dynamic d in macros.macros.children)
            {
                if (d.type == "folder")
                {
                    Folder f = new Folder((string)d.name);
                    Nodes[0].Nodes.Add(f);
                    f.ReadJSON(d);
                }
                else if (d.type == "macro")
                {
                    Macro m = new Macro((string)d.name);
                    Nodes[0].Nodes.Add(m);
                    m.ReadJSON(d);
                }
            }
        }
    }
}
