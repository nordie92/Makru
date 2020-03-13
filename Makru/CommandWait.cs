using InputManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Makru
{
    class CommandWait : Command
    {
        private int m_duration;
        private Macro m_macro;
        public int Duration
        {
            set
            {
                Text = "Wait " + Math.Round((double)m_duration / 1000.0, 3) + "s";
                m_duration = value;
            }
            get
            {
                return m_duration;
            }
        }

        public CommandWait(int waitDuration, Macro macro)
        {
            Duration = waitDuration;

            Text = "Wait " + Math.Round((double)Duration / 1000.0, 3) + "s";
            ImageKey = "wait";
            SelectedImageKey = "wait";
            Name = "command";

            m_macro = macro;
        }

        private int CompensateDuration()
        {
            int waitTime = 0;
            if (m_macro.SettingsMacro.WaitCommandCompensation)
            {
                if (Duration - m_macro.LastTimeNeeded < 0)
                {
                    waitTime = 0;
                    m_macro.LastTimeNeeded = m_macro.LastTimeNeeded - Duration;
                }
                else
                {
                    waitTime = (int)((long)Duration - m_macro.LastTimeNeeded);
                    m_macro.LastTimeNeeded = 0;
                }
            }
            else
            {
                waitTime = Duration;
            }
            return waitTime;
        }

        public override void ExecuteCommand()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int duration = CompensateDuration();

            Macros.AddLog("Play: Wait for " + Duration + "(" + duration + ")ms");

            //create little steps between two mouse events/positions
            bool waitWithSteps = false;

            if (Index + 1 < Parent.Nodes.Count && Index - 1 >= 0 && m_macro.SettingsMacro.MouseMoveInterpolationActive)
            {
                Command cia1 = (Command)Parent.Nodes[Index - 1];
                Command cia2 = (Command)Parent.Nodes[Index + 1];

                if (cia1.GetType() == typeof(CommandInput) && cia2.GetType() == typeof(CommandInput))
                {
                    CommandInput ci1 = (CommandInput)cia1;
                    CommandInput ci2 = (CommandInput)cia2;

                    if ((ci1.InputType == CommandType.MouseDown || ci1.InputType == CommandType.MouseUp) &&
                        (ci2.InputType == CommandType.MouseDown || ci2.InputType == CommandType.MouseUp))
                    {
                        int calcTime = 0;

                        PointF p1 = new PointF(ci1.X, ci1.Y);
                        PointF p2 = new PointF(ci2.X, ci2.Y);
                        PointF pDelta = new PointF(
                            (ci2.X - ci1.X) / ((float)duration / (float)m_macro.SettingsMacro.MouseMoveInterpolationInterval),
                            (ci2.Y - ci1.Y) / ((float)duration / (float)m_macro.SettingsMacro.MouseMoveInterpolationInterval));
                        PointF pCurrent = new PointF(ci1.X, ci1.Y);

                        for (int j = 0; j < duration; j += m_macro.SettingsMacro.MouseMoveInterpolationInterval)
                        {
                            pCurrent.X += pDelta.X;
                            pCurrent.Y += pDelta.Y;

                            if (m_macro.SettingsMacro.RelativeMouseMove)
                            {
                                int relX = (int)(pCurrent.X) - m_macro.LastMousePosition.X;
                                int relY = (int)(pCurrent.Y) - m_macro.LastMousePosition.Y;

                                Mouse.MoveRelative(relX, relY);

                                m_macro.LastMousePosition = new Point((int)pCurrent.X, (int)pCurrent.Y);
                            }
                            else
                            {
                                Mouse.Move((int)pCurrent.X, (int)pCurrent.Y);
                            }

                            if (j == 0)
                                calcTime += duration % m_macro.SettingsMacro.MouseMoveInterpolationInterval;
                            else
                                calcTime += m_macro.SettingsMacro.MouseMoveInterpolationInterval;

                            Thread.Sleep(Math.Max(0, calcTime - (int)sw.ElapsedMilliseconds));
                        }
                        waitWithSteps = true;
                    }
                }
            }

            if (!waitWithSteps)
                Thread.Sleep(duration - (int)sw.ElapsedMilliseconds);
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{\"type\": \"wait\",";
            strReturn += "\"duration\": \"" + Duration + "\"}";
            return strReturn;
        }
    }
}
