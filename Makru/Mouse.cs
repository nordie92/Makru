using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Makru
{
    //class Mouse
    //{
    //    [DllImport("user32.dll")]
    //    public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
    //    public const int MOUSEEVENTF_LEFTDOWN = 0x02;
    //    public const int MOUSEEVENTF_LEFTUP = 0x04;
    //    private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
    //    private const int MOUSEEVENTF_RIGHTUP = 0x0010;

    //    [DllImport("user32.dll")]
    //    static extern bool SetCursorPos(int X, int Y);

    //    public static void MouseDown(int x, int y, bool rightButton)
    //    {
    //        SetCursorPos(x, y);
    //        if (rightButton)
    //        {
    //            mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
    //        }
    //        else
    //        {
    //            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
    //        }
    //    }

    //    public static void MouseUp(int x, int y, bool rightButton)
    //    {
    //        SetCursorPos(x, y);
    //        if (rightButton)
    //        {
    //            mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
    //        }
    //        else
    //        {
    //            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
    //        }
    //    }
    //}
}
