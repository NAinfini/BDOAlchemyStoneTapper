
namespace BDOAlchemyStoneTapper
{
    partial class SelectArea
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ApplyBtn = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ApplyBtn
            // 
            ApplyBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ApplyBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            ApplyBtn.Location = new System.Drawing.Point(470, 299);
            ApplyBtn.Margin = new System.Windows.Forms.Padding(2);
            ApplyBtn.Name = "ApplyBtn";
            ApplyBtn.Size = new System.Drawing.Size(87, 48);
            ApplyBtn.TabIndex = 0;
            ApplyBtn.Text = "Select";
            ApplyBtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(ApplyBtn);
            panel1.Location = new System.Drawing.Point(12, 14);
            panel1.Margin = new System.Windows.Forms.Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(561, 351);
            panel1.TabIndex = 1;
            panel1.MouseDown += SelectArea_MouseDown;
            // 
            // SelectArea
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(582, 375);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(2);
            Name = "SelectArea";
            Text = "SelectArea";
            MouseDown += SelectArea_MouseDown;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.Panel panel1;
    }
}