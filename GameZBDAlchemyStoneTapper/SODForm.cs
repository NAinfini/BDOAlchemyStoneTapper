using IronSoftware.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Yolov7net;

namespace GameZBDAlchemyStoneTapper
{
    public partial class SODForm : Form
    {
        private int ScreenX;
        private int ScreenY;
        private int ScreenWidth;
        private int ScreenHeight;
        private List<string> selectedAlchemyStone = new List<string>();
        private List<string> selectedMaterial = new List<string>();
        private Bitmap toDisplay;
        private bool isRunning = false;
        private ObjectDetection OBJ;
        private Thread thread;

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
            if (selectedAlchemyStone.Contains(((PictureBox)sender).Name))
            {
                selectedAlchemyStone.Remove((((PictureBox)sender).Name));
                ((PictureBox)sender).BorderStyle = BorderStyle.None;
            }
            else
            {
                selectedAlchemyStone.Add((((PictureBox)sender).Name));
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
            if (selectedMaterial.Contains(((PictureBox)sender).Name))
            {
                selectedMaterial.Remove((((PictureBox)sender).Name));
                ((PictureBox)sender).BorderStyle = BorderStyle.None;
            }
            else
            {
                selectedMaterial.Add((((PictureBox)sender).Name));
                ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
            }
        }

        #endregion selection area

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
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
                AnyBitmap tempMap = CaptureScreen.Snip(ScreenX, ScreenY, ScreenWidth, ScreenHeight);

                OBJ = new ObjectDetection();
                OBJ.loadLists(selectedAlchemyStone, selectedMaterial);

                thread = new Thread(new ThreadStart(detectStones));
                thread.Start();
                ((Button)sender).Text = "Stop";
            }
            else
            {
                isRunning = false;
                thread.Join();
                while (thread.IsAlive) { }
                ((Button)sender).Text = "Start";
            }
        }

        private void detectStones()
        {
            do
            {
                toDisplay = CaptureScreen.Snip(ScreenX, ScreenY, ScreenWidth, ScreenHeight);
                List<YoloPrediction> perdictions = OBJ.getPerdictions(toDisplay);
                OBJ.getPositions(perdictions);
                ScreenShotBox.Image = OBJ.drawRectangles(toDisplay, perdictions);
                Thread.Sleep(50);
            } while (isRunning);
        }
    }
}