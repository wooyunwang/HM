namespace HM.FacePlatform
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
            this.MtpSystemUserManage = new MetroFramework.Controls.MetroTabPage();
            this.MtpRegister = new MetroFramework.Controls.MetroTabPage();
            this.MtpRegisterManage = new MetroFramework.Controls.MetroTabPage();
            this.MtpLog = new MetroFramework.Controls.MetroTabPage();
            this.TileResetPassword = new HM.Form_.HMTile();
            this.HtcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // HtcMain
            // 
            this.HtcMain.Controls.Add(this.MtpDataBase);
            this.HtcMain.Controls.Add(this.MtpCheck);
            this.HtcMain.Controls.Add(this.MtpRegister);
            this.HtcMain.Controls.Add(this.MtpRegisterManage);
            this.HtcMain.Controls.Add(this.MtpLog);
            this.HtcMain.Controls.Add(this.MtpSystemUserManage);
            this.HtcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HtcMain.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.HtcMain.ItemSize = new System.Drawing.Size(150, 36);
            this.HtcMain.Location = new System.Drawing.Point(20, 60);
            this.HtcMain.Margin = new System.Windows.Forms.Padding(2);
            this.HtcMain.Name = "HtcMain";
            this.HtcMain.SelectedIndex = 0;
            this.HtcMain.Size = new System.Drawing.Size(1160, 676);
            this.HtcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.HtcMain.TabIndex = 0;
            this.HtcMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HtcMain.SelectedIndexChanged += new System.EventHandler(this.HtcMain_SelectedIndexChanged);
            this.HtcMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.HtcMain_Selected);
            // 
            // MtpDataBase
            // 
            this.MtpDataBase.HorizontalScrollbarBarColor = true;
            this.MtpDataBase.Location = new System.Drawing.Point(4, 40);
            this.MtpDataBase.Name = "MtpDataBase";
            this.MtpDataBase.Size = new System.Drawing.Size(1152, 632);
            this.MtpDataBase.TabIndex = 0;
            this.MtpDataBase.Tag = "HM.FacePlatform.DataBase";
            this.MtpDataBase.Text = "基础数据";
            this.MtpDataBase.VerticalScrollbarBarColor = true;
            // 
            // MtpCheck
            // 
            this.MtpCheck.HorizontalScrollbarBarColor = true;
            this.MtpCheck.Location = new System.Drawing.Point(4, 40);
            this.MtpCheck.Name = "MtpCheck";
            this.MtpCheck.Size = new System.Drawing.Size(1152, 632);
            this.MtpCheck.TabIndex = 2;
            this.MtpCheck.Tag = "HM.FacePlatform.Check";
            this.MtpCheck.Text = "审核";
            this.MtpCheck.VerticalScrollbarBarColor = true;
            // 
            // MtpSystemUserManage
            // 
            this.MtpSystemUserManage.HorizontalScrollbarBarColor = true;
            this.MtpSystemUserManage.Location = new System.Drawing.Point(4, 40);
            this.MtpSystemUserManage.Name = "MtpSystemUserManage";
            this.MtpSystemUserManage.Size = new System.Drawing.Size(1152, 632);
            this.MtpSystemUserManage.TabIndex = 5;
            this.MtpSystemUserManage.Tag = "HM.FacePlatform.SystemUserManage";
            this.MtpSystemUserManage.Text = "登陆管理";
            this.MtpSystemUserManage.VerticalScrollbarBarColor = true;
            // 
            // MtpRegister
            // 
            this.MtpRegister.HorizontalScrollbarBarColor = true;
            this.MtpRegister.Location = new System.Drawing.Point(4, 40);
            this.MtpRegister.Name = "MtpRegister";
            this.MtpRegister.Size = new System.Drawing.Size(1152, 632);
            this.MtpRegister.TabIndex = 1;
            this.MtpRegister.Tag = "HM.FacePlatform.Register";
            this.MtpRegister.Text = "注册";
            this.MtpRegister.VerticalScrollbarBarColor = true;
            // 
            // MtpRegisterManage
            // 
            this.MtpRegisterManage.HorizontalScrollbarBarColor = true;
            this.MtpRegisterManage.Location = new System.Drawing.Point(4, 40);
            this.MtpRegisterManage.Name = "MtpRegisterManage";
            this.MtpRegisterManage.Size = new System.Drawing.Size(1152, 632);
            this.MtpRegisterManage.TabIndex = 3;
            this.MtpRegisterManage.Tag = "HM.FacePlatform.RegisterManage";
            this.MtpRegisterManage.Text = "注册管理";
            this.MtpRegisterManage.VerticalScrollbarBarColor = true;
            // 
            // MtpLog
            // 
            this.MtpLog.HorizontalScrollbarBarColor = true;
            this.MtpLog.Location = new System.Drawing.Point(4, 40);
            this.MtpLog.Name = "MtpLog";
            this.MtpLog.Size = new System.Drawing.Size(1152, 632);
            this.MtpLog.TabIndex = 4;
            this.MtpLog.Tag = "HM.FacePlatform.Log";
            this.MtpLog.Text = "日志";
            this.MtpLog.VerticalScrollbarBarColor = true;
            // 
            // TileResetPassword
            // 
            this.TileResetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TileResetPassword.Location = new System.Drawing.Point(1096, 28);
            this.TileResetPassword.Name = "TileResetPassword";
            this.TileResetPassword.Size = new System.Drawing.Size(80, 36);
            this.TileResetPassword.TabIndex = 2;
            this.TileResetPassword.Text = "修改密码";
            this.TileResetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TileResetPassword.TileImage = global::HM.FacePlatform.Properties.Resources.delete;
            this.TileResetPassword.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TileResetPassword.Click += new System.EventHandler(this.TileResetPassword_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1200, 756);
            this.Controls.Add(this.TileResetPassword);
            this.Controls.Add(this.HtcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "黑猫一号 · 人脸综合管理平台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
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
        private MetroFramework.Controls.MetroTabPage MtpSystemUserManage;
        private Form_.HMTile TileResetPassword;
    }
}

