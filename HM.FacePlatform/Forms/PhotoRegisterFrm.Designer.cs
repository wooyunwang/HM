using HM.Form_.Old.TextBox;
namespace HM.FacePlatform.Forms
{
    partial class PhotoRegisterFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoRegisterFrm));
            this.Tsp = new System.Windows.Forms.ToolStrip();
            this.btn_SelPic = new System.Windows.Forms.ToolStripButton();
            this.btn_PCCamera = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cb_FaceVendorList = new System.Windows.Forms.ToolStripComboBox();
            this.btn_RegisterTemp = new System.Windows.Forms.ToolStripButton();
            this.btn_DelTemp = new System.Windows.Forms.ToolStripButton();
            this.btn_UploadDB = new System.Windows.Forms.ToolStripButton();
            this.groupBox_Info = new System.Windows.Forms.GroupBox();
            this.pnEndTime = new HM.Form_.Old.PanelXP();
            this.tbEnd = new System.Windows.Forms.DateTimePicker();
            this.labEndTime = new System.Windows.Forms.Label();
            this.tbHouse = new HM.Form_.Old.TextBox.RTextBox();
            this.tbName = new HM.Form_.Old.TextBox.RTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox_photo = new System.Windows.Forms.GroupBox();
            this.pnToRegister = new System.Windows.Forms.FlowLayoutPanel();
            this.gbRegisted = new System.Windows.Forms.GroupBox();
            this.pnRegisted = new System.Windows.Forms.FlowLayoutPanel();
            this.ed_ResultBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Tsp.SuspendLayout();
            this.groupBox_Info.SuspendLayout();
            this.pnEndTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox_photo.SuspendLayout();
            this.gbRegisted.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tsp
            // 
            this.Tsp.CanOverflow = false;
            this.Tsp.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Tsp.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Tsp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_SelPic,
            this.btn_PCCamera,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cb_FaceVendorList,
            this.btn_RegisterTemp,
            this.btn_DelTemp,
            this.btn_UploadDB});
            this.Tsp.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.Tsp.Location = new System.Drawing.Point(20, 60);
            this.Tsp.Name = "Tsp";
            this.Tsp.Size = new System.Drawing.Size(774, 56);
            this.Tsp.TabIndex = 22;
            // 
            // btn_SelPic
            // 
            this.btn_SelPic.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelPic.Image")));
            this.btn_SelPic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SelPic.Name = "btn_SelPic";
            this.btn_SelPic.Size = new System.Drawing.Size(60, 53);
            this.btn_SelPic.Text = "选择照片";
            this.btn_SelPic.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_SelPic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_SelPic.Click += new System.EventHandler(this.btn_SelPic_Click);
            // 
            // btn_PCCamera
            // 
            this.btn_PCCamera.Image = global::HM.FacePlatform.Properties.Resources.camera;
            this.btn_PCCamera.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_PCCamera.Name = "btn_PCCamera";
            this.btn_PCCamera.Size = new System.Drawing.Size(48, 53);
            this.btn_PCCamera.Text = "摄像头";
            this.btn_PCCamera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_PCCamera.ToolTipText = "摄像头抓拍|双击画面抓拍";
            this.btn_PCCamera.Click += new System.EventHandler(this.btn_PCCamera_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 56);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(83, 53);
            this.toolStripLabel1.Text = "人脸识别引擎:";
            this.toolStripLabel1.Visible = false;
            // 
            // cb_FaceVendorList
            // 
            this.cb_FaceVendorList.Name = "cb_FaceVendorList";
            this.cb_FaceVendorList.Size = new System.Drawing.Size(121, 56);
            this.cb_FaceVendorList.Visible = false;
            // 
            // btn_RegisterTemp
            // 
            this.btn_RegisterTemp.Image = ((System.Drawing.Image)(resources.GetObject("btn_RegisterTemp.Image")));
            this.btn_RegisterTemp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_RegisterTemp.Name = "btn_RegisterTemp";
            this.btn_RegisterTemp.Size = new System.Drawing.Size(60, 53);
            this.btn_RegisterTemp.Text = "注册模板";
            this.btn_RegisterTemp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_RegisterTemp.Click += new System.EventHandler(this.btn_RegisterTemp_Click);
            // 
            // btn_DelTemp
            // 
            this.btn_DelTemp.Image = ((System.Drawing.Image)(resources.GetObject("btn_DelTemp.Image")));
            this.btn_DelTemp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_DelTemp.Name = "btn_DelTemp";
            this.btn_DelTemp.Size = new System.Drawing.Size(60, 53);
            this.btn_DelTemp.Text = "删除模板";
            this.btn_DelTemp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_DelTemp.Visible = false;
            // 
            // btn_UploadDB
            // 
            this.btn_UploadDB.Image = ((System.Drawing.Image)(resources.GetObject("btn_UploadDB.Image")));
            this.btn_UploadDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_UploadDB.Name = "btn_UploadDB";
            this.btn_UploadDB.Size = new System.Drawing.Size(60, 53);
            this.btn_UploadDB.Text = "上传记录";
            this.btn_UploadDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_UploadDB.Visible = false;
            // 
            // groupBox_Info
            // 
            this.groupBox_Info.Controls.Add(this.pnEndTime);
            this.groupBox_Info.Controls.Add(this.labEndTime);
            this.groupBox_Info.Controls.Add(this.tbHouse);
            this.groupBox_Info.Controls.Add(this.tbName);
            this.groupBox_Info.Controls.Add(this.label4);
            this.groupBox_Info.Controls.Add(this.label3);
            this.groupBox_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_Info.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox_Info.Location = new System.Drawing.Point(20, 116);
            this.groupBox_Info.Name = "groupBox_Info";
            this.groupBox_Info.Size = new System.Drawing.Size(774, 55);
            this.groupBox_Info.TabIndex = 25;
            this.groupBox_Info.TabStop = false;
            this.groupBox_Info.Text = "信息";
            // 
            // pnEndTime
            // 
            this.pnEndTime.BorderColor = System.Drawing.Color.Gray;
            this.pnEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnEndTime.Controls.Add(this.tbEnd);
            this.pnEndTime.Location = new System.Drawing.Point(643, 21);
            this.pnEndTime.Name = "pnEndTime";
            this.pnEndTime.Size = new System.Drawing.Size(125, 23);
            this.pnEndTime.TabIndex = 115;
            this.pnEndTime.Visible = false;
            // 
            // tbEnd
            // 
            this.tbEnd.CalendarMonthBackground = System.Drawing.SystemColors.ControlLightLight;
            this.tbEnd.Location = new System.Drawing.Point(-1, -1);
            this.tbEnd.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.tbEnd.Name = "tbEnd";
            this.tbEnd.Size = new System.Drawing.Size(125, 21);
            this.tbEnd.TabIndex = 114;
            this.tbEnd.Visible = false;
            // 
            // labEndTime
            // 
            this.labEndTime.AutoSize = true;
            this.labEndTime.BackColor = System.Drawing.Color.Transparent;
            this.labEndTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labEndTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labEndTime.ForeColor = System.Drawing.Color.Black;
            this.labEndTime.Location = new System.Drawing.Point(555, 23);
            this.labEndTime.Name = "labEndTime";
            this.labEndTime.Size = new System.Drawing.Size(83, 17);
            this.labEndTime.TabIndex = 113;
            this.labEndTime.Text = "人脸有效期至:";
            this.labEndTime.Visible = false;
            // 
            // tbHouse
            // 
            this.tbHouse.BackColor = System.Drawing.SystemColors.Window;
            this.tbHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbHouse.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbHouse.HotBackColor = System.Drawing.Color.White;
            this.tbHouse.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.tbHouse.Location = new System.Drawing.Point(209, 21);
            this.tbHouse.LostBackColor = System.Drawing.SystemColors.Window;
            this.tbHouse.LostBorderColor = System.Drawing.Color.Transparent;
            this.tbHouse.Name = "tbHouse";
            this.tbHouse.ReadOnly = true;
            this.tbHouse.Size = new System.Drawing.Size(315, 23);
            this.tbHouse.TabIndex = 10;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbName.HotBackColor = System.Drawing.Color.White;
            this.tbName.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.tbName.Location = new System.Drawing.Point(53, 21);
            this.tbName.LostBackColor = System.Drawing.SystemColors.Window;
            this.tbName.LostBorderColor = System.Drawing.Color.Transparent;
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(91, 23);
            this.tbName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(170, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "房号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "姓名：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_photo);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbRegisted);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(774, 267);
            this.splitContainer1.SplitterDistance = 334;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 27;
            // 
            // groupBox_photo
            // 
            this.groupBox_photo.Controls.Add(this.pnToRegister);
            this.groupBox_photo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_photo.Location = new System.Drawing.Point(0, 0);
            this.groupBox_photo.Name = "groupBox_photo";
            this.groupBox_photo.Size = new System.Drawing.Size(334, 267);
            this.groupBox_photo.TabIndex = 1;
            this.groupBox_photo.TabStop = false;
            this.groupBox_photo.Text = "照片";
            // 
            // pnToRegister
            // 
            this.pnToRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnToRegister.Location = new System.Drawing.Point(3, 17);
            this.pnToRegister.Margin = new System.Windows.Forms.Padding(2);
            this.pnToRegister.Name = "pnToRegister";
            this.pnToRegister.Size = new System.Drawing.Size(328, 247);
            this.pnToRegister.TabIndex = 1;
            // 
            // gbRegisted
            // 
            this.gbRegisted.Controls.Add(this.pnRegisted);
            this.gbRegisted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRegisted.Location = new System.Drawing.Point(0, 0);
            this.gbRegisted.Name = "gbRegisted";
            this.gbRegisted.Size = new System.Drawing.Size(435, 267);
            this.gbRegisted.TabIndex = 13;
            this.gbRegisted.TabStop = false;
            this.gbRegisted.Text = "已注册模板";
            // 
            // pnRegisted
            // 
            this.pnRegisted.AutoScroll = true;
            this.pnRegisted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRegisted.Location = new System.Drawing.Point(3, 17);
            this.pnRegisted.Margin = new System.Windows.Forms.Padding(2);
            this.pnRegisted.Name = "pnRegisted";
            this.pnRegisted.Size = new System.Drawing.Size(429, 247);
            this.pnRegisted.TabIndex = 0;
            // 
            // ed_ResultBox
            // 
            this.ed_ResultBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ed_ResultBox.HideSelection = false;
            this.ed_ResultBox.Location = new System.Drawing.Point(0, 267);
            this.ed_ResultBox.Margin = new System.Windows.Forms.Padding(2);
            this.ed_ResultBox.Name = "ed_ResultBox";
            this.ed_ResultBox.Size = new System.Drawing.Size(774, 88);
            this.ed_ResultBox.TabIndex = 28;
            this.ed_ResultBox.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.ed_ResultBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 171);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 355);
            this.panel1.TabIndex = 29;
            // 
            // PhotoRegisterFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 546);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox_Info);
            this.Controls.Add(this.Tsp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PhotoRegisterFrm";
            this.Text = "人脸注册";
            this.Load += new System.EventHandler(this.PhotoRegisterFrm_Load);
            this.Tsp.ResumeLayout(false);
            this.Tsp.PerformLayout();
            this.groupBox_Info.ResumeLayout(false);
            this.groupBox_Info.PerformLayout();
            this.pnEndTime.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox_photo.ResumeLayout(false);
            this.gbRegisted.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Tsp;
        private System.Windows.Forms.ToolStripButton btn_SelPic;
        private System.Windows.Forms.ToolStripButton btn_PCCamera;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cb_FaceVendorList;
        private System.Windows.Forms.ToolStripButton btn_RegisterTemp;
        private System.Windows.Forms.ToolStripButton btn_DelTemp;
        private System.Windows.Forms.ToolStripButton btn_UploadDB;
        private System.Windows.Forms.GroupBox groupBox_Info;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox_photo;
        private System.Windows.Forms.GroupBox gbRegisted;
        private RTextBox tbHouse;
        private RTextBox tbName;
        private System.Windows.Forms.DateTimePicker tbEnd;
        private System.Windows.Forms.Label labEndTime;
        private HM.Form_.Old.PanelXP pnEndTime;
        private System.Windows.Forms.FlowLayoutPanel pnRegisted;
        private System.Windows.Forms.FlowLayoutPanel pnToRegister;
        private System.Windows.Forms.RichTextBox ed_ResultBox;
        private System.Windows.Forms.Panel panel1;
    }
}