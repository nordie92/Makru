using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    class ActivatorTime : Activator
    {
        private DateTime m_triggerTime;
        public DateTime TriggerTime
        {
            get
            {
                return m_triggerTime;
            }
            set
            {
                m_triggerTime = value;
                Text = "Ausführung um \"" + TriggerTime.ToString("HH:mm:ss") + "\"" + (TriggerInterval.TotalSeconds > 0 ? " + Interval" : "");

                if (TriggerTime.TimeOfDay >= DateTime.Now.TimeOfDay || TriggerInterval.TotalSeconds > 0)
                {
                    m_timer = new System.Threading.Timer(
                    timerTick,
                    null,
                    Math.Max(2000, (int)(TriggerTime.TimeOfDay - DateTime.Now.TimeOfDay).TotalMilliseconds),
                    (int)TriggerInterval.TotalMilliseconds);
                }
            }
        }
        private TimeSpan m_triggerInterval;
        public TimeSpan TriggerInterval
        {
            get
            {
                return m_triggerInterval;
            }
            set
            {
                m_triggerInterval = value;
                Text = "Ausführung um \"" + TriggerTime.ToString("HH:mm:ss") + "\"" + (TriggerInterval.TotalSeconds > 0 ? " + Interval" : "");

                if (TriggerTime.TimeOfDay >= DateTime.Now.TimeOfDay || TriggerInterval.TotalSeconds > 0)
                {
                    m_timer = new System.Threading.Timer(
                        timerTick,
                        null,
                        Math.Max(2000, (int)(TriggerTime.TimeOfDay - DateTime.Now.TimeOfDay).TotalMilliseconds),
                        (int)TriggerInterval.TotalMilliseconds);
                }
            }
        }
        private System.Threading.Timer m_timer;
        private Macro m_macro;

        public ActivatorTime(DateTime triggerTime, TimeSpan triggerInterval, Macro macro)
        {
            m_macro = macro;
            TriggerTime = triggerTime;
            TriggerInterval = triggerInterval;

            if (TriggerTime.TimeOfDay >= DateTime.Now.TimeOfDay || TriggerInterval.TotalSeconds > 0)
            {
                m_timer = new System.Threading.Timer(
                timerTick,
                null,
                Math.Max(2000, (int)(TriggerTime.TimeOfDay - DateTime.Now.TimeOfDay).TotalMilliseconds),
                (int)TriggerInterval.TotalMilliseconds);
            }

            Text = "Ausführung um \"" + TriggerTime.ToString("HH:mm:ss") + "\"" + (TriggerInterval.TotalSeconds > 0 ? " + Interval" : "");
            ImageKey = "clock";
            SelectedImageKey = "clock";
            Name = "activator";
        }

        public static void CancelTimers(TreeNode rootNode)
        {
            if (rootNode.GetType() == typeof(ActivatorTime))
            {
                if ((rootNode as ActivatorTime).m_timer != null)
                {
                    (rootNode as ActivatorTime).m_timer.Change(Timeout.Infinite, Timeout.Infinite);
                }
            }
            else
            {
                foreach (TreeNode tn2 in rootNode.Nodes)
                {
                    CancelTimers(tn2);
                }
            }
        }

        private void timerTick(object state)
        {
            m_macro.StartReplayThread(false);
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"activatorTime\",";
            strReturn += "\"time\": \"" + TriggerTime.ToString("HH:mm:ss") + "\",";
            strReturn += "\"interval\": \"" + TriggerInterval.ToString("dd':'hh':'mm':'ss") + "\"";
            strReturn += "}";
            return strReturn;
        }
    }
}
