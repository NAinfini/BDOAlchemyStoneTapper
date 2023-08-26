using IronSoftware.Drawing;
using SixLabors.ImageSharp;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Navigation;
using Yolov7net;

namespace GameZBDAlchemyStoneTapper
{
    internal class ObjectDetection
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private Yolov8 yolo;
        private List<string> selectedAlchemyStone = new List<string>();
        private List<string> selectedMaterial = new List<string>();

        public ObjectDetection(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public ObjectDetection()
        {
            yolo = new Yolov7net.Yolov8("./best.onnx", false);
            // setup labels of onnx model
            string[] labels = new string[46]
            {
                    "0:Acacia","Arrow","Ash","Birch","Cedar","Cloud","Copper","Ghost","Gold","Grape","ImperfectD","ImperfectL","ImperfectP",
                    "Iron","Lead","Maple","Palm","Pine","PolishedD","PolishedL","PolishedP","Purple", "ResplendentD", "ResplendentL",
                    "ResplendentP","RoughD","RoughL","RoughP","SharpD","SharpL", "SharpP", "ShiningD", "ShiningL", "ShiningP","SplendidD",
                    "SplendidL","SplendidP","StrawBerry","SturdyD", "SturdyL", "SturdyP", "Sunflower",  "Tin","Titanium", "Vanadium", "Zinc"
            };
            yolo.SetupLabels(labels);   // use custom trained model should use your labels like: yolo.SetupLabels(string[] labels)
        }

        public void loadLists(List<string> stoneList, List<string> matList)
        {
            selectedAlchemyStone = stoneList;
            selectedMaterial = matList;
        }

        public Bitmap drawRectangles(Bitmap image, List<YoloPrediction> predictions)
        {
            using (Graphics graphics = Graphics.FromImage(image))
            {
                foreach (var prediction in predictions) // iterate predictions to draw results
                {
                    double score = Math.Round(prediction.Score, 2);
                    graphics.DrawRectangles(new Pen(System.Drawing.Color.Red, 1), new[] { prediction.Rectangle });
                    var (x, y) = (prediction.Rectangle.X - 3, prediction.Rectangle.Y - 23);
                    graphics.DrawString($"{prediction.Label.Name}  {score}",
                                    new System.Drawing.Font("Consolas", 10, GraphicsUnit.Pixel), new SolidBrush(System.Drawing.Color.Red),
                                    new System.Drawing.PointF(x, y));
                }
            }
            image.Save("./temp.png");
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