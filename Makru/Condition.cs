using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public abstract class Condition : UserControl
    {
        public delegate void OnConditionChangedEvent(object sender, ConditionChangedArgs e);

        public abstract event OnConditionChangedEvent OnConditionChanged;

        public abstract bool GetResult();

        public abstract string GetText();

        public abstract string JSON();
    }


    public class ConditionChangedArgs : EventArgs
    {
        // Eigenschaften, die uns in diesem Beispiel interessiere.
        // Können nach Bedarf erweitert werden.

        // Konstruktor mit den Standard-Parametern, die wir als Pflicht ansehen
        public ConditionChangedArgs()
        {
        }
    }
}
