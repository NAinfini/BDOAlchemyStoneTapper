using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shell;
using WindowsInput.Native;
using WindowsInput;
using Yolov7net;

namespace GameZBDAlchemyStoneTapper
{
    public partial class Detection : Form
    {
        private Rectangle sniplocation;
        private Yolov8 yolo;
        private List<string> selectedAlchemyStone = new List<string>();
        private List<string> selectedMaterial = new List<string>();
        private ObjectDetection OBJ;
        private Bitmap toDisplay;
        private Thread thread;
        private bool isRunning = true;
        private List<List<RectangleF>> materialPositions = new List<List<RectangleF>>();
        private Dictionary<string, RectangleF> positionList;
        private RectangleF BlackStonePosition;
        private bool ButtonPositionsFound = false;

        public Detection(Rectangle rec, List<string> stoneList, List<string> matList)
        {
            sniplocation = rec;
            selectedAlchemyStone = stoneList;
            selectedMaterial = matList;
            InitializeComponent();
            OBJ = new ObjectDetection();
            OBJ.loadLists(selectedAlchemyStone, selectedMaterial);
            thread = new Thread(new ThreadStart(detectStones));
            thread.Start();
            FormClosing += detectionClose;
        }

        private void detectStones()
        {
            while (isRunning)
            {
                toDisplay = CaptureScreen.Snip(sniplocation);
                List<YoloPrediction> perdictions = OBJ.getPerdictions(toDisplay);
                OBJ.getPositions(perdictions);
                CaptureZonePictureBox.Image = OBJ.drawRectangles(toDisplay, perdictions);
                Thread.Sleep(50);
            }
        }

        private void PolishStonesOnce()
        {
            if (!findButtonsPositionsFromPolishSlot()) return;
            toDisplay = CaptureScreen.Snip(sniplocation);
            List<YoloPrediction> perdictions = OBJ.getPerdictions(toDisplay);
            Dictionary<string, List<RectangleF>> positions = OBJ.getPositions(perdictions);
            //now start polishing stones
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    foreach (RectangleF tempRect in tempList)
                    {
                        RightClickRectangle(tempRect);
                        //temp code, grabs whatever material is first in the list
                        RightClickRectangle(materialPositions[0][0]);
                        //press space to max material
                        InputSimulator sim = new InputSimulator();
                        sim.Keyboard.KeyPress(VirtualKeyCode.SPACE);
                        //left click polishing button
                        LeftClickRectangle(positionList["LowerPolishButton"]);
                        //send item back to inventory
                        RightClickRectangle(positionList["PolishPosition"]);
                    }
                }
            }

            CaptureZonePictureBox.Image = OBJ.drawRectangles(OBJ.drawRectangles(toDisplay, perdictions), positionList);
            Thread.Sleep(50);
        }

        private void GrowStonesOnce()
        {
            if (!findButtonsPositionsFromGrowthSlot()) return;
            toDisplay = CaptureScreen.Snip(sniplocation);
            List<YoloPrediction> perdictions = OBJ.getPerdictions(toDisplay);
            Dictionary<string, List<RectangleF>> positions = OBJ.getPositions(perdictions);
            //now start polishing stones
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    foreach (RectangleF tempRect in tempList)
                    {
                        RightClickRectangle(tempRect);
                        //temp code, grabs whatever material is first in the list
                        RightClickRectangle(BlackStonePosition);
                        //press space to max material
                        InputSimulator sim = new InputSimulator();
                        sim.Keyboard.KeyPress(VirtualKeyCode.SPACE);
                        //left click Growth button
                        LeftClickRectangle(positionList["LowerGrowthButton"]);
                    }
                }
            }

            CaptureZonePictureBox.Image = OBJ.drawRectangles(OBJ.drawRectangles(toDisplay, perdictions), positionList);
            Thread.Sleep(50);
        }

        #region helper functions

        private bool findButtonsPositionsFromPolishSlot()
        {
            //find position for polish slot
            toDisplay = CaptureScreen.Snip(sniplocation);
            List<YoloPrediction> perdictions = OBJ.getPerdictions(toDisplay);
            Dictionary<string, List<RectangleF>> positions = OBJ.getPositions(perdictions);
            CaptureZonePictureBox.Image = OBJ.drawRectangles(toDisplay, perdictions);
            //find position for all materials
            foreach (string tempStr in selectedMaterial)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    materialPositions.Add(tempList);
                }
            }
            //right click on stone to move it to polish slot
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    RightClickRectangle(tempList.FirstOrDefault());
                    break;
                }
            }
            RectangleF PolishPosition = new RectangleF(9999999, 0, 0, 0);
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    foreach (RectangleF tempRect in tempList)
                    {
                        if (tempRect.X < PolishPosition.X)
                        {
                            PolishPosition = tempRect;
                        }
                    }
                }
            }
            //move stone back to inventory
            RightClickRectangle(PolishPosition);
            positionList = new Dictionary<string, RectangleF>();
            positionList.Add("PolishPosition", PolishPosition);
            positionList.Add("GrowthPosition", new RectangleF(PolishPosition.X, PolishPosition.X, PolishPosition.X, PolishPosition.X));
            positionList.Add("LowerPolishButton", new RectangleF(PolishPosition.X, PolishPosition.X, PolishPosition.X, PolishPosition.X));
            positionList.Add("LowerGrowthButton", new RectangleF(PolishPosition.X, PolishPosition.X, PolishPosition.X, PolishPosition.X));
            positionList.Add("UpperPolishButton", new RectangleF(PolishPosition.X, PolishPosition.X, PolishPosition.X, PolishPosition.X));
            positionList.Add("UpperGrowthButton", new RectangleF(PolishPosition.X, PolishPosition.X, PolishPosition.X, PolishPosition.X));
            CaptureZonePictureBox.Image = OBJ.drawRectangles(toDisplay, positionList);
            ButtonPositionsFound = true;
            return true;
        }

        private bool findButtonsPositionsFromGrowthSlot()
        {
            toDisplay = CaptureScreen.Snip(sniplocation);
            List<YoloPrediction> perdictions = OBJ.getPerdictions(toDisplay);
            Dictionary<string, List<RectangleF>> positions = OBJ.getPositions(perdictions);
            CaptureZonePictureBox.Image = OBJ.drawRectangles(toDisplay, perdictions);
            if (positions.TryGetValue("BlackStone", out List<RectangleF> blackStoneList))
            {
                BlackStonePosition = blackStoneList.FirstOrDefault();
            }
            else
            {
                MessageBox.Show("Black Stone not found");
                return false;
            }
            //right click on stone to move it to polish slot
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    RightClickRectangle(tempList.FirstOrDefault());
                    return false;
                }
            }
            //find position for Growth slot
            toDisplay = CaptureScreen.Snip(sniplocation);
            perdictions = OBJ.getPerdictions(toDisplay);
            positions = OBJ.getPositions(perdictions);
            RectangleF GrowthPosition = new RectangleF(9999999, 0, 0, 0);
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    foreach (RectangleF tempRect in tempList)
                    {
                        if (tempRect.X < GrowthPosition.X)
                        {
                            GrowthPosition = tempRect;
                        }
                    }
                }
            }

            //move stone back to inventory
            RightClickRectangle(GrowthPosition);
            positionList = new Dictionary<string, RectangleF>();
            positionList.Add("GrowthPosition", GrowthPosition);
            positionList.Add("PolishPosition", new RectangleF(GrowthPosition.X, GrowthPosition.X, GrowthPosition.X, GrowthPosition.X));
            positionList.Add("LowerPolishButton", new RectangleF(GrowthPosition.X, GrowthPosition.X, GrowthPosition.X, GrowthPosition.X));
            positionList.Add("LowerGrowthButton", new RectangleF(GrowthPosition.X, GrowthPosition.X, GrowthPosition.X, GrowthPosition.X));
            positionList.Add("UpperPolishButton", new RectangleF(GrowthPosition.X, GrowthPosition.X, GrowthPosition.X, GrowthPosition.X));
            positionList.Add("UpperGrowthButton", new RectangleF(GrowthPosition.X, GrowthPosition.X, GrowthPosition.X, GrowthPosition.X));
            CaptureZonePictureBox.Image = OBJ.drawRectangles(toDisplay, positionList);
            ButtonPositionsFound = true;
            return true;
        }

        private void tapStonesOnceBtn_Click(object sender, EventArgs e)
        {
            PolishStonesOnce();
        }

        private void GrowStonesOnceBtn_Click(object sender, EventArgs e)
        {
            GrowStonesOnce();
        }

        private void RightClickRectangle(RectangleF tempRect)
        {
            Point pt = new Point((int)tempRect.X + sniplocation.X + (int)tempRect.Width / 2, (int)tempRect.Y + sniplocation.Y + (int)tempRect.Height / 2);
            MouseClickHelper.RightClick(DPIFinder.PhysicalToScaled(pt));
        }

        private void LeftClickRectangle(RectangleF tempRect)
        {
            Point pt = new Point((int)tempRect.X + sniplocation.X + (int)tempRect.Width / 2, (int)tempRect.Y + sniplocation.Y + (int)tempRect.Height / 2);
            MouseClickHelper.LeftClick(DPIFinder.PhysicalToScaled(pt));
        }

        private void detectionClose(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
            thread.Join();
            while (thread.IsAlive) { }
            toDisplay.Dispose();
        }

        #endregion helper functions
    }
}