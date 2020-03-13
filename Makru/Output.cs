using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public abstract class Output : UserControl
    {
        public abstract Variable GetOutput();

        public abstract string GetText();

        public abstract string JSON();
    }
}
