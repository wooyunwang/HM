namespace HM.FacePlatform.UserControls
{
    partial class ucFamily
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblUserType = new System.Windows.Forms.Label();
            this.lblDataFrom = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.picIsRegisted = new System.Windows.Forms.PictureBox();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIsRegisted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(110, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "姓名";
            // 
            // btnReg
            // 
            this.btnReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnReg.FlatAppearance.BorderSize = 0;
            this.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReg.Location = new System.Drawing.Point(251, 82);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(62, 25);
            this.btnReg.TabIndex = 10;
            this.btnReg.Text = "注册";
            this.btnReg.UseVisualStyleBackColor = false;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate.Location = new System.Drawing.Point(167, 82);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(62, 25);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "编辑";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Location = new System.Drawing.Point(110, 50);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(53, 12);
            this.lblUserType.TabIndex = 12;
            this.lblUserType.Text = "用户类型";
            // 
            // lblDataFrom
            // 
            this.lblDataFrom.AutoSize = true;
            this.lblDataFrom.Location = new System.Drawing.Point(251, 50);
            this.lblDataFrom.Name = "lblDataFrom";
            this.lblDataFrom.Size = new System.Drawing.Size(29, 12);
            this.lblDataFrom.TabIndex = 13;
            this.lblDataFrom.Text = "来源";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(251, 18);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(29, 12);
            this.lblSex.TabIndex = 14;
            this.lblSex.Text = "性别";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(196, 50);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(17, 12);
            this.lblId.TabIndex = 15;
            this.lblId.Text = "Id";
            this.lblId.Visible = false;
            // 
            // picIsRegisted
            // 
            this.picIsRegisted.Image = global::HM.FacePlatform.Properties.Resources.registed;
            this.picIsRegisted.Location = new System.Drawing.Point(110, 86);
            this.picIsRegisted.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picIsRegisted.Name = "picIsRegisted";
            this.picIsRegisted.Size = new System.Drawing.Size(50, 18);
            this.picIsRegisted.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picIsRegisted.TabIndex = 17;
            this.picIsRegisted.TabStop = false;
            // 
            // picPhoto
            // 
            this.picPhoto.BackColor = System.Drawing.Color.White;
            this.picPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPhoto.InitialImage = global::HM.FacePlatform.Properties.Resources.userPhoto;
            this.picPhoto.Location = new System.Drawing.Point(2, 10);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(85, 93);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 1;
            this.picPhoto.TabStop = false;
            // 
            // ucFamily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picIsRegisted);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblDataFrom);
            this.Controls.Add(this.lblUserType);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picPhoto);
            this.Name = "ucFamily";
            this.Size = new System.Drawing.Size(374, 114);
            this.Load += new System.EventHandler(this.ucFamily_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIsRegisted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblUserType;
        private System.Windows.Forms.Label lblDataFrom;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.PictureBox picIsRegisted;
    }
}
