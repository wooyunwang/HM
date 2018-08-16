namespace HM.FacePlatform
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cbxUserName = new System.Windows.Forms.CheckBox();
            this.cbxPassword = new System.Windows.Forms.CheckBox();
            this.txtUserName = new HM.Form_.Old.TextBox.RTextBox();
            this.txtPassword = new HM.Form_.Old.TextBox.RTextBox();
            this.btnLogin = new HM.Form_.HMTile();
            this.btnExit = new HM.Form_.HMTile();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Location = new System.Drawing.Point(81, 237);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(29, 12);
            this.lblUserName.TabIndex = 66;
            this.lblUserName.Text = "用户";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(81, 273);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(29, 12);
            this.lblPassword.TabIndex = 67;
            this.lblPassword.Text = "密码";
            // 
            // cbxUserName
            // 
            this.cbxUserName.AutoSize = true;
            this.cbxUserName.Location = new System.Drawing.Point(241, 239);
            this.cbxUserName.Name = "cbxUserName";
            this.cbxUserName.Size = new System.Drawing.Size(84, 16);
            this.cbxUserName.TabIndex = 5;
            this.cbxUserName.Text = "保存登录名";
            this.cbxUserName.UseVisualStyleBackColor = true;
            this.cbxUserName.Click += new System.EventHandler(this.cbxUserName_Click);
            // 
            // cbxPassword
            // 
            this.cbxPassword.AutoSize = true;
            this.cbxPassword.Location = new System.Drawing.Point(241, 271);
            this.cbxPassword.Name = "cbxPassword";
            this.cbxPassword.Size = new System.Drawing.Size(72, 16);
            this.cbxPassword.TabIndex = 6;
            this.cbxPassword.Text = "保存密码";
            this.cbxPassword.UseVisualStyleBackColor = true;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtUserName.HotBackColor = System.Drawing.Color.White;
            this.txtUserName.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.txtUserName.Location = new System.Drawing.Point(121, 233);
            this.txtUserName.LostBackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.LostBorderColor = System.Drawing.Color.Transparent;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(112, 23);
            this.txtUserName.TabIndex = 68;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPassword.HotBackColor = System.Drawing.Color.White;
            this.txtPassword.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.txtPassword.Location = new System.Drawing.Point(121, 267);
            this.txtPassword.LostBackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.LostBorderColor = System.Drawing.Color.Transparent;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(112, 23);
            this.txtPassword.TabIndex = 69;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(346, 233);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(65, 25);
            this.btnLogin.TabIndex = 70;
            this.btnLogin.Text = "登录";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(346, 267);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 25);
            this.btnExit.TabIndex = 71;
            this.btnExit.Text = "退出";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::HM.FacePlatform.Properties.Resources.原始图;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(523, 304);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.cbxPassword);
            this.Controls.Add(this.cbxUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "访客系统-登录";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox cbxUserName;
        private System.Windows.Forms.CheckBox cbxPassword;
        private HM.Form_.Old.TextBox.RTextBox txtUserName;
        private HM.Form_.Old.TextBox.RTextBox txtPassword;
        private HM.Form_.HMTile btnLogin;
        private HM.Form_.HMTile btnExit;
    }
}