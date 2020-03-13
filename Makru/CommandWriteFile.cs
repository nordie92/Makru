using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makru
{
    class CommandWriteFile : Command
    {
        public string FileName { get; internal set; }
        public string FileText { get; internal set; }
        public bool AppendFile { get; internal set; }
        private Macro m_macro;

        public CommandWriteFile(Macro macro)
        {
            m_macro = macro;

            Text = "Schreibe Datei (Keine)";

            ImageKey = "writeFile";
            SelectedImageKey = "writeFile";
            Name = "command";
        }

        public CommandWriteFile(string fileName, string text, bool append, Macro macro)
        {
            FileName = fileName;
            FileText = text;
            AppendFile = append;
            m_macro = macro;

            if (FileName != null)
            {
                string[] fileNameSplit = FileName.Split('\\');
                Text = "Schreibe Datei \"" + fileNameSplit[fileNameSplit.Length - 1] + "\"";
            }
            else
            {
                Text = "Schreibe Datei (Keine)";
            }

            ImageKey = "writeFile";
            SelectedImageKey = "writeFile";
            Name = "command";
        }

        public override void ExecuteCommand()
        {
            StreamWriter sw = new StreamWriter(FileName, AppendFile);

            string text = FileText;
            //replace variables
            foreach (Variable v in m_macro.Variables)
                text = text.Replace("{$" + v.Name + "}", v.Value);
            //replace static variables
            DateTime dt = DateTime.Now;
            text = text.Replace("{§yy}", dt.ToString("yy"));
            text = text.Replace("{§yyyy}", dt.ToString("yyyy"));
            text = text.Replace("{§M}", dt.ToString("M"));
            text = text.Replace("{§MM}", dt.ToString("MM"));
            text = text.Replace("{§MMMM}", dt.ToString("MMMM"));
            text = text.Replace("{§d}", dt.ToString("d"));
            text = text.Replace("{§dd}", dt.ToString("dd"));
            text = text.Replace("{§dddd}", dt.ToString("dddd"));
            text = text.Replace("{§hh}", dt.ToString("hh"));
            text = text.Replace("{§HH}", dt.ToString("HH"));
            text = text.Replace("{§m}", dt.ToString("m"));
            text = text.Replace("{§mm}", dt.ToString("mm"));
            text = text.Replace("{§M}", dt.ToString("M"));
            text = text.Replace("{§MM}", dt.ToString("MM"));
            text = text.Replace("{§s}", dt.ToString("s"));
            text = text.Replace("{§ss}", dt.ToString("ss"));
            text = text.Replace("{§f}", dt.ToString("f"));
            text = text.Replace("{§ff}", dt.ToString("ff"));
            text = text.Replace("{§fff}", dt.ToString("fff"));
            text = text.Replace("{§ffff}", dt.ToString("ffff"));
            text = text.Replace("{§F}", dt.ToString("F"));
            text = text.Replace("{§FF}", dt.ToString("FF"));
            text = text.Replace("{§FFF}", dt.ToString("FFF"));
            text = text.Replace("{§FFFF}", dt.ToString("FFFF"));
            sw.Write(text);

            sw.Close();

            string[] fileNameSplit = FileName.Split('\\');
            Macros.AddLog("Play: Schreibe in Datei \"" + fileNameSplit[fileNameSplit.Length - 1] + "\"");
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"writeFile\",";
            strReturn += "\"fileName\": \"" + FileName.Replace("\\", "\\\\") + "\",";
            strReturn += "\"appendFile\": " + (AppendFile ? "true" : "false") + ",";
            strReturn += "\"text\": \"" + FileText.Replace("\"", "\\\"") + "\"";
            strReturn += "}";
            return strReturn;
        }
    }
}
