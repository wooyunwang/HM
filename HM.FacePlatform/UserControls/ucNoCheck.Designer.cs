namespace HM.FacePlatform.UserControls
{
    partial class ucNoCheck
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
            this.btnCheck = new HM.Form_.HMTile();
            this.Lbl_Name = new System.Windows.Forms.Label();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.cbSel = new System.Windows.Forms.CheckBox();
            this.Lbl_Time = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.LblRegisterType = new System.Windows.Forms.Label();
            this.labCheckState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(235, 69);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(62, 25);
            this.btnCheck.TabIndex = 20;
            this.btnCheck.Text = "审核";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // Lbl_Name
            // 
            this.Lbl_Name.AutoSize = true;
            this.Lbl_Name.Location = new System.Drawing.Point(115, 14);
            this.Lbl_Name.Name = "Lbl_Name";
            this.Lbl_Name.Size = new System.Drawing.Size(35, 12);
            this.Lbl_Name.TabIndex = 19;
            this.Lbl_Name.Text = "姓名:";
            // 
            // picPhoto
            // 
            this.picPhoto.BackColor = System.Drawing.Color.White;
            this.picPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPhoto.InitialImage = global::HM.FacePlatform.Properties.Resources.userPhoto;
            this.picPhoto.Location = new System.Drawing.Point(5, 8);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(85, 93);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 18;
            this.picPhoto.TabStop = false;
            // 
            // cbSel
            // 
            this.cbSel.AutoSize = true;
            this.cbSel.Location = new System.Drawing.Point(285, 13);
            this.cbSel.Name = "cbSel";
            this.cbSel.Size = new System.Drawing.Size(15, 14);
            this.cbSel.TabIndex = 21;
            this.cbSel.UseVisualStyleBackColor = true;
            this.cbSel.CheckedChanged += new System.EventHandler(this.cbSel_CheckedChanged);
            // 
            // Lbl_Time
            // 
            this.Lbl_Time.AutoSize = true;
            this.Lbl_Time.Location = new System.Drawing.Point(115, 44);
            this.Lbl_Time.Name = "Lbl_Time";
            this.Lbl_Time.Size = new System.Drawing.Size(35, 12);
            this.Lbl_Time.TabIndex = 22;
            this.Lbl_Time.Text = "时间:";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(156, 13);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(17, 12);
            this.LblName.TabIndex = 24;
            this.LblName.Text = "__";
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Location = new System.Drawing.Point(156, 44);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(17, 12);
            this.LblTime.TabIndex = 25;
            this.LblTime.Text = "__";
            // 
            // LblRegisterType
            // 
            this.LblRegisterType.AutoSize = true;
            this.LblRegisterType.Location = new System.Drawing.Point(115, 74);
            this.LblRegisterType.Name = "LblRegisterType";
            this.LblRegisterType.Size = new System.Drawing.Size(53, 12);
            this.LblRegisterType.TabIndex = 27;
            this.LblRegisterType.Text = "注册类型";
            // 
            // labCheckState
            // 
            this.labCheckState.AutoSize = true;
            this.labCheckState.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCheckState.ForeColor = System.Drawing.Color.Green;
            this.labCheckState.Location = new System.Drawing.Point(238, 13);
            this.labCheckState.Name = "labCheckState";
            this.labCheckState.Size = new System.Drawing.Size(39, 15);
            this.labCheckState.TabIndex = 38;
            this.labCheckState.Text = "通过";
            this.labCheckState.Visible = false;
            // 
            // ucNoCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.Controls.Add(this.labCheckState);
            this.Controls.Add(this.cbSel);
            this.Controls.Add(this.LblRegisterType);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.LblTime);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.Lbl_Time);
            this.Controls.Add(this.Lbl_Name);
            this.Name = "ucNoCheck";
            this.Size = new System.Drawing.Size(306, 106);
            this.Load += new System.EventHandler(this.ucNoCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HM.Form_.HMTile btnCheck;
        private System.Windows.Forms.Label Lbl_Name;
        public System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.CheckBox cbSel;
        private System.Windows.Forms.Label Lbl_Time;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Label LblRegisterType;
        private System.Windows.Forms.Label labCheckState;
    }
}
