using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    class CommandCondition : Command
    {
        public CommandCondition()
        {
            Text = "WennDannSonst";
            Name = "command";
            ImageIndex = 7;
            SelectedImageIndex = 7;

            TreeNode tn1 = new TreeNode("Wenn...");
            tn1.ImageIndex = 7;
            tn1.SelectedImageIndex = 7;
            tn1.Name = "conditions";
            Nodes.Add(tn1);

            TreeNode tn2 = new TreeNode("Dann...");
            tn2.ImageIndex = 3;
            tn2.SelectedImageIndex = 3;
            tn2.Name = "commands";
            Nodes.Add(tn2);

            TreeNode tn3 = new TreeNode("Sonst...");
            tn3.ImageIndex = 3;
            tn3.SelectedImageIndex = 3;
            tn3.Name = "commands";
            Nodes.Add(tn3);
        }

        public override void ExecuteCommand()
        {
            bool conditionsResult = true;

            for (int i = 0; i < Nodes[0].Nodes.Count && conditionsResult; i++)
            {
                conditionsResult = (Nodes[0].Nodes[i] as ConditionNode).Condition.GetResult();
            }

            if (conditionsResult)
            {
                Macros.AddLog("Play: \"Wenn...Dann...Sonst\" ist TRUE");

                foreach (Command cmd in Nodes[1].Nodes)
                {
                    cmd.ExecuteCommand();
                }
            }
            else
            {
                Macros.AddLog("Play: \"Wenn...Dann...Sonst\" ist FALSE");

                foreach (Command cmd in Nodes[2].Nodes)
                {
                    cmd.ExecuteCommand();
                }
            }
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{\"type\": \"condition\",";

            //add conditions
            strReturn += "\"conditions\": [";
            bool firstItem = true;
            foreach (ConditionNode conditionNode in Nodes[0].Nodes)
            {
                strReturn += (firstItem ? "" : ",") + conditionNode.Condition.JSON();
                firstItem = false;
            }
            strReturn += "],";

            //add then commands
            strReturn += "\"thenCommands\": [";
            firstItem = true;
            foreach (TreeNode tn in Nodes[1].Nodes)
            {
                strReturn += (firstItem ? "" : ",") + (tn as Command).JSON();
                firstItem = false;
            }
            strReturn += "],";

            //add else commands
            strReturn += "\"elseCommands\": [";
            firstItem = true;
            foreach (TreeNode tn in Nodes[2].Nodes)
            {
                strReturn += (firstItem ? "" : ",") + (tn as Command).JSON();
                firstItem = false;
            }
            strReturn += "]}";

            return strReturn;
        }
    }
}
