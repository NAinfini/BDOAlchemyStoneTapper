using System;
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
        public string NoBlackStoneErr { get; set; }
        public string NoStonesErr { get; set; }
        public string NoProcessFound { get; set; }
    }
}