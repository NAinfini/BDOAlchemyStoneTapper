using System.Drawing;

namespace Yolov7net
{
    public class YoloLabel
    {
        public int Id { get; set; }
        private string name;

        public string? Name
        {
            get { return name; }
            set
            {
                name = value;
                if (value.Equals("Imperfect") || value.Equals("Rough") || value.Equals("Polished") || value.Equals("Sharp") ||
                    value.Equals("Sturdy") || value.Equals("Resplendent") || value.Equals("Splendid") || value.Equals("Shining"))
                {
                    Color = Color.Red;
                }
                if (value.Equals("Material") || value.Equals("StrawBerry") || value.Equals("Purple"))
                {
                    Color = Color.Yellow;
                }
                if (value.Equals("BlackStone"))
                {
                    Color = Color.Purple;
                }
            }
        }

        public YoloLabelKind Kind { get; set; }

        public Color Color { get; set; }

        public YoloLabel() => Color = Color.White;
    }
}