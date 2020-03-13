using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using InputManager;

namespace Makru
{
    public partial class FormMacro : Form
    {
        private TreeNode m_selectedNode;

        public FormMacro()
        {
            InitializeComponent();

            tvMakros.Load();

            if (File.Exists(@".\save.json"))
            {
                StreamReader sr = new StreamReader(@".\save.json", Encoding.UTF8);
                tvMakros.ReadJSON(sr.ReadToEnd());
                sr.Close();
            }

            if (!Macros.Settings.StartProgramMinimzed)
            {
                Show();
            }

            ExpandTreeView(tvMakros.Nodes[0], 2);
        }

        private void FormMakro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Macros.Settings.MinimizeProgrammOnClose)
            {
                Hide();
                e.Cancel = true;
            }
            else
            {
                Save();
            }
        }

        public void Save()
        {
            StreamWriter sw = new StreamWriter(@".\save.json", false, Encoding.UTF8);
            sw.WriteLine(tvMakros.JSON());
            sw.Close();
        }

        private void tvMakros_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvMakros.SelectedNode = e.Node;

            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.GetType() == typeof(CommandWait))
                {
                    CommandWait c = (CommandWait)tvMakros.SelectedNode;

                    FormCommandWait frm = new FormCommandWait(c.Duration);
                    if (frm.ShowDialog() == DialogResult.OK)
                        c.Duration = frm.WaitDuration;
                }
                else if (e.Node.GetType() == typeof(ActivatorShortcut))
                {
                    ActivatorShortcut a = (ActivatorShortcut)e.Node;
                    FormActivatorShortcut frm = new FormActivatorShortcut(a.Shortcut, a.LoopexEcution);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        a.Shortcut.Keys = frm.Shortcut.Keys;
                        a.Shortcut = a.Shortcut;
                        a.LoopexEcution = frm.LoopExecution;
                    }
                }
                else if (e.Node.GetType() == typeof(ActivatorTime))
                {
                    ActivatorTime a = (ActivatorTime)e.Node;
                    FormActivatorTime frm = new FormActivatorTime(a.TriggerTime, a.TriggerInterval);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        a.TriggerTime = frm.TriggerTime;
                        a.TriggerInterval = frm.TriggerInterval;
                    }
                }
                else if (e.Node.GetType() == typeof(CommandInput))
                {
                    Macro m = Macro.GetMacroByChild(m_selectedNode);
                    FormCommandInput frm = new FormCommandInput((CommandInput)e.Node, m);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        e.Node.Parent.Nodes.Insert(e.Node.Index, frm.CommandInput);
                        e.Node.Remove();
                    }
                }
                else if (e.Node.GetType() == typeof(ConditionNode))
                {
                    Macro m = Macro.GetMacroByChild(tvMakros.SelectedNode);
                    ConditionNode cn = (ConditionNode)e.Node;

                    FormCondition frm = null;
                    if (cn.Condition != null)
                        frm = new FormCondition(cn.Condition, m);
                    else
                        frm = new FormCondition(m);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        cn.Condition = frm.Condition;
                    }
                }
                else if (e.Node.GetType() == typeof(CommandSetVariable))
                {
                    CommandSetVariable c = (CommandSetVariable)m_selectedNode;
                    Macro m = Macro.GetMacroByChild(c);
                    FormCommandSetVariable frm = new FormCommandSetVariable((c.Variable != null ? c.Variable.Name : ""), c.Output, m);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        c.Variable = frm.Variable;
                        c.Output = frm.Output;
                    }
                }
                else if (e.Node.GetType() == typeof(CommandReplayMakro))
                {
                    CommandReplayMakro c = (CommandReplayMakro)m_selectedNode;
                    FormCommandReplayMacro frm = new FormCommandReplayMacro(c.MacroName);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        c.MacroName = frm.MacroName;
                    }
                }
                else if (e.Node.GetType() == typeof(CommandWriteFile))
                {
                    Macro m = Macro.GetMacroByChild(m_selectedNode);
                    CommandWriteFile c = (CommandWriteFile)m_selectedNode;
                    FormCommandWriteFile frm = new FormCommandWriteFile(c.FileName, c.FileText, c.AppendFile, m);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        c.FileName = frm.FileName;
                        c.FileText = frm.Text;
                        c.AppendFile = frm.AppendFile;
                    }
                }
            }
        }

        private void ExpandTreeView(TreeNode node, int depth)
        {
            if (depth > 0)
            {
                node.Expand();

                foreach (TreeNode tn in node.Nodes)
                    ExpandTreeView(tn, depth - 1);
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.WriteLine(tvMakros.JSON());
                sw.Close();
            }
        }

        private void tsmiLoadJSON_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Es gehen alle aktuellen Makros verloren.\nWollen sie wirklich forfahren?",
                "Warnung",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(ofd.FileName, Encoding.Default);
                    tvMakros.ReadJSON(sr.ReadToEnd());
                    sr.Close();
                }
            }
        }

        private void tsmiLog_Click(object sender, EventArgs e)
        {
            Macros.StartLog();
        }

        private void tsmiStopMacro_Click11(object sender, EventArgs e)
        {
            if (m_selectedNode.GetType() == typeof(Macro))
            {
                Macro m = (Macro)m_selectedNode;
                if (m.ThreadWorking())
                {
                    m.StopReplayThread();
                }
            }
        }

        private List<string> GetMacroNames()
        {
            return GetMacroNames(new List<string>(), tvMakros.Nodes[0]);
        }

        private List<string> GetMacroNames(List<string> macroNames, TreeNode rootNode)
        {
            List<string> names = new List<string>();

            foreach (TreeNode tn in rootNode.Nodes)
            {
                if (tn.GetType() == typeof(Folder))
                {
                    names.AddRange(GetMacroNames(names, tn));
                }
                else if (tn.GetType() == typeof(Macro))
                {
                    names.Add(tn.Text);
                }
            }

            return names;
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings frm = new FormSettings(Macros.Settings);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Macros.Settings = frm.Settings;
            }
        }

        private void tvMakros_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvMakros.SelectedNode = e.Node;
            m_selectedNode = e.Node;

            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.Name == "folder")
                {
                    cmsMakros.Items["tsmiNew"].Enabled = true;
                    cmsMakros.Items["tsmiNewActivator"].Enabled = false;
                    cmsMakros.Items["tsmiNewCondition"].Enabled = false;
                    cmsMakros.Items["tsmiNewCommand"].Enabled = false;
                    cmsMakros.Items["tsmiRename"].Enabled = e.Node.Level != 0;
                    cmsMakros.Items["tsmiRemove"].Enabled = e.Node.Level != 0;
                    cmsMakros.Items["tsmiReplayMacro"].Enabled = false;
                    cmsMakros.Items["tsmiStopReplay"].Enabled = false;
                    cmsMakros.Items["tsmiRecordMacro"].Enabled = false;
                    cmsMakros.Items["tsmiSettings"].Enabled = false;
                    cmsMakros.Show(tvMakros, e.Location);
                }
                else if (e.Node.Name == "makro")
                {
                    cmsMakros.Items["tsmiNew"].Enabled = false;
                    cmsMakros.Items["tsmiNewActivator"].Enabled = false;
                    cmsMakros.Items["tsmiNewCondition"].Enabled = false;
                    cmsMakros.Items["tsmiNewCommand"].Enabled = false;
                    cmsMakros.Items["tsmiRename"].Enabled = true;
                    cmsMakros.Items["tsmiRemove"].Enabled = true;
                    cmsMakros.Items["tsmiReplayMacro"].Enabled = !(e.Node as Macro).ThreadWorking();
                    cmsMakros.Items["tsmiStopReplay"].Enabled = (e.Node as Macro).ThreadWorking();
                    cmsMakros.Items["tsmiRecordMacro"].Enabled = false;
                    cmsMakros.Items["tsmiSettings"].Enabled = true;
                    cmsMakros.Show(tvMakros, e.Location);
                }
                else if (e.Node.Name == "activators" || e.Node.Name == "activator")
                {
                    cmsMakros.Items["tsmiNew"].Enabled = false;
                    cmsMakros.Items["tsmiNewActivator"].Enabled = true;
                    cmsMakros.Items["tsmiNewCondition"].Enabled = false;
                    cmsMakros.Items["tsmiNewCommand"].Enabled = false;
                    cmsMakros.Items["tsmiRename"].Enabled = false;
                    cmsMakros.Items["tsmiRemove"].Enabled = true;
                    cmsMakros.Items["tsmiReplayMacro"].Enabled = false;
                    cmsMakros.Items["tsmiStopReplay"].Enabled = false;
                    cmsMakros.Items["tsmiRecordMacro"].Enabled = false;
                    cmsMakros.Items["tsmiSettings"].Enabled = false;
                    cmsMakros.Show(tvMakros, e.Location);
                }
                else if (e.Node.Name == "conditions" || e.Node.Name == "condition")
                {
                    cmsMakros.Items["tsmiNew"].Enabled = false;
                    cmsMakros.Items["tsmiNewActivator"].Enabled = false;
                    cmsMakros.Items["tsmiNewCondition"].Enabled = true;
                    cmsMakros.Items["tsmiNewCommand"].Enabled = false;
                    cmsMakros.Items["tsmiRename"].Enabled = false;
                    cmsMakros.Items["tsmiRemove"].Enabled = true;
                    cmsMakros.Items["tsmiReplayMacro"].Enabled = false;
                    cmsMakros.Items["tsmiStopReplay"].Enabled = false;
                    cmsMakros.Items["tsmiRecordMacro"].Enabled = false;
                    cmsMakros.Items["tsmiSettings"].Enabled = false;
                    cmsMakros.Show(tvMakros, e.Location);
                }
                else if (e.Node.Name == "command")
                {
                    cmsMakros.Items["tsmiNew"].Enabled = false;
                    cmsMakros.Items["tsmiNewActivator"].Enabled = false;
                    cmsMakros.Items["tsmiNewCondition"].Enabled = false;
                    cmsMakros.Items["tsmiNewCommand"].Enabled = true;
                    cmsMakros.Items["tsmiRename"].Enabled = false;
                    cmsMakros.Items["tsmiRemove"].Enabled = true;
                    cmsMakros.Items["tsmiReplayMacro"].Enabled = false;
                    cmsMakros.Items["tsmiStopReplay"].Enabled = false;
                    cmsMakros.Items["tsmiRecordMacro"].Enabled = false;
                    cmsMakros.Items["tsmiSettings"].Enabled = false;
                    cmsMakros.Show(tvMakros, e.Location);
                }
                else if (e.Node.Name == "commands")
                {
                    cmsMakros.Items["tsmiNew"].Enabled = false;
                    cmsMakros.Items["tsmiNewActivator"].Enabled = false;
                    cmsMakros.Items["tsmiNewCondition"].Enabled = false;
                    cmsMakros.Items["tsmiNewCommand"].Enabled = true;
                    cmsMakros.Items["tsmiRename"].Enabled = false;
                    cmsMakros.Items["tsmiRemove"].Enabled = true;
                    cmsMakros.Items["tsmiReplayMacro"].Enabled = false;
                    cmsMakros.Items["tsmiStopReplay"].Enabled = false;
                    cmsMakros.Items["tsmiRecordMacro"].Enabled = true;
                    cmsMakros.Items["tsmiSettings"].Enabled = false;
                    cmsMakros.Show(tvMakros, e.Location);
                }
            }
        }

        private void tsmiNewMacro_Click(object sender, EventArgs e)
        {
            string name = "Mein Makro 1";
            while (GetMacroNames().Contains(name))
            {
                string[] nameSplit = name.Split(' ');
                int nameNumber = 0;
                if (int.TryParse(nameSplit[nameSplit.Length - 1], out nameNumber))
                {
                    name = "";
                    for (int i = 0; i < nameSplit.Length - 1; i++)
                    {
                        name += nameSplit[i] + " ";
                    }
                    name += (nameNumber + 1);
                }
                else
                {
                    name += " 1";
                }
            }

            m_selectedNode.Nodes.Add(new Macro(name));
        }

        private void tsmiNewFolder_Click(object sender, EventArgs e)
        {
            Folder f = new Folder("Neuer Ordner");
            m_selectedNode.Nodes.Add(f);
        }

        private void tsmiNewActivatorShortcut_Click_1(object sender, EventArgs e)
        {
            FormActivatorShortcut frm = new FormActivatorShortcut(new Shortcut(new List<Keys>()), false);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Macro m = null;
                if (m_selectedNode.Name == "activator")
                {
                    m = (Macro)m_selectedNode.Parent.Parent;
                    ActivatorShortcut a = new ActivatorShortcut(new Shortcut(frm.Shortcut.Keys), frm.LoopExecution, m);
                    m_selectedNode.Parent.Nodes.Add(a);
                }
                else if (m_selectedNode.Name == "activators")
                {
                    m = (Macro)m_selectedNode.Parent;
                    ActivatorShortcut a = new ActivatorShortcut(new Shortcut(frm.Shortcut.Keys), frm.LoopExecution, m);
                    m_selectedNode.Nodes.Insert(0, a);
                }
            }
        }

        private void tsmiNewActivatorTime_Click(object sender, EventArgs e)
        {
            FormActivatorTime frm = new FormActivatorTime(DateTime.Now, new TimeSpan());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Macro m = null;
                if (m_selectedNode.Name == "activator")
                {
                    m = (Macro)m_selectedNode.Parent.Parent;
                    ActivatorTime a = new ActivatorTime(frm.TriggerTime, frm.TriggerInterval, m);
                    m_selectedNode.Parent.Nodes.Add(a);
                }
                else if (m_selectedNode.Name == "activators")
                {
                    m = (Macro)m_selectedNode.Parent;
                    ActivatorTime a = new ActivatorTime(frm.TriggerTime, frm.TriggerInterval, m);
                    m_selectedNode.Nodes.Insert(0, a);
                }
            }
        }

        private void tsmiNewCondition_Click(object sender, EventArgs e)
        {
            Macro m = Macro.GetMacroByChild(tvMakros.SelectedNode);

            FormCondition frm = new FormCondition(m);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (m_selectedNode.Name == "conditions")
                    m_selectedNode.Nodes.Insert(0, new ConditionNode(frm.Condition));
                else
                    m_selectedNode.Parent.Nodes.Insert(m_selectedNode.Index + 1, new ConditionNode(frm.Condition));
            }
        }

        private void tsmiNewWait_Click(object sender, EventArgs e)
        {
            FormCommandWait frm = new FormCommandWait(1000);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Macro m = (Macro.GetMacroByChild(m_selectedNode) as Macro);

                if (m_selectedNode.Name == "commands")
                    m_selectedNode.Nodes.Insert(0, new CommandWait(frm.WaitDuration, m));
                else
                    m_selectedNode.Parent.Nodes.Insert(m_selectedNode.Index + 1, new CommandWait(frm.WaitDuration, m));
            }
        }

        private void tsmiNewInput_Click(object sender, EventArgs e)
        {
            Macro m = Macro.GetMacroByChild(m_selectedNode);
            FormCommandInput frm = new FormCommandInput(new CommandInput(CommandType.MouseDown, Keys.None, 0, 0, false, false, m), m);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (m_selectedNode.Name == "commands")
                    m_selectedNode.Nodes.Insert(0, frm.CommandInput);
                else
                    m_selectedNode.Parent.Nodes.Insert(m_selectedNode.Index + 1, frm.CommandInput);
            }
        }

        private void tsmiNewComandCondition_Click(object sender, EventArgs e)
        {
            if (m_selectedNode.Name == "commands")
                m_selectedNode.Nodes.Insert(0, new CommandCondition());
            else
                m_selectedNode.Parent.Nodes.Insert(m_selectedNode.Index + 1, new CommandCondition());
        }

        private void tsmiNewCommandReplayMacro_Click(object sender, EventArgs e)
        {
            FormCommandReplayMacro frm = new FormCommandReplayMacro("");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Macro macro = Macro.GetMacroByChild(m_selectedNode);
                CommandReplayMakro replayMacro = new CommandReplayMakro(frm.MacroName, macro);

                if (m_selectedNode.Name == "commands")
                    m_selectedNode.Nodes.Insert(0, replayMacro);
                else
                    m_selectedNode.Parent.Nodes.Insert(m_selectedNode.Index + 1, replayMacro);
            }
        }

        private void tsmiNewSetVariable_Click(object sender, EventArgs e)
        {
            Macro m = Macro.GetMacroByChild(m_selectedNode);
            FormCommandSetVariable frm = new FormCommandSetVariable("", null, Macro.GetMacroByChild(m_selectedNode));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CommandSetVariable c = new CommandSetVariable(frm.Variable, frm.Output, m);

                if (m_selectedNode.Name == "commands")
                    m_selectedNode.Nodes.Insert(0, c);
                else
                    m_selectedNode.Parent.Nodes.Insert(m_selectedNode.Index + 1, c);
            }
        }

        private void tsmiNewWriteFIle_Click(object sender, EventArgs e)
        {
            Macro m = Macro.GetMacroByChild(m_selectedNode);
            FormCommandWriteFile frm = new FormCommandWriteFile("", "", true, m);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CommandWriteFile c = new CommandWriteFile(frm.FileName, frm.Text, frm.AppendFile, m);

                if (m_selectedNode.Name == "commands")
                    m_selectedNode.Nodes.Insert(0, c);
                else
                    m_selectedNode.Parent.Nodes.Insert(m_selectedNode.Index + 1, c);
            }
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            string name = "";

            FormRename frm = new FormRename(m_selectedNode.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                name = frm.Name;

                if (m_selectedNode.GetType() == typeof(Macro))
                {
                    while (GetMacroNames().Contains(name) && name != m_selectedNode.Text)
                    {
                        MessageBox.Show("Der Name \"" + name + "\" ist bereits vorhanden", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        FormRename frm2 = new FormRename(m_selectedNode.Text);
                        if (frm2.ShowDialog() == DialogResult.OK)
                        {
                            name = frm2.Name;
                        }
                        else
                        {
                            name = m_selectedNode.Text;
                            break;
                        }
                    }
                }

                m_selectedNode.Text = name;
            }
        }

        private void tsmiRemove_Click(object sender, EventArgs e)
        {
            if (m_selectedNode.Name == "commands" || m_selectedNode.Name == "activators" || m_selectedNode.Name == "conditions")
            {
                DialogResult result = MessageBox.Show("Mit \"Löschen\" werden in diesem Kontext alle Unterpunkte des geklicken Punktes gelöscht. Wollen Sie wirklich forfahren?", "Alle Unterpunkte löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ActivatorShortcut.RemoveEvents(m_selectedNode);
                    ActivatorTime.CancelTimers(m_selectedNode);
                    m_selectedNode.Nodes.Clear();
                }
            }
            else if (m_selectedNode.Name == "folder")
            {
                DialogResult result = MessageBox.Show("Wollen Sie \"" + m_selectedNode.Text + "\" und smit auch alle Unterpunkte wirklich löschen?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ActivatorShortcut.RemoveEvents(m_selectedNode);
                    ActivatorTime.CancelTimers(m_selectedNode);
                    tvMakros.Nodes.Remove(m_selectedNode);
                    m_selectedNode = null;
                }
            }
            else if (m_selectedNode.Name == "makro")
            {
                DialogResult result = MessageBox.Show("Wollen Sie \"" + m_selectedNode.Text + "\" und smit auch alle Unterpunkte wirklich löschen?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ActivatorShortcut.RemoveEvents(m_selectedNode);
                    ActivatorTime.CancelTimers(m_selectedNode);
                    tvMakros.Nodes.Remove(m_selectedNode);
                    m_selectedNode = null;
                }
            }
            else
            {
                ActivatorShortcut.RemoveEvents(m_selectedNode);
                ActivatorTime.CancelTimers(m_selectedNode);
                tvMakros.Nodes.Remove(m_selectedNode);
                m_selectedNode = null;
            }
        }

        private void tsmiReplayMacro_Click(object sender, EventArgs e)
        {
            Macro m = (Macro)m_selectedNode;
            m.StartReplayThread(false);
        }

        private void tsmiStopReplay_Click(object sender, EventArgs e)
        {
            Macro m = (Macro)m_selectedNode;
            m.StopReplayThread();
        }

        private void tsmiRecordMacro_Click(object sender, EventArgs e)
        {
            FormRecordMakro frm = new FormRecordMakro(m_selectedNode);
            frm.ShowDialog();
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            Macro m = (Macro)m_selectedNode;
            FormSettingsMacro frm = new FormSettingsMacro(m.SettingsMacro);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                m.SettingsMacro = frm.SettingsMacro;
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
