using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public class Commands : TreeNode
    {
        public Macro Macro { get; }

        public Commands(Macro macro)
        {
            Text = "Befehle";
            ImageKey = "command";
            SelectedImageKey = "command";
            Name = "commands";

            Macro = macro;
        }
    }
}
