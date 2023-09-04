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
using System.Drawing.Imaging;
using System.Windows.Input;

using GlobalHotKey;

namespace BDOAlchemyStoneTapper
{
    public partial class Detection : Form
    {
        private Rectangle sniplocation;
        private List<string> selectedAlchemyStone = new List<string>();
        private ObjectDetection OBJ;
        private Bitmap toDisplay;
        private List<YoloPrediction> perdictions;
        private Dictionary<string, List<RectangleF>> positions;
        private RectangleF materialPosition;
        private Thread thread;
        private bool isRunning = true;

        private Dictionary<string, RectangleF> positionList;
        private RectangleF BlackStonePosition;
        private bool boxObtained = false;
        private bool polishOrGrow = false;
        private string StoneType;
        private HotKeyManager hotKeyManager = new HotKeyManager();
        private HotKey hotKey;

        private int DelayShort;
        private int DelayLong;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public Detection(Rectangle rec, List<string> stoneList, string typeOfStone, int delayShort, int delayLong)
        {
            //saving info
            sniplocation = rec;
            selectedAlchemyStone = stoneList;
            StoneType = typeOfStone;
            DelayShort = delayShort;
            DelayLong = delayLong;
            InitializeComponent();
            //setting basic interface texts
            this.Text = language.Instance.DetectionName;
            PolishStonesOnceBtn.Text = language.Instance.PolishOnceBtn;
            GrowStonesOnceBtn.Text = language.Instance.GrowOnceBtn;
            PolishGrowBtn.Text = language.Instance.PolishGrowBtn;
            //preparing for object detection
            OBJ = new ObjectDetection(typeOfStone);
            thread = new Thread(new ThreadStart(detectStones));
            thread.Start();
            FormClosing += detectionClose;

            // Register Ctrl+Alt+F5 hotkey. Save this variable somewhere for the further unregistering.
            hotKey = hotKeyManager.Register(Key.F5, System.Windows.Input.ModifierKeys.Shift | System.Windows.Input.ModifierKeys.Alt);

            // Handle hotkey presses.
            hotKeyManager.KeyPressed += HotKeyManagerPressed;
            DelayShort = delayShort;
            DelayLong = delayLong;
        }

        private void detectStones()
        {
            //display snip location whenever not tapping
            ObjectDetection ForPictureBox = new ObjectDetection(StoneType);
            while (isRunning)
            {
                Bitmap boxMap = CaptureScreen.Snip(sniplocation);
                List<YoloPrediction> tempperdictions = ForPictureBox.getPerdictions(MakeGrayscale3(boxMap));
                boxMap = ForPictureBox.drawRectangles(boxMap, tempperdictions);
                if (boxObtained) { ForPictureBox.drawRectangles(boxMap, positionList); }
                CaptureZonePictureBox.Image = boxMap;
                Thread.Sleep(300);
            }
        }

        private bool PolishStonesOnce()
        {
            //Polishing all stones once
            //getting process handle and setting it forward
            var prc = Process.GetProcessesByName("BlackDesert64");
            if (prc.Length > 0)
            {
                SetForegroundWindow(prc[0].MainWindowHandle);
            }
            else
            {
                MessageBox.Show(language.Instance.NoProcessFound);
                return false;
            }
            //try get polish position and all button positions
            if (!findButtonsPositionsFromPolishSlot()) return false;
            Thread.Sleep(200);
            updatePerdictionList();
            //for all stones, do procedures once
            Dictionary<string, List<RectangleF>> tempPos = positions;
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (tempPos.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    foreach (RectangleF tempRect in tempList)
                    {
                        RightClickRectangle(tempRect);
                        Thread.Sleep(DelayShort);
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
                        RightClickRectangle(materialPosition);
                        Thread.Sleep(DelayShort);
                        //press space to max material
                        MouseClickHelper.PressSpace();
                        Thread.Sleep(DelayShort);
                        //left click polishing button
                        LeftClickRectangle(positionList["LowerPolishButton"]);
                        Thread.Sleep(DelayShort);
                        //send item back to inventory
                        RightClickRectangle(positionList["PolishPosition"]);
                        if (!polishOrGrow)
                            return false;
                        Thread.Sleep(DelayShort);
                    }
                }
            }
            return true;
        }

        private bool GrowStonesOnce()
        {
            //growing all stones once
            //getting handle and setting it to the front
            var prc = Process.GetProcessesByName("BlackDesert64");
            if (prc.Length > 0)
            {
                SetForegroundWindow(prc[0].MainWindowHandle);
            }
            else
            {
                MessageBox.Show(language.Instance.NoProcessFound);
                return false;
            }
            //trying to get grow location and all button locations
            if (!findButtonsPositionsFromGrowthSlot()) return false;
            Thread.Sleep(200);
            updatePerdictionList();
            Dictionary<string, List<RectangleF>> tempPos = positions;
            //now start growing stones
            foreach (string tempStr in selectedAlchemyStone)
            {
                if (tempPos.TryGetValue(tempStr, out List<RectangleF> tempList))
                {
                    foreach (RectangleF tempRect in tempList)
                    {
                        RightClickRectangle(tempRect);
                        Thread.Sleep(DelayShort);
                        //checking for black stone will slow down the program significantly.
                        /*if (!BlackStoneExists())
                        {
                            MessageBox.Show("Out of Black Stones");
                            return;
                        }*/
                        //temp code, grabs whatever material is first in the list
                        RightClickRectangle(BlackStonePosition);
                        Thread.Sleep(DelayShort);
                        //press space to max material
                        MouseClickHelper.PressSpace();
                        Thread.Sleep(DelayLong);
                        //left click Growth button
                        LeftClickRectangle(positionList["LowerGrowthButton"]);
                        Thread.Sleep(DelayShort);
                        //Press enter
                        MouseClickHelper.PressSpace();
                        Thread.Sleep(DelayShort);
                        RightClickRectangle(positionList["GrowthPosition"]);
                        Thread.Sleep(DelayShort);
                        if (!polishOrGrow)
                            return false;
                    }
                }
            }
            return true;
        }

