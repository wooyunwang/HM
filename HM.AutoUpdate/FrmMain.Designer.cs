namespace HM.AutoUpdate
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.hmProgressBar1 = new HM.Form_.HMProgressBar();
            this.TxtDetail = new HM.Form_.HMTextBox();
            this.SuspendLayout();
            // 
            // hmProgressBar1
            // 
            this.hmProgressBar1.Location = new System.Drawing.Point(23, 82);
            this.hmProgressBar1.Name = "hmProgressBar1";
            this.hmProgressBar1.Size = new System.Drawing.Size(754, 23);
            this.hmProgressBar1.TabIndex = 0;
            this.hmProgressBar1.Value = 30;
            // 
            // TxtDetail
            // 
            this.TxtDetail.Location = new System.Drawing.Point(23, 111);
            this.TxtDetail.Multiline = true;
            this.TxtDetail.Name = "TxtDetail";
            this.TxtDetail.Size = new System.Drawing.Size(754, 230);
            this.TxtDetail.TabIndex = 1;
            this.TxtDetail.Text = "hmTextBox1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 365);
            this.Controls.Add(this.TxtDetail);
            this.Controls.Add(this.hmProgressBar1);
            this.Name = "FrmMain";
            this.Text = "黑猫一号自动升级程序";
            this.ResumeLayout(false);

        }

        #endregion

        private Form_.HMProgressBar hmProgressBar1;
        private Form_.HMTextBox TxtDetail;
    }
}

