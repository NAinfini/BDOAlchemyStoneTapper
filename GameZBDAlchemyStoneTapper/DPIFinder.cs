using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameZBDAlchemyStoneTapper
{
    internal class DPIFinder
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;

            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;

            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

        public static double FindDPI(Screen screen)
        {
            DEVMODE dm = new DEVMODE();
            dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            EnumDisplaySettings(screen.DeviceName, -1, ref dm);
            return Math.Round((double)dm.dmPelsWidth / screen.Bounds.Width, 2);
        }

        public static double FindDPIScaleOnPoint(Point pt)
        {
            Screen screen = Screen.FromPoint(pt);
            DEVMODE dm = new DEVMODE();
            dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            EnumDisplaySettings(screen.DeviceName, -1, ref dm);
            return Math.Round((double)dm.dmPelsWidth / screen.Bounds.Width, 2);
        }

        public static Point ScaledToPhysical(Point pt)
        {
            double DPI = FindDPIScaleOnPoint(new Point(pt.X, pt.Y));
            int Xi = Convert.ToInt32(pt.X / DPI);
            int Yi = Convert.ToInt32(pt.Y / DPI);
            return new Point(Xi, Yi);
        }

        public static Point PhysicalToScaled(Point pt)
        {
            double DPI = FindDPIScaleOnPoint(new Point(pt.X, pt.Y));
            int Xi = Convert.ToInt32(pt.X / DPI);
            int Yi = Convert.ToInt32(pt.Y / DPI);
            return new Point(Xi, Yi);
        }

        public static Rectangle ScaledToPhysical(Rectangle rec)
        {
            double DPI = DPIFinder.FindDPIScaleOnPoint(new Point(rec.X, rec.Y));
            int X = Convert.ToInt32(rec.X * DPI);
            int Y = Convert.ToInt32(rec.Y * DPI);
            int width = Convert.ToInt32(rec.Width * DPI);
            int height = Convert.ToInt32(rec.Height * DPI);
            return new Rectangle(X, Y, width, height);
        }

        public static Rectangle PhysicalToScaled(Rectangle rec)
        {
            double DPI = DPIFinder.FindDPIScaleOnPoint(new Point(rec.X, rec.Y));
            int X = Convert.ToInt32(rec.X * DPI);
            int Y = Convert.ToInt32(rec.Y * DPI);
            int width = Convert.ToInt32(rec.Width / DPI);
            int height = Convert.ToInt32(rec.Height / DPI);
            return new Rectangle(X, Y, width, height);
        }
    }
}