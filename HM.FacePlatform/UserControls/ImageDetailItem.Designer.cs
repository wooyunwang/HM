namespace HM.FacePlatform.UserControls
{
    partial class ImageDetailItem
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
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.LblRegisterType = new System.Windows.Forms.Label();
            this.LblCreateTime = new System.Windows.Forms.Label();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.LblCheckType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // picPhoto
            // 
            this.picPhoto.BackColor = System.Drawing.Color.White;
            this.picPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPhoto.InitialImage = global::HM.FacePlatform.Properties.Resources.userPhoto;
            this.picPhoto.Location = new System.Drawing.Point(37, 6);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(111, 114);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 12;
            this.picPhoto.TabStop = false;
            // 
            // LblRegisterType
            // 
            this.LblRegisterType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRegisterType.AutoSize = true;
            this.LblRegisterType.Location = new System.Drawing.Point(23, 127);
            this.LblRegisterType.Name = "LblRegisterType";
            this.LblRegisterType.Size = new System.Drawing.Size(53, 12);
            this.LblRegisterType.TabIndex = 13;
            this.LblRegisterType.Text = "注册类型";
            // 
            // LblCreateTime
            // 
            this.LblCreateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCreateTime.AutoSize = true;
            this.LblCreateTime.Location = new System.Drawing.Point(23, 169);
            this.LblCreateTime.Name = "LblCreateTime";
            this.LblCreateTime.Size = new System.Drawing.Size(53, 12);
            this.LblCreateTime.TabIndex = 14;
            this.LblCreateTime.Text = "注册时间";
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.BackgroundImage = global::HM.FacePlatform.Properties.Resources.delete;
            this.btnDeleteImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteImage.FlatAppearance.BorderSize = 0;
            this.btnDeleteImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteImage.Location = new System.Drawing.Point(127, 9);
            this.btnDeleteImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(17, 17);
            this.btnDeleteImage.TabIndex = 15;
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // LblCheckType
            // 
            this.LblCheckType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCheckType.AutoSize = true;
            this.LblCheckType.Location = new System.Drawing.Point(23, 147);
            this.LblCheckType.Name = "LblCheckType";
            this.LblCheckType.Size = new System.Drawing.Size(53, 12);
            this.LblCheckType.TabIndex = 16;
            this.LblCheckType.Text = "审核状态";
            // 
            // ImageDetailItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.Controls.Add(this.LblCheckType);
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.LblCreateTime);
            this.Controls.Add(this.LblRegisterType);
            this.Controls.Add(this.picPhoto);
            this.Name = "ImageDetailItem";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(182, 185);
            this.Load += new System.EventHandler(this.ImageDetailItem_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageDetailItem_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Label LblRegisterType;
        private System.Windows.Forms.Label LblCreateTime;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Label LblCheckType;
    }
}
