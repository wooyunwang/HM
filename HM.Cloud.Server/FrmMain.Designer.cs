namespace HM.Cloud.Server
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
            this.TxtConsole = new HM.Form_.HMTextBox();
            this.PnlCondition = new HM.Form_.HMPanel();
            this.BtnConsoleReset = new HM.Form_.HMButton();
            this.TxtKey = new HM.Form_.HMTextBox();
            this.LblKey = new HM.Form_.HMLabel();
            this.MtpAutoUpdate = new MetroFramework.Controls.MetroTabPage();
            this.PnlPackage = new HM.Form_.HMPanel();
            this.PagerPackage = new HM.Form_.HMPager();
            this.DgvPackage = new System.Windows.Forms.DataGridView();
            this.PnlPackageTool = new HM.Form_.HMPanel();
            this.MtpCat = new MetroFramework.Controls.MetroTabPage();
            this.PnlCat = new HM.Form_.HMPanel();
            this.DgvCat = new System.Windows.Forms.DataGridView();
            this.PnlCatTool = new HM.Form_.HMPanel();
            this.hmButton1 = new HM.Form_.HMButton();
            this.hmTextBox1 = new HM.Form_.HMTextBox();
            this.LblCatKey = new HM.Form_.HMLabel();
            this.PagerCat = new HM.Form_.HMPager();
            this.HtcMain.SuspendLayout();
            this.MtpConsole.SuspendLayout();
            this.PnlCondition.SuspendLayout();
            this.MtpAutoUpdate.SuspendLayout();
            this.PnlPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPackage)).BeginInit();
            this.MtpCat.SuspendLayout();
            this.PnlCat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCat)).BeginInit();
            this.PnlCatTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // HtcMain
            // 
            this.HtcMain.Controls.Add(this.MtpConsole);
            this.HtcMain.Controls.Add(this.MtpAutoUpdate);
            this.HtcMain.Controls.Add(this.MtpCat);
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
            // TxtConsole
            // 
            this.TxtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtConsole.Location = new System.Drawing.Point(0, 60);
            this.TxtConsole.Multiline = true;
            this.TxtConsole.Name = "TxtConsole";
            this.TxtConsole.ReadOnly = true;
            this.TxtConsole.Size = new System.Drawing.Size(1152, 624);
            this.TxtConsole.TabIndex = 4;
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
            this.PnlCondition.Location = new System.Drawing.Point(0, 4);
            this.PnlCondition.Name = "PnlCondition";
            this.PnlCondition.Size = new System.Drawing.Size(1152, 50);
            this.PnlCondition.TabIndex = 3;
            this.PnlCondition.VerticalScrollbarBarColor = true;
            this.PnlCondition.VerticalScrollbarHighlightOnWheel = false;
            this.PnlCondition.VerticalScrollbarSize = 10;
            // 
            // BtnConsoleReset
            // 
            this.BtnConsoleReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConsoleReset.Location = new System.Drawing.Point(1039, 15);
            this.BtnConsoleReset.Name = "BtnConsoleReset";
            this.BtnConsoleReset.Size = new System.Drawing.Size(75, 19);
            this.BtnConsoleReset.TabIndex = 4;
            this.BtnConsoleReset.Text = "重置";
            // 
            // TxtKey
            // 
            this.TxtKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtKey.Location = new System.Drawing.Point(856, 15);
            this.TxtKey.Name = "TxtKey";
            this.TxtKey.Size = new System.Drawing.Size(177, 19);
            this.TxtKey.TabIndex = 3;
            // 
            // LblKey
            // 
            this.LblKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblKey.AutoSize = true;
            this.LblKey.Location = new System.Drawing.Point(785, 15);
            this.LblKey.Name = "LblKey";
            this.LblKey.Size = new System.Drawing.Size(65, 19);
            this.LblKey.TabIndex = 2;
            this.LblKey.Text = "过滤条件";
            // 
            // MtpAutoUpdate
            // 
            this.MtpAutoUpdate.Controls.Add(this.PnlPackage);
            this.MtpAutoUpdate.HorizontalScrollbarBarColor = true;
            this.MtpAutoUpdate.Location = new System.Drawing.Point(4, 36);
            this.MtpAutoUpdate.Name = "MtpAutoUpdate";
            this.MtpAutoUpdate.Size = new System.Drawing.Size(1152, 680);
            this.MtpAutoUpdate.TabIndex = 1;
            this.MtpAutoUpdate.Text = "更新包管理";
            this.MtpAutoUpdate.VerticalScrollbarBarColor = true;
            // 
            // PnlPackage
            // 
            this.PnlPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlPackage.Controls.Add(this.PagerPackage);
            this.PnlPackage.Controls.Add(this.DgvPackage);
            this.PnlPackage.Controls.Add(this.PnlPackageTool);
            this.PnlPackage.HorizontalScrollbarBarColor = true;
            this.PnlPackage.HorizontalScrollbarHighlightOnWheel = false;
            this.PnlPackage.HorizontalScrollbarSize = 10;
            this.PnlPackage.Location = new System.Drawing.Point(0, 3);
            this.PnlPackage.Name = "PnlPackage";
            this.PnlPackage.Size = new System.Drawing.Size(1153, 678);
            this.PnlPackage.TabIndex = 2;
            this.PnlPackage.VerticalScrollbarBarColor = true;
            this.PnlPackage.VerticalScrollbarHighlightOnWheel = false;
            this.PnlPackage.VerticalScrollbarSize = 10;
            // 
            // PagerPackage
            // 
            this.PagerPackage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PagerPackage.Location = new System.Drawing.Point(0, 654);
            this.PagerPackage.Name = "PagerPackage";
            this.PagerPackage.NMax = 0;
            this.PagerPackage.PageCount = 0;
            this.PagerPackage.PageCurrent = 1;
            this.PagerPackage.PageSize = 20;
            this.PagerPackage.Size = new System.Drawing.Size(1153, 24);
            this.PagerPackage.TabIndex = 9;
            // 
            // DgvPackage
            // 
            this.DgvPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvPackage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPackage.Location = new System.Drawing.Point(12, 60);
            this.DgvPackage.Name = "DgvPackage";
            this.DgvPackage.Size = new System.Drawing.Size(1126, 588);
            this.DgvPackage.TabIndex = 8;
            // 
            // PnlPackageTool
            // 
            this.PnlPackageTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPackageTool.HorizontalScrollbarBarColor = true;
            this.PnlPackageTool.HorizontalScrollbarHighlightOnWheel = false;
            this.PnlPackageTool.HorizontalScrollbarSize = 10;
            this.PnlPackageTool.Location = new System.Drawing.Point(0, 0);
            this.PnlPackageTool.Name = "PnlPackageTool";
            this.PnlPackageTool.Size = new System.Drawing.Size(1153, 54);
            this.PnlPackageTool.TabIndex = 7;
            this.PnlPackageTool.VerticalScrollbarBarColor = true;
            this.PnlPackageTool.VerticalScrollbarHighlightOnWheel = false;
            this.PnlPackageTool.VerticalScrollbarSize = 10;
            // 
            // MtpCat
            // 
            this.MtpCat.Controls.Add(this.PnlCat);
            this.MtpCat.HorizontalScrollbarBarColor = true;
            this.MtpCat.Location = new System.Drawing.Point(4, 36);
            this.MtpCat.Name = "MtpCat";
            this.MtpCat.Size = new System.Drawing.Size(1152, 680);
            this.MtpCat.TabIndex = 2;
            this.MtpCat.Text = "猫";
            this.MtpCat.VerticalScrollbarBarColor = true;
            // 
            // PnlCat
            // 
            this.PnlCat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlCat.Controls.Add(this.DgvCat);
            this.PnlCat.Controls.Add(this.PnlCatTool);
            this.PnlCat.Controls.Add(this.PagerCat);
            this.PnlCat.HorizontalScrollbarBarColor = true;
            this.PnlCat.HorizontalScrollbarHighlightOnWheel = false;
            this.PnlCat.HorizontalScrollbarSize = 10;
            this.PnlCat.Location = new System.Drawing.Point(0, 3);
            this.PnlCat.Name = "PnlCat";
            this.PnlCat.Size = new System.Drawing.Size(1152, 676);
            this.PnlCat.TabIndex = 3;
            this.PnlCat.VerticalScrollbarBarColor = true;
            this.PnlCat.VerticalScrollbarHighlightOnWheel = false;
            this.PnlCat.VerticalScrollbarSize = 10;
            // 
            // DgvCat
            // 
            this.DgvCat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCat.Location = new System.Drawing.Point(13, 60);
            this.DgvCat.Name = "DgvCat";
            this.DgvCat.Size = new System.Drawing.Size(1126, 586);
            this.DgvCat.TabIndex = 8;
            // 
            // PnlCatTool
            // 
            this.PnlCatTool.Controls.Add(this.hmButton1);
            this.PnlCatTool.Controls.Add(this.hmTextBox1);
            this.PnlCatTool.Controls.Add(this.LblCatKey);
            this.PnlCatTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlCatTool.HorizontalScrollbarBarColor = true;
            this.PnlCatTool.HorizontalScrollbarHighlightOnWheel = false;
            this.PnlCatTool.HorizontalScrollbarSize = 10;
            this.PnlCatTool.Location = new System.Drawing.Point(0, 0);
            this.PnlCatTool.Name = "PnlCatTool";
            this.PnlCatTool.Size = new System.Drawing.Size(1152, 54);
            this.PnlCatTool.TabIndex = 7;
            this.PnlCatTool.VerticalScrollbarBarColor = true;
            this.PnlCatTool.VerticalScrollbarHighlightOnWheel = false;
            this.PnlCatTool.VerticalScrollbarSize = 10;
            // 
            // hmButton1
            // 
            this.hmButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hmButton1.Location = new System.Drawing.Point(526, 18);
            this.hmButton1.Name = "hmButton1";
            this.hmButton1.Size = new System.Drawing.Size(75, 19);
            this.hmButton1.TabIndex = 7;
            this.hmButton1.Text = "重置";
            // 
            // hmTextBox1
            // 
            this.hmTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hmTextBox1.Location = new System.Drawing.Point(121, 18);
            this.hmTextBox1.Name = "hmTextBox1";
            this.hmTextBox1.Size = new System.Drawing.Size(177, 19);
            this.hmTextBox1.TabIndex = 6;
            // 
            // LblCatKey
            // 
            this.LblCatKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCatKey.AutoSize = true;
            this.LblCatKey.Location = new System.Drawing.Point(38, 18);
            this.LblCatKey.Name = "LblCatKey";
            this.LblCatKey.Size = new System.Drawing.Size(51, 19);
            this.LblCatKey.TabIndex = 5;
            this.LblCatKey.Text = "关键词";
            // 
            // PagerCat
            // 
            this.PagerCat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PagerCat.Location = new System.Drawing.Point(0, 652);
            this.PagerCat.Name = "PagerCat";
            this.PagerCat.NMax = 0;
            this.PagerCat.PageCount = 0;
            this.PagerCat.PageCurrent = 1;
            this.PagerCat.PageSize = 20;
            this.PagerCat.Size = new System.Drawing.Size(1152, 24);
            this.PagerCat.TabIndex = 6;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.HtcMain);
            this.Name = "FrmMain";
            this.Text = "黑猫一号 · 数据上云 · 服务端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.HtcMain.ResumeLayout(false);
            this.MtpConsole.ResumeLayout(false);
            this.PnlCondition.ResumeLayout(false);
            this.PnlCondition.PerformLayout();
            this.MtpAutoUpdate.ResumeLayout(false);
            this.PnlPackage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPackage)).EndInit();
            this.MtpCat.ResumeLayout(false);
            this.PnlCat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCat)).EndInit();
            this.PnlCatTool.ResumeLayout(false);
            this.PnlCatTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Form_.HMTabControl HtcMain;
        private MetroFramework.Controls.MetroTabPage MtpConsole;
        private MetroFramework.Controls.MetroTabPage MtpCat;
        private MetroFramework.Controls.MetroTabPage MtpAutoUpdate;
        private Form_.HMTextBox TxtConsole;
        private Form_.HMPanel PnlCondition;
        private Form_.HMButton BtnConsoleReset;
        private Form_.HMTextBox TxtKey;
        private Form_.HMLabel LblKey;
        private Form_.HMPanel PnlPackage;
        private System.Windows.Forms.DataGridView DgvPackage;
        private Form_.HMPanel PnlPackageTool;
        private Form_.HMPanel PnlCat;
        private System.Windows.Forms.DataGridView DgvCat;
        private Form_.HMPanel PnlCatTool;
        private Form_.HMPager PagerCat;
        private Form_.HMButton hmButton1;
        private Form_.HMTextBox hmTextBox1;
        private Form_.HMLabel LblCatKey;
        private Form_.HMPager PagerPackage;
    }
}

