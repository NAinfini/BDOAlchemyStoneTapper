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
using System.Windows.Input;
using Yolov7net;

namespace BDOAlchemyStoneTapper
{
    public partial class SOLForm : Form
    {
        private Rectangle snipLocation;
        private List<string> selectedAlchemyStone = new List<string>();
        private bool isRunning = false;
        private Detection dec;

        public SOLForm()
        {
            InitializeComponent();
            SOLTopTextLbl.Text = language.Instance.UpgreadeFollowing;
            SOLText2Lbl.Text = language.Instance.WithFollowingMaterials;
            startBtn.Text = language.Instance.Start;
        }

        #region select area

        private void Imperfect_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void Rough_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void Polished_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void Sturdy_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void Sharp_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void Resplendent_Click(object sender, EventArgs e)
        {
            updateAlchemyStoneList(sender);
        }

        private void Splendid_Click(object sender, EventArgs e)
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

        #endregion select area

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

                dec = new Detection(snipLocation, selectedAlchemyStone, "Life");
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
    }
}