using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Yolov8Net;

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

        public void Starter()
        {
            using var yolo = YoloV8Predictor.Create("./assets/yolov8m.onnx");

            // Provide an input image.  Image will be resized to model input if needed.
            using Image image = Image.FromFile("Assets/rufus.jpg");

            ImageConverter imageConverter = new ImageConverter();
            SixLabors.ImageSharp.Image sharpImage = (SixLabors.ImageSharp.Image)imageConverter.ConvertTo(image, typeof(SixLabors.ImageSharp.Image));
            var predictions = yolo.Predict(sharpImage);

            foreach (var pred in predictions)
            {
                var originalImageHeight = image.Height;
                var originalImageWidth = image.Width;

                var x = Math.Max(pred.Rectangle.X, 0);
                var y = Math.Max(pred.Rectangle.Y, 0);
                var width = Math.Min(originalImageWidth - x, pred.Rectangle.Width);
                var height = Math.Min(originalImageHeight - y, pred.Rectangle.Height);

                ////////////////////////////////////////////////////////////////////////////////////////////
                // *** Note that the output is already scaled to the original image height and width. ***
                ////////////////////////////////////////////////////////////////////////////////////////////

                // Bounding Box Text
                string text = $"{pred.Label.Name} [{pred.Score}]";

                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    // Define Text Options
                    Font drawFont = new Font("consolas", 11, FontStyle.Regular);
                    SizeF size = graphics.MeasureString(text, drawFont);
                    SolidBrush fontBrush = new SolidBrush(System.Drawing.Color.Black);
                    Point atPoint = new Point((int)x, (int)y - (int)size.Height - 1);

                    // Define BoundingBox options
                    System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Yellow, 2.0f);
                    SolidBrush colorBrush = new SolidBrush(System.Drawing.Color.Yellow);

                    // Draw text on image
                    graphics.FillRectangle(colorBrush, (int)x, (int)(y - size.Height - 1), (int)size.Width, (int)size.Height);
                    graphics.DrawString(text, drawFont, fontBrush, atPoint);

                    // Draw bounding box on image
                    graphics.DrawRectangle(pen, x, y, width, height);
                }
            }
        }
    }
}