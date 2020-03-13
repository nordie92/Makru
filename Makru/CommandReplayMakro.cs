using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makru
{
    public class CommandReplayMakro : Command
    {
        private string m_macroName = "";
        public string MacroName
        {
            get
            {
                return m_macroName;
            }
            set
            {
                m_macroName = value;
                Text = "Replay macro \"" + value + "\"";
            }
        }
        private Macro m_macro;

        public CommandReplayMakro(string macroName, Macro macro)
        {
            m_macroName = macroName;
            m_macro = macro;

            Text = "Replay macro \"" + macroName + "\"";
            ImageKey = "makro";
            SelectedImageKey = "makro";
            Name = "command";
        }

        private Macro FindMacroByName(List<Macro> macros)
        {
            Macro returnMacro = null;
            for (int i = 0; i < macros.Count && returnMacro == null; i++)
            {
                if (macros[i].Text == m_macroName)
                {
                    returnMacro = macros[i];
                }
            }
            return returnMacro;
        }

        public override void ExecuteCommand()
        {
            List<Macro> macros = (m_macro.TreeView as Macros).GetAllMacros();
            m_macro = FindMacroByName(macros);

            Macros.AddLog("Play: Playback Makro: \"" + m_macroName + "\"");

            m_macro.PlaybackMacro(false);

            Macros.AddLog("Play: Finish Makro: \"" + m_macroName + "\"");
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{\"type\": \"replayMacro\",";
            strReturn += "\"name\": \"" + m_macroName + "\"}";
            return strReturn;
        }
    }
}
