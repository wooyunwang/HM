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
            this.lblRegisterType = new System.Windows.Forms.Label();
            this.labCreateTime = new System.Windows.Forms.Label();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // picPhoto
            // 
            this.picPhoto.BackColor = System.Drawing.Color.White;
            this.picPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPhoto.InitialImage = global::HM.FacePlatform.Properties.Resources.userPhoto;
            this.picPhoto.Location = new System.Drawing.Point(45, 4);
            this.picPhoto.Margin = new System.Windows.Forms.Padding(4);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(206, 171);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 12;
            this.picPhoto.TabStop = false;
            // 
            // lblRegisterType
            // 
            this.lblRegisterType.AutoSize = true;
            this.lblRegisterType.Location = new System.Drawing.Point(53, 190);
            this.lblRegisterType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegisterType.Name = "lblRegisterType";
            this.lblRegisterType.Size = new System.Drawing.Size(80, 18);
            this.lblRegisterType.TabIndex = 13;
            this.lblRegisterType.Text = "注册类型";
            // 
            // labCreateTime
            // 
            this.labCreateTime.AutoSize = true;
            this.labCreateTime.Location = new System.Drawing.Point(54, 224);
            this.labCreateTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labCreateTime.Name = "labCreateTime";
            this.labCreateTime.Size = new System.Drawing.Size(80, 18);
            this.labCreateTime.TabIndex = 14;
            this.labCreateTime.Text = "注册时间";
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.BackgroundImage = global::HM.FacePlatform.Properties.Resources.delete;
            this.btnDeleteImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteImage.FlatAppearance.BorderSize = 0;
            this.btnDeleteImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteImage.Location = new System.Drawing.Point(220, 8);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteImage.TabIndex = 15;
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // ImageDetailItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.labCreateTime);
            this.Controls.Add(this.lblRegisterType);
            this.Controls.Add(this.picPhoto);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ImageDetailItem";
            this.Size = new System.Drawing.Size(292, 258);
            this.Load += new System.EventHandler(this.ImageDetailItem_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageDetailItem_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Label lblRegisterType;
        private System.Windows.Forms.Label labCreateTime;
        private System.Windows.Forms.Button btnDeleteImage;
    }
}
