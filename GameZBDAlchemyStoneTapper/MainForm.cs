using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.Json;

using System.IO;
using System.Windows.Input;

namespace GameZBDAlchemyStoneTapper
{
    public partial class MainForm : Form
    {
        public language Lan = new language();

        public MainForm()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            loadJson();
            Closing += MainWindow_Closing;
        }

        private void loadJson()
        {
            try
            {
                string text = File.ReadAllText(@"./DefaultLanguage.json");
                Lan = JsonSerializer.Deserialize<language>(text);
                language.CopyToStatic(Lan);
                this.Text = language.Instance.ProjectName;
                SODMainPanelBtn.Text = language.Instance.SOD;
                SOPMainPanelBtn.Text = language.Instance.SOP;
                SOLMainPanelBtn.Text = language.Instance.SOL;
            }
            catch (FileNotFoundException E)
            {
                MessageBox.Show("Could not find DefaultLanguage.json");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void SODMainPanelBtn_Click(object sender, EventArgs e)
        {
            MainPanelAllSelection.Height = SODMainPanelBtn.Height;
            MainPanelAllSelection.Top = SODMainPanelBtn.Top;
            MainPanelAllSelection.Left = SODMainPanelBtn.Left;
            SODMainPanelBtn.BackColor = Color.FromArgb(46, 51, 73);

            NameOfFormLbl.Text = language.Instance.SOD;
            this.SubSectionPanel.Controls.Clear();
            SODForm SODFormInstance = new SODForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            SODFormInstance.FormBorderStyle = FormBorderStyle.None;
            this.SubSectionPanel.Controls.Add(SODFormInstance);
            SODFormInstance.Show();
        }

        private void SOPMainPanelBtn_Click(object sender, EventArgs e)
        {
            MainPanelAllSelection.Height = SOPMainPanelBtn.Height;
            MainPanelAllSelection.Top = SOPMainPanelBtn.Top;
            MainPanelAllSelection.Left = SODMainPanelBtn.Left;
            SOPMainPanelBtn.BackColor = Color.FromArgb(46, 51, 73);

            NameOfFormLbl.Text = language.Instance.SOP;
            this.SubSectionPanel.Controls.Clear();
            SOPForm SOPFormInstance = new SOPForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            SOPFormInstance.FormBorderStyle = FormBorderStyle.None;
            this.SubSectionPanel.Controls.Add(SOPFormInstance);
            SOPFormInstance.Show();
        }

        private void SOLMainPanelBtn_Click(object sender, EventArgs e)
        {
            MainPanelAllSelection.Height = SOLMainPanelBtn.Height;
            MainPanelAllSelection.Top = SOLMainPanelBtn.Top;
            MainPanelAllSelection.Left = SOLMainPanelBtn.Left;
            SOLMainPanelBtn.BackColor = Color.FromArgb(46, 51, 73);

            NameOfFormLbl.Text = language.Instance.SOL;
            this.SubSectionPanel.Controls.Clear();
            SOLForm SOLFormInstance = new SOLForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            SOLFormInstance.FormBorderStyle = FormBorderStyle.None;
            this.SubSectionPanel.Controls.Add(SOLFormInstance);
            SOLFormInstance.Show();
        }

        private void SODMainPanelBtn_Leave(object sender, EventArgs e)
        {
            SODMainPanelBtn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void SOPMainPanelBtn_Leave(object sender, EventArgs e)
        {
            SOPMainPanelBtn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void SOLMainPanelBtn_Leave(object sender, EventArgs e)
        {
            SOLMainPanelBtn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Need to shutdown the hook. idk what happens if
            // you dont, but it might cause a memory leak.
        }
    }
}