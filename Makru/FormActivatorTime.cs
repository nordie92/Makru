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
    public partial class FormActivatorTime : Form
    {
        public DateTime TriggerTime { get; set; }
        public TimeSpan TriggerInterval { get; set; }
        private Macro m_macro;

        public FormActivatorTime(DateTime triggerTime, TimeSpan triggerInterval)
        {
            InitializeComponent();

            TriggerTime = triggerTime;
            TriggerInterval = triggerInterval;

            dtpTime.Value = TriggerTime;
            nudDays.Value = (decimal)triggerInterval.TotalDays;
            nudHours.Value = (decimal)triggerInterval.Hours;
            nudMinutes.Value = (decimal)triggerInterval.Minutes;
            nudSeconds.Value = (decimal)triggerInterval.Seconds;
        }

        private void FormActivatorTime_KeyDown(object sender, KeyEventArgs e)
        {
            TriggerTime = dtpTime.Value;
            TriggerInterval = new TimeSpan((int)nudDays.Value, (int)nudHours.Value, (int)nudMinutes.Value, (int)nudSeconds.Value);
            if (TriggerInterval.TotalSeconds == 0 || TriggerInterval.TotalSeconds >= 2)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Die Wiederholung muss mindestens alle 2 Sekunden stattfinden.", "Zeitaktivierung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TriggerTime = dtpTime.Value;
            TriggerInterval = new TimeSpan((int)nudDays.Value, (int)nudHours.Value, (int)nudMinutes.Value, (int)nudSeconds.Value);
            if (TriggerInterval.TotalSeconds == 0 || TriggerInterval.TotalSeconds >= 2)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Die Wiederholung muss mindestens alle 2 Sekunden stattfinden.", "Zeitaktivierung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
