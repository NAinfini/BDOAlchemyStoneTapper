namespace BDOAlchemyStoneTapper
{
    partial class Detection
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
            CaptureZonePictureBox = new System.Windows.Forms.PictureBox();
            PolishStonesOnceBtn = new System.Windows.Forms.Button();
            GrowStonesOnceBtn = new System.Windows.Forms.Button();
            PolishGrowBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)CaptureZonePictureBox).BeginInit();
            SuspendLayout();
            // 
            // CaptureZonePictureBox
            // 
            CaptureZonePictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CaptureZonePictureBox.Location = new System.Drawing.Point(0, 0);
            CaptureZonePictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            CaptureZonePictureBox.Name = "CaptureZonePictureBox";
            CaptureZonePictureBox.Size = new System.Drawing.Size(879, 695);
            CaptureZonePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            CaptureZonePictureBox.TabIndex = 0;
            CaptureZonePictureBox.TabStop = false;
            // 
            // PolishStonesOnceBtn
            // 
            PolishStonesOnceBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            PolishStonesOnceBtn.Location = new System.Drawing.Point(883, 649);
            PolishStonesOnceBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            PolishStonesOnceBtn.MaximumSize = new System.Drawing.Size(229, 53);
            PolishStonesOnceBtn.Name = "PolishStonesOnceBtn";
            PolishStonesOnceBtn.Size = new System.Drawing.Size(193, 53);
            PolishStonesOnceBtn.TabIndex = 5;
            PolishStonesOnceBtn.Text = "Polish Stones Once";
            PolishStonesOnceBtn.UseVisualStyleBackColor = true;
            PolishStonesOnceBtn.Click += tapStonesOnceBtn_Click;
            // 
            // GrowStonesOnceBtn
            // 
            GrowStonesOnceBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            GrowStonesOnceBtn.Location = new System.Drawing.Point(883, 591);
            GrowStonesOnceBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            GrowStonesOnceBtn.MaximumSize = new System.Drawing.Size(229, 53);
            GrowStonesOnceBtn.Name = "GrowStonesOnceBtn";
            GrowStonesOnceBtn.Size = new System.Drawing.Size(193, 53);
            GrowStonesOnceBtn.TabIndex = 6;
            GrowStonesOnceBtn.Text = "Grow Stones Once";
            GrowStonesOnceBtn.UseVisualStyleBackColor = true;
            GrowStonesOnceBtn.Click += GrowStonesOnceBtn_Click;
            // 
            // PolishGrowBtn
            // 
            PolishGrowBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            PolishGrowBtn.Location = new System.Drawing.Point(883, 532);
            PolishGrowBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            PolishGrowBtn.MaximumSize = new System.Drawing.Size(229, 53);
            PolishGrowBtn.Name = "PolishGrowBtn";
            PolishGrowBtn.Size = new System.Drawing.Size(193, 53);
            PolishGrowBtn.TabIndex = 7;
            PolishGrowBtn.Text = "Polish Grow Once";
            PolishGrowBtn.UseVisualStyleBackColor = true;
            PolishGrowBtn.Click += PolishGrowBtn_Click;
            // 
            // Detection
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1078, 703);
            Controls.Add(PolishGrowBtn);
            Controls.Add(GrowStonesOnceBtn);
            Controls.Add(PolishStonesOnceBtn);
            Controls.Add(CaptureZonePictureBox);
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            Name = "Detection";
            Text = "Detection";
            ((System.ComponentModel.ISupportInitialize)CaptureZonePictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox CaptureZonePictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PolishStonesOnceBtn;
        private System.Windows.Forms.Button GrowStonesOnceBtn;
        private System.Windows.Forms.Button PolishGrowBtn;
    }
}