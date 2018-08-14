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
            this.btnCheck = new System.Windows.Forms.Button();
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
            this.btnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheck.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCheck.Location = new System.Drawing.Point(352, 114);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(93, 38);
            this.btnCheck.TabIndex = 20;
            this.btnCheck.Text = "审核";
            this.btnCheck.UseVisualStyleBackColor = false;
            // 
            // abc
            // 
            this.abc.AutoSize = true;
            this.abc.Location = new System.Drawing.Point(172, 20);
            this.abc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.abc.Name = "abc";
            this.abc.Size = new System.Drawing.Size(53, 18);
            this.abc.TabIndex = 19;
            this.abc.Text = "姓名:";
            // 
            // picPhoto
            // 
            this.picPhoto.BackColor = System.Drawing.Color.White;
            this.picPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPhoto.InitialImage = global::HM.FacePlatform.Properties.Resources.userPhoto;
            this.picPhoto.Location = new System.Drawing.Point(8, 12);
            this.picPhoto.Margin = new System.Windows.Forms.Padding(4);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(128, 140);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 18;
            this.picPhoto.TabStop = false;
            // 
            // cbSel
            // 
            this.cbSel.AutoSize = true;
            this.cbSel.Location = new System.Drawing.Point(434, 8);
            this.cbSel.Margin = new System.Windows.Forms.Padding(4);
            this.cbSel.Name = "cbSel";
            this.cbSel.Size = new System.Drawing.Size(22, 21);
            this.cbSel.TabIndex = 21;
            this.cbSel.UseVisualStyleBackColor = true;
            this.cbSel.CheckedChanged += new System.EventHandler(this.cbSel_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "注册类型:";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(234, 20);
            this.labName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(0, 18);
            this.labName.TabIndex = 24;
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(234, 66);
            this.labTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(0, 18);
            this.labTime.TabIndex = 25;
            // 
            // labNum
            // 
            this.labNum.AutoSize = true;
            this.labNum.Location = new System.Drawing.Point(234, 112);
            this.labNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(0, 18);
            this.labNum.TabIndex = 26;
            // 
            // labRegType
            // 
            this.labRegType.AutoSize = true;
            this.labRegType.Location = new System.Drawing.Point(261, 114);
            this.labRegType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labRegType.Name = "labRegType";
            this.labRegType.Size = new System.Drawing.Size(0, 18);
            this.labRegType.TabIndex = 27;
            // 
            // labCheckState
            // 
            this.labCheckState.AutoSize = true;
            this.labCheckState.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCheckState.ForeColor = System.Drawing.Color.Green;
            this.labCheckState.Location = new System.Drawing.Point(370, 8);
            this.labCheckState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labCheckState.Name = "labCheckState";
            this.labCheckState.Size = new System.Drawing.Size(56, 22);
            this.labCheckState.TabIndex = 38;
            this.labCheckState.Text = "通过";
            this.labCheckState.Visible = false;
            // 
            // ucNoCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucNoCheck";
            this.Size = new System.Drawing.Size(462, 162);
            this.Load += new System.EventHandler(this.ucNoCheck_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucNoCheck_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
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
