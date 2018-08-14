namespace HM.FacePlatform.Forms
{
    partial class ShowCamera
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
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
            this.pnl_video = new System.Windows.Forms.Panel();
            this.videoPlayer = new AForge.Controls.VideoSourcePlayer();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnCapture = new System.Windows.Forms.ToolStripButton();
            this.pnl_video.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_video
            // 
            this.pnl_video.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_video.Controls.Add(this.videoPlayer);
            this.pnl_video.Controls.Add(this.toolbar);
            this.pnl_video.Location = new System.Drawing.Point(29, 68);
            this.pnl_video.Name = "pnl_video";
            this.pnl_video.Size = new System.Drawing.Size(498, 390);
            this.pnl_video.TabIndex = 11;
            // 
            // videoPlayer
            // 
            this.videoPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayer.Location = new System.Drawing.Point(0, 39);
            this.videoPlayer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.videoPlayer.Name = "videoPlayer";
            this.videoPlayer.Size = new System.Drawing.Size(498, 351);
            this.videoPlayer.TabIndex = 23;
            this.videoPlayer.Text = "videoSourcePlayer1";
            this.videoPlayer.VideoSource = null;
            // 
            // toolbar
            // 
            this.toolbar.AllowMerge = false;
            this.toolbar.BackColor = System.Drawing.Color.Transparent;
            this.toolbar.CanOverflow = false;
            this.toolbar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCapture});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolbar.Size = new System.Drawing.Size(498, 39);
            this.toolbar.TabIndex = 22;
            // 
            // btnCapture
            // 
            this.btnCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCapture.Image = global::HM.FacePlatform.Properties.Resources.拍照_32;
            this.btnCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(36, 36);
            this.btnCapture.Text = "现场拍摄";
            this.btnCapture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCapture.ToolTipText = "现场拍摄";
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // ShowCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 484);
            this.Controls.Add(this.pnl_video);
            this.Name = "ShowCamera";
            this.Padding = new System.Windows.Forms.Padding(13, 40, 13, 13);
            this.Text = "摄像头";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowCamera_FormClosing);
            this.Load += new System.EventHandler(this.ShowCamera_Load);
            this.pnl_video.ResumeLayout(false);
            this.pnl_video.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_video;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton btnCapture;
        private AForge.Controls.VideoSourcePlayer videoPlayer;
    }
}