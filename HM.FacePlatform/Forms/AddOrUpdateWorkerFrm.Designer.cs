namespace HM.FacePlatform.Forms
{
    partial class AddOrUpdateWorkerFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrUpdateWorkerFrm));
            this.tbMoblie = new HM.Form_.HMTextBox();
            this.tbIdNum = new HM.Form_.HMTextBox();
            this.tbName = new HM.Form_.HMTextBox();
            this.label14 = new HM.Form_.HMLabel();
            this.label13 = new HM.Form_.HMLabel();
            this.label11 = new HM.Form_.HMLabel();
            this.label9 = new HM.Form_.HMLabel();
            this.lblJob = new HM.Form_.HMLabel();
            this.BtnAdd = new HM.Form_.HMTile();
            this.BtnCancel = new HM.Form_.HMTile();
            this.imageList_Photo = new System.Windows.Forms.ImageList(this.components);
            this.lblHouseName = new HM.Form_.HMLabel();
            this.label2 = new HM.Form_.HMLabel();
            this.dropSex = new HM.Form_.HMComboBox();
            this.tbJob = new HM.Form_.HMTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbMoblie
            // 
            this.tbMoblie.Location = new System.Drawing.Point(133, 199);
            this.tbMoblie.MaxLength = 11;
            this.tbMoblie.Name = "tbMoblie";
            this.tbMoblie.Size = new System.Drawing.Size(156, 30);
            this.tbMoblie.TabIndex = 5;
            // 
            // tbIdNum
            // 
            this.tbIdNum.Location = new System.Drawing.Point(133, 243);
            this.tbIdNum.MaxLength = 18;
            this.tbIdNum.Name = "tbIdNum";
            this.tbIdNum.Size = new System.Drawing.Size(156, 30);
            this.tbIdNum.TabIndex = 4;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(133, 108);
            this.tbName.MaxLength = 20;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(156, 30);
            this.tbName.TabIndex = 2;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(47, 205);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 19);
            this.label14.TabIndex = 100;
            this.label14.Text = "手机号:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(47, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 19);
            this.label13.TabIndex = 100;
            this.label13.Text = "身份证号:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(47, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 19);
            this.label11.TabIndex = 100;
            this.label11.Text = "姓名:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(47, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 19);
            this.label9.TabIndex = 100;
            this.label9.Text = "房号:";
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.BackColor = System.Drawing.Color.Transparent;
            this.lblJob.ForeColor = System.Drawing.Color.Black;
            this.lblJob.Location = new System.Drawing.Point(47, 291);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(40, 19);
            this.lblJob.TabIndex = 100;
            this.lblJob.Text = "职位:";
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.BtnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnAdd.Location = new System.Drawing.Point(196, 344);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(76, 25);
            this.BtnAdd.TabIndex = 7;
            this.BtnAdd.Text = "保存";
            this.BtnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCancel.Location = new System.Drawing.Point(76, 344);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(76, 25);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // imageList_Photo
            // 
            this.imageList_Photo.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList_Photo.ImageSize = new System.Drawing.Size(120, 120);
            this.imageList_Photo.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lblHouseName
            // 
            this.lblHouseName.AutoSize = true;
            this.lblHouseName.Location = new System.Drawing.Point(133, 75);
            this.lblHouseName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHouseName.Name = "lblHouseName";
            this.lblHouseName.Size = new System.Drawing.Size(95, 19);
            this.lblHouseName.TabIndex = 105;
            this.lblHouseName.Text = "lblHouseName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(47, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 19);
            this.label2.TabIndex = 106;
            this.label2.Text = "性别:";
            // 
            // dropSex
            // 
            this.dropSex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dropSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropSex.FormattingEnabled = true;
            this.dropSex.ItemHeight = 23;
            this.dropSex.Location = new System.Drawing.Point(133, 152);
            this.dropSex.Name = "dropSex";
            this.dropSex.Size = new System.Drawing.Size(156, 29);
            this.dropSex.TabIndex = 4;
            // 
            // tbJob
            // 
            this.tbJob.Location = new System.Drawing.Point(133, 287);
            this.tbJob.Name = "tbJob";
            this.tbJob.Size = new System.Drawing.Size(156, 30);
            this.tbJob.TabIndex = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(31, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 115;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(31, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 117;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(31, 205);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 118;
            this.label5.Text = "*";
            // 
            // AddOrUpdateWorkerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 406);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dropSex);
            this.Controls.Add(this.tbJob);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHouseName);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.tbMoblie);
            this.Controls.Add(this.tbIdNum);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOrUpdateWorkerFrm";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Resizable = false;
            this.Text = "注册新工作人员";
            this.Load += new System.EventHandler(this.AddOrUpdateWorkerFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HM.Form_.HMTextBox tbMoblie;
        private HM.Form_.HMTextBox tbIdNum;
        private HM.Form_.HMTextBox tbName;
        private HM.Form_.HMLabel label14;
        private HM.Form_.HMLabel label13;
        private HM.Form_.HMLabel label11;
        private HM.Form_.HMLabel label9;
        private HM.Form_.HMLabel lblJob;
        private HM.Form_.HMTile BtnAdd;
        private HM.Form_.HMTile BtnCancel;
        private System.Windows.Forms.ImageList imageList_Photo;
        private HM.Form_.HMLabel lblHouseName;
        private HM.Form_.HMLabel label2;
        private HM.Form_.HMTextBox tbJob;
        private HM.Form_.HMComboBox dropSex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}