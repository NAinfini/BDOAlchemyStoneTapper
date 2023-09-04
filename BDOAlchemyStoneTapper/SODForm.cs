using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using Yolov7net;

namespace BDOAlchemyStoneTapper
{
    public partial class SODForm : Form
    {
        private Rectangle snipLocation;
        private List<string> selectedAlchemyStone = new List<string>();
        private bool isRunning = false;
        private Detection dec;

        public SODForm()
        {
            InitializeComponent();
            SODTopTextLbl.Text = language.Instance.UpgreadeFollowing;
            SODText2Lbl.Text = language.Instance.WithFollowingMaterials;
            startBtn.Text = language.Instance.Start;
            DelayShortLbl.Text = language.Instance.DelayShort;
            DelayTimeLong.Text = language.Instance.DelayLong;
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

                dec = new Detection(snipLocation, selectedAlchemyStone, "Destruction", Convert.ToInt32(DelayShortLbl.Text), Convert.ToInt32(DelayTimeLong.Text));
                dec.Show();
                dec.FormClosed += Dec_FormClosed;
                startBtn.Text = language.Instance.Stop;
            }
            else
            {
                stopRunning();
            }
        }

        private void Dec_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRunning = false;
            startBtn.Text = language.Instance.Start;
        }

        private void stopRunning()
        {
            isRunning = false;
            startBtn.Text = language.Instance.Start;
            dec.Close();
        }

        private void IntCHeck(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(((TextBox)sender).Text, "[^0-9]"))
            {
                MessageBox.Show(language.Instance.OnlyNumberErr);
                ((TextBox)sender).Text = "150";
            }
        }
    }
}