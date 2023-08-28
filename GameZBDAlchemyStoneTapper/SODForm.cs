using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using Yolov7net;

namespace GameZBDAlchemyStoneTapper
{
    public partial class SODForm : Form
    {
        private Rectangle snipLocation;
        private List<string> selectedAlchemyStone = new List<string>();
        private List<string> selectedMaterial = new List<string>();
        private Bitmap toDisplay;
        private bool isRunning = false;
        private ObjectDetection OBJ;
        private Thread thread;
        private Detection dec;

        public SODForm()
        {
            InitializeComponent();
            HotkeysManager.AddHotkey(new GlobalHotkey(System.Windows.Input.ModifierKeys.Control, Key.C, () => { stopRunning(); }));
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
                        snipLocation = new Rectangle(tempArea.Location.X, tempArea.Location.Y, tempArea.Width, tempArea.Height);
                    }
                }

                dec = new Detection(snipLocation, selectedAlchemyStone, selectedMaterial);
                dec.Show();
                startBtn.Text = "stop";
            }
            else
            {
                stopRunning();
            }
        }

        private void stopRunning()
        {
            isRunning = false;
            startBtn.Text = "start";
            dec.Close();
        }
    }
}