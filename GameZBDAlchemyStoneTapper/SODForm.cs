using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace GameZBDAlchemyStoneTapper
{
    public partial class SODForm : Form
    {
        private int ScreenX;
        private int ScreenY;
        private int ScreenWidth;
        private int ScreenHeight;
        private List<Image> selectedAlchemyStone = new List<Image>();
        private List<Image> selectedMaterial = new List<Image>();
        private Bitmap toDisplay;

        public SODForm()
        {
            InitializeComponent();
        }

        #region selection area

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void updateAlchemyStoneList(object sender)
        {
            if (selectedAlchemyStone.Contains(((PictureBox)sender).Image))
            {
                selectedAlchemyStone.Remove((((PictureBox)sender).Image));
                ((PictureBox)sender).BorderStyle = BorderStyle.None;
            }
            else
            {
                selectedAlchemyStone.Add((((PictureBox)sender).Image));
                ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void Copper_Click(object sender, EventArgs e)
        {
            updateMaterialList(sender);
        }

        private void Iron_Click(object sender, EventArgs e)
        {
            updateMaterialList(sender);
        }

        private void Lead_Click(object sender, EventArgs e)
        {
            updateMaterialList(sender);
        }

        private void Tin_Click(object sender, EventArgs e)
        {
            updateMaterialList(sender);
        }

        private void Zinc_Click(object sender, EventArgs e)
        {
            updateMaterialList(sender);
        }

        private void Titanium_Click(object sender, EventArgs e)
        {
            updateMaterialList(sender);
        }

        private void Vanadium_Click(object sender, EventArgs e)
        {
            updateMaterialList(sender);
        }

        private void updateMaterialList(object sender)
        {
            if (selectedMaterial.Contains(((PictureBox)sender).Image))
            {
                selectedMaterial.Remove((((PictureBox)sender).Image));
                ((PictureBox)sender).BorderStyle = BorderStyle.None;
            }
            else
            {
                selectedMaterial.Add((((PictureBox)sender).Image));
                ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
            }
        }

        #endregion selection area

        private void startBtn_Click(object sender, EventArgs e)
        {
            using (SelectArea tempArea = new SelectArea())
            {
                if (tempArea.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.ScreenX = tempArea.Location.X;
                    this.ScreenY = tempArea.Location.Y;
                    this.ScreenWidth = tempArea.Width;
                    this.ScreenHeight = tempArea.Height;
                }
            }
            toDisplay = CaptureScreen.Snip(ScreenX, ScreenY, ScreenWidth, ScreenHeight);
            List<List<Rectangle>> StonePositions = findLocations(toDisplay, selectedAlchemyStone);
            List<List<Rectangle>> MaterialPositions = findLocations(toDisplay, selectedMaterial);
            Bitmap tempMap = (Bitmap)toDisplay.Clone();
            foreach (List<Rectangle> tempList in StonePositions)
            {
                tempMap = drawRectangles(tempMap, tempList);
            }
            foreach (List<Rectangle> tempList in MaterialPositions)
            {
                tempMap = drawRectangles(tempMap, tempList);
            }
            ScreenShotBox.Image = tempMap;
            /*while (true)
            {
                var oldPic = ScreenShotBox.Image;

                if (oldPic != null)
                {
                    oldPic.Dispose();
                }
                ScreenShotBox.Refresh();
            }
            */
            /*
            List<Bitmap> allScreenShots  = CaptureScreen.TakeAllScreens();
            for(int i = 0; i < allScreenShots.Count; i++)
            {
                allScreenShots[i].Save(i.ToString() + "text.png", ImageFormat.Png);
            }
            //sc.CaptureWindow(process.Handle).Save("test.png", ImageFormat.Png);
            */
        }

        private List<List<Rectangle>> findLocations(Bitmap reference, List<Image> ImageList)
        {
            Image<Bgr, byte> source = reference.ToImage<Bgr, byte>(); // Image B
            Image<Bgr, byte> imageToShow = source.Copy();
            List<List<Rectangle>> rectangleList = new List<List<Rectangle>>();
            foreach (Image TempImage in ImageList)
            {
                Bitmap tempMap = (Bitmap)TempImage;
                Image<Bgr, byte> template = tempMap.ToImage<Bgr, byte>();
                using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
                {
                    double[] minValues, maxValues;
                    Point[] minLocations, maxLocations;
                    result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                    List<Rectangle> tempRectangle = findLocation(reference, TempImage);
                    rectangleList.Add(tempRectangle);
                }
            }
            return rectangleList;
        }

        private List<Rectangle> findLocation(Bitmap reference, Image TempImage)
        {
            Image<Bgr, byte> source = reference.ToImage<Bgr, byte>();
            Image<Bgr, byte> template = ((Bitmap)TempImage).ToImage<Bgr, byte>();
            Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);

            // Normalize the result image into a matrix of floats (thresholds?)
            Mat thresholds = new Mat();
            CvInvoke.Normalize(result, thresholds, 0, 1, Emgu.CV.CvEnum.NormType.MinMax);

            var rectangles = new List<Rectangle>();
            var size = new Size(template.Width, template.Height);

            // Convert it to a multidimensional array to be able to iterate through it
            // (is it really necessary, isn't something native in EmguCV for this?)
            var thresholdData = thresholds.GetData();
            for (int y = 0; y < thresholdData.GetLength(0); y++)
            {
                for (int x = 0; x < thresholdData.GetLength(1); x++)
                {
                    if ((float)thresholdData.GetValue(y, x) > 0.95)
                    {
                        rectangles.Add(new Rectangle(x, y, size.Width, size.Height));
                    }
                }
            }

            var groupedRectangles = new VectorOfRect(rectangles.ToArray());
            CvInvoke.GroupRectangles(groupedRectangles, 1);
            var groupedRectanglesArray = groupedRectangles.ToArray();
            return groupedRectanglesArray.ToList();
        }

        private Bitmap drawRectangles(Bitmap reference, List<Rectangle> RecList)
        {
            Image<Bgr, byte> source = reference.ToImage<Bgr, byte>();
            foreach (Rectangle TempRec in RecList)
            {
                source.Draw(TempRec, new Bgr(Color.Red), 3);
            }
            return source.ToBitmap();
        }
    }
}