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
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new HM.Form_.Old.ProgressBar();
            this.btnStarLoad = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.tbPicUrl = new HM.Form_.Old.TextBox.RTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbtnLoadTempt = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbShow = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbShow);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.btnStarLoad);
            this.panel1.Controls.Add(this.btnSelectFile);
            this.panel1.Controls.Add(this.tbPicUrl);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbtnLoadTempt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 580);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // progressBar1
            // 
            this.progressBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.progressBar1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.progressBar1.Location = new System.Drawing.Point(123, 507);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Maximum = 100;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(604, 34);
            this.progressBar1.TabIndex = 115;
            this.progressBar1.Value = 0;
            this.progressBar1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.progressBar1.Visible = false;
            // 
            // btnStarLoad
            // 
            this.btnStarLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnStarLoad.FlatAppearance.BorderSize = 0;
            this.btnStarLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStarLoad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStarLoad.Location = new System.Drawing.Point(592, 200);
            this.btnStarLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStarLoad.Name = "btnStarLoad";
            this.btnStarLoad.Size = new System.Drawing.Size(135, 52);
            this.btnStarLoad.TabIndex = 113;
            this.btnStarLoad.Text = "开始导入";
            this.btnStarLoad.UseVisualStyleBackColor = false;
            this.btnStarLoad.Click += new System.EventHandler(this.btnStarLoad_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnSelectFile.FlatAppearance.BorderSize = 0;
            this.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSelectFile.Location = new System.Drawing.Point(453, 208);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(82, 34);
            this.btnSelectFile.TabIndex = 112;
            this.btnSelectFile.Text = "选择...";
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // tbPicUrl
            // 
            this.tbPicUrl.BackColor = System.Drawing.SystemColors.Window;
            this.tbPicUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPicUrl.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.tbPicUrl.HotBackColor = System.Drawing.Color.White;
            this.tbPicUrl.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.tbPicUrl.Location = new System.Drawing.Point(123, 208);
            this.tbPicUrl.LostBackColor = System.Drawing.SystemColors.Window;
            this.tbPicUrl.LostBorderColor = System.Drawing.Color.Transparent;
            this.tbPicUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPicUrl.Name = "tbPicUrl";
            this.tbPicUrl.ReadOnly = true;
            this.tbPicUrl.Size = new System.Drawing.Size(328, 31);
            this.tbPicUrl.TabIndex = 111;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "第二步：导入填写完成的模板";
            // 
            // lbtnLoadTempt
            // 
            this.lbtnLoadTempt.AutoSize = true;
            this.lbtnLoadTempt.Location = new System.Drawing.Point(120, 98);
            this.lbtnLoadTempt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtnLoadTempt.Name = "lbtnLoadTempt";
            this.lbtnLoadTempt.Size = new System.Drawing.Size(224, 18);
            this.lbtnLoadTempt.TabIndex = 1;
            this.lbtnLoadTempt.TabStop = true;
            this.lbtnLoadTempt.Text = "点击下载楼栋信息导入模板";
            this.lbtnLoadTempt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnLoadTempt_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "第一步：下载模板";
            // 
            // tbShow
            // 
            this.tbShow.Location = new System.Drawing.Point(123, 263);
            this.tbShow.Name = "tbShow";
            this.tbShow.Size = new System.Drawing.Size(604, 227);
            this.tbShow.TabIndex = 117;
            this.tbShow.Text = "";
            // 
            // FrmLoadBaseData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(872, 630);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmLoadBaseData";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入基础数据";
            this.Load += new System.EventHandler(this.FrmLoadBaseData_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lbtnLoadTempt;
        private System.Windows.Forms.Label label1;
        private HM.Form_.Old.TextBox.RTextBox tbPicUrl;
        private System.Windows.Forms.Button btnStarLoad;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private HM.Form_.Old.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox tbShow;
    }
}