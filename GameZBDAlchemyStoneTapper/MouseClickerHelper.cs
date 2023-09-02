using GregsStack.InputSimulatorStandard;
using NumSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GameZBDAlchemyStoneTapper.InputSender;

namespace GameZBDAlchemyStoneTapper
{
    internal class MouseClickHelper
    {
        private static InputSimulator Ins = new InputSimulator();

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy,
                      int dwData, int dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern void SetCursorPos(int X, int Y);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        public static void LeftClick(int x, int y)
        {
            SetCursorPos(x, y);
            Thread.Sleep(50);
            Ins.Mouse.LeftButtonDown();
            Thread.Sleep(50);
            Ins.Mouse.LeftButtonUp();
        }

        public static void LeftClick(Point pt)
        {
            SetCursorPos(pt.X, pt.Y);
            Thread.Sleep(50);
            Ins.Mouse.LeftButtonDown();
            Thread.Sleep(50);
            Ins.Mouse.LeftButtonUp();
        }

        public static void RightClick(int x, int y)
        {
            SetCursorPos(x, y);
            Thread.Sleep(50);
            Ins.Mouse.RightButtonDown();
            Thread.Sleep(50);
            Ins.Mouse.RightButtonUp();
        }

        public static void RightClick(Point pt)
        {
            SetCursorPos(pt.X, pt.Y);
            Thread.Sleep(50);
            Ins.Mouse.RightButtonDown();
            Thread.Sleep(50);
            Ins.Mouse.RightButtonUp();
        }

        public static void PressSpace()
        {
            Ins.Keyboard.KeyPress(GregsStack.InputSimulatorStandard.Native.VirtualKeyCode.SPACE);
        }

        public static void PressEnter()
        {
            Ins.Keyboard.KeyPress(GregsStack.InputSimulatorStandard.Native.VirtualKeyCode.EXECUTE);
        }
    }
}