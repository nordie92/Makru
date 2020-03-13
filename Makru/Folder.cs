using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    [Serializable]
    class Folder : TreeNode
    {
        public Folder(string name)
        {
            Text = name;
            ImageKey = "folder";
            SelectedImageKey = "folder";
            Name = "folder";
        }

        public string JSON()
        {
            bool firstItem = true;
            string strReturn = "";
            strReturn += "{\"type\": \"folder\",";
            strReturn += "\"name\": \"" + Text + "\",";
            strReturn += "\"children\": [";
            foreach (TreeNode node in Nodes)
            {
                if (node.GetType() == typeof(Folder))
                {
                    strReturn += (firstItem ? "" : ",") + (node as Folder).JSON();
                }
                else if (node.GetType() == typeof(Macro))
                {
                    strReturn += (firstItem ? "" : ",") + (node as Macro).JSON();
                }
                firstItem = false;
            }
            strReturn += "]}";
            return strReturn;
        }

        public void ReadJSON(dynamic json)
        {
            foreach (dynamic d in json.children)
            {
                if (d.type == "folder")
                {
                    Folder f = new Folder(d.name);
                    Nodes.Add(f);
                    f.ReadJSON(d);
                }
                else if (d.type == "macro")
                {
                    Macro m = new Macro(d.name);
                    Nodes.Add(m);
                    m.ReadJSON(d);
                }
            }
        }
    }
}
