using Compunet.YoloV8;
using Compunet.YoloV8.Plotting;
using IronSoftware.Drawing;
using SixLabors.ImageSharp;
using System.Drawing;
using System.IO;

namespace GameZBDAlchemyStoneTapper
{
    internal class ObjectDetection
    {
        private int x;
        private int y;
        private int width;
        private int height;

        public ObjectDetection(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public ObjectDetection()
        {
        }

        public Bitmap Starter(AnyBitmap image)
        {
            using SixLabors.ImageSharp.Image sharpImage = image;
            using var predictor = new YoloV8("./yolov8s.onnx");
            var result = predictor.Pose(sharpImage);
            using var origin = sharpImage;
            using AnyBitmap ploted = result.PlotImage(origin);
            return ploted.ToBitmap<Bitmap>();
        }
    }
}