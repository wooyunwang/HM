namespace HM.FacePlatform.UserControls
{
    partial class UcFamily
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
            this.BtnReg = new HM.Form_.HMTile();
            this.BtnUpdate = new HM.Form_.HMTile();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblCountCompare = new System.Windows.Forms.Label();
            this.lblUserType = new System.Windows.Forms.Label();
            this.lblDataFrom = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.picIsRegisted = new System.Windows.Forms.PictureBox();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.BtnDelete = new HM.Form_.HMTile();
            ((System.ComponentModel.ISupportInitialize)(this.picIsRegisted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(101, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "姓名";
            // 
            // BtnReg
            // 
            this.BtnReg.Location = new System.Drawing.Point(228, 78);
            this.BtnReg.Name = "BtnReg";
            this.BtnReg.Size = new System.Drawing.Size(48, 25);
            this.BtnReg.TabIndex = 10;
            this.BtnReg.Text = "注册";
            this.BtnReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnReg.Click += new System.EventHandler(this.BtnReg_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(175, 78);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(48, 25);
            this.BtnUpdate.TabIndex = 11;
            this.BtnUpdate.Text = "编辑";
            this.BtnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // lblCountCompare
            // 
            this.lblCountCompare.AutoSize = true;
            this.lblCountCompare.Location = new System.Drawing.Point(127, 75);
            this.lblCountCompare.Name = "lblCountCompare";
            this.lblCountCompare.Size = new System.Drawing.Size(23, 12);
            this.lblCountCompare.TabIndex = 15;
            this.lblCountCompare.Text = "0-0";
            this.toolTip1.SetToolTip(this.lblCountCompare, "已审核-已注册");
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Location = new System.Drawing.Point(101, 50);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(53, 12);
            this.lblUserType.TabIndex = 12;
            this.lblUserType.Text = "用户类型";
            // 
            // lblDataFrom
            // 
            this.lblDataFrom.AutoSize = true;
            this.lblDataFrom.Location = new System.Drawing.Point(241, 50);
            this.lblDataFrom.Name = "lblDataFrom";
            this.lblDataFrom.Size = new System.Drawing.Size(29, 12);
            this.lblDataFrom.TabIndex = 13;
            this.lblDataFrom.Text = "来源";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(241, 18);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(29, 12);
            this.lblSex.TabIndex = 14;
            this.lblSex.Text = "性别";
            // 
            // picIsRegisted
            // 
            this.picIsRegisted.Image = global::HM.FacePlatform.Properties.Resources.registed;
            this.picIsRegisted.Location = new System.Drawing.Point(115, 89);
            this.picIsRegisted.Margin = new System.Windows.Forms.Padding(2);
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
            this.picPhoto.Location = new System.Drawing.Point(4, 10);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(85, 93);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 1;
            this.picPhoto.TabStop = false;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(281, 78);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(48, 25);
            this.BtnDelete.TabIndex = 18;
            this.BtnDelete.Text = "删除";
            this.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // UcFamily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.picIsRegisted);
            this.Controls.Add(this.lblCountCompare);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblDataFrom);
            this.Controls.Add(this.lblUserType);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnReg);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picPhoto);
            this.Name = "UcFamily";
            this.Size = new System.Drawing.Size(335, 112);
            this.Load += new System.EventHandler(this.ucFamily_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIsRegisted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Label lblName;
        private HM.Form_.HMTile BtnReg;
        private HM.Form_.HMTile BtnUpdate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblUserType;
        private System.Windows.Forms.Label lblDataFrom;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.PictureBox picIsRegisted;
        private System.Windows.Forms.Label lblCountCompare;
        private Form_.HMTile BtnDelete;
    }
}
