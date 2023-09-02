namespace GameZBDAlchemyStoneTapper
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            PolishStonesOnceBtn = new System.Windows.Forms.Button();
            GrowStonesOnceBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)CaptureZonePictureBox).BeginInit();
            SuspendLayout();
            // 
            // CaptureZonePictureBox
            // 
            CaptureZonePictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CaptureZonePictureBox.Location = new System.Drawing.Point(0, 0);
            CaptureZonePictureBox.Margin = new System.Windows.Forms.Padding(2);
            CaptureZonePictureBox.Name = "CaptureZonePictureBox";
            CaptureZonePictureBox.Size = new System.Drawing.Size(769, 521);
            CaptureZonePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            CaptureZonePictureBox.TabIndex = 0;
            CaptureZonePictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(787, 7);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(124, 15);
            label1.TabIndex = 1;
            label1.Text = "press Ctrl +C to break.";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(787, 30);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(787, 53);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(38, 15);
            label3.TabIndex = 4;
            label3.Text = "label3";
            // 
            // PolishStonesOnceBtn
            // 
            PolishStonesOnceBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            PolishStonesOnceBtn.Location = new System.Drawing.Point(773, 487);
            PolishStonesOnceBtn.Margin = new System.Windows.Forms.Padding(2);
            PolishStonesOnceBtn.MaximumSize = new System.Drawing.Size(200, 40);
            PolishStonesOnceBtn.Name = "PolishStonesOnceBtn";
            PolishStonesOnceBtn.Size = new System.Drawing.Size(169, 40);
            PolishStonesOnceBtn.TabIndex = 5;
            PolishStonesOnceBtn.Text = "Polish Stones Once";
            PolishStonesOnceBtn.UseVisualStyleBackColor = true;
            PolishStonesOnceBtn.Click += tapStonesOnceBtn_Click;
            // 
            // GrowStonesOnceBtn
            // 
            GrowStonesOnceBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            GrowStonesOnceBtn.Location = new System.Drawing.Point(773, 443);
            GrowStonesOnceBtn.Margin = new System.Windows.Forms.Padding(2);
            GrowStonesOnceBtn.MaximumSize = new System.Drawing.Size(200, 40);
            GrowStonesOnceBtn.Name = "GrowStonesOnceBtn";
            GrowStonesOnceBtn.Size = new System.Drawing.Size(169, 40);
            GrowStonesOnceBtn.TabIndex = 6;
            GrowStonesOnceBtn.Text = "Grow Stones Once";
            GrowStonesOnceBtn.UseVisualStyleBackColor = true;
            GrowStonesOnceBtn.Click += GrowStonesOnceBtn_Click;
            // 
            // Detection
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(943, 527);
            Controls.Add(GrowStonesOnceBtn);
            Controls.Add(PolishStonesOnceBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CaptureZonePictureBox);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "Detection";
            Text = "Detection";
            ((System.ComponentModel.ISupportInitialize)CaptureZonePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox CaptureZonePictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button PolishStonesOnceBtn;
        private System.Windows.Forms.Button GrowStonesOnceBtn;
    }
}