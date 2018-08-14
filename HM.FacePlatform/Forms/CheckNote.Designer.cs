using HM.Form_.Old.TextBox;
namespace HM.FacePlatform.Forms
{
    partial class CheckNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckNote));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNote = new HM.Form_.Old.TextBox.RTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnNO = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox_photo = new System.Windows.Forms.GroupBox();
            this.FlpRegisted = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRegTime = new HM.Form_.Old.TextBox.RTextBox();
            this.tbUserType = new HM.Form_.Old.TextBox.RTextBox();
            this.tbName = new HM.Form_.Old.TextBox.RTextBox();
            this.tbHouseName = new HM.Form_.Old.TextBox.RTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRelation = new HM.Form_.Old.TextBox.RTextBox();
            this.labEndTime = new System.Windows.Forms.Label();
            this.pnEndTime = new HM.Form_.Old.PanelXP();
            this.tbEnd = new System.Windows.Forms.DateTimePicker();
            this.labCheckTime = new System.Windows.Forms.Label();
            this.tbCheckTime = new HM.Form_.Old.TextBox.RTextBox();
            this.labPeople = new System.Windows.Forms.Label();
            this.tbCheckPepole = new HM.Form_.Old.TextBox.RTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbMessage = new System.Windows.Forms.RichTextBox();
            this.groupBox_photo.SuspendLayout();
            this.pnEndTime.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 99;
            this.label1.Text = "备注:";
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.SystemColors.Window;
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNote.HotBackColor = System.Drawing.Color.White;
            this.txtNote.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.txtNote.Location = new System.Drawing.Point(117, 382);
            this.txtNote.LostBackColor = System.Drawing.SystemColors.Window;
            this.txtNote.LostBorderColor = System.Drawing.Color.Transparent;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(429, 44);
            this.txtNote.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOK.Location = new System.Drawing.Point(289, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(65, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "通过";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnNO
            // 
            this.btnNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnNO.FlatAppearance.BorderSize = 0;
            this.btnNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNO.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNO.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNO.Location = new System.Drawing.Point(377, 5);
            this.btnNO.Name = "btnNO";
            this.btnNO.Size = new System.Drawing.Size(65, 25);
            this.btnNO.TabIndex = 3;
            this.btnNO.Text = "不通过";
            this.btnNO.UseVisualStyleBackColor = false;
            this.btnNO.Click += new System.EventHandler(this.btnNO_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(464, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox_photo
            // 
            this.groupBox_photo.Controls.Add(this.FlpRegisted);
            this.groupBox_photo.Location = new System.Drawing.Point(31, 193);
            this.groupBox_photo.Name = "groupBox_photo";
            this.groupBox_photo.Size = new System.Drawing.Size(515, 184);
            this.groupBox_photo.TabIndex = 100;
            this.groupBox_photo.TabStop = false;
            this.groupBox_photo.Text = "已注册照片";
            // 
            // FlpRegisted
            // 
            this.FlpRegisted.AutoScroll = true;
            this.FlpRegisted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlpRegisted.Location = new System.Drawing.Point(3, 17);
            this.FlpRegisted.Margin = new System.Windows.Forms.Padding(2);
            this.FlpRegisted.Name = "FlpRegisted";
            this.FlpRegisted.Size = new System.Drawing.Size(509, 164);
            this.FlpRegisted.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(329, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 105;
            this.label2.Text = "关系:";
            // 
            // tbRegTime
            // 
            this.tbRegTime.BackColor = System.Drawing.SystemColors.Window;
            this.tbRegTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRegTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbRegTime.HotBackColor = System.Drawing.Color.White;
            this.tbRegTime.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.tbRegTime.Location = new System.Drawing.Point(386, 160);
            this.tbRegTime.LostBackColor = System.Drawing.SystemColors.Window;
            this.tbRegTime.LostBorderColor = System.Drawing.Color.Transparent;
            this.tbRegTime.Name = "tbRegTime";
            this.tbRegTime.ReadOnly = true;
            this.tbRegTime.Size = new System.Drawing.Size(153, 23);
            this.tbRegTime.TabIndex = 104;
            // 
            // tbUserType
            // 
            this.tbUserType.BackColor = System.Drawing.SystemColors.Window;
            this.tbUserType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbUserType.HotBackColor = System.Drawing.Color.White;
            this.tbUserType.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.tbUserType.Location = new System.Drawing.Point(104, 160);
            this.tbUserType.LostBackColor = System.Drawing.SystemColors.Window;
            this.tbUserType.LostBorderColor = System.Drawing.Color.Transparent;
            this.tbUserType.Name = "tbUserType";
            this.tbUserType.ReadOnly = true;
            this.tbUserType.Size = new System.Drawing.Size(155, 23);
            this.tbUserType.TabIndex = 103;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbName.HotBackColor = System.Drawing.Color.White;
            this.tbName.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.tbName.Location = new System.Drawing.Point(104, 125);
            this.tbName.LostBackColor = System.Drawing.SystemColors.Window;
            this.tbName.LostBorderColor = System.Drawing.Color.Transparent;
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(155, 23);
            this.tbName.TabIndex = 102;
            // 
            // tbHouseName
            // 
            this.tbHouseName.BackColor = System.Drawing.SystemColors.Window;
            this.tbHouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbHouseName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbHouseName.HotBackColor = System.Drawing.Color.White;
            this.tbHouseName.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.tbHouseName.Location = new System.Drawing.Point(104, 90);
            this.tbHouseName.LostBackColor = System.Drawing.SystemColors.Window;
            this.tbHouseName.LostBorderColor = System.Drawing.Color.Transparent;
            this.tbHouseName.Name = "tbHouseName";
            this.tbHouseName.ReadOnly = true;
            this.tbHouseName.Size = new System.Drawing.Size(435, 23);
            this.tbHouseName.TabIndex = 101;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(327, 166);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 17);
            this.label14.TabIndex = 106;
            this.label14.Text = "到期时间:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(42, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 107;
            this.label13.Text = "用户类型:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(42, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 108;
            this.label11.Text = "姓名:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(42, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 109;
            this.label9.Text = "房号:";
            // 
            // tbRelation
            // 
            this.tbRelation.BackColor = System.Drawing.SystemColors.Window;
            this.tbRelation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRelation.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbRelation.HotBackColor = System.Drawing.Color.White;
            this.tbRelation.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.tbRelation.Location = new System.Drawing.Point(386, 126);
            this.tbRelation.LostBackColor = System.Drawing.SystemColors.Window;
            this.tbRelation.LostBorderColor = System.Drawing.Color.Transparent;
            this.tbRelation.Name = "tbRelation";
            this.tbRelation.ReadOnly = true;
            this.tbRelation.Size = new System.Drawing.Size(153, 23);
            this.tbRelation.TabIndex = 110;
            // 
            // labEndTime
            // 
            this.labEndTime.AutoSize = true;
            this.labEndTime.BackColor = System.Drawing.Color.Transparent;
            this.labEndTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labEndTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labEndTime.ForeColor = System.Drawing.Color.Black;
            this.labEndTime.Location = new System.Drawing.Point(29, 467);
            this.labEndTime.Name = "labEndTime";
            this.labEndTime.Size = new System.Drawing.Size(83, 17);
            this.labEndTime.TabIndex = 111;
            this.labEndTime.Text = "人脸有效期至:";
            this.labEndTime.Visible = false;
            // 
            // pnEndTime
            // 
            this.pnEndTime.BorderColor = System.Drawing.Color.Gray;
            this.pnEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnEndTime.Controls.Add(this.tbEnd);
            this.pnEndTime.Location = new System.Drawing.Point(117, 464);
            this.pnEndTime.Name = "pnEndTime";
            this.pnEndTime.Size = new System.Drawing.Size(153, 23);
            this.pnEndTime.TabIndex = 113;
            this.pnEndTime.Visible = false;
            // 
            // tbEnd
            // 
            this.tbEnd.CalendarMonthBackground = System.Drawing.SystemColors.ControlLightLight;
            this.tbEnd.Location = new System.Drawing.Point(-1, 1);
            this.tbEnd.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.tbEnd.Name = "tbEnd";
            this.tbEnd.Size = new System.Drawing.Size(153, 21);
            this.tbEnd.TabIndex = 120;
            this.tbEnd.Visible = false;
            // 
            // labCheckTime
            // 
            this.labCheckTime.AutoSize = true;
            this.labCheckTime.BackColor = System.Drawing.Color.Transparent;
            this.labCheckTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labCheckTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labCheckTime.ForeColor = System.Drawing.Color.Black;
            this.labCheckTime.Location = new System.Drawing.Point(320, 438);
            this.labCheckTime.Name = "labCheckTime";
            this.labCheckTime.Size = new System.Drawing.Size(59, 17);
            this.labCheckTime.TabIndex = 114;
            this.labCheckTime.Text = "审核时间:";
            this.labCheckTime.Visible = false;
            // 
            // tbCheckTime
            // 
            this.tbCheckTime.BackColor = System.Drawing.SystemColors.Window;
            this.tbCheckTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCheckTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbCheckTime.HotBackColor = System.Drawing.Color.White;
            this.tbCheckTime.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.tbCheckTime.Location = new System.Drawing.Point(393, 436);
            this.tbCheckTime.LostBackColor = System.Drawing.SystemColors.Window;
            this.tbCheckTime.LostBorderColor = System.Drawing.Color.Transparent;
            this.tbCheckTime.Name = "tbCheckTime";
            this.tbCheckTime.ReadOnly = true;
            this.tbCheckTime.Size = new System.Drawing.Size(153, 23);
            this.tbCheckTime.TabIndex = 115;
            this.tbCheckTime.Visible = false;
            // 
            // labPeople
            // 
            this.labPeople.AutoSize = true;
            this.labPeople.BackColor = System.Drawing.Color.Transparent;
            this.labPeople.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labPeople.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labPeople.ForeColor = System.Drawing.Color.Black;
            this.labPeople.Location = new System.Drawing.Point(36, 436);
            this.labPeople.Name = "labPeople";
            this.labPeople.Size = new System.Drawing.Size(47, 17);
            this.labPeople.TabIndex = 116;
            this.labPeople.Text = "审核人:";
            this.labPeople.Visible = false;
            // 
            // tbCheckPepole
            // 
            this.tbCheckPepole.BackColor = System.Drawing.SystemColors.Window;
            this.tbCheckPepole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCheckPepole.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbCheckPepole.HotBackColor = System.Drawing.Color.White;
            this.tbCheckPepole.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.tbCheckPepole.Location = new System.Drawing.Point(117, 436);
            this.tbCheckPepole.LostBackColor = System.Drawing.SystemColors.Window;
            this.tbCheckPepole.LostBorderColor = System.Drawing.Color.Transparent;
            this.tbCheckPepole.Name = "tbCheckPepole";
            this.tbCheckPepole.ReadOnly = true;
            this.tbCheckPepole.Size = new System.Drawing.Size(153, 23);
            this.tbCheckPepole.TabIndex = 117;
            this.tbCheckPepole.Text = "管理员";
            this.tbCheckPepole.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnNO);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Location = new System.Drawing.Point(23, 491);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 39);
            this.panel1.TabIndex = 118;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(13, 675);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 56);
            this.panel2.TabIndex = 119;
            // 
            // tbMessage
            // 
            this.tbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessage.HideSelection = false;
            this.tbMessage.Location = new System.Drawing.Point(0, 0);
            this.tbMessage.Margin = new System.Windows.Forms.Padding(2);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(575, 56);
            this.tbMessage.TabIndex = 29;
            this.tbMessage.Text = "";
            // 
            // CheckNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 744);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbCheckPepole);
            this.Controls.Add(this.labPeople);
            this.Controls.Add(this.tbCheckTime);
            this.Controls.Add(this.labCheckTime);
            this.Controls.Add(this.pnEndTime);
            this.Controls.Add(this.labEndTime);
            this.Controls.Add(this.tbRelation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbRegTime);
            this.Controls.Add(this.tbUserType);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbHouseName);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox_photo);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckNote";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Text = "审核";
            this.Load += new System.EventHandler(this.CheckNote_Load);
            this.groupBox_photo.ResumeLayout(false);
            this.pnEndTime.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private RTextBox txtNote;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnNO;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox_photo;
        private System.Windows.Forms.Label label2;
        private RTextBox tbRegTime;
        private RTextBox tbUserType;
        private RTextBox tbName;
        private RTextBox tbHouseName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private RTextBox tbRelation;
        private System.Windows.Forms.Label labEndTime;
        private HM.Form_.Old.PanelXP pnEndTime;
        private System.Windows.Forms.Label labCheckTime;
        private RTextBox tbCheckTime;
        private System.Windows.Forms.Label labPeople;
        private RTextBox tbCheckPepole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel FlpRegisted;
        private System.Windows.Forms.DateTimePicker tbEnd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox tbMessage;
    }
}