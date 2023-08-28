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
                if (value.EndsWith('D'))
                {
                    Color = Color.Purple;
                }
                if (value.EndsWith('P'))
                {
                    Color = Color.Yellow;
                }
                if (value.EndsWith('L'))
                {
                    Color = Color.Green;
                }
                if (value.Equals("Copper") || value.Equals("Iron") || value.Equals("Lead") || value.Equals("Tin") ||
                    value.Equals("Titanium") || value.Equals("Vanadium") || value.Equals("Zinc"))
                {
                    Color = Color.Purple;
                }
                if (value.Equals("Acacia") || value.Equals("Ash") || value.Equals("Birch") || value.Equals("Cedar") ||
                    value.Equals("Maple") || value.Equals("Palm") || value.Equals("Pine"))
                {
                    Color = Color.Yellow;
                }
                if (value.Equals("Arrow") || value.Equals("Cloud") || value.Equals("Grape") || value.Equals("Purple") ||
                    value.Equals("StrawBerry") || value.Equals("Ghost") || value.Equals("Sunflower"))
                {
                    Color = Color.Green;
                }
            }
        }

        public YoloLabelKind Kind { get; set; }

        public Color Color { get; set; }

        public YoloLabel() => Color = Color.White;
    }
}