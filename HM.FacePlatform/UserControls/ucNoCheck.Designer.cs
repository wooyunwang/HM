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
            this.abc = new System.Windows.Forms.Label();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.cbSel = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.labTime = new System.Windows.Forms.Label();
            this.labNum = new System.Windows.Forms.Label();
            this.labRegType = new System.Windows.Forms.Label();
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
            // abc
            // 
            this.abc.AutoSize = true;
            this.abc.Location = new System.Drawing.Point(115, 14);
            this.abc.Name = "abc";
            this.abc.Size = new System.Drawing.Size(35, 12);
            this.abc.TabIndex = 19;
            this.abc.Text = "姓名:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "注册类型:";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(156, 13);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(0, 12);
            this.labName.TabIndex = 24;
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(156, 44);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(0, 12);
            this.labTime.TabIndex = 25;
            // 
            // labNum
            // 
            this.labNum.AutoSize = true;
            this.labNum.Location = new System.Drawing.Point(156, 75);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(0, 12);
            this.labNum.TabIndex = 26;
            // 
            // labRegType
            // 
            this.labRegType.AutoSize = true;
            this.labRegType.Location = new System.Drawing.Point(174, 76);
            this.labRegType.Name = "labRegType";
            this.labRegType.Size = new System.Drawing.Size(0, 12);
            this.labRegType.TabIndex = 27;
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
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labCheckState);
            this.Controls.Add(this.cbSel);
            this.Controls.Add(this.labRegType);
            this.Controls.Add(this.labNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.abc);
            this.Name = "ucNoCheck";
            this.Size = new System.Drawing.Size(306, 106);
            this.Load += new System.EventHandler(this.ucNoCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HM.Form_.HMTile btnCheck;
        private System.Windows.Forms.Label abc;
        public System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.CheckBox cbSel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.Label labRegType;
        private System.Windows.Forms.Label labCheckState;
    }
}
