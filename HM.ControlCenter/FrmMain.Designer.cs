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
            this.hmTabControl1 = new HM.Form_.HMTabControl();
            this.stpMoniter = new MetroFramework.Controls.MetroTabPage();
            this.stpLiveVideo = new MetroFramework.Controls.MetroTabPage();
            this.stpVisitor = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.hmTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hmTabControl1
            // 
            this.hmTabControl1.Controls.Add(this.stpMoniter);
            this.hmTabControl1.Controls.Add(this.stpLiveVideo);
            this.hmTabControl1.Controls.Add(this.stpVisitor);
            this.hmTabControl1.Controls.Add(this.metroTabPage4);
            this.hmTabControl1.Controls.Add(this.metroTabPage5);
            this.hmTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hmTabControl1.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.hmTabControl1.ItemSize = new System.Drawing.Size(150, 36);
            this.hmTabControl1.Location = new System.Drawing.Point(15, 60);
            this.hmTabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.hmTabControl1.Name = "hmTabControl1";
            this.hmTabControl1.SelectedIndex = 1;
            this.hmTabControl1.Size = new System.Drawing.Size(1095, 564);
            this.hmTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.hmTabControl1.TabIndex = 0;
            this.hmTabControl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stpMoniter
            // 
            this.stpMoniter.HorizontalScrollbarBarColor = true;
            this.stpMoniter.HorizontalScrollbarHighlightOnWheel = true;
            this.stpMoniter.HorizontalScrollbarSize = 8;
            this.stpMoniter.Location = new System.Drawing.Point(4, 40);
            this.stpMoniter.Margin = new System.Windows.Forms.Padding(2);
            this.stpMoniter.Name = "stpMoniter";
            this.stpMoniter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stpMoniter.Size = new System.Drawing.Size(1087, 520);
            this.stpMoniter.TabIndex = 0;
            this.stpMoniter.Tag = "HM.ControlCenter.UCs.ucMoniter";
            this.stpMoniter.Text = "运行监控";
            this.stpMoniter.VerticalScrollbarBarColor = true;
            this.stpMoniter.VerticalScrollbarSize = 8;
            // 
            // stpLiveVideo
            // 
            this.stpLiveVideo.HorizontalScrollbarBarColor = true;
            this.stpLiveVideo.HorizontalScrollbarSize = 8;
            this.stpLiveVideo.Location = new System.Drawing.Point(4, 40);
            this.stpLiveVideo.Margin = new System.Windows.Forms.Padding(2);
            this.stpLiveVideo.Name = "stpLiveVideo";
            this.stpLiveVideo.Size = new System.Drawing.Size(1087, 520);
            this.stpLiveVideo.TabIndex = 1;
            this.stpLiveVideo.Tag = "HM.ControlCenter.UCs.ucLiveVideo";
            this.stpLiveVideo.Text = "现场视频";
            this.stpLiveVideo.VerticalScrollbarBarColor = true;
            this.stpLiveVideo.VerticalScrollbarSize = 8;
            // 
            // stpVisitor
            // 
            this.stpVisitor.HorizontalScrollbarBarColor = true;
            this.stpVisitor.HorizontalScrollbarSize = 8;
            this.stpVisitor.Location = new System.Drawing.Point(4, 40);
            this.stpVisitor.Margin = new System.Windows.Forms.Padding(2);
            this.stpVisitor.Name = "stpVisitor";
            this.stpVisitor.Size = new System.Drawing.Size(1087, 520);
            this.stpVisitor.TabIndex = 2;
            this.stpVisitor.Tag = "HM.ControlCenter.UCs.ucVisitor";
            this.stpVisitor.Text = "访客管理";
            this.stpVisitor.VerticalScrollbarBarColor = true;
            this.stpVisitor.VerticalScrollbarSize = 8;
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
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1125, 640);
            this.Controls.Add(this.hmTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "黑猫一号 · 集中管控中心";
            this.hmTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Form_.HMTabControl hmTabControl1;
        private MetroFramework.Controls.MetroTabPage stpMoniter;
        private MetroFramework.Controls.MetroTabPage stpLiveVideo;
        private MetroFramework.Controls.MetroTabPage stpVisitor;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
    }
}

