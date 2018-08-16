namespace HM.FacePlatform.BasicData
{
    partial class FrmLoadBaseData
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
            this.PnlMain = new System.Windows.Forms.Panel();
            this.TbShow = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new HM.Form_.HMProgressBar();
            this.BtnStartLoad = new HM.Form_.HMTile();
            this.BtnSelectFile = new HM.Form_.HMTile();
            this.TxtPicUrl = new HM.Form_.Old.TextBox.RTextBox();
            this.LblStep2 = new System.Windows.Forms.Label();
            this.LbtnLoadTemplate = new System.Windows.Forms.LinkLabel();
            this.LblStep1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.TbShow);
            this.PnlMain.Controls.Add(this.progressBar1);
            this.PnlMain.Controls.Add(this.BtnStartLoad);
            this.PnlMain.Controls.Add(this.BtnSelectFile);
            this.PnlMain.Controls.Add(this.TxtPicUrl);
            this.PnlMain.Controls.Add(this.LblStep2);
            this.PnlMain.Controls.Add(this.LbtnLoadTemplate);
            this.PnlMain.Controls.Add(this.LblStep1);
            this.PnlMain.Location = new System.Drawing.Point(38, 86);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(557, 387);
            this.PnlMain.TabIndex = 0;
            this.PnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // TbShow
            // 
            this.TbShow.Location = new System.Drawing.Point(82, 175);
            this.TbShow.Margin = new System.Windows.Forms.Padding(2);
            this.TbShow.Name = "TbShow";
            this.TbShow.Size = new System.Drawing.Size(404, 153);
            this.TbShow.TabIndex = 117;
            this.TbShow.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(82, 338);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(403, 23);
            this.progressBar1.TabIndex = 115;
            this.progressBar1.Visible = false;
            // 
            // BtnStartLoad
            // 
            this.BtnStartLoad.Location = new System.Drawing.Point(395, 133);
            this.BtnStartLoad.Name = "BtnStartLoad";
            this.BtnStartLoad.Size = new System.Drawing.Size(90, 35);
            this.BtnStartLoad.TabIndex = 113;
            this.BtnStartLoad.Text = "开始导入";
            this.BtnStartLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnStartLoad.Click += new System.EventHandler(this.btnStarLoad_Click);
            // 
            // BtnSelectFile
            // 
            this.BtnSelectFile.Location = new System.Drawing.Point(302, 139);
            this.BtnSelectFile.Name = "BtnSelectFile";
            this.BtnSelectFile.Size = new System.Drawing.Size(61, 23);
            this.BtnSelectFile.TabIndex = 112;
            this.BtnSelectFile.Text = "选择...";
            this.BtnSelectFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // TxtPicUrl
            // 
            this.TxtPicUrl.BackColor = System.Drawing.SystemColors.Window;
            this.TxtPicUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPicUrl.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.TxtPicUrl.HotBackColor = System.Drawing.Color.White;
            this.TxtPicUrl.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.TxtPicUrl.Location = new System.Drawing.Point(82, 139);
            this.TxtPicUrl.LostBackColor = System.Drawing.SystemColors.Window;
            this.TxtPicUrl.LostBorderColor = System.Drawing.Color.Transparent;
            this.TxtPicUrl.Name = "TxtPicUrl";
            this.TxtPicUrl.ReadOnly = true;
            this.TxtPicUrl.Size = new System.Drawing.Size(219, 23);
            this.TxtPicUrl.TabIndex = 111;
            // 
            // LblStep2
            // 
            this.LblStep2.AutoSize = true;
            this.LblStep2.Location = new System.Drawing.Point(32, 110);
            this.LblStep2.Name = "LblStep2";
            this.LblStep2.Size = new System.Drawing.Size(161, 12);
            this.LblStep2.TabIndex = 2;
            this.LblStep2.Text = "第二步：导入填写完成的模板";
            // 
            // LbtnLoadTemplate
            // 
            this.LbtnLoadTemplate.AutoSize = true;
            this.LbtnLoadTemplate.Location = new System.Drawing.Point(80, 65);
            this.LbtnLoadTemplate.Name = "LbtnLoadTemplate";
            this.LbtnLoadTemplate.Size = new System.Drawing.Size(149, 12);
            this.LbtnLoadTemplate.TabIndex = 1;
            this.LbtnLoadTemplate.TabStop = true;
            this.LbtnLoadTemplate.Text = "点击下载楼栋信息导入模板";
            this.LbtnLoadTemplate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnLoadTempt_LinkClicked);
            // 
            // LblStep1
            // 
            this.LblStep1.AutoSize = true;
            this.LblStep1.Location = new System.Drawing.Point(32, 35);
            this.LblStep1.Name = "LblStep1";
            this.LblStep1.Size = new System.Drawing.Size(101, 12);
            this.LblStep1.TabIndex = 0;
            this.LblStep1.Text = "第一步：下载模板";
            // 
            // FrmLoadBaseData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 498);
            this.Controls.Add(this.PnlMain);
            this.MaximizeBox = false;
            this.Name = "FrmLoadBaseData";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Resizable = false;
            this.ShowIcon = false;
            this.Text = "导入基础数据";
            this.Load += new System.EventHandler(this.FrmLoadBaseData_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Label LblStep2;
        private System.Windows.Forms.LinkLabel LbtnLoadTemplate;
        private System.Windows.Forms.Label LblStep1;
        private HM.Form_.Old.TextBox.RTextBox TxtPicUrl;
        private HM.Form_.HMTile BtnStartLoad;
        private HM.Form_.HMTile BtnSelectFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private HM.Form_.HMProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox TbShow;
    }
}