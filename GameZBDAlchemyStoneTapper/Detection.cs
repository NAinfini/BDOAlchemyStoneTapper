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
using System.Xml.Linq;

namespace GameZBDAlchemyStoneTapper
{
    public partial class Detection : Form
    {
        private Rectangle sniplocation;
        private Rectangle PhysicalSnipLocation;
        private Yolov8 yolo;
        private List<string> selectedAlchemyStone = new List<string>();
        private List<string> selectedMaterial = new List<string>();
        private ObjectDetection OBJ;
        private Bitmap toDisplay;
        private List<YoloPrediction> perdictions;
        private Dictionary<string, List<RectangleF>> positions;
        private Thread thread;
        private bool isRunning = true;
        private Stack<RectangleF> materialPositions = new Stack<RectangleF>();
        private Stack<string> materialNames = new Stack<string>();
        private Dictionary<string, RectangleF> positionList;
        private RectangleF BlackStonePosition;

        public Detection(Rectangle rec, List<string> stoneList, List<string> matList)
        {
            sniplocation = rec;
            PhysicalSnipLocation = DPIFinder.ScaledToPhysical(sniplocation);
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
                lock (ThreadLocks.BitMapLock)
                {
                    updatePerdictionList();
                    CaptureZonePictureBox.Image = OBJ.drawRectangles(toDisplay, perdictions);
                    Thread.Sleep(50);
                }
            }
        }

        private void PolishStonesOnce()
        {
            if (!findButtonsPositionsFromPolishSlot()) return;
            updatePerdictionList();
            //now start polishing stones
            RectangleF CurrentMaterial = materialPositions.Pop();
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    foreach (RectangleF tempRect in tempList)
                    {
                        bool StoneTapped = false;
                        do
                        {
                            StoneTapped = true;
                            RightClickRectangle(tempRect);
                            Thread.Sleep(500);
                            //temp code, grabs whatever material is first in the list
                            RightClickRectangle(CurrentMaterial);
                            Thread.Sleep(500);
                            //press space to max material
                            InputSimulator sim = new InputSimulator();
                            sim.Keyboard.KeyPress(VirtualKeyCode.SPACE);
                            Thread.Sleep(500);
                            //left click polishing button
                            LeftClickRectangle(positionList["LowerPolishButton"]);
                            Thread.Sleep(500);
                            //send item back to inventory
                            RightClickRectangle(positionList["PolishPosition"]);
                            Thread.Sleep(500);
                            if (!MaterialExists(materialNames.Peek()))
                            {
                                StoneTapped = false;
                                if (materialPositions.TryPop(out RectangleF tempRect2))
                                {
                                    CurrentMaterial = tempRect2;
                                    materialNames.Pop();
                                }
                                else
                                {
                                    MessageBox.Show("Out of Materials");
                                    return;
                                }
                            }
                        } while (StoneTapped == false);
                    }
                }
            }

            CaptureZonePictureBox.Image = OBJ.drawRectangles(OBJ.drawRectangles(toDisplay, perdictions), positionList);
            Thread.Sleep(50);
        }

        private void GrowStonesOnce()
        {
            if (!findButtonsPositionsFromGrowthSlot()) return;
            updatePerdictionList();
            //now start polishing stones
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    foreach (RectangleF tempRect in tempList)
                    {
                        RightClickRectangle(tempRect);
                        Thread.Sleep(500);
                        //temp code, grabs whatever material is first in the list
                        RightClickRectangle(BlackStonePosition);
                        Thread.Sleep(500);
                        //press space to max material
                        InputSimulator sim = new InputSimulator();
                        sim.Keyboard.KeyPress(VirtualKeyCode.SPACE);
                        Thread.Sleep(500);
                        //left click Growth button
                        LeftClickRectangle(positionList["LowerGrowthButton"]);
                        Thread.Sleep(500);
                        if (!BlackStoneExists())
                        {
                            MessageBox.Show("Out of Black Stones");
                            return;
                        }
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
            updatePerdictionList();
            CaptureZonePictureBox.Image = OBJ.drawRectangles(toDisplay, perdictions);

            //right click on stone to move it to polish slot
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    RightClickRectangle(tempList.FirstOrDefault());
                    break;
                }
            }
            updatePerdictionList();
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
            updatePerdictionList();
            CaptureZonePictureBox.Image = OBJ.drawRectangles(toDisplay, perdictions);
            //find position for all materials
            foreach (string tempStr in selectedMaterial)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    materialPositions.Push(tempList.FirstOrDefault());
                    materialNames.Push(tempStr);
                }
            }
            if (materialPositions.Count == 0)
            {
                MessageBox.Show("Material Not Found");
                return false;
            }
            //move stone back to inventory
            RightClickRectangle(PolishPosition);
            positionList = new Dictionary<string, RectangleF>
            {
                { "PolishPosition", PolishPosition },
                {
                    "GrowthPosition",
                    new RectangleF(PolishPosition.X-360, PolishPosition.Y-70,50 , 50)
                },
                {
                    "LowerPolishButton",
                    new RectangleF(PolishPosition.X - 440, PolishPosition.Y +230 ,570 ,50 )
                },
                {
                    "LowerGrowthButton",
                    new RectangleF(PolishPosition.X - 440, PolishPosition.Y + 230,570 ,50 )
                },
                {
                    "UpperPolishButton",
                    new RectangleF(PolishPosition.X-260,PolishPosition.Y -240, 70,20)
                },
                {
                    "UpperGrowthButton",
                    new RectangleF(PolishPosition.X-110,  PolishPosition.Y -240, 70,20)
                }
            };
            CaptureZonePictureBox.Image = OBJ.drawRectangles(toDisplay, positionList);
            return true;
        }

        private bool findButtonsPositionsFromGrowthSlot()
        {
            updatePerdictionList();
            CaptureZonePictureBox.Image = OBJ.drawRectangles(toDisplay, perdictions);
            if (positions.TryGetValue("BlackStone", out List<RectangleF> blackStoneList))
            {
                BlackStonePosition = blackStoneList.FirstOrDefault();
            }
            else
            {
                MessageBox.Show("Black Stone not found");
                //return false;
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
            //find position for Growth slot
            updatePerdictionList();
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
            positionList = new Dictionary<string, RectangleF>
            {
                { "GrowthPosition", GrowthPosition },
                {
                    "PolishPosition",
                    new RectangleF(GrowthPosition.X+360, GrowthPosition.Y+70,50,50)
                },
                {
                    "LowerPolishButton",
                    new RectangleF(GrowthPosition.X-80,GrowthPosition.Y+300,570,50)
                },
                {
                    "LowerGrowthButton",
                    new RectangleF(GrowthPosition.X-80,GrowthPosition.Y+300,570,50)
                },
                {
                    "UpperPolishButton",
                    new RectangleF(GrowthPosition.X+100,GrowthPosition.Y-170,70,20)
                },
                {
                    "UpperGrowthButton",
                    new RectangleF(GrowthPosition.X+250,GrowthPosition.Y-170,70,20)
                }
            };
            CaptureZonePictureBox.Image = OBJ.drawRectangles(toDisplay, positionList);
            return true;
        }

        private void tapStonesOnceBtn_Click(object sender, EventArgs e)
        {
            LeftClickRectangleAbs(PhysicalSnipLocation);
            Thread.Sleep(500);
            PolishStonesOnce();
        }

        private void GrowStonesOnceBtn_Click(object sender, EventArgs e)
        {
            LeftClickRectangleAbs(PhysicalSnipLocation);
            Thread.Sleep(500);
            GrowStonesOnce();
        }

        private bool MaterialExists(string name)
        {
            updatePerdictionList();
            if (positions.TryGetValue(name, out List<RectangleF> tempList))
            {
                return true;
            }
            return false;
        }

        private bool BlackStoneExists()
        {
            updatePerdictionList();
            if (positions.TryGetValue("BlackStone", out List<RectangleF> tempList))
            {
                return true;
            }
            return false;
        }

        private void RightClickRectangle(RectangleF tempRect)
        {
            Point pt = new Point((int)tempRect.X + PhysicalSnipLocation.X + (int)tempRect.Width / 2, (int)tempRect.Y + PhysicalSnipLocation.Y + (int)tempRect.Height / 2);
            MouseClickHelper.RightClick(DPIFinder.PhysicalToScaled(pt));
        }

        private void LeftClickRectangle(RectangleF tempRect)
        {
            Point pt = new Point((int)tempRect.X + PhysicalSnipLocation.X + (int)tempRect.Width / 2, (int)tempRect.Y + PhysicalSnipLocation.Y + (int)tempRect.Height / 2);
            MouseClickHelper.LeftClick(DPIFinder.PhysicalToScaled(pt));
        }

        private void RightClickRectangleAbs(RectangleF tempRect)
        {
            Point pt = new Point((int)tempRect.X + (int)tempRect.Width / 2, (int)tempRect.Y + (int)tempRect.Height / 2);
            MouseClickHelper.RightClick(DPIFinder.PhysicalToScaled(pt));
        }

        private void LeftClickRectangleAbs(RectangleF tempRect)
        {
            Point pt = new Point((int)tempRect.X + (int)tempRect.Width / 2, (int)tempRect.Y + (int)tempRect.Height / 2);
            MouseClickHelper.LeftClick(DPIFinder.PhysicalToScaled(pt));
        }

        private void detectionClose(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
            toDisplay.Dispose();
            thread.Join();
            while (thread.IsAlive) { }
            
        }

        private void updatePerdictionList()
        {
            lock (ThreadLocks.BitMapLock)
            {
                toDisplay = CaptureScreen.Snip(sniplocation);
                perdictions = OBJ.getPerdictions(toDisplay);
                positions = OBJ.getPositions(perdictions);
            }
        }

        #endregion helper functions
    }
}