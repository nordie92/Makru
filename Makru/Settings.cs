using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makru
{
    public class Settings
    {
        private float m_screenshootsPerSecond = 2;
        public float ScreenshootsPerSecond
        {
            get
            {
                return m_screenshootsPerSecond;
            }
            set
            {
                m_screenshootsPerSecond = value;
            }
        }
        private bool m_startProgramMinimzed = false;
        public bool StartProgramMinimzed
        {
            get
            {
                return m_startProgramMinimzed;
            }
            set
            {
                m_startProgramMinimzed = value;
            }
        }
        private bool m_minimizeProgrammOnClose = false;
        public bool MinimizeProgrammOnClose
        {
            get
            {
                return m_minimizeProgrammOnClose;
            }
            set
            {
                m_minimizeProgrammOnClose = value;
            }
        }

        public string JSON()
        {
            string retJSON = "";
            retJSON += "{";
            retJSON += "\"screenshootsPerSecond\": " + ScreenshootsPerSecond.ToString().Replace(",", ".") + ",";
            retJSON += "\"startProgramMinimzed\": " + (StartProgramMinimzed ? "true" : "false") + ",";
            retJSON += "\"minimizeProgrammOnClose\": " + (MinimizeProgrammOnClose ? "true" : "false");
            retJSON += "}";
            return retJSON;
        }

        public void ReadJSON(dynamic settings)
        {
            ScreenshootsPerSecond = (float)settings.screenshootsPerSecond;
            StartProgramMinimzed = (bool)settings.startProgramMinimzed;
            MinimizeProgrammOnClose = (bool)settings.minimizeProgrammOnClose;
        }
    }
}
