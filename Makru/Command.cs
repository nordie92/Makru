using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public abstract class Command : TreeNode
    {
        public Command()
        {
            ImageKey = "command";
            SelectedImageKey = "command";
            Name = "command";
        }

        public abstract void ExecuteCommand();

        public abstract string JSON();
    }
}
