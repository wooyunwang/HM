namespace HM.FacePlatForm
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
            this.MtpDataBase = new MetroFramework.Controls.MetroTabPage();
            this.MtpCheck = new MetroFramework.Controls.MetroTabPage();
            this.MtpRegister = new MetroFramework.Controls.MetroTabPage();
            this.MtpRegisterManage = new MetroFramework.Controls.MetroTabPage();
            this.MtpLog = new MetroFramework.Controls.MetroTabPage();
            this.HtcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // HtcMain
            // 
            this.HtcMain.Controls.Add(this.MtpDataBase);
            this.HtcMain.Controls.Add(this.MtpRegister);
            this.HtcMain.Controls.Add(this.MtpCheck);
            this.HtcMain.Controls.Add(this.MtpRegisterManage);
            this.HtcMain.Controls.Add(this.MtpLog);
            this.HtcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HtcMain.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.HtcMain.ItemSize = new System.Drawing.Size(150, 36);
            this.HtcMain.Location = new System.Drawing.Point(20, 60);
            this.HtcMain.Margin = new System.Windows.Forms.Padding(2);
            this.HtcMain.Name = "HtcMain";
            this.HtcMain.SelectedIndex = 2;
            this.HtcMain.Size = new System.Drawing.Size(1160, 676);
            this.HtcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.HtcMain.TabIndex = 0;
            this.HtcMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mtpDataBase
            // 
            this.MtpDataBase.HorizontalScrollbarBarColor = true;
            this.MtpDataBase.Location = new System.Drawing.Point(4, 40);
            this.MtpDataBase.Name = "mtpDataBase";
            this.MtpDataBase.Size = new System.Drawing.Size(1152, 632);
            this.MtpDataBase.TabIndex = 0;
            this.MtpDataBase.Tag = "HM.FacePlatform.DataBase";
            this.MtpDataBase.Text = "基础数据";
            this.MtpDataBase.VerticalScrollbarBarColor = true;
            // 
            // mtpCheck
            // 
            this.MtpCheck.HorizontalScrollbarBarColor = true;
            this.MtpCheck.Location = new System.Drawing.Point(4, 40);
            this.MtpCheck.Name = "mtpCheck";
            this.MtpCheck.Size = new System.Drawing.Size(1152, 632);
            this.MtpCheck.TabIndex = 2;
            this.MtpCheck.Tag = "HM.FacePlatform.Check";
            this.MtpCheck.Text = "审核";
            this.MtpCheck.VerticalScrollbarBarColor = true;
            // 
            // mtpRegister
            // 
            this.MtpRegister.HorizontalScrollbarBarColor = true;
            this.MtpRegister.Location = new System.Drawing.Point(4, 40);
            this.MtpRegister.Name = "mtpRegister";
            this.MtpRegister.Size = new System.Drawing.Size(1152, 632);
            this.MtpRegister.TabIndex = 1;
            this.MtpRegister.Tag = "HM.FacePlatform.Register";
            this.MtpRegister.Text = "注册";
            this.MtpRegister.VerticalScrollbarBarColor = true;
            // 
            // mtpRegisterManage
            // 
            this.MtpRegisterManage.HorizontalScrollbarBarColor = true;
            this.MtpRegisterManage.Location = new System.Drawing.Point(4, 40);
            this.MtpRegisterManage.Name = "mtpRegisterManage";
            this.MtpRegisterManage.Size = new System.Drawing.Size(1152, 632);
            this.MtpRegisterManage.TabIndex = 3;
            this.MtpRegisterManage.Tag = "HM.FacePlatform.RegisterManage";
            this.MtpRegisterManage.Text = "注册管理";
            this.MtpRegisterManage.VerticalScrollbarBarColor = true;
            // 
            // mtpLog
            // 
            this.MtpLog.HorizontalScrollbarBarColor = true;
            this.MtpLog.Location = new System.Drawing.Point(4, 40);
            this.MtpLog.Name = "mtpLog";
            this.MtpLog.Size = new System.Drawing.Size(1152, 632);
            this.MtpLog.TabIndex = 4;
            this.MtpLog.Tag = "HM.FacePlatform.Log";
            this.MtpLog.Text = "日志";
            this.MtpLog.VerticalScrollbarBarColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1200, 756);
            this.Controls.Add(this.HtcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "黑猫一号 · 人脸综合管理平台";
            this.HtcMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Form_.HMTabControl HtcMain;
        private MetroFramework.Controls.MetroTabPage MtpDataBase;
        private MetroFramework.Controls.MetroTabPage MtpRegister;
        private MetroFramework.Controls.MetroTabPage MtpCheck;
        private MetroFramework.Controls.MetroTabPage MtpRegisterManage;
        private MetroFramework.Controls.MetroTabPage MtpLog;
    }
}

