using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public partial class FormConditionProcessIsRunning : Form
    {
        public FormConditionProcessIsRunning()
        {
            InitializeComponent();

            foreach (Process p in Process.GetProcesses())
                if (!cbProcessName.Items.Contains(p.ProcessName))
                    cbProcessName.Items.Add(p.ProcessName);
        }
    }
}
