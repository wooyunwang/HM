namespace HM.FacePlatform.Forms
{
    partial class AddOrUpdateSystemUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrUpdateSystemUser));
            this.btnCancel = new HM.Form_.HMTile();
            this.btnSave = new HM.Form_.HMTile();
            this.txtPasswordConfirm = new HM.Form_.Old.TextBox.RTextBox();
            this.txtPassword = new HM.Form_.Old.TextBox.RTextBox();
            this.txtUserName = new HM.Form_.Old.TextBox.RTextBox();
            this.lblPasswordConfirm = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblStar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(60, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 25);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(174, 223);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 25);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.BackColor = System.Drawing.SystemColors.Window;
            this.txtPasswordConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordConfirm.HotBackColor = System.Drawing.Color.White;
            this.txtPasswordConfirm.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.txtPasswordConfirm.Location = new System.Drawing.Point(120, 173);
            this.txtPasswordConfirm.LostBackColor = System.Drawing.SystemColors.Window;
            this.txtPasswordConfirm.LostBorderColor = System.Drawing.Color.Transparent;
            this.txtPasswordConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.txtPasswordConfirm.MaxLength = 20;
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.PasswordChar = '*';
            this.txtPasswordConfirm.Size = new System.Drawing.Size(140, 21);
            this.txtPasswordConfirm.TabIndex = 16;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.HotBackColor = System.Drawing.Color.White;
            this.txtPassword.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.txtPassword.Location = new System.Drawing.Point(120, 135);
            this.txtPassword.LostBackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.LostBorderColor = System.Drawing.Color.Transparent;
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(140, 21);
            this.txtPassword.TabIndex = 15;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.HotBackColor = System.Drawing.Color.White;
            this.txtUserName.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.txtUserName.Location = new System.Drawing.Point(120, 93);
            this.txtUserName.LostBackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.LostBorderColor = System.Drawing.Color.Transparent;
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(140, 21);
            this.txtUserName.TabIndex = 11;
            // 
            // lblPasswordConfirm
            // 
            this.lblPasswordConfirm.AutoSize = true;
            this.lblPasswordConfirm.Location = new System.Drawing.Point(51, 175);
            this.lblPasswordConfirm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPasswordConfirm.Name = "lblPasswordConfirm";
            this.lblPasswordConfirm.Size = new System.Drawing.Size(65, 12);
            this.lblPasswordConfirm.TabIndex = 14;
            this.lblPasswordConfirm.Text = "确认密码：";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(51, 137);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(41, 12);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "密码：";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(51, 95);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(53, 12);
            this.lblUserName.TabIndex = 12;
            this.lblUserName.Text = "用户名：";
            // 
            // lblStar
            // 
            this.lblStar.AutoSize = true;
            this.lblStar.ForeColor = System.Drawing.Color.Red;
            this.lblStar.Location = new System.Drawing.Point(36, 95);
            this.lblStar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStar.Name = "lblStar";
            this.lblStar.Size = new System.Drawing.Size(11, 12);
            this.lblStar.TabIndex = 114;
            this.lblStar.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(36, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 115;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(36, 175);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 116;
            this.label2.Text = "*";
            // 
            // AddOrUpdateSystemUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 293);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPasswordConfirm);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPasswordConfirm);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddOrUpdateSystemUser";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Text = "新增登录用户";
            this.Load += new System.EventHandler(this.AddOrUpdateSystemUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HM.Form_.HMTile btnCancel;
        private HM.Form_.HMTile btnSave;
        private HM.Form_.Old.TextBox.RTextBox txtPasswordConfirm;
        private HM.Form_.Old.TextBox.RTextBox txtPassword;
        private HM.Form_.Old.TextBox.RTextBox txtUserName;
        private System.Windows.Forms.Label lblPasswordConfirm;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblStar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}