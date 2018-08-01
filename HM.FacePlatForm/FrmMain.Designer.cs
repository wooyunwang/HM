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
            this.htcMain = new HM.Form_.HMTabControl();
            this.mtpDataBase = new MetroFramework.Controls.MetroTabPage();
            this.mtpRegister = new MetroFramework.Controls.MetroTabPage();
            this.mtpCheck = new MetroFramework.Controls.MetroTabPage();
            this.mtpRegisterManage = new MetroFramework.Controls.MetroTabPage();
            this.mtpLog = new MetroFramework.Controls.MetroTabPage();
            this.htcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // htcMain
            // 
            this.htcMain.Controls.Add(this.mtpDataBase);
            this.htcMain.Controls.Add(this.mtpCheck);
            this.htcMain.Controls.Add(this.mtpRegister);
            this.htcMain.Controls.Add(this.mtpRegisterManage);
            this.htcMain.Controls.Add(this.mtpLog);
            this.htcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htcMain.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.htcMain.ItemSize = new System.Drawing.Size(150, 36);
            this.htcMain.Location = new System.Drawing.Point(20, 60);
            this.htcMain.Margin = new System.Windows.Forms.Padding(2);
            this.htcMain.Name = "htcMain";
            this.htcMain.SelectedIndex = 2;
            this.htcMain.Size = new System.Drawing.Size(1160, 676);
            this.htcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.htcMain.TabIndex = 0;
            this.htcMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mtpDataBase
            // 
            this.mtpDataBase.HorizontalScrollbarBarColor = true;
            this.mtpDataBase.Location = new System.Drawing.Point(4, 40);
            this.mtpDataBase.Name = "mtpDataBase";
            this.mtpDataBase.Size = new System.Drawing.Size(1152, 632);
            this.mtpDataBase.TabIndex = 0;
            this.mtpDataBase.Tag = "HM.FacePlatform.DataBase";
            this.mtpDataBase.Text = "基础数据";
            this.mtpDataBase.VerticalScrollbarBarColor = true;
            // 
            // mtpRegister
            // 
            this.mtpRegister.HorizontalScrollbarBarColor = true;
            this.mtpRegister.Location = new System.Drawing.Point(4, 40);
            this.mtpRegister.Name = "mtpRegister";
            this.mtpRegister.Size = new System.Drawing.Size(1152, 632);
            this.mtpRegister.TabIndex = 1;
            this.mtpRegister.Tag = "HM.FacePlatform.Register";
            this.mtpRegister.Text = "注册";
            this.mtpRegister.VerticalScrollbarBarColor = true;
            // 
            // mtpCheck
            // 
            this.mtpCheck.HorizontalScrollbarBarColor = true;
            this.mtpCheck.Location = new System.Drawing.Point(4, 40);
            this.mtpCheck.Name = "mtpCheck";
            this.mtpCheck.Size = new System.Drawing.Size(1152, 632);
            this.mtpCheck.TabIndex = 2;
            this.mtpCheck.Tag = "HM.FacePlatform.Check";
            this.mtpCheck.Text = "审核";
            this.mtpCheck.VerticalScrollbarBarColor = true;
            // 
            // mtpRegisterManage
            // 
            this.mtpRegisterManage.HorizontalScrollbarBarColor = true;
            this.mtpRegisterManage.Location = new System.Drawing.Point(4, 40);
            this.mtpRegisterManage.Name = "mtpRegisterManage";
            this.mtpRegisterManage.Size = new System.Drawing.Size(1152, 632);
            this.mtpRegisterManage.TabIndex = 3;
            this.mtpRegisterManage.Tag = "HM.FacePlatform.RegisterManage";
            this.mtpRegisterManage.Text = "注册管理";
            this.mtpRegisterManage.VerticalScrollbarBarColor = true;
            // 
            // mtpLog
            // 
            this.mtpLog.HorizontalScrollbarBarColor = true;
            this.mtpLog.Location = new System.Drawing.Point(4, 40);
            this.mtpLog.Name = "mtpLog";
            this.mtpLog.Size = new System.Drawing.Size(1152, 632);
            this.mtpLog.TabIndex = 4;
            this.mtpLog.Tag = "HM.FacePlatform.Log";
            this.mtpLog.Text = "日志";
            this.mtpLog.VerticalScrollbarBarColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1200, 756);
            this.Controls.Add(this.htcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "黑猫一号 · 人脸综合管理平台";
            this.htcMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Form_.HMTabControl htcMain;
        private MetroFramework.Controls.MetroTabPage mtpDataBase;
        private MetroFramework.Controls.MetroTabPage mtpRegister;
        private MetroFramework.Controls.MetroTabPage mtpCheck;
        private MetroFramework.Controls.MetroTabPage mtpRegisterManage;
        private MetroFramework.Controls.MetroTabPage mtpLog;
    }
}

