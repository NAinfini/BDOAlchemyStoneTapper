
namespace GameZBDAlchemyStoneTapper
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
            this.MainPanelAllSelection = new System.Windows.Forms.Panel();
            this.SOLMainPanelBtn = new System.Windows.Forms.Button();
            this.SOPMainPanelBtn = new System.Windows.Forms.Button();
            this.SODMainPanelBtn = new System.Windows.Forms.Button();
            this.MainPanelImage = new System.Windows.Forms.Panel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.NameOfFormLbl = new System.Windows.Forms.Label();
            this.SubSectionPanel = new System.Windows.Forms.Panel();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.MainPanelAllSelection.SuspendLayout();
            this.MainPanelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanelAllSelection
            // 
            this.MainPanelAllSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.MainPanelAllSelection.Controls.Add(this.SOLMainPanelBtn);
            this.MainPanelAllSelection.Controls.Add(this.SOPMainPanelBtn);
            this.MainPanelAllSelection.Controls.Add(this.SODMainPanelBtn);
            this.MainPanelAllSelection.Controls.Add(this.MainPanelImage);
            this.MainPanelAllSelection.Controls.Add(this.panel3);
            this.MainPanelAllSelection.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainPanelAllSelection.Location = new System.Drawing.Point(0, 0);
            this.MainPanelAllSelection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MainPanelAllSelection.Name = "MainPanelAllSelection";
            this.MainPanelAllSelection.Size = new System.Drawing.Size(176, 546);
            this.MainPanelAllSelection.TabIndex = 0;
            // 
            // SOLMainPanelBtn
            // 
            this.SOLMainPanelBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SOLMainPanelBtn.FlatAppearance.BorderSize = 0;
            this.SOLMainPanelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(86)))), ((int)(((byte)(135)))));
            this.SOLMainPanelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SOLMainPanelBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.SOLMainPanelBtn.Image = ((System.Drawing.Image)(resources.GetObject("SOLMainPanelBtn.Image")));
            this.SOLMainPanelBtn.Location = new System.Drawing.Point(0, 207);
            this.SOLMainPanelBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SOLMainPanelBtn.Name = "SOLMainPanelBtn";
            this.SOLMainPanelBtn.Size = new System.Drawing.Size(176, 56);
            this.SOLMainPanelBtn.TabIndex = 4;
            this.SOLMainPanelBtn.Text = "Stone of Life";
            this.SOLMainPanelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SOLMainPanelBtn.UseVisualStyleBackColor = true;
            this.SOLMainPanelBtn.Click += new System.EventHandler(this.SOLMainPanelBtn_Click);
            this.SOLMainPanelBtn.Leave += new System.EventHandler(this.SOLMainPanelBtn_Leave);
            // 
            // SOPMainPanelBtn
            // 
            this.SOPMainPanelBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SOPMainPanelBtn.FlatAppearance.BorderSize = 0;
            this.SOPMainPanelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(86)))), ((int)(((byte)(135)))));
            this.SOPMainPanelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SOPMainPanelBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.SOPMainPanelBtn.Image = ((System.Drawing.Image)(resources.GetObject("SOPMainPanelBtn.Image")));
            this.SOPMainPanelBtn.Location = new System.Drawing.Point(0, 152);
            this.SOPMainPanelBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SOPMainPanelBtn.Name = "SOPMainPanelBtn";
            this.SOPMainPanelBtn.Size = new System.Drawing.Size(176, 55);
            this.SOPMainPanelBtn.TabIndex = 3;
            this.SOPMainPanelBtn.Text = "Stone of Protection";
            this.SOPMainPanelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SOPMainPanelBtn.UseVisualStyleBackColor = true;
            this.SOPMainPanelBtn.Click += new System.EventHandler(this.SOPMainPanelBtn_Click);
            this.SOPMainPanelBtn.Leave += new System.EventHandler(this.SOPMainPanelBtn_Leave);
            // 
            // SODMainPanelBtn
            // 
            this.SODMainPanelBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SODMainPanelBtn.FlatAppearance.BorderSize = 0;
            this.SODMainPanelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(86)))), ((int)(((byte)(135)))));
            this.SODMainPanelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SODMainPanelBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.SODMainPanelBtn.Image = ((System.Drawing.Image)(resources.GetObject("SODMainPanelBtn.Image")));
            this.SODMainPanelBtn.Location = new System.Drawing.Point(0, 93);
            this.SODMainPanelBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SODMainPanelBtn.Name = "SODMainPanelBtn";
            this.SODMainPanelBtn.Size = new System.Drawing.Size(176, 59);
            this.SODMainPanelBtn.TabIndex = 1;
            this.SODMainPanelBtn.Text = "Stone of Destruction";
            this.SODMainPanelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SODMainPanelBtn.UseVisualStyleBackColor = true;
            this.SODMainPanelBtn.Click += new System.EventHandler(this.SODMainPanelBtn_Click);
            this.SODMainPanelBtn.Leave += new System.EventHandler(this.SODMainPanelBtn_Leave);
            // 
            // MainPanelImage
            // 
            this.MainPanelImage.Controls.Add(this.Logo);
            this.MainPanelImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainPanelImage.Location = new System.Drawing.Point(0, 0);
            this.MainPanelImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MainPanelImage.Name = "MainPanelImage";
            this.MainPanelImage.Size = new System.Drawing.Size(176, 93);
            this.MainPanelImage.TabIndex = 2;
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(62, 23);
            this.Logo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(43, 51);
            this.Logo.TabIndex = 2;
            this.Logo.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(14, 7);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(109, 54);
            this.panel3.TabIndex = 1;
            // 
            // NameOfFormLbl
            // 
            this.NameOfFormLbl.AutoSize = true;
            this.NameOfFormLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameOfFormLbl.ForeColor = System.Drawing.Color.White;
            this.NameOfFormLbl.Location = new System.Drawing.Point(202, 12);
            this.NameOfFormLbl.Name = "NameOfFormLbl";
            this.NameOfFormLbl.Size = new System.Drawing.Size(109, 39);
            this.NameOfFormLbl.TabIndex = 2;
            this.NameOfFormLbl.Text = "label1";
            // 
            // SubSectionPanel
            // 
            this.SubSectionPanel.Location = new System.Drawing.Point(181, 64);
            this.SubSectionPanel.Name = "SubSectionPanel";
            this.SubSectionPanel.Size = new System.Drawing.Size(648, 470);
            this.SubSectionPanel.TabIndex = 3;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(841, 546);
            this.Controls.Add(this.SubSectionPanel);
            this.Controls.Add(this.NameOfFormLbl);
            this.Controls.Add(this.MainPanelAllSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MainPanelAllSelection.ResumeLayout(false);
            this.MainPanelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

