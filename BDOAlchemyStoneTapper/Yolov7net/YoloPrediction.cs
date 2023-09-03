﻿using System.Drawing;

namespace Yolov7net
{
    public class YoloPrediction
    {
        public YoloLabel? Label { get; set; }

        public RectangleF Rectangle { get; set; }
        
        public float Score { get; set; }

        public YoloPrediction() { }

        public YoloPrediction(YoloLabel label, float confidence) : this(label)
        {
            Score = confidence;
        }

        public YoloPrediction(YoloLabel label)
        {
            Label = label;
        }
    }
}
