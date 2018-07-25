﻿namespace HM.CenterControl
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
            this.hmTabControl1.CustomBackground = true;
            this.hmTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hmTabControl1.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.hmTabControl1.ItemSize = new System.Drawing.Size(150, 36);
            this.hmTabControl1.Location = new System.Drawing.Point(20, 60);
            this.hmTabControl1.Name = "hmTabControl1";
            this.hmTabControl1.SelectedIndex = 0;
            this.hmTabControl1.Size = new System.Drawing.Size(1460, 720);
            this.hmTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.hmTabControl1.TabIndex = 0;
            this.hmTabControl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stpMoniter
            // 
            this.stpMoniter.HorizontalScrollbarBarColor = true;
            this.stpMoniter.HorizontalScrollbarHighlightOnWheel = true;
            this.stpMoniter.Location = new System.Drawing.Point(4, 40);
            this.stpMoniter.Name = "stpMoniter";
            this.stpMoniter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stpMoniter.Size = new System.Drawing.Size(1452, 676);
            this.stpMoniter.TabIndex = 0;
            this.stpMoniter.Tag = "HM.CenterControl.UCs.ucMoniter";
            this.stpMoniter.Text = "运行监控";
            this.stpMoniter.VerticalScrollbarBarColor = true;
            // 
            // stpLiveVideo
            // 
            this.stpLiveVideo.HorizontalScrollbarBarColor = true;
            this.stpLiveVideo.Location = new System.Drawing.Point(4, 40);
            this.stpLiveVideo.Name = "stpLiveVideo";
            this.stpLiveVideo.Size = new System.Drawing.Size(1452, 676);
            this.stpLiveVideo.TabIndex = 1;
            this.stpLiveVideo.Tag = "HM.CenterControl.UCs.ucLiveVideo";
            this.stpLiveVideo.Text = "现场视频";
            this.stpLiveVideo.VerticalScrollbarBarColor = true;
            // 
            // stpVisitor
            // 
            this.stpVisitor.HorizontalScrollbarBarColor = true;
            this.stpVisitor.Location = new System.Drawing.Point(4, 40);
            this.stpVisitor.Name = "stpVisitor";
            this.stpVisitor.Size = new System.Drawing.Size(1452, 676);
            this.stpVisitor.TabIndex = 2;
            this.stpVisitor.Tag = "HM.CenterControl.UCs.ucVisitor";
            this.stpVisitor.Text = "访客管理";
            this.stpVisitor.VerticalScrollbarBarColor = true;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 40);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(1452, 676);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "内容发布";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.Location = new System.Drawing.Point(4, 40);
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Size = new System.Drawing.Size(1452, 676);
            this.metroTabPage5.TabIndex = 4;
            this.metroTabPage5.Text = "系统管理";
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1500, 800);
            this.Controls.Add(this.hmTabControl1);
            this.Name = "FrmMain";
            this.Text = "黑猫一号集中管控中心";
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
