namespace HM.FacePlatform.Forms
{
    partial class FaceJobFrm
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
            this.BtnClose = new HM.Form_.HMTile();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnClose.Enabled = false;
            this.BtnClose.Location = new System.Drawing.Point(20, 398);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(760, 32);
            this.BtnClose.TabIndex = 114;
            this.BtnClose.Text = "关闭";
            this.BtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessage.Location = new System.Drawing.Point(20, 60);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(760, 338);
            this.tbMessage.TabIndex = 115;
            // 
            // FaceJobFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.BtnClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FaceJobFrm";
            this.Text = "人脸操作";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FaceJobFrm_FormClosing);
            this.Load += new System.EventHandler(this.FaceJobFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Form_.HMTile BtnClose;
        private System.Windows.Forms.TextBox tbMessage;
    }
}