using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Navigation;
using Yolov7net;
using static System.Formats.Asn1.AsnWriter;

namespace BDOAlchemyStoneTapper
{
    internal class ObjectDetection
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private Yolov8 yolo;

        public ObjectDetection(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public ObjectDetection(string typeOfStone)
        {
            yolo = new Yolov7net.Yolov8("./" + typeOfStone + ".onnx", false);
            string[] DestructionLabels = new string[10]
            {
                 "BlackStone", "Imperfect", "Material", "Polished", "Resplendent", "Rough", "Sharp", "Shining", "Splendid", "Sturdy"
            };
            string[] LifeLabels = new string[11]
            {
                  "BlackStone", "Imperfect", "Polished", "Purple", "Resplendent", "Rough", "Sharp", "Shining", "Splendid", "StrawBerry", "Sturdy"
            };
            if (typeOfStone.Equals("Destruction") || typeOfStone.Equals("Protection"))
            {
                yolo.SetupLabels(DestructionLabels);
            }
            else if (typeOfStone.Equals("Life"))
            {
                yolo.SetupLabels(LifeLabels);
            }
            else
            {
                throw new Exception();
            }
            // use custom trained model should use your labels like: yolo.SetupLabels(string[] labels)
        }

        public Bitmap drawRectangles(Bitmap image, List<YoloPrediction> predictions)
        {
            using (Graphics graphics = Graphics.FromImage(image))
            {
                foreach (var prediction in predictions) // iterate predictions to draw results
                {
                    double score = Math.Round(prediction.Score, 2);

                    graphics.DrawRectangles(new Pen(prediction.Label.Color, 1), new[] { prediction.Rectangle });
                    var (x, y) = (prediction.Rectangle.X - 3, prediction.Rectangle.Y - 23);
                    graphics.DrawString($"{prediction.Label.Name}  {score}",
                                    new System.Drawing.Font("Consolas", 15, GraphicsUnit.Pixel), new SolidBrush(prediction.Label.Color),
                                    new System.Drawing.PointF(x, y));
                }
            }
            return image;
        }

        public Bitmap drawRectangles(Bitmap image, Dictionary<string, RectangleF> recs)
        {
            using (Graphics graphics = Graphics.FromImage(image))
            {
                foreach (var prediction in recs) // iterate predictions to draw results
                {
                    graphics.DrawRectangles(new Pen(Color.Red, 1), new[] { prediction.Value });
                    var (x, y) = (prediction.Value.X - 3, prediction.Value.Y - 23);
                    graphics.DrawString(prediction.Key,
                                    new System.Drawing.Font("Consolas", 15, GraphicsUnit.Pixel), new SolidBrush(Color.Red),
                                    new System.Drawing.PointF(x, y));
                }
            }
            return image;
        }

        public Dictionary<string, List<System.Drawing.RectangleF>> getPositions(List<YoloPrediction> predictions)
        {
            Dictionary<string, List<System.Drawing.RectangleF>> returnList = new Dictionary<string, List<System.Drawing.RectangleF>>();
            foreach (var prediction in predictions) // iterate predictions to draw results
            {
                if (!returnList.TryGetValue(prediction.Label.Name, out List<System.Drawing.RectangleF> tempList))
                {
                    tempList = new List<System.Drawing.RectangleF>(); // Create a new list for each label
                    returnList.Add(prediction.Label.Name, tempList);
                }

                tempList.Add(prediction.Rectangle);
            }
            return returnList;
        }

        public List<YoloPrediction> getPerdictions(Bitmap image)
        {
            return yolo.Predict(image);
        }
    }
}