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
using Yolov7net;
using System.Xml.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace GameZBDAlchemyStoneTapper
{
    public partial class Detection : Form
    {
        private Rectangle sniplocation;
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
        private bool boxObtained = false;
        private bool polishOrGrow = true;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public Detection(Rectangle rec, List<string> stoneList, List<string> matList)
        {
            sniplocation = rec;
            selectedAlchemyStone = stoneList;
            selectedMaterial = matList;
            InitializeComponent();
            OBJ = new ObjectDetection();
            thread = new Thread(new ThreadStart(detectStones));
            thread.Start();
            FormClosing += detectionClose;
            HotkeysManager.AddHotkey(new GlobalHotkey(System.Windows.Input.ModifierKeys.Shift, Key.Q, () => { stopRunning(); }));
        }

        private void detectStones()
        {
            ObjectDetection ForPictureBox = new ObjectDetection();
            while (isRunning)
            {
                Bitmap boxMap = CaptureScreen.Snip(sniplocation);
                List<YoloPrediction> tempperdictions = ForPictureBox.getPerdictions(boxMap);
                boxMap = ForPictureBox.drawRectangles(boxMap, tempperdictions);
                if (boxObtained) { ForPictureBox.drawRectangles(boxMap, positionList); }
                CaptureZonePictureBox.Image = boxMap;
                Thread.Sleep(300);
            }
        }

        private void PolishStonesOnce()
        {
            var prc = Process.GetProcessesByName("BlackDesert64");
            if (prc.Length > 0)
            {
                SetForegroundWindow(prc[0].MainWindowHandle);
            }
            else
            {
                MessageBox.Show("Cant get process");
                return;
            }
            if (!findButtonsPositionsFromPolishSlot()) return;

            //now start polishing stones
            if (materialPositions.Count <= 0)
            {
                MessageBox.Show("Out of Materials");
                return;
            }
            RectangleF CurrentMaterial = materialPositions.Pop();
            Thread.Sleep(200);
            updatePerdictionList();
            Dictionary<string, List<RectangleF>> tempPos = positions;
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (tempPos.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    foreach (RectangleF tempRect in tempList)
                    {
                        RightClickRectangle(tempRect);
                        Thread.Sleep(15);
                        //checking for material will slow down the program significantly.
                        /*if (!MaterialExists(materialNames.Peek()))
                        {
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
                        }*/
                        //temp code, grabs whatever material is first in the list
                        RightClickRectangle(CurrentMaterial);
                        Thread.Sleep(10);
                        //press space to max material
                        MouseClickHelper.PressSpace();
                        Thread.Sleep(20);
                        //left click polishing button
                        LeftClickRectangle(positionList["LowerPolishButton"]);
                        Thread.Sleep(10);
                        //send item back to inventory
                        RightClickRectangle(positionList["PolishPosition"]);
                        if (!polishOrGrow) return;
                        Thread.Sleep(15);
                    }
                }
            }
        }

        private void GrowStonesOnce()
        {
            var prc = Process.GetProcessesByName("BlackDesert64");
            if (prc.Length > 0)
            {
                SetForegroundWindow(prc[0].MainWindowHandle);
            }
            else
            {
                MessageBox.Show("Cant get process");
                return;
            }
            if (!findButtonsPositionsFromGrowthSlot()) return;
            Thread.Sleep(200);
            updatePerdictionList();
            Dictionary<string, List<RectangleF>> tempPos = positions;
            //now start polishing stones
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (tempPos.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    foreach (RectangleF tempRect in tempList)
                    {
                        RightClickRectangle(tempRect);
                        Thread.Sleep(20);
                        //checking for black stone will slow down the program significantly.
                        /*if (!BlackStoneExists())
                        {
                            MessageBox.Show("Out of Black Stones");
                            return;
                        }*/
                        //temp code, grabs whatever material is first in the list
                        RightClickRectangle(BlackStonePosition);
                        Thread.Sleep(10);
                        //press space to max material
                        MouseClickHelper.PressSpace();
                        Thread.Sleep(130);
                        //left click Growth button
                        LeftClickRectangle(positionList["LowerGrowthButton"]);
                        Thread.Sleep(10);
                        //Press enter
                        MouseClickHelper.PressSpace();
                        Thread.Sleep(10);
                        RightClickRectangle(positionList["GrowthPosition"]);
                        Thread.Sleep(10);
                        if (!polishOrGrow) return;
                    }
                }
            }
        }

        #region helper functions

        private bool findButtonsPositionsFromPolishSlot()
        {
            bool stoneFound = false;
            //find position for polish slot
            updatePerdictionList();

            //right click on stone to move it to polish slot
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    RightClickRectangle(tempList.FirstOrDefault());
                    stoneFound = true;
                    break;
                }
            }
            if (!stoneFound)
            {
                MessageBox.Show("No stone found");
                return false;
            }
            Thread.Sleep(100);
            updatePerdictionList();
            foreach (string tempStr in selectedMaterial)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    materialPositions.Push(tempList.FirstOrDefault());
                    materialNames.Push(tempStr);
                }
            }
            if (materialPositions.Count <= 0)
            {
                MessageBox.Show("Material Not Found");
                return false;
            }

            RectangleF PolishPosition = new RectangleF(9999999, 0, 0, 0);
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    PolishPosition = tempList.FirstOrDefault();
                }
            }

            //move stone back to inventory
            RightClickRectangle(PolishPosition);
            positionList = new Dictionary<string, RectangleF>
            {
                { "PolishPosition", PolishPosition },
                {
                    "GrowthPosition",
                    new RectangleF(PolishPosition.X-370, PolishPosition.Y-75,50 , 50)
                },
                {
                    "LowerPolishButton",
                    new RectangleF(PolishPosition.X - 450, PolishPosition.Y +235,570 ,50 )
                },
                {
                    "LowerGrowthButton",
                    new RectangleF(PolishPosition.X - 450, PolishPosition.Y + 235,570 ,50 )
                },
                {
                    "UpperPolishButton",
                    new RectangleF(PolishPosition.X-270,PolishPosition.Y -248, 75,22)
                },
                {
                    "UpperGrowthButton",
                    new RectangleF(PolishPosition.X-123,  PolishPosition.Y -246, 70,22)
                }
            };
            boxObtained = true;
            return true;
        }

        private bool findButtonsPositionsFromGrowthSlot()
        {
            updatePerdictionList();
            bool stoneFound = false;

            //right click on stone to move it to polish slot
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (positions.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    RightClickRectangle(tempList.FirstOrDefault());
                    stoneFound = true;
                    break;
                }
            }

            if (!stoneFound)
            {
                MessageBox.Show("No stone found");
                return false;
            }
            Thread.Sleep(200);
            updatePerdictionList();
            if (positions.TryGetValue("BlackStone", out List<RectangleF> blackStoneList))
            {
                BlackStonePosition = blackStoneList.FirstOrDefault();
            }
            else
            {
                MessageBox.Show("Black Stone not found");
                return false;
            }
            //find position for Growth slot
            Thread.Sleep(200);
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
                    new RectangleF(GrowthPosition.X+358, GrowthPosition.Y+65,50,50)
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
                    new RectangleF(GrowthPosition.X+93,GrowthPosition.Y-177,80,22)
                },
                {
                    "UpperGrowthButton",
                    new RectangleF(GrowthPosition.X+248,GrowthPosition.Y-178,68,22)
                }
            };
            boxObtained = true;
            return true;
        }

        private void tapStonesOnceBtn_Click(object sender, EventArgs e)
        {
            isRunning = false;
            PolishStonesOnceBtn.Enabled = false;
            GrowStonesOnceBtn.Enabled = false;
            Thread thread = new Thread(PolishStonesOnce);
            thread.Start();
            while (thread.IsAlive) { }
            PolishStonesOnceBtn.Enabled = true;
            GrowStonesOnceBtn.Enabled = true;
            isRunning = true;
            thread = new Thread(new ThreadStart(detectStones));
            thread.Start();
        }

        private void GrowStonesOnceBtn_Click(object sender, EventArgs e)
        {
            isRunning = false;
            PolishStonesOnceBtn.Enabled = false;
            GrowStonesOnceBtn.Enabled = false;
            Thread thread = new Thread(GrowStonesOnce);
            thread.Start();
            while (thread.IsAlive) { }
            PolishStonesOnceBtn.Enabled = true;
            GrowStonesOnceBtn.Enabled = true;
            isRunning = true;
            thread = new Thread(new ThreadStart(detectStones));
            thread.Start();
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
            var tempTemp = DPIFinder.PhysicalToScaled(tempRect);
            MouseClickHelper.RightClick((int)tempTemp.X + sniplocation.X + (int)tempTemp.Width / 2, (int)tempTemp.Y + sniplocation.Y + (int)tempTemp.Height / 2);
        }

        private void LeftClickRectangle(RectangleF tempRect)
        {
            var tempTemp = DPIFinder.PhysicalToScaled(tempRect);
            MouseClickHelper.LeftClick((int)tempTemp.X + sniplocation.X + (int)tempTemp.Width / 2, (int)tempTemp.Y + sniplocation.Y + (int)tempTemp.Height / 2);
        }

        private void detectionClose(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
            if (toDisplay != null) { toDisplay.Dispose(); }

            thread.Join();
            while (thread.IsAlive) { }
        }

        private void updatePerdictionList()
        {
            toDisplay = CaptureScreen.Snip(sniplocation);
            perdictions = OBJ.getPerdictions(toDisplay);
            positions = OBJ.getPositions(perdictions);
        }

        private void stopRunning()
        {
            this.Close();
        }

        #endregion helper functions
    }
}