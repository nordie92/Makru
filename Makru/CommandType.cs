using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makru
{
    public enum CommandType
    {
        KeyDown,
        KeyUp,
        MouseDown,
        MouseUp,
        MouseMove,
        MouseWheel,
        StartProgramm,
        TakeScreenshoot,
        Wait
    }
}
