using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    class Activators : Command
    {
        public Activators()
        {
            Text = "Aktivierung";
            ImageKey = "activator";
            SelectedImageKey = "activator";
            Name = "activators";
        }

        public override void ExecuteCommand()
        {
            //nothing to execute
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "\"activators\": [";
            //ToDo: HIER WEITER
            strReturn += "]";
            return strReturn;
        }
    }
}
