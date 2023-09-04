
namespace BDOAlchemyStoneTapper
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MainPanelAllSelection = new System.Windows.Forms.Panel();
            SOLMainPanelBtn = new System.Windows.Forms.Button();
            SOPMainPanelBtn = new System.Windows.Forms.Button();
            SODMainPanelBtn = new System.Windows.Forms.Button();
            MainPanelImage = new System.Windows.Forms.Panel();
            Logo = new System.Windows.Forms.PictureBox();
            panel3 = new System.Windows.Forms.Panel();
            NameOfFormLbl = new System.Windows.Forms.Label();
            SubSectionPanel = new System.Windows.Forms.Panel();
            fileSystemWatcher1 = new FileSystemWatcher();
            MainPanelAllSelection.SuspendLayout();
            MainPanelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // MainPanelAllSelection
            // 
            MainPanelAllSelection.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            MainPanelAllSelection.Controls.Add(SOLMainPanelBtn);
            MainPanelAllSelection.Controls.Add(SOPMainPanelBtn);
            MainPanelAllSelection.Controls.Add(SODMainPanelBtn);
            MainPanelAllSelection.Controls.Add(MainPanelImage);
            MainPanelAllSelection.Controls.Add(panel3);
            MainPanelAllSelection.Dock = System.Windows.Forms.DockStyle.Left;
            MainPanelAllSelection.Location = new System.Drawing.Point(0, 0);
            MainPanelAllSelection.Name = "MainPanelAllSelection";
            MainPanelAllSelection.Size = new System.Drawing.Size(235, 567);
            MainPanelAllSelection.TabIndex = 0;
            // 
            // SOLMainPanelBtn
            // 
            SOLMainPanelBtn.Dock = System.Windows.Forms.DockStyle.Top;
            SOLMainPanelBtn.FlatAppearance.BorderSize = 0;
            SOLMainPanelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(74, 86, 135);
            SOLMainPanelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SOLMainPanelBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            SOLMainPanelBtn.Image = (System.Drawing.Image)resources.GetObject("SOLMainPanelBtn.Image");
            SOLMainPanelBtn.Location = new System.Drawing.Point(0, 319);
            SOLMainPanelBtn.Name = "SOLMainPanelBtn";
            SOLMainPanelBtn.Size = new System.Drawing.Size(235, 86);
            SOLMainPanelBtn.TabIndex = 4;
            SOLMainPanelBtn.Text = "Stone of Life";
            SOLMainPanelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            SOLMainPanelBtn.UseVisualStyleBackColor = true;
            SOLMainPanelBtn.Click += SOLMainPanelBtn_Click;
            SOLMainPanelBtn.Leave += SOLMainPanelBtn_Leave;
            // 
            // SOPMainPanelBtn
            // 
            SOPMainPanelBtn.Dock = System.Windows.Forms.DockStyle.Top;
            SOPMainPanelBtn.FlatAppearance.BorderSize = 0;
            SOPMainPanelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(74, 86, 135);
            SOPMainPanelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SOPMainPanelBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            SOPMainPanelBtn.Image = (System.Drawing.Image)resources.GetObject("SOPMainPanelBtn.Image");
            SOPMainPanelBtn.Location = new System.Drawing.Point(0, 234);
            SOPMainPanelBtn.Name = "SOPMainPanelBtn";
            SOPMainPanelBtn.Size = new System.Drawing.Size(235, 85);
            SOPMainPanelBtn.TabIndex = 3;
            SOPMainPanelBtn.Text = "Stone of Protection";
            SOPMainPanelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            SOPMainPanelBtn.UseVisualStyleBackColor = true;
            SOPMainPanelBtn.Click += SOPMainPanelBtn_Click;
            SOPMainPanelBtn.Leave += SOPMainPanelBtn_Leave;
            // 
            // SODMainPanelBtn
            // 
            SODMainPanelBtn.Dock = System.Windows.Forms.DockStyle.Top;
            SODMainPanelBtn.FlatAppearance.BorderSize = 0;
            SODMainPanelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(74, 86, 135);
            SODMainPanelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SODMainPanelBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            SODMainPanelBtn.Image = (System.Drawing.Image)resources.GetObject("SODMainPanelBtn.Image");
            SODMainPanelBtn.Location = new System.Drawing.Point(0, 143);
            SODMainPanelBtn.Name = "SODMainPanelBtn";
            SODMainPanelBtn.Size = new System.Drawing.Size(235, 91);
            SODMainPanelBtn.TabIndex = 1;
            SODMainPanelBtn.Text = "Stone of Destruction";
            SODMainPanelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            SODMainPanelBtn.UseVisualStyleBackColor = true;
            SODMainPanelBtn.Click += SODMainPanelBtn_Click;
            SODMainPanelBtn.Leave += SODMainPanelBtn_Leave;
            // 
            // MainPanelImage
            // 
            MainPanelImage.Controls.Add(Logo);
            MainPanelImage.Dock = System.Windows.Forms.DockStyle.Top;
            MainPanelImage.Location = new System.Drawing.Point(0, 0);
            MainPanelImage.Name = "MainPanelImage";
            MainPanelImage.Size = new System.Drawing.Size(235, 143);
            MainPanelImage.TabIndex = 2;
            // 
            // Logo
            // 
            Logo.Image = (System.Drawing.Image)resources.GetObject("Logo.Image");
            Logo.Location = new System.Drawing.Point(83, 35);
            Logo.Name = "Logo";
            Logo.Size = new System.Drawing.Size(57, 78);
            Logo.TabIndex = 2;
            Logo.TabStop = false;
            // 
            // panel3
            // 
            panel3.Location = new System.Drawing.Point(19, 11);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(145, 83);
            panel3.TabIndex = 1;
            // 
            // NameOfFormLbl
            // 
            NameOfFormLbl.AutoSize = true;
            NameOfFormLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            NameOfFormLbl.ForeColor = System.Drawing.Color.White;
            NameOfFormLbl.Location = new System.Drawing.Point(269, 18);
            NameOfFormLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            NameOfFormLbl.Name = "NameOfFormLbl";
            NameOfFormLbl.Size = new System.Drawing.Size(0, 48);
            NameOfFormLbl.TabIndex = 2;
            // 
            // SubSectionPanel
            // 
            SubSectionPanel.Location = new System.Drawing.Point(241, 98);
            SubSectionPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            SubSectionPanel.Name = "SubSectionPanel";
            SubSectionPanel.Size = new System.Drawing.Size(755, 455);
            SubSectionPanel.TabIndex = 3;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(41, 53, 73);
            ClientSize = new System.Drawing.Size(1009, 567);
            Controls.Add(SubSectionPanel);
            Controls.Add(NameOfFormLbl);
            Controls.Add(MainPanelAllSelection);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "StoneTapper";
            MainPanelAllSelection.ResumeLayout(false);
            MainPanelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel MainPanelAllSelection;
        private System.Windows.Forms.Panel MainPanelImage;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button SOLMainPanelBtn;
        private System.Windows.Forms.Button SOPMainPanelBtn;
        private System.Windows.Forms.Button SODMainPanelBtn;
        private System.Windows.Forms.Label NameOfFormLbl;
        private System.Windows.Forms.Panel SubSectionPanel;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