        private bool findButtonsPositionsFromPolishSlot()
        {
            bool stoneFound = false;
            //find position for polish slot
            updatePerdictionList();
            //click random stone over to polish position
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
                MessageBox.Show(language.Instance.NoStonesErr);
                return false;
            }

            Thread.Sleep(100);
            updatePerdictionList();
            //look for materials to polish with
            if (StoneType.Equals("Life"))
            {
                if (positions.TryGetValue("Purple", out List<RectangleF> Materials))
                {
                    materialPosition = (Materials.FirstOrDefault());
                }
                else if (positions.TryGetValue("StrawBerry", out Materials))
                {
                    materialPosition = (Materials.FirstOrDefault());
                }
                else
                {
                    MessageBox.Show(language.Instance.NoMaterialErr);
                    return false;
                }
            }
            else
            {
                if (positions.TryGetValue("Material", out List<RectangleF> Materials))
                {
                    materialPosition = (Materials.FirstOrDefault());
                }
                else
                {
                    MessageBox.Show(language.Instance.NoMaterialErr);
                    return false;
                }
            }

            RectangleF PolishPosition = new RectangleF(9999999, 0, 0, 0);
            //looing for the stone in the polish spot, left most stone there is
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
            // and cauclate button positions
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
            //looking for grow positions and button positions
            updatePerdictionList();
            bool stoneFound = false;
            //right click on stone to move it to grow slot
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
                MessageBox.Show(language.Instance.NoStonesErr);
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
                MessageBox.Show(language.Instance.NoBlackStoneErr);
                return false;
            }
            //find position for Growth slot left most
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

        #region helper functions

        private void PolishGrowBtn_Click(object sender, EventArgs e)
        {
            //update stats of buttons and stop display thread from running
            isRunning = false;
            polishOrGrow = true;
            PolishGrowBtn.Enabled = false;
            PolishStonesOnceBtn.Enabled = false;
            GrowStonesOnceBtn.Enabled = false;
            if (PolishStonesOnce())
            {
                LeftClickRectangle(positionList["UpperGrowthButton"]);
                if (GrowStonesOnce())
                {
                    LeftClickRectangle(positionList["UpperPolishButton"]);
                }
            }

            PolishGrowBtn.Enabled = true;
            PolishStonesOnceBtn.Enabled = true;
            GrowStonesOnceBtn.Enabled = true;
            isRunning = true;
            thread = new Thread(new ThreadStart(detectStones));
            thread.Start();
        }

        private void tapStonesOnceBtn_Click(object sender, EventArgs e)
        {
            //update stats of buttons and stop display thread from running
            isRunning = false;
            polishOrGrow = true;
            PolishStonesOnceBtn.Enabled = false;
            GrowStonesOnceBtn.Enabled = false;
            PolishGrowBtn.Enabled = false;
            PolishStonesOnce();
            PolishGrowBtn.Enabled = true;
            PolishStonesOnceBtn.Enabled = true;
            GrowStonesOnceBtn.Enabled = true;
            isRunning = true;
            thread = new Thread(new ThreadStart(detectStones));
            thread.Start();
        }

        private void GrowStonesOnceBtn_Click(object sender, EventArgs e)
        {
            isRunning = false;
            polishOrGrow = true;
            PolishStonesOnceBtn.Enabled = false;
            GrowStonesOnceBtn.Enabled = false;
            PolishGrowBtn.Enabled = false;
            GrowStonesOnce();
            PolishStonesOnceBtn.Enabled = true;
            GrowStonesOnceBtn.Enabled = true;
            PolishGrowBtn.Enabled = true;
            isRunning = true;
            thread = new Thread(new ThreadStart(detectStones));
            thread.Start();
        }

        private bool MaterialExists(string name)
        {
            //unused method
            updatePerdictionList();
            if (positions.TryGetValue(name, out List<RectangleF> tempList))
            {
                return true;
            }
            return false;
        }

        private bool BlackStoneExists()
        {
            //unused method
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
            // Unregister Ctrl+Alt+F5 hotkey.
            hotKeyManager.Unregister(hotKey);

            // Dispose the hotkey manager.
            hotKeyManager.Dispose();
            thread.Join();
            while (thread.IsAlive) { }
        }

        private void updatePerdictionList()
        {
            toDisplay = CaptureScreen.Snip(sniplocation);
            perdictions = OBJ.getPerdictions(MakeGrayscale3(toDisplay));
            positions = OBJ.getPositions(perdictions);
        }

        private void stopRunning()
        {
            this.Close();
        }

        private void HotKeyManagerPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.HotKey.Key == Key.F5)
            {
                polishOrGrow = false;
            }
        }

        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                //create the grayscale ColorMatrix
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
                   });

                //create some image attributes
                using (ImageAttributes attributes = new ImageAttributes())
                {
                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }

        #endregion helper functions
    }
}