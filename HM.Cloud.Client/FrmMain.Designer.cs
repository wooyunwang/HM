namespace HM.Cloud.Client
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
            this.HtcMain = new HM.Form_.HMTabControl();
            this.MtpConsole = new MetroFramework.Controls.MetroTabPage();
            this.MtpSetting = new MetroFramework.Controls.MetroTabPage();
            this.TxtConsole = new HM.Form_.HMTextBox();
            this.PnlCondition = new HM.Form_.HMPanel();
            this.BtnConsoleReset = new HM.Form_.HMButton();
            this.TxtKey = new HM.Form_.HMTextBox();
            this.LblKey = new HM.Form_.HMLabel();
            this.MtpFace = new MetroFramework.Controls.MetroTabPage();
            this.HtcMain.SuspendLayout();
            this.MtpConsole.SuspendLayout();
            this.PnlCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // HtcMain
            // 
            this.HtcMain.Controls.Add(this.MtpConsole);
            this.HtcMain.Controls.Add(this.MtpFace);
            this.HtcMain.Controls.Add(this.MtpSetting);
            this.HtcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HtcMain.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.HtcMain.ItemSize = new System.Drawing.Size(150, 32);
            this.HtcMain.Location = new System.Drawing.Point(20, 60);
            this.HtcMain.Name = "HtcMain";
            this.HtcMain.SelectedIndex = 0;
            this.HtcMain.Size = new System.Drawing.Size(1160, 720);
            this.HtcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.HtcMain.TabIndex = 0;
            this.HtcMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MtpConsole
            // 
            this.MtpConsole.Controls.Add(this.TxtConsole);
            this.MtpConsole.Controls.Add(this.PnlCondition);
            this.MtpConsole.HorizontalScrollbarBarColor = true;
            this.MtpConsole.Location = new System.Drawing.Point(4, 36);
            this.MtpConsole.Name = "MtpConsole";
            this.MtpConsole.Size = new System.Drawing.Size(1152, 680);
            this.MtpConsole.TabIndex = 0;
            this.MtpConsole.Text = "控制台";
            this.MtpConsole.VerticalScrollbarBarColor = true;
            // 
            // MtpSetting
            // 
            this.MtpSetting.HorizontalScrollbarBarColor = true;
            this.MtpSetting.Location = new System.Drawing.Point(4, 36);
            this.MtpSetting.Name = "MtpSetting";
            this.MtpSetting.Size = new System.Drawing.Size(1152, 680);
            this.MtpSetting.TabIndex = 1;
            this.MtpSetting.Text = "设置";
            this.MtpSetting.VerticalScrollbarBarColor = true;
            // 
            // TxtConsole
            // 
            this.TxtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtConsole.Location = new System.Drawing.Point(3, 59);
            this.TxtConsole.Multiline = true;
            this.TxtConsole.Name = "TxtConsole";
            this.TxtConsole.ReadOnly = true;
            this.TxtConsole.Size = new System.Drawing.Size(1153, 625);
            this.TxtConsole.TabIndex = 6;
            // 
            // PnlCondition
            // 
            this.PnlCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlCondition.Controls.Add(this.BtnConsoleReset);
            this.PnlCondition.Controls.Add(this.TxtKey);
            this.PnlCondition.Controls.Add(this.LblKey);
            this.PnlCondition.HorizontalScrollbarBarColor = true;
            this.PnlCondition.HorizontalScrollbarHighlightOnWheel = false;
            this.PnlCondition.HorizontalScrollbarSize = 10;
            this.PnlCondition.Location = new System.Drawing.Point(3, 3);
            this.PnlCondition.Name = "PnlCondition";
            this.PnlCondition.Size = new System.Drawing.Size(1153, 50);
            this.PnlCondition.TabIndex = 5;
            this.PnlCondition.VerticalScrollbarBarColor = true;
            this.PnlCondition.VerticalScrollbarHighlightOnWheel = false;
            this.PnlCondition.VerticalScrollbarSize = 10;
            // 
            // BtnConsoleReset
            // 
            this.BtnConsoleReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConsoleReset.Location = new System.Drawing.Point(1040, 15);
            this.BtnConsoleReset.Name = "BtnConsoleReset";
            this.BtnConsoleReset.Size = new System.Drawing.Size(75, 19);
            this.BtnConsoleReset.TabIndex = 4;
            this.BtnConsoleReset.Text = "重置";
            // 
            // TxtKey
            // 
            this.TxtKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtKey.Location = new System.Drawing.Point(857, 15);
            this.TxtKey.Name = "TxtKey";
            this.TxtKey.Size = new System.Drawing.Size(177, 19);
            this.TxtKey.TabIndex = 3;
            // 
            // LblKey
            // 
            this.LblKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblKey.AutoSize = true;
            this.LblKey.Location = new System.Drawing.Point(786, 15);
            this.LblKey.Name = "LblKey";
            this.LblKey.Size = new System.Drawing.Size(65, 19);
            this.LblKey.TabIndex = 2;
            this.LblKey.Text = "过滤条件";
            // 
            // MtpFace
            // 
            this.MtpFace.HorizontalScrollbarBarColor = true;
            this.MtpFace.Location = new System.Drawing.Point(4, 36);
            this.MtpFace.Name = "MtpFace";
            this.MtpFace.Size = new System.Drawing.Size(1152, 680);
            this.MtpFace.TabIndex = 2;
            this.MtpFace.Text = "人脸数据同步";
            this.MtpFace.VerticalScrollbarBarColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.HtcMain);
            this.Name = "FrmMain";
            this.Text = "黑猫一号 · 数据上云 · 客户端";
            this.HtcMain.ResumeLayout(false);
            this.MtpConsole.ResumeLayout(false);
            this.PnlCondition.ResumeLayout(false);
            this.PnlCondition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Form_.HMTabControl HtcMain;
        private MetroFramework.Controls.MetroTabPage MtpConsole;
        private MetroFramework.Controls.MetroTabPage MtpSetting;
        private Form_.HMTextBox TxtConsole;
        private Form_.HMPanel PnlCondition;
        private Form_.HMButton BtnConsoleReset;
        private Form_.HMTextBox TxtKey;
        private Form_.HMLabel LblKey;
        private MetroFramework.Controls.MetroTabPage MtpFace;
    }
}

