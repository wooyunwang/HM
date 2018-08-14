namespace HM.FacePlatform
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NAVI = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUserManage = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnRegisterManage = new System.Windows.Forms.Button();
            this.labState = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnDataBase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.tip = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTip = new System.Windows.Forms.StatusStrip();
            this.NAVI.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.statusTip.SuspendLayout();
            this.SuspendLayout();
            // 
            // NAVI
            // 
            this.NAVI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NAVI.BackColor = System.Drawing.Color.Black;
            this.NAVI.Controls.Add(this.panel2);
            this.NAVI.Controls.Add(this.pnlTop);
            this.NAVI.Location = new System.Drawing.Point(-4, -1);
            this.NAVI.Name = "NAVI";
            this.NAVI.Size = new System.Drawing.Size(1243, 54);
            this.NAVI.TabIndex = 0;
            this.NAVI.Click += new System.EventHandler(this.NavigationButtonClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnResetPassword);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnUserManage);
            this.panel2.Location = new System.Drawing.Point(983, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(214, 42);
            this.panel2.TabIndex = 8;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.FlatAppearance.BorderSize = 0;
            this.btnResetPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnResetPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnResetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetPassword.Location = new System.Drawing.Point(83, -15);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(67, 69);
            this.btnResetPassword.TabIndex = 10;
            this.btnResetPassword.Tag = "";
            this.btnResetPassword.Text = "修改密码";
            this.btnResetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(156, -15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(55, 69);
            this.btnExit.TabIndex = 6;
            this.btnExit.Tag = "";
            this.btnExit.Text = "退出";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUserManage
            // 
            this.btnUserManage.FlatAppearance.BorderSize = 0;
            this.btnUserManage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnUserManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserManage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUserManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManage.Location = new System.Drawing.Point(1, -15);
            this.btnUserManage.Name = "btnUserManage";
            this.btnUserManage.Size = new System.Drawing.Size(67, 69);
            this.btnUserManage.TabIndex = 9;
            this.btnUserManage.Tag = "HM.FacePlatform.SystemUserManage";
            this.btnUserManage.Text = "登录管理";
            this.btnUserManage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUserManage.UseVisualStyleBackColor = true;
            this.btnUserManage.Visible = false;
            this.btnUserManage.Click += new System.EventHandler(this.NavigationButtonClick);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnRegisterManage);
            this.pnlTop.Controls.Add(this.labState);
            this.pnlTop.Controls.Add(this.btnLog);
            this.pnlTop.Controls.Add(this.btnCount);
            this.pnlTop.Controls.Add(this.btnDataBase);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.btnCheck);
            this.pnlTop.Controls.Add(this.btnRegister);
            this.pnlTop.Location = new System.Drawing.Point(3, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(975, 63);
            this.pnlTop.TabIndex = 1;
            // 
            // btnRegisterManage
            // 
            this.btnRegisterManage.FlatAppearance.BorderSize = 0;
            this.btnRegisterManage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnRegisterManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterManage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegisterManage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegisterManage.Image = global::HM.FacePlatform.Properties.Resources.注册;
            this.btnRegisterManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegisterManage.Location = new System.Drawing.Point(643, -9);
            this.btnRegisterManage.Name = "btnRegisterManage";
            this.btnRegisterManage.Size = new System.Drawing.Size(94, 69);
            this.btnRegisterManage.TabIndex = 7;
            this.btnRegisterManage.Tag = "HM.FacePlatform.RegisterManage";
            this.btnRegisterManage.Text = "注册管理";
            this.btnRegisterManage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegisterManage.UseVisualStyleBackColor = true;
            this.btnRegisterManage.Click += new System.EventHandler(this.NavigationButtonClick);
            // 
            // labState
            // 
            this.labState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labState.AutoSize = true;
            this.labState.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labState.ForeColor = System.Drawing.Color.Red;
            this.labState.Location = new System.Drawing.Point(101, 20);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(0, 14);
            this.labState.TabIndex = 6;
            // 
            // btnLog
            // 
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLog.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLog.Image = global::HM.FacePlatform.Properties.Resources.日志;
            this.btnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLog.Location = new System.Drawing.Point(770, -9);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(79, 69);
            this.btnLog.TabIndex = 5;
            this.btnLog.Tag = "HM.FacePlatform.Log";
            this.btnLog.Text = "日志";
            this.btnLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.NavigationButtonClick);
            // 
            // btnCount
            // 
            this.btnCount.FlatAppearance.BorderSize = 0;
            this.btnCount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCount.Image = global::HM.FacePlatform.Properties.Resources.统计;
            this.btnCount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCount.Location = new System.Drawing.Point(881, -9);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(79, 69);
            this.btnCount.TabIndex = 4;
            this.btnCount.Tag = "HM.FacePlatform.Count";
            this.btnCount.Text = "统计";
            this.btnCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Visible = false;
            this.btnCount.Click += new System.EventHandler(this.NavigationButtonClick);
            this.btnCount.MouseEnter += new System.EventHandler(this.ButtonEnter);
            this.btnCount.MouseLeave += new System.EventHandler(this.ButtonLeave);
            // 
            // btnDataBase
            // 
            this.btnDataBase.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDataBase.FlatAppearance.BorderSize = 0;
            this.btnDataBase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnDataBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataBase.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDataBase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDataBase.Image = global::HM.FacePlatform.Properties.Resources.基础数据;
            this.btnDataBase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataBase.Location = new System.Drawing.Point(294, -9);
            this.btnDataBase.Name = "btnDataBase";
            this.btnDataBase.Size = new System.Drawing.Size(94, 69);
            this.btnDataBase.TabIndex = 1;
            this.btnDataBase.Tag = "HM.FacePlatform.DataBase";
            this.btnDataBase.Text = "基础数据";
            this.btnDataBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDataBase.UseVisualStyleBackColor = false;
            this.btnDataBase.Click += new System.EventHandler(this.NavigationButtonClick);
            this.btnDataBase.MouseEnter += new System.EventHandler(this.ButtonEnter);
            this.btnDataBase.MouseLeave += new System.EventHandler(this.ButtonLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(22, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "人脸综合管理平台";
            // 
            // btnCheck
            // 
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheck.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCheck.Image = global::HM.FacePlatform.Properties.Resources.审核;
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(532, -9);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(79, 69);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Tag = "HM.FacePlatform.Check";
            this.btnCheck.Text = "审核";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.NavigationButtonClick);
            this.btnCheck.MouseEnter += new System.EventHandler(this.ButtonEnter);
            this.btnCheck.MouseLeave += new System.EventHandler(this.ButtonLeave);
            // 
            // btnRegister
            // 
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegister.Image = global::HM.FacePlatform.Properties.Resources.注册;
            this.btnRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegister.Location = new System.Drawing.Point(421, -9);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(79, 69);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Tag = "HM.FacePlatform.Register";
            this.btnRegister.Text = "注册";
            this.btnRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.NavigationButtonClick);
            this.btnRegister.MouseEnter += new System.EventHandler(this.ButtonEnter);
            this.btnRegister.MouseLeave += new System.EventHandler(this.ButtonLeave);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.Location = new System.Drawing.Point(0, 50);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1216, 578);
            this.pnlBottom.TabIndex = 1;
            // 
            // tip
            // 
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(56, 17);
            this.tip.Text = "状态正常";
            // 
            // statusTip
            // 
            this.statusTip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusTip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tip});
            this.statusTip.Location = new System.Drawing.Point(0, 630);
            this.statusTip.Name = "statusTip";
            this.statusTip.Size = new System.Drawing.Size(1228, 22);
            this.statusTip.TabIndex = 2;
            this.statusTip.Text = "statusStrip1";
            this.statusTip.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 652);
            this.Controls.Add(this.statusTip);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.NAVI);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "人脸综合管理平台V1.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.NAVI.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.statusTip.ResumeLayout(false);
            this.statusTip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel NAVI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnDataBase;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.ToolStripStatusLabel tip;
        private System.Windows.Forms.StatusStrip statusTip;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.Button btnRegisterManage;
        private System.Windows.Forms.Button btnUserManage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnResetPassword;
    }
}

