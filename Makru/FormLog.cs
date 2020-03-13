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
    public partial class FormLog : Form
    {
        public static List<string> Logs;

        public FormLog()
        {
            InitializeComponent();

            Logs = new List<string>();
        }

        public void AddLog(string logText)
        {
            lock(FormLog.Logs)
            {
                Logs.Add(logText);
            }
        }

        private void timerReadLogs_Tick(object sender, EventArgs e)
        {
            lock (FormLog.Logs)
            {
                foreach (string log in Logs)
                {
                    rtbLog.Text = DateTime.Now.ToString("HH:mm:ss") + ": " + log + "\n" + rtbLog.Text;
                }
                Logs.Clear();
            }  
        }
    }
}
