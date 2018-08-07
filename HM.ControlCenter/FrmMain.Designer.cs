namespace HM.ControlCenter
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.HtcMain = new HM.Form_.HMTabControl();
            this.MtpMoniter = new MetroFramework.Controls.MetroTabPage();
            this.MtpLiveVideo = new MetroFramework.Controls.MetroTabPage();
            this.MtpVisitor = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.HtcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // HtcMain
            // 
            this.HtcMain.Controls.Add(this.MtpMoniter);
            this.HtcMain.Controls.Add(this.MtpLiveVideo);
            this.HtcMain.Controls.Add(this.MtpVisitor);
            this.HtcMain.Controls.Add(this.metroTabPage4);
            this.HtcMain.Controls.Add(this.metroTabPage5);
            this.HtcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HtcMain.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.HtcMain.ItemSize = new System.Drawing.Size(150, 36);
            this.HtcMain.Location = new System.Drawing.Point(15, 60);
            this.HtcMain.Margin = new System.Windows.Forms.Padding(2);
            this.HtcMain.Name = "HtcMain";
            this.HtcMain.SelectedIndex = 1;
            this.HtcMain.Size = new System.Drawing.Size(1095, 564);
            this.HtcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.HtcMain.TabIndex = 0;
            this.HtcMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stpMoniter
            // 
            this.MtpMoniter.HorizontalScrollbarBarColor = true;
            this.MtpMoniter.HorizontalScrollbarHighlightOnWheel = true;
            this.MtpMoniter.HorizontalScrollbarSize = 8;
            this.MtpMoniter.Location = new System.Drawing.Point(4, 40);
            this.MtpMoniter.Margin = new System.Windows.Forms.Padding(2);
            this.MtpMoniter.Name = "stpMoniter";
            this.MtpMoniter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MtpMoniter.Size = new System.Drawing.Size(1087, 520);
            this.MtpMoniter.TabIndex = 0;
            this.MtpMoniter.Tag = "HM.ControlCenter.UCs.ucMoniter";
            this.MtpMoniter.Text = "运行监控";
            this.MtpMoniter.VerticalScrollbarBarColor = true;
            this.MtpMoniter.VerticalScrollbarSize = 8;
            // 
            // stpLiveVideo
            // 
            this.MtpLiveVideo.HorizontalScrollbarBarColor = true;
            this.MtpLiveVideo.HorizontalScrollbarSize = 8;
            this.MtpLiveVideo.Location = new System.Drawing.Point(4, 40);
            this.MtpLiveVideo.Margin = new System.Windows.Forms.Padding(2);
            this.MtpLiveVideo.Name = "stpLiveVideo";
            this.MtpLiveVideo.Size = new System.Drawing.Size(1087, 520);
            this.MtpLiveVideo.TabIndex = 1;
            this.MtpLiveVideo.Tag = "HM.ControlCenter.UCs.ucLiveVideo";
            this.MtpLiveVideo.Text = "现场视频";
            this.MtpLiveVideo.VerticalScrollbarBarColor = true;
            this.MtpLiveVideo.VerticalScrollbarSize = 8;
            // 
            // stpVisitor
            // 
            this.MtpVisitor.HorizontalScrollbarBarColor = true;
            this.MtpVisitor.HorizontalScrollbarSize = 8;
            this.MtpVisitor.Location = new System.Drawing.Point(4, 40);
            this.MtpVisitor.Margin = new System.Windows.Forms.Padding(2);
            this.MtpVisitor.Name = "stpVisitor";
            this.MtpVisitor.Size = new System.Drawing.Size(1087, 520);
            this.MtpVisitor.TabIndex = 2;
            this.MtpVisitor.Tag = "HM.ControlCenter.UCs.ucVisitor";
            this.MtpVisitor.Text = "访客管理";
            this.MtpVisitor.VerticalScrollbarBarColor = true;
            this.MtpVisitor.VerticalScrollbarSize = 8;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarSize = 8;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 40);
            this.metroTabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(1087, 520);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "内容发布";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarSize = 8;
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.HorizontalScrollbarSize = 8;
            this.metroTabPage5.Location = new System.Drawing.Point(4, 40);
            this.metroTabPage5.Margin = new System.Windows.Forms.Padding(2);
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Size = new System.Drawing.Size(1087, 520);
            this.metroTabPage5.TabIndex = 4;
            this.metroTabPage5.Text = "系统管理";
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            this.metroTabPage5.VerticalScrollbarSize = 8;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1125, 640);
            this.Controls.Add(this.HtcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Text = "黑猫一号 · 集中管控中心";
            this.HtcMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Form_.HMTabControl HtcMain;
        private MetroFramework.Controls.MetroTabPage MtpMoniter;
        private MetroFramework.Controls.MetroTabPage MtpLiveVideo;
        private MetroFramework.Controls.MetroTabPage MtpVisitor;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
    }
}

