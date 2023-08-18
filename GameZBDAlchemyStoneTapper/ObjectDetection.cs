using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace GameZBDAlchemyStoneTapper
{
    class ObjectDetection
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private Bitmap processedBitmap;
        public ObjectDetection(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public Bitmap GetBitmap()
        {
            return processedBitmap;
        }
        public void Starter()
        {

        }
    }
}
