using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    class ConditionProcessName : Condition
    {
        public override event OnConditionChangedEvent OnConditionChanged;
        private ComboBox m_cbProcessname;
        private ComboBox m_cbProcessesContain;
        public string ProcessName { get; internal set; }
        public bool ProcessesContain { get; internal set; }

        public ConditionProcessName(string processname, bool processesContain)
        {
            ProcessName = processname;
            ProcessesContain = processesContain;

            CreateUI();
        }

        private void CreateUI()
        {
            Height = 84;
            Width = 271;

            Label lbProcessName = new Label();
            lbProcessName.Text = "Prozessname";
            lbProcessName.AutoSize = false;
            lbProcessName.Top = 9;
            lbProcessName.Left = 10;
            Controls.Add(lbProcessName);

            m_cbProcessname = new ComboBox();
            m_cbProcessname.Text = ProcessName;
            m_cbProcessname.Top = lbProcessName.Height + 9 + 8;
            m_cbProcessname.Left = 10;
            m_cbProcessname.Width = 120;

            Process[] processes = Process.GetProcesses();
            List<string> processNames = new List<string>();
            for (int i = 0; i < processes.Length; i++)
            {
                if (!processNames.Contains(processes[i].ProcessName))
                {
                    processNames.Add(processes[i].ProcessName);
                }
            }
            processNames.Sort();
            m_cbProcessname.Items.AddRange(processNames.ToArray());
            Controls.Add(m_cbProcessname);

            m_cbProcessesContain = new ComboBox();
            m_cbProcessesContain.Top = lbProcessName.Height + 9 + 8;
            m_cbProcessesContain.Left = 10 + 10 + m_cbProcessname.Width;
            m_cbProcessesContain.Width = 120;
            m_cbProcessesContain.DropDownStyle = ComboBoxStyle.DropDownList;
            m_cbProcessesContain.Items.AddRange(new string[] { "wird ausgeführt", "wird nicht ausgeführt" });
            m_cbProcessesContain.SelectedIndex = (ProcessesContain ? 0 : 1);
            Controls.Add(m_cbProcessesContain);
        }

        public override bool GetResult()
        {
            Process[] p = Process.GetProcesses();
            bool contains = false;
            for (int i = 0; i < p.Length && !contains; i++)
            {
                contains = p[i].ProcessName == m_cbProcessname.Text;
            }
            return contains == (m_cbProcessesContain.SelectedIndex == 0);
        }

        public override string GetText()
        {
            return "Prozess \"" + m_cbProcessname.Text + "\" " + m_cbProcessesContain.Text;
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"conditionProcessName\",";
            strReturn += "\"processName\": \"" + m_cbProcessname.Text + "\",";
            strReturn += "\"processesContain\": " + (m_cbProcessesContain.SelectedIndex == 0 ? "true" : "false");
            strReturn += "}";
            return strReturn;
        }
    }
}
