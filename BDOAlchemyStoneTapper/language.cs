﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace BDOAlchemyStoneTapper
{
    public class language
    {
        private static language instance = null;
        private static readonly object padlock = new object();

        public language()
        {
        }

        public static language Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new language();
                    }
                    return instance;
                }
            }
        }

        public static void CopyToStatic(language other)
        {
            instance = other;
        }

<<<<<<< HEAD
        public string ProjectName { get; set; }
        public string SOP { get; set; }
        public string SOD { get; set; }
        public string SOL { get; set; }
        public string UpgreadeFollowing { get; set; }
        public string WithFollowingMaterials { get; set; }
        public string Start { get; set; }
        public string Stop { get; set; }
        public string Select { get; set; }
        public string DetectionName { get; set; }
        public string PolishOnceBtn { get; set; }
        public string GrowOnceBtn { get; set; }
        public string PolishGrowBtn { get; set; }
        public string NoMaterialErr { get; set; }
        public string OnlyNumberErr { get; set; }
        public string DelayShort { get; set; }
        public string DelayLong { get; set; }
        public string NoBlackStoneErr { get; set; }
        public string NoStonesErr { get; set; }
        public string NoProcessFound { get; set; }
        public string ProcessName { get; set; }
=======
        public string MaterialCountLabel { get; set; } = "Enter number of material to use";
        public string ProjectName { get; set; } = "BDO Alchemy Stone Tapper";
        public string SOP { get; set; } = "SOP";
        public string SOD { get; set; } = "SOD";
        public string SOL { get; set; } = "SOL";
        public string UpgreadeFollowing { get; set; } = "Upgrade following";
        public string WithFollowingMaterials { get; set; } = "with following materials";
        public string Start { get; set; } = "Start";
        public string Stop { get; set; } = "Stop";
        public string Select { get; set; } = "Select";
        public string DetectionName { get; set; } = "Object Detection";
        public string PolishOnceBtn { get; set; } = "Polish Stones Once";
        public string GrowOnceBtn { get; set; } = "Grow Stones Once";
        public string PolishGrowBtn { get; set; } = "Polish and Grow Stones";
        public string NoMaterialErr { get; set; } = "No materials found";
        public string OnlyNumberErr { get; set; } = "Only numbers allowed";
        public string DelayShort { get; set; } = "Delay (short)";
        public string DelayLong { get; set; } = "Delay (long)";
        public string NoBlackStoneErr { get; set; } = "No black stones found";
        public string NoStonesErr { get; set; } = "No stones found";
        public string NoProcessFound { get; set; } = "BDO Process Not Found(process name set to BlackDesert64), report Error with proper process name";
>>>>>>> c44b8e38da8204654d40bb4e0563bd12299911d4
    }
}