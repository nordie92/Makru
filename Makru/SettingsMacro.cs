using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makru
{
    public class SettingsMacro
    {
        private int m_moveClickDelay = 30;
        public int MoveClickDelay
        {
            get
            {
                return m_moveClickDelay;
            }
            set
            {
                m_moveClickDelay = value;
            }
        }
        private bool m_mouseMoveInterpolation = true;
        public bool MouseMoveInterpolationActive
        {
            get
            {
                return m_mouseMoveInterpolation;
            }
            set
            {
                m_mouseMoveInterpolation = value;
            }
        }
        private int m_mouseMoveInterpolationSteps = 30;
        public int MouseMoveInterpolationInterval
        {
            get
            {
                return m_mouseMoveInterpolationSteps;
            }
            set
            {
                m_mouseMoveInterpolationSteps = value;
            }
        }
        private bool m_relativeMouseMove = false;
        public bool RelativeMouseMove
        {
            get
            {
                return m_relativeMouseMove;
            }
            set
            {
                m_relativeMouseMove = value;
            }
        }
        private bool m_waitCommandCompensation = true;
        public bool WaitCommandCompensation
        {
            get
            {
                return m_waitCommandCompensation;
            }
            set
            {
                m_waitCommandCompensation = value;
            }
        }

        public string JSON()
        {
            string retJSON = "";
            retJSON += "{";
            retJSON += "\"moveClickDelay\": " + MoveClickDelay + ",";
            retJSON += "\"mouseMoveInterpolation\": " + (MouseMoveInterpolationActive ? "true" : "false") + ",";
            retJSON += "\"mouseInterpolationSteps\": " + MouseMoveInterpolationInterval + ",";
            retJSON += "\"relativeMouseMove\": " + (RelativeMouseMove ? "true" : "false") + ",";
            retJSON += "\"waitCommandCompensation\": " + (WaitCommandCompensation ? "true" : "false");
            retJSON += "}";
            return retJSON;
        }

        public void ReadJSON(dynamic settings)
        {
            MoveClickDelay = (int)settings.moveClickDelay;
            MouseMoveInterpolationActive = (bool)settings.mouseMoveInterpolation;
            MouseMoveInterpolationInterval = (int)settings.mouseInterpolationSteps;
            RelativeMouseMove = (bool)settings.relativeMouseMove;
            WaitCommandCompensation = (bool)settings.waitCommandCompensation;
        }
    }
}
