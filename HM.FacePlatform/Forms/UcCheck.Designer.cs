using HM.Form_.Old;
using HM.Form_.Old.TextBox;
namespace HM.FacePlatform
{
    partial class UcCheck
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
            this.HtcMain = new HM.Form_.HMTabControl();
            this.MtpWaitReview = new System.Windows.Forms.TabPage();
            this.FlpWaitReview = new System.Windows.Forms.FlowLayoutPanel();
            this.pagerWaitReview = new HM.Form_.HMPager();
            this.PnlWaitReview = new System.Windows.Forms.Panel();
            this.LblWait_RegisterType = new HM.Form_.HMLabel();
            this.PxlWait_RegisterType = new HM.Form_.Old.PanelXP();
            this.CbxWait_RegisterType = new HM.Form_.Old.RComboBox();
            this.LblWait_UserType = new HM.Form_.HMLabel();
            this.PnlWait_UserType = new HM.Form_.Old.PanelXP();
            this.CbxWait_UserType = new HM.Form_.Old.RComboBox();
            this.LblWait_Name = new HM.Form_.HMLabel();
            this.TxtWait_Name = new HM.Form_.Old.TextBox.RTextBox();
            this.CbxAll = new HM.Form_.HMCheckBox();
            this.BtnBatchReview = new HM.Form_.HMTile();
            this.BtnSelectWaitReview = new HM.Form_.HMTile();
            this.MtpHasReview = new System.Windows.Forms.TabPage();
            this.FlpHasReview = new System.Windows.Forms.FlowLayoutPanel();
            this.pagerHasReview = new HM.Form_.HMPager();
            this.PnlHasReview = new System.Windows.Forms.Panel();
            this.LblHas_CheckType = new HM.Form_.HMLabel();
            this.PnlHas_CheckType = new HM.Form_.Old.PanelXP();
            this.CbxHas_CheckType = new HM.Form_.Old.RComboBox();
            this.LblHas_RegisterType = new HM.Form_.HMLabel();
            this.PnlHas_RegisterType = new HM.Form_.Old.PanelXP();
            this.CbxHas_RegisterType = new HM.Form_.Old.RComboBox();
            this.LblHas_UserType = new HM.Form_.HMLabel();
            this.PnlHas_UserType = new HM.Form_.Old.PanelXP();
            this.CbxHas_UserType = new HM.Form_.Old.RComboBox();
            this.LblHas_Name = new HM.Form_.HMLabel();
            this.TxtHas_Name = new HM.Form_.Old.TextBox.RTextBox();
            this.BtnSelecteHasReview = new HM.Form_.HMTile();
            this.rTextBox1 = new HM.Form_.Old.TextBox.RTextBox();
            this.HtcMain.SuspendLayout();
            this.MtpWaitReview.SuspendLayout();
            this.PnlWaitReview.SuspendLayout();
            this.PxlWait_RegisterType.SuspendLayout();
            this.PnlWait_UserType.SuspendLayout();
            this.MtpHasReview.SuspendLayout();
            this.PnlHasReview.SuspendLayout();
            this.PnlHas_CheckType.SuspendLayout();
            this.PnlHas_RegisterType.SuspendLayout();
            this.PnlHas_UserType.SuspendLayout();
            this.SuspendLayout();
            // 
            // HtcMain
            // 
            this.HtcMain.Controls.Add(this.MtpWaitReview);
            this.HtcMain.Controls.Add(this.MtpHasReview);
            this.HtcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HtcMain.ItemSize = new System.Drawing.Size(120, 30);
            this.HtcMain.Location = new System.Drawing.Point(0, 0);
            this.HtcMain.Name = "HtcMain";
            this.HtcMain.SelectedIndex = 1;
            this.HtcMain.Size = new System.Drawing.Size(1200, 600);
            this.HtcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.HtcMain.TabIndex = 99;
            this.HtcMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HtcMain.SelectedIndexChanged += new System.EventHandler(this.HtcMain_SelectedIndexChanged);
            // 
            // MtpWaitReview
            // 
            this.MtpWaitReview.Controls.Add(this.FlpWaitReview);
            this.MtpWaitReview.Controls.Add(this.pagerWaitReview);
            this.MtpWaitReview.Controls.Add(this.PnlWaitReview);
            this.MtpWaitReview.Location = new System.Drawing.Point(4, 34);
            this.MtpWaitReview.Name = "MtpWaitReview";
            this.MtpWaitReview.Padding = new System.Windows.Forms.Padding(3);
            this.MtpWaitReview.Size = new System.Drawing.Size(1192, 562);
            this.MtpWaitReview.TabIndex = 99;
            this.MtpWaitReview.Text = "待审核列表";
            this.MtpWaitReview.UseVisualStyleBackColor = true;
            // 
            // FlpWaitReview
            // 
            this.FlpWaitReview.AutoScroll = true;
            this.FlpWaitReview.AutoSize = true;
            this.FlpWaitReview.BackColor = System.Drawing.Color.White;
            this.FlpWaitReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlpWaitReview.Location = new System.Drawing.Point(3, 53);
            this.FlpWaitReview.Name = "FlpWaitReview";
            this.FlpWaitReview.Size = new System.Drawing.Size(1186, 479);
            this.FlpWaitReview.TabIndex = 99;
            // 
            // pagerWaitReview
            // 
            this.pagerWaitReview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerWaitReview.Location = new System.Drawing.Point(3, 532);
            this.pagerWaitReview.Margin = new System.Windows.Forms.Padding(4);
            this.pagerWaitReview.Name = "pagerWaitReview";
            this.pagerWaitReview.NMax = 0;
            this.pagerWaitReview.PageCount = 0;
            this.pagerWaitReview.PageCurrent = 1;
            this.pagerWaitReview.PageSize = 16;
            this.pagerWaitReview.Size = new System.Drawing.Size(1186, 27);
            this.pagerWaitReview.TabIndex = 102;
            this.pagerWaitReview.EventPaging += new HM.Form_.EventPagingHandler(this.pagerWaitReview_EventPaging);
            // 
            // PnlWaitReview
            // 
            this.PnlWaitReview.BackColor = System.Drawing.Color.White;
            this.PnlWaitReview.Controls.Add(this.LblWait_RegisterType);
            this.PnlWaitReview.Controls.Add(this.PxlWait_RegisterType);
            this.PnlWaitReview.Controls.Add(this.LblWait_UserType);
            this.PnlWaitReview.Controls.Add(this.PnlWait_UserType);
            this.PnlWaitReview.Controls.Add(this.LblWait_Name);
            this.PnlWaitReview.Controls.Add(this.TxtWait_Name);
            this.PnlWaitReview.Controls.Add(this.CbxAll);
            this.PnlWaitReview.Controls.Add(this.BtnBatchReview);
            this.PnlWaitReview.Controls.Add(this.BtnSelectWaitReview);
            this.PnlWaitReview.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlWaitReview.Location = new System.Drawing.Point(3, 3);
            this.PnlWaitReview.Name = "PnlWaitReview";
            this.PnlWaitReview.Size = new System.Drawing.Size(1186, 50);
            this.PnlWaitReview.TabIndex = 99;
            // 
            // LblWait_RegisterType
            // 
            this.LblWait_RegisterType.AutoSize = true;
            this.LblWait_RegisterType.BackColor = System.Drawing.Color.Transparent;
            this.LblWait_RegisterType.Location = new System.Drawing.Point(365, 15);
            this.LblWait_RegisterType.Name = "LblWait_RegisterType";
            this.LblWait_RegisterType.Size = new System.Drawing.Size(68, 19);
            this.LblWait_RegisterType.TabIndex = 109;
            this.LblWait_RegisterType.Text = "注册方式:";
            // 
            // PxlWait_RegisterType
            // 
            this.PxlWait_RegisterType.BorderColor = System.Drawing.Color.Gray;
            this.PxlWait_RegisterType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PxlWait_RegisterType.Controls.Add(this.CbxWait_RegisterType);
            this.PxlWait_RegisterType.Location = new System.Drawing.Point(443, 13);
            this.PxlWait_RegisterType.Name = "PxlWait_RegisterType";
            this.PxlWait_RegisterType.Size = new System.Drawing.Size(76, 23);
            this.PxlWait_RegisterType.TabIndex = 110;
            // 
            // CbxWait_RegisterType
            // 
            this.CbxWait_RegisterType.BackColor = System.Drawing.SystemColors.Window;
            this.CbxWait_RegisterType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbxWait_RegisterType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CbxWait_RegisterType.FormattingEnabled = true;
            this.CbxWait_RegisterType.HotBackColor = System.Drawing.Color.White;
            this.CbxWait_RegisterType.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.CbxWait_RegisterType.Location = new System.Drawing.Point(1, 2);
            this.CbxWait_RegisterType.LostBackColor = System.Drawing.SystemColors.Window;
            this.CbxWait_RegisterType.LostBorderColor = System.Drawing.Color.Transparent;
            this.CbxWait_RegisterType.Name = "CbxWait_RegisterType";
            this.CbxWait_RegisterType.Size = new System.Drawing.Size(73, 20);
            this.CbxWait_RegisterType.TabIndex = 109;
            // 
            // LblWait_UserType
            // 
            this.LblWait_UserType.AutoSize = true;
            this.LblWait_UserType.BackColor = System.Drawing.Color.Transparent;
            this.LblWait_UserType.Location = new System.Drawing.Point(193, 15);
            this.LblWait_UserType.Name = "LblWait_UserType";
            this.LblWait_UserType.Size = new System.Drawing.Size(68, 19);
            this.LblWait_UserType.TabIndex = 107;
            this.LblWait_UserType.Text = "人员类型:";
            // 
            // PnlWait_UserType
            // 
            this.PnlWait_UserType.BorderColor = System.Drawing.Color.Gray;
            this.PnlWait_UserType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlWait_UserType.Controls.Add(this.CbxWait_UserType);
            this.PnlWait_UserType.Location = new System.Drawing.Point(271, 13);
            this.PnlWait_UserType.Name = "PnlWait_UserType";
            this.PnlWait_UserType.Size = new System.Drawing.Size(73, 23);
            this.PnlWait_UserType.TabIndex = 108;
            // 
            // CbxWait_UserType
            // 
            this.CbxWait_UserType.BackColor = System.Drawing.SystemColors.Window;
            this.CbxWait_UserType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbxWait_UserType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CbxWait_UserType.FormattingEnabled = true;
            this.CbxWait_UserType.HotBackColor = System.Drawing.Color.White;
            this.CbxWait_UserType.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.CbxWait_UserType.Location = new System.Drawing.Point(2, 2);
            this.CbxWait_UserType.LostBackColor = System.Drawing.SystemColors.Window;
            this.CbxWait_UserType.LostBorderColor = System.Drawing.Color.Transparent;
            this.CbxWait_UserType.Name = "CbxWait_UserType";
            this.CbxWait_UserType.Size = new System.Drawing.Size(68, 20);
            this.CbxWait_UserType.TabIndex = 112;
            // 
            // LblWait_Name
            // 
            this.LblWait_Name.AutoSize = true;
            this.LblWait_Name.BackColor = System.Drawing.Color.Transparent;
            this.LblWait_Name.Location = new System.Drawing.Point(19, 15);
            this.LblWait_Name.Name = "LblWait_Name";
            this.LblWait_Name.Size = new System.Drawing.Size(40, 19);
            this.LblWait_Name.TabIndex = 106;
            this.LblWait_Name.Text = "姓名:";
            // 
            // TxtWait_Name
            // 
            this.TxtWait_Name.BackColor = System.Drawing.SystemColors.Window;
            this.TxtWait_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtWait_Name.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.TxtWait_Name.HotBackColor = System.Drawing.Color.White;
            this.TxtWait_Name.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.TxtWait_Name.Location = new System.Drawing.Point(74, 13);
            this.TxtWait_Name.LostBackColor = System.Drawing.SystemColors.Window;
            this.TxtWait_Name.LostBorderColor = System.Drawing.Color.Transparent;
            this.TxtWait_Name.Name = "TxtWait_Name";
            this.TxtWait_Name.Size = new System.Drawing.Size(98, 23);
            this.TxtWait_Name.TabIndex = 105;
            // 
            // CbxAll
            // 
            this.CbxAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxAll.AutoSize = true;
            this.CbxAll.Location = new System.Drawing.Point(954, 17);
            this.CbxAll.Name = "CbxAll";
            this.CbxAll.Size = new System.Drawing.Size(88, 15);
            this.CbxAll.TabIndex = 104;
            this.CbxAll.Text = "全选或全消";
            this.CbxAll.UseVisualStyleBackColor = true;
            this.CbxAll.CheckedChanged += new System.EventHandler(this.CbxAll_CheckedChanged);
            // 
            // BtnBatchReview
            // 
            this.BtnBatchReview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBatchReview.Location = new System.Drawing.Point(1048, 12);
            this.BtnBatchReview.Name = "BtnBatchReview";
            this.BtnBatchReview.Size = new System.Drawing.Size(90, 25);
            this.BtnBatchReview.TabIndex = 5;
            this.BtnBatchReview.Text = "批量审核";
            this.BtnBatchReview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnBatchReview.Click += new System.EventHandler(this.BtnBatchReview_Click);
            // 
            // BtnSelectWaitReview
            // 
            this.BtnSelectWaitReview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSelectWaitReview.Location = new System.Drawing.Point(544, 12);
            this.BtnSelectWaitReview.Name = "BtnSelectWaitReview";
            this.BtnSelectWaitReview.Size = new System.Drawing.Size(65, 25);
            this.BtnSelectWaitReview.TabIndex = 4;
            this.BtnSelectWaitReview.Text = "查询";
            this.BtnSelectWaitReview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnSelectWaitReview.Click += new System.EventHandler(this.BtnSelectWaitReview_Click);
            // 
            // MtpHasReview
            // 
            this.MtpHasReview.Controls.Add(this.FlpHasReview);
            this.MtpHasReview.Controls.Add(this.pagerHasReview);
            this.MtpHasReview.Controls.Add(this.PnlHasReview);
            this.MtpHasReview.Location = new System.Drawing.Point(4, 34);
            this.MtpHasReview.Name = "MtpHasReview";
            this.MtpHasReview.Size = new System.Drawing.Size(1192, 562);
            this.MtpHasReview.TabIndex = 99;
            this.MtpHasReview.Text = "已审核列表";
            this.MtpHasReview.UseVisualStyleBackColor = true;
            // 
            // FlpHasReview
            // 
            this.FlpHasReview.AutoScroll = true;
            this.FlpHasReview.AutoSize = true;
            this.FlpHasReview.BackColor = System.Drawing.Color.White;
            this.FlpHasReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlpHasReview.Location = new System.Drawing.Point(0, 47);
            this.FlpHasReview.Name = "FlpHasReview";
            this.FlpHasReview.Size = new System.Drawing.Size(1192, 488);
            this.FlpHasReview.TabIndex = 99;
            // 
            // pagerHasReview
            // 
            this.pagerHasReview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerHasReview.Location = new System.Drawing.Point(0, 535);
            this.pagerHasReview.Margin = new System.Windows.Forms.Padding(4);
            this.pagerHasReview.Name = "pagerHasReview";
            this.pagerHasReview.NMax = 0;
            this.pagerHasReview.PageCount = 0;
            this.pagerHasReview.PageCurrent = 1;
            this.pagerHasReview.PageSize = 16;
            this.pagerHasReview.Size = new System.Drawing.Size(1192, 27);
            this.pagerHasReview.TabIndex = 100;
            this.pagerHasReview.EventPaging += new HM.Form_.EventPagingHandler(this.pagerHasReview_EventPaging);
            // 
            // PnlHasReview
            // 
            this.PnlHasReview.BackColor = System.Drawing.Color.White;
            this.PnlHasReview.Controls.Add(this.LblHas_CheckType);
            this.PnlHasReview.Controls.Add(this.PnlHas_CheckType);
            this.PnlHasReview.Controls.Add(this.LblHas_RegisterType);
            this.PnlHasReview.Controls.Add(this.PnlHas_RegisterType);
            this.PnlHasReview.Controls.Add(this.LblHas_UserType);
            this.PnlHasReview.Controls.Add(this.PnlHas_UserType);
            this.PnlHasReview.Controls.Add(this.LblHas_Name);
            this.PnlHasReview.Controls.Add(this.TxtHas_Name);
            this.PnlHasReview.Controls.Add(this.BtnSelecteHasReview);
            this.PnlHasReview.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHasReview.Location = new System.Drawing.Point(0, 0);
            this.PnlHasReview.Name = "PnlHasReview";
            this.PnlHasReview.Size = new System.Drawing.Size(1192, 47);
            this.PnlHasReview.TabIndex = 99;
            // 
            // LblHas_CheckType
            // 
            this.LblHas_CheckType.AutoSize = true;
            this.LblHas_CheckType.ForeColor = System.Drawing.Color.Black;
            this.LblHas_CheckType.Location = new System.Drawing.Point(575, 16);
            this.LblHas_CheckType.Name = "LblHas_CheckType";
            this.LblHas_CheckType.Size = new System.Drawing.Size(68, 19);
            this.LblHas_CheckType.TabIndex = 113;
            this.LblHas_CheckType.Text = "审核结果:";
            // 
            // PnlHas_CheckType
            // 
            this.PnlHas_CheckType.BorderColor = System.Drawing.Color.Gray;
            this.PnlHas_CheckType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlHas_CheckType.Controls.Add(this.CbxHas_CheckType);
            this.PnlHas_CheckType.Location = new System.Drawing.Point(659, 13);
            this.PnlHas_CheckType.Name = "PnlHas_CheckType";
            this.PnlHas_CheckType.Size = new System.Drawing.Size(76, 23);
            this.PnlHas_CheckType.TabIndex = 114;
            // 
            // CbxHas_CheckType
            // 
            this.CbxHas_CheckType.BackColor = System.Drawing.SystemColors.Window;
            this.CbxHas_CheckType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbxHas_CheckType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CbxHas_CheckType.FormattingEnabled = true;
            this.CbxHas_CheckType.HotBackColor = System.Drawing.Color.White;
            this.CbxHas_CheckType.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.CbxHas_CheckType.Location = new System.Drawing.Point(1, 2);
            this.CbxHas_CheckType.LostBackColor = System.Drawing.SystemColors.Window;
            this.CbxHas_CheckType.LostBorderColor = System.Drawing.Color.Transparent;
            this.CbxHas_CheckType.Name = "CbxHas_CheckType";
            this.CbxHas_CheckType.Size = new System.Drawing.Size(73, 20);
            this.CbxHas_CheckType.TabIndex = 110;
            // 
            // LblHas_RegisterType
            // 
            this.LblHas_RegisterType.AutoSize = true;
            this.LblHas_RegisterType.BackColor = System.Drawing.Color.Transparent;
            this.LblHas_RegisterType.Location = new System.Drawing.Point(387, 15);
            this.LblHas_RegisterType.Name = "LblHas_RegisterType";
            this.LblHas_RegisterType.Size = new System.Drawing.Size(68, 19);
            this.LblHas_RegisterType.TabIndex = 111;
            this.LblHas_RegisterType.Text = "注册方式:";
            // 
            // PnlHas_RegisterType
            // 
            this.PnlHas_RegisterType.BorderColor = System.Drawing.Color.Gray;
            this.PnlHas_RegisterType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlHas_RegisterType.Controls.Add(this.CbxHas_RegisterType);
            this.PnlHas_RegisterType.Location = new System.Drawing.Point(472, 12);
            this.PnlHas_RegisterType.Name = "PnlHas_RegisterType";
            this.PnlHas_RegisterType.Size = new System.Drawing.Size(76, 23);
            this.PnlHas_RegisterType.TabIndex = 112;
            // 
            // CbxHas_RegisterType
            // 
            this.CbxHas_RegisterType.BackColor = System.Drawing.SystemColors.Window;
            this.CbxHas_RegisterType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbxHas_RegisterType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CbxHas_RegisterType.FormattingEnabled = true;
            this.CbxHas_RegisterType.HotBackColor = System.Drawing.Color.White;
            this.CbxHas_RegisterType.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.CbxHas_RegisterType.Location = new System.Drawing.Point(1, 2);
            this.CbxHas_RegisterType.LostBackColor = System.Drawing.SystemColors.Window;
            this.CbxHas_RegisterType.LostBorderColor = System.Drawing.Color.Transparent;
            this.CbxHas_RegisterType.Name = "CbxHas_RegisterType";
            this.CbxHas_RegisterType.Size = new System.Drawing.Size(73, 20);
            this.CbxHas_RegisterType.TabIndex = 110;
            // 
            // LblHas_UserType
            // 
            this.LblHas_UserType.AutoSize = true;
            this.LblHas_UserType.ForeColor = System.Drawing.Color.Black;
            this.LblHas_UserType.Location = new System.Drawing.Point(203, 15);
            this.LblHas_UserType.Name = "LblHas_UserType";
            this.LblHas_UserType.Size = new System.Drawing.Size(68, 19);
            this.LblHas_UserType.TabIndex = 109;
            this.LblHas_UserType.Text = "人员类型:";
            // 
            // PnlHas_UserType
            // 
            this.PnlHas_UserType.BorderColor = System.Drawing.Color.Gray;
            this.PnlHas_UserType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlHas_UserType.Controls.Add(this.CbxHas_UserType);
            this.PnlHas_UserType.Location = new System.Drawing.Point(288, 12);
            this.PnlHas_UserType.Name = "PnlHas_UserType";
            this.PnlHas_UserType.Size = new System.Drawing.Size(73, 23);
            this.PnlHas_UserType.TabIndex = 110;
            // 
            // CbxHas_UserType
            // 
            this.CbxHas_UserType.BackColor = System.Drawing.SystemColors.Window;
            this.CbxHas_UserType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CbxHas_UserType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CbxHas_UserType.FormattingEnabled = true;
            this.CbxHas_UserType.HotBackColor = System.Drawing.Color.White;
            this.CbxHas_UserType.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.CbxHas_UserType.Location = new System.Drawing.Point(2, 2);
            this.CbxHas_UserType.LostBackColor = System.Drawing.SystemColors.Window;
            this.CbxHas_UserType.LostBorderColor = System.Drawing.Color.Transparent;
            this.CbxHas_UserType.Name = "CbxHas_UserType";
            this.CbxHas_UserType.Size = new System.Drawing.Size(68, 20);
            this.CbxHas_UserType.TabIndex = 113;
            // 
            // LblHas_Name
            // 
            this.LblHas_Name.AutoSize = true;
            this.LblHas_Name.Location = new System.Drawing.Point(18, 15);
            this.LblHas_Name.Name = "LblHas_Name";
            this.LblHas_Name.Size = new System.Drawing.Size(40, 19);
            this.LblHas_Name.TabIndex = 108;
            this.LblHas_Name.Text = "姓名:";
            // 
            // TxtHas_Name
            // 
            this.TxtHas_Name.BackColor = System.Drawing.SystemColors.Window;
            this.TxtHas_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtHas_Name.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.TxtHas_Name.HotBackColor = System.Drawing.Color.White;
            this.TxtHas_Name.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.TxtHas_Name.Location = new System.Drawing.Point(79, 13);
            this.TxtHas_Name.LostBackColor = System.Drawing.SystemColors.Window;
            this.TxtHas_Name.LostBorderColor = System.Drawing.Color.Transparent;
            this.TxtHas_Name.Name = "TxtHas_Name";
            this.TxtHas_Name.Size = new System.Drawing.Size(98, 23);
            this.TxtHas_Name.TabIndex = 107;
            // 
            // BtnSelecteHasReview
            // 
            this.BtnSelecteHasReview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSelecteHasReview.Location = new System.Drawing.Point(752, 11);
            this.BtnSelecteHasReview.Name = "BtnSelecteHasReview";
            this.BtnSelecteHasReview.Size = new System.Drawing.Size(65, 25);
            this.BtnSelecteHasReview.TabIndex = 16;
            this.BtnSelecteHasReview.Text = "查询";
            this.BtnSelecteHasReview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnSelecteHasReview.Click += new System.EventHandler(this.BtnSelecteHasReview_Click);
            // 
            // rTextBox1
            // 
            this.rTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.rTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rTextBox1.HotBackColor = System.Drawing.Color.White;
            this.rTextBox1.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.rTextBox1.Location = new System.Drawing.Point(442, 15);
            this.rTextBox1.LostBackColor = System.Drawing.SystemColors.Window;
            this.rTextBox1.LostBorderColor = System.Drawing.Color.Transparent;
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.Size = new System.Drawing.Size(112, 23);
            this.rTextBox1.TabIndex = 14;
            // 
            // UcCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.HtcMain);
            this.Name = "UcCheck";
            this.Size = new System.Drawing.Size(1200, 600);
            this.Load += new System.EventHandler(this.Check_Load);
            this.HtcMain.ResumeLayout(false);
            this.MtpWaitReview.ResumeLayout(false);
            this.MtpWaitReview.PerformLayout();
            this.PnlWaitReview.ResumeLayout(false);
            this.PnlWaitReview.PerformLayout();
            this.PxlWait_RegisterType.ResumeLayout(false);
            this.PnlWait_UserType.ResumeLayout(false);
            this.MtpHasReview.ResumeLayout(false);
            this.MtpHasReview.PerformLayout();
            this.PnlHasReview.ResumeLayout(false);
            this.PnlHasReview.PerformLayout();
            this.PnlHas_CheckType.ResumeLayout(false);
            this.PnlHas_RegisterType.ResumeLayout(false);
            this.PnlHas_UserType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public HM.Form_.HMTabControl HtcMain;
        private System.Windows.Forms.TabPage MtpWaitReview;
        private System.Windows.Forms.TabPage MtpHasReview;
        private System.Windows.Forms.Panel PnlWaitReview;
        public System.Windows.Forms.FlowLayoutPanel FlpWaitReview;
        private HM.Form_.HMTile BtnBatchReview;
        private HM.Form_.HMTile BtnSelectWaitReview;
        private System.Windows.Forms.FlowLayoutPanel FlpHasReview;
        private System.Windows.Forms.Panel PnlHasReview;
        private HM.Form_.HMTile BtnSelecteHasReview;
        private HM.Form_.HMCheckBox CbxAll;
        private RTextBox rTextBox1;
        private HM.Form_.HMLabel LblWait_Name;
        private RTextBox TxtWait_Name;
        private HM.Form_.HMLabel LblWait_UserType;
        private PanelXP PnlWait_UserType;
        private HM.Form_.HMLabel LblWait_RegisterType;
        private PanelXP PxlWait_RegisterType;
        private RComboBox CbxWait_RegisterType;
        private RComboBox CbxWait_UserType;
        private HM.Form_.HMLabel LblHas_CheckType;
        private PanelXP PnlHas_CheckType;
        private RComboBox CbxHas_CheckType;
        private HM.Form_.HMLabel LblHas_RegisterType;
        private PanelXP PnlHas_RegisterType;
        private RComboBox CbxHas_RegisterType;
        private HM.Form_.HMLabel LblHas_UserType;
        private PanelXP PnlHas_UserType;
        private RComboBox CbxHas_UserType;
        private HM.Form_.HMLabel LblHas_Name;
        private RTextBox TxtHas_Name;
        private Form_.HMPager pagerHasReview;
        private Form_.HMPager pagerWaitReview;
    }
}
