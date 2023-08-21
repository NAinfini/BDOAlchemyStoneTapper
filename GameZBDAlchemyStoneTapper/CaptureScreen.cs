using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameZBDAlchemyStoneTapper
{
    public class CaptureScreen
    {
        public static List<Bitmap> TakeAllScreens()
        {
            List<Bitmap> result = new List<Bitmap>();
            foreach (Screen screen in Screen.AllScreens)
            {
                result.Add(TakeScreenShot(screen));
            }
            return result;
        }

        public static Bitmap TakeScreenShot(Screen screen)
        {
            double DPI = DPIFinder.FindDPI(screen);
            int X = Convert.ToInt32(screen.Bounds.X * DPI);
            int Y = Convert.ToInt32(screen.Bounds.Y * DPI);
            int width = Convert.ToInt32(screen.Bounds.Width * DPI);
            int height = Convert.ToInt32(screen.Bounds.Height * DPI);
            Rectangle captureRectangle = new Rectangle(X, Y, width, height);
            Bitmap captureBitmap = new Bitmap(captureRectangle.Width, captureRectangle.Height, PixelFormat.Format32bppArgb);
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            return captureBitmap;
        }

        public static Bitmap Snip(int Xi, int Yi, int widthi, int heighti)
        {
            double DPI = DPIFinder.FindDPIOnPoint(new Point(Xi, Yi));
            int X = Convert.ToInt32(Xi * DPI);
            int Y = Convert.ToInt32(Yi * DPI);
            int width = Convert.ToInt32(widthi * DPI);
            int height = Convert.ToInt32(heighti * DPI);
            Rectangle captureRectangle = new Rectangle(X, Y, width, height);
            Bitmap captureBitmap = new Bitmap(captureRectangle.Width, captureRectangle.Height, PixelFormat.Format32bppArgb);
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            captureGraphics.Dispose();
            return captureBitmap;
        }

        public static void SnipToFIle(int Xi, int Yi, int widthi, int heighti, string fileName)
        {
            double DPI = DPIFinder.FindDPIOnPoint(new Point(Xi, Yi));
            int X = Convert.ToInt32(Xi * DPI);
            int Y = Convert.ToInt32(Yi * DPI);
            int width = Convert.ToInt32(widthi * DPI);
            int height = Convert.ToInt32(heighti * DPI);
            Rectangle captureRectangle = new Rectangle(X, Y, width, height);
            Bitmap captureBitmap = new Bitmap(captureRectangle.Width, captureRectangle.Height, PixelFormat.Format32bppArgb);
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            captureBitmap.Save(fileName, ImageFormat.Png);
            captureBitmap.Dispose();
            captureGraphics.Dispose();
        }
    }
}