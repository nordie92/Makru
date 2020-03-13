using InputManager;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public class Macro : TreeNode
    {
        private bool m_active;
        public bool IsPlayingMacro;
        private Thread m_replayThread;
        public SettingsMacro SettingsMacro;
        private System.Windows.Forms.Timer m_threadWatcherTimer;
        public List<Variable> Variables { get; set; }
        public Point LastMousePosition { get; set; }
        public long LastTimeNeeded { get; set; }

        public Macro(string name)
        {
            Text = name;
            ImageKey = "makro";
            SelectedImageKey = "makro";
            Name = "makro";

            Variables = new List<Variable>();
            SettingsMacro = new SettingsMacro();

            m_threadWatcherTimer = new System.Windows.Forms.Timer();
            m_threadWatcherTimer.Interval = 500;
            m_threadWatcherTimer.Enabled = true;

            Nodes.Add(new Activators());
            Nodes.Add(new Commands(this));
        }

        private void M_threadWatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!ThreadWorking())
            {
                NodeFont = new Font(TreeView.Font, FontStyle.Regular);
                ForeColor = Color.Black;
                Macros.AddLog("Makro \"" + Text + "\" ist fertig");
                m_threadWatcherTimer.Tick -= M_threadWatcherTimer_Tick;
            }
        }

        public void RemoveActivators()
        {
            foreach (Activator a in Nodes[0].Nodes)
            {
                if (a.GetType() == typeof(ActivatorShortcut))
                {
                    InputDetection.RemoveShortcut((a as ActivatorShortcut).Shortcut);
                }
            }
        }

        public Variable GetVariableByName(string name)
        {
            Variable result = null;
            for (int i = 0; i < Variables.Count && result == null; i++)
            {
                if (Variables[i].Name == name)
                {
                    result = Variables[i];
                }
            }
            return result;
        }

        public void EmptyVariables()
        {
            foreach (Variable v in Variables)
            {
                v.Value = "";
            }
        }

        public static Macro GetMacroByChild(TreeNode node)
        {
            if (node.GetType() == typeof(Macro))
            {
                return (Macro)node;
            }
            else
            {
                return GetMacroByChild(node.Parent);
            }
        }

        public void StartReplayThread(bool loopexEcution)
        {
            try
            {
                if (!ThreadWorking())
                {
                    m_replayThread = new Thread(PlaybackMacro);
                    m_replayThread.IsBackground = true;
                    m_replayThread.Start(loopexEcution);
                    Macros.AddLog("Makro \"" + Text + "\" started");
                    NodeFont = new Font(TreeView.Font, FontStyle.Bold);
                    ForeColor = Color.Green;
                    m_threadWatcherTimer.Tick += M_threadWatcherTimer_Tick;
                }
            }
            catch (Exception)
            {
                Macros.AddLog("Fehler: Makro konnte nicht wiedergegeben werden!");
            }
        }

        public void StopReplayThread()
        {
            if (ThreadWorking())
            {
                m_replayThread.Abort();
                NodeFont = new Font(TreeView.Font, FontStyle.Regular);
                ForeColor = Color.Black;
                Macros.AddLog("Makro \"" + Text + "\" wurde gestoppt");
                m_threadWatcherTimer.Tick -= M_threadWatcherTimer_Tick;
            }
        }

        public bool ThreadWorking()
        {
            bool result = true;

            if (m_replayThread != null)
            {
                if (m_replayThread.ThreadState == System.Threading.ThreadState.Aborted || m_replayThread.ThreadState == System.Threading.ThreadState.Stopped)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public void PlaybackMacro(object objLoop)
        {
            IsPlayingMacro = true;

            EmptyVariables();

            LastMousePosition = new Point(-1, -1);

            bool doLoop = (bool)objLoop;

            foreach (Command cmd in Nodes[1].Nodes)
            {
                if (cmd.GetType() == typeof(CommandInput) || cmd.GetType() == typeof(CommandSetVariable) || cmd.GetType() == typeof(CommandWriteFile))
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();

                    cmd.ExecuteCommand();

                    sw.Stop();
                    LastTimeNeeded = sw.ElapsedMilliseconds;
                }
                else
                {
                    cmd.ExecuteCommand();
                }
            }

            if (doLoop)
            {
                PlaybackMacro(true);
            }

            IsPlayingMacro = false;
        }

        public string JSON()
        {
            bool firstItem = true;
            string strReturn = "";
            strReturn += "{\"type\": \"macro\",";
            strReturn += "\"settings\":" + SettingsMacro.JSON() + ",";
            strReturn += "\"name\": \"" + Text + "\",";
            strReturn += "\"active\": " + (m_active ? "true" : "false") + ",";
            strReturn += "\"activators\": [";
            foreach (TreeNode node in Nodes[0].Nodes)
            {
                strReturn += (firstItem ? "" : ",") + (node as Activator).JSON();
                firstItem = false;
            }
            strReturn += "],";
            strReturn += "\"commands\": [";
            firstItem = true;
            foreach (TreeNode node in Nodes[1].Nodes)
            {
                strReturn += (firstItem ? "" : ",") + (node as Command).JSON();
                firstItem = false;
            }
            strReturn += "]}";
            return strReturn;
        }

        public void ReadJSON(dynamic json)
        {
            m_active = (json.active == "true" ? true : false);
            SettingsMacro.ReadJSON(json.settings);
            foreach (dynamic d in json.activators)
            {
                if (d.type == "activatorShortcut")
                {
                    List<Keys> keys = new List<Keys>();
                    foreach (Keys k in d.keys.ToObject<Keys[]>())
                        keys.Add(k);
                    Shortcut shortcut = new Shortcut(keys);
                    ActivatorShortcut a = new ActivatorShortcut(shortcut, d.loop.ToObject<bool>(), this);
                    Nodes[0].Nodes.Add(a);
                }
                else if (d.type == "activatorTime")
                {
                    ActivatorTime a = new ActivatorTime(
                        DateTime.ParseExact((string)d.time, "HH:mm:ss", CultureInfo.InvariantCulture),
                        TimeSpan.ParseExact((string)d.interval, "dd':'hh':'mm':'ss", CultureInfo.InvariantCulture),
                        this);
                    Nodes[0].Nodes.Add(a);
                }
            }
            ReadJSONCommand(json, Nodes[1], 0);
        }

        private void ReadJSONCommand(dynamic json, TreeNode currentNode, int index)
        {
            dynamic d;
            try
            {
                d = json.commands;
            }
            catch (RuntimeBinderException)
            {
                d = json;
            }
            foreach (dynamic command in d)
            {
                switch ((string)command.type)
                {
                    case "KeyDown":
                        CommandInput ci1 = new CommandInput(CommandType.KeyDown, command.keyCode.ToObject<Keys>(), 0, 0, false, false, this);
                        currentNode.Nodes.Add(ci1);
                        break;
                    case "KeyUp":
                        CommandInput ci2 = new CommandInput(CommandType.KeyUp, command.keyCode.ToObject<Keys>(), 0, 0, false, false, this);
                        currentNode.Nodes.Add(ci2);
                        break;
                    case "MouseDown":
                        CommandInput ci3 = new CommandInput(CommandType.MouseDown, Keys.None, command.x.ToObject<int>(), command.y.ToObject<int>(), false, (command.button.ToObject<string>() == "right" ? true : false), this);
                        currentNode.Nodes.Add(ci3);
                        break;
                    case "MouseUp":
                        CommandInput ci4 = new CommandInput(CommandType.MouseUp, Keys.None, command.x.ToObject<int>(), command.y.ToObject<int>(), false, (command.button.ToObject<string>() == "right" ? true : false), this);
                        currentNode.Nodes.Add(ci4);
                        break;
                    case "MouseMove":
                        CommandInput ci41 = new CommandInput(CommandType.MouseMove, Keys.None, command.x.ToObject<int>(), command.y.ToObject<int>(), false, false, this);
                        currentNode.Nodes.Add(ci41);
                        break;
                    case "MouseWheel":
                        CommandInput ci5 = new CommandInput(CommandType.MouseWheel, Keys.None, command.x.ToObject<int>(), command.y.ToObject<int>(), (command.wheelDirection.ToObject<string>() == "up" ? true : false), false, this);
                        currentNode.Nodes.Add(ci5);
                        break;
                    case "wait":
                        CommandWait ci6 = new CommandWait(command.duration.ToObject<int>(), this);
                        currentNode.Nodes.Add(ci6);
                        break;
                    case "condition":
                        CommandCondition ci8 = new CommandCondition();
                        currentNode.Nodes.Add(ci8);
                        foreach (dynamic j in command.conditions)
                        {
                            ci8.Nodes[0].Nodes.Add(new ConditionNode(ReadJSONCondition(j)));
                        }
                        ReadJSONCommand(command.thenCommands, ci8.Nodes[1], 0);
                        ReadJSONCommand(command.elseCommands, ci8.Nodes[2], 0);
                        break;
                    case "replayMacro":
                        CommandReplayMakro ci9 = new CommandReplayMakro((string)command.name, this);
                        currentNode.Nodes.Add(ci9);
                        break;
                    case "setVariable":
                        Variable v = new Variable((string)command.variable, "");
                        this.Variables.Add(v);
                        CommandSetVariable ci10 = new CommandSetVariable(v, ReadJSONOutput(command.output), this);
                        currentNode.Nodes.Add(ci10);
                        break;
                    case "writeFile":
                        string fileName = (string)command.fileName;
                        fileName = fileName.Replace("\\\\", "\\");
                        CommandWriteFile ci11 = new CommandWriteFile(fileName, (string)command.text, (bool)command.appendFile, this);
                        currentNode.Nodes.Add(ci11);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private Condition ReadJSONCondition(dynamic json)
        {
            if (json.Count == 0)
                return null;

            Condition retCondition = null;

            switch ((string)json.type)
            {
                case "conditionAnd":
                    retCondition = new ConditionAnd(ReadJSONCondition(json.condition1), ReadJSONCondition(json.condition2), this);
                    break;
                case "conditionOr":
                    retCondition = new ConditionOr(ReadJSONCondition(json.condition1), ReadJSONCondition(json.condition2), this);
                    break;
                case "conditionWaitFor":
                    retCondition = new ConditionWaitFor(ReadJSONCondition(json.condition), (int)json.checkInterval, this);
                    break;
                case "conditionPixelColor":
                    retCondition = new ConditionPixelColor((int)json.x, (int)json.y, Color.FromArgb((int)json.color), (int)json.maxColorifference);
                    break;
                case "conditionComapeText":
                    retCondition = new ConditionCompareOutputs(ReadJSONOutput(json.output1), (string)json.conditionOperator, ReadJSONOutput(json.output2), this);
                    break;
                case "conditionProcessName":
                    retCondition = new ConditionProcessName((string)json.processName, (bool)json.processesContain);
                    break;
            }

            return retCondition;
        }

        private Output ReadJSONOutput(dynamic json)
        {
            if (json.Count == 0)
                return null;

            Output returnOutput = null;

            switch ((string)json.type)
            {
                case "outputOCR":
                    Rectangle textRec = new Rectangle((int)json.x, (int)json.y, (int)json.width, (int)json.height);
                    Size letterSize = new Size((int)json.letterWidth, (int)json.letterHeight);
                    Size letterBorder = new Size((int)json.letterBorderX, (int)json.letterBorderY);
                    returnOutput = new OutputOCR(textRec, (bool)json.grayscale, (float)json.contrast, (int)json.scale, (bool)json.letterSpacingActive, letterSize, letterBorder);
                    break;
                case "outputStaticText":
                    returnOutput = new OutputStaticText((string)json.value);
                    break;
                case "outputAddition":
                    returnOutput = new OutputAddition(ReadJSONOutput(json.output1), ReadJSONOutput(json.output2), this);
                    break;
                case "outputSubstract":
                    returnOutput = new OutputSubstract(ReadJSONOutput(json.output1), ReadJSONOutput(json.output2), this);
                    break;
                case "outputMultiply":
                    returnOutput = new OutputMultiply(ReadJSONOutput(json.output1), ReadJSONOutput(json.output2), this);
                    break;
                case "outputDivide":
                    returnOutput = new OutputDivide(ReadJSONOutput(json.output1), ReadJSONOutput(json.output2), this);
                    break;
                case "outputVariable":
                    returnOutput = new OutputVariable((string)json.name, this);
                    break;
            }

            return returnOutput;
        }
    }
}
