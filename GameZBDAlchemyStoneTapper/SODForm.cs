using OpenCvSharp;
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
using OpenCvSharp.Extensions;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

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
                ((PictureBox)sender).BackColor = Color.FromArgb(41, 53, 73);
                ((PictureBox)sender).BorderStyle = BorderStyle.None;
            }
            else
            {
                selectedAlchemyStone.Add((((PictureBox)sender).Name));
                ((PictureBox)sender).BackColor = Color.FromArgb(52, 73, 235);
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
                ((PictureBox)sender).BackColor = Color.FromArgb(41, 53, 73);
                ((PictureBox)sender).BorderStyle = BorderStyle.None;
            }
            else
            {
                selectedMaterial.Add((((PictureBox)sender).Name));
                ((PictureBox)sender).BackColor = Color.FromArgb(52, 73, 235);
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
            while (true)
            {
                var oldPic = ScreenShotBox.Image;
                ScreenShotBox.Image = CaptureScreen.Snip(ScreenX, ScreenY, ScreenWidth, ScreenHeight); ;
                if (oldPic != null)
                {
                    oldPic.Dispose();
                }
                ScreenShotBox.Refresh();
            }
            /*
            List<Bitmap> allScreenShots  = CaptureScreen.TakeAllScreens();
            for(int i = 0; i < allScreenShots.Count; i++)
            {
                allScreenShots[i].Save(i.ToString() + "text.png", ImageFormat.Png);
            }
            //sc.CaptureWindow(process.Handle).Save("test.png", ImageFormat.Png);
            */
        }
    }
}