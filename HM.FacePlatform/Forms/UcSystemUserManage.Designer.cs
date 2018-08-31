namespace HM.FacePlatform
{
    partial class UcSystemUserManage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvSystemUser = new HM.Form_.HMDataGridView();
            this.col_user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_is_admin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_last_login_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_disable = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_reset_password = new System.Windows.Forms.DataGridViewLinkColumn();
            this.PagerSystemManage = new HM.Form_.HMPager();
            this.pnToolBar = new System.Windows.Forms.Panel();
            this.BtnAdd = new HM.Form_.HMTile();
            this.PnlMain = new HM.Form_.HMPanel();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSystemUser)).BeginInit();
            this.pnToolBar.SuspendLayout();
            this.PnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvSystemUser
            // 
            this.DgvSystemUser.AllowUserToAddRows = false;
            this.DgvSystemUser.AllowUserToDeleteRows = false;
            this.DgvSystemUser.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.DgvSystemUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvSystemUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvSystemUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvSystemUser.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DgvSystemUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvSystemUser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgvSystemUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvSystemUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvSystemUser.ColumnHeadersHeight = 36;
            this.DgvSystemUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvSystemUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_user_name,
            this.col_is_admin,
            this.col_last_login_date,
            this.col_disable,
            this.col_reset_password});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSystemUser.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvSystemUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSystemUser.EnableHeadersVisualStyles = false;
            this.DgvSystemUser.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DgvSystemUser.Location = new System.Drawing.Point(10, 61);
            this.DgvSystemUser.Name = "DgvSystemUser";
            this.DgvSystemUser.ReadOnly = true;
            this.DgvSystemUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvSystemUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvSystemUser.RowHeadersVisible = false;
            this.DgvSystemUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvSystemUser.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvSystemUser.RowTemplate.Height = 50;
            this.DgvSystemUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSystemUser.Size = new System.Drawing.Size(1180, 505);
            this.DgvSystemUser.TabIndex = 67;
            this.DgvSystemUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSystemUser_CellContentClick);
            this.DgvSystemUser.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DgvSystemUser_RowPrePaint);
            // 
            // col_user_name
            // 
            this.col_user_name.DataPropertyName = "user_name";
            this.col_user_name.FillWeight = 300F;
            this.col_user_name.HeaderText = "用户名";
            this.col_user_name.MinimumWidth = 300;
            this.col_user_name.Name = "col_user_name";
            this.col_user_name.ReadOnly = true;
            // 
            // col_is_admin
            // 
            this.col_is_admin.DataPropertyName = "is_admin";
            this.col_is_admin.FillWeight = 1F;
            this.col_is_admin.HeaderText = "是否管理员";
            this.col_is_admin.MinimumWidth = 120;
            this.col_is_admin.Name = "col_is_admin";
            this.col_is_admin.ReadOnly = true;
            // 
            // col_last_login_date
            // 
            this.col_last_login_date.DataPropertyName = "last_login_date";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewCellStyle3.NullValue = null;
            this.col_last_login_date.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_last_login_date.FillWeight = 1F;
            this.col_last_login_date.HeaderText = "最近登录日期";
            this.col_last_login_date.MinimumWidth = 150;
            this.col_last_login_date.Name = "col_last_login_date";
            this.col_last_login_date.ReadOnly = true;
            // 
            // col_disable
            // 
            this.col_disable.FillWeight = 1F;
            this.col_disable.HeaderText = "启用/禁用";
            this.col_disable.MinimumWidth = 100;
            this.col_disable.Name = "col_disable";
            this.col_disable.ReadOnly = true;
            // 
            // col_reset_password
            // 
            this.col_reset_password.FillWeight = 1F;
            this.col_reset_password.HeaderText = "重置密码";
            this.col_reset_password.MinimumWidth = 100;
            this.col_reset_password.Name = "col_reset_password";
            this.col_reset_password.ReadOnly = true;
            this.col_reset_password.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_reset_password.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PagerSystemManage
            // 
            this.PagerSystemManage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PagerSystemManage.Location = new System.Drawing.Point(10, 566);
            this.PagerSystemManage.Name = "PagerSystemManage";
            this.PagerSystemManage.NMax = 0;
            this.PagerSystemManage.PageCount = 0;
            this.PagerSystemManage.PageCurrent = 1;
            this.PagerSystemManage.PageSize = 20;
            this.PagerSystemManage.Size = new System.Drawing.Size(1180, 24);
            this.PagerSystemManage.TabIndex = 68;
            this.PagerSystemManage.EventPaging += new HM.Form_.EventPagingHandler(this.PagerSystemManage_EventPaging);
            // 
            // pnToolBar
            // 
            this.pnToolBar.Controls.Add(this.BtnAdd);
            this.pnToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnToolBar.Location = new System.Drawing.Point(10, 10);
            this.pnToolBar.Margin = new System.Windows.Forms.Padding(2);
            this.pnToolBar.Name = "pnToolBar";
            this.pnToolBar.Size = new System.Drawing.Size(1180, 51);
            this.pnToolBar.TabIndex = 0;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.Location = new System.Drawing.Point(1041, 12);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(121, 25);
            this.BtnAdd.TabIndex = 110;
            this.BtnAdd.Text = "新增登录用户";
            this.BtnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.DgvSystemUser);
            this.PnlMain.Controls.Add(this.pnToolBar);
            this.PnlMain.Controls.Add(this.PagerSystemManage);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.HorizontalScrollbarBarColor = true;
            this.PnlMain.HorizontalScrollbarHighlightOnWheel = false;
            this.PnlMain.HorizontalScrollbarSize = 10;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.PnlMain.Size = new System.Drawing.Size(1200, 600);
            this.PnlMain.TabIndex = 69;
            this.PnlMain.VerticalScrollbarBarColor = true;
            this.PnlMain.VerticalScrollbarHighlightOnWheel = false;
            this.PnlMain.VerticalScrollbarSize = 10;
            // 
            // UcSystemUserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PnlMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UcSystemUserManage";
            this.Size = new System.Drawing.Size(1200, 600);
            this.Load += new System.EventHandler(this.SystemUserManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSystemUser)).EndInit();
            this.pnToolBar.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnToolBar;
        private HM.Form_.HMTile BtnAdd;
        private HM.Form_.HMDataGridView DgvSystemUser;
        private Form_.HMPager PagerSystemManage;
        private Form_.HMPanel PnlMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_is_admin;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_last_login_date;
        private System.Windows.Forms.DataGridViewLinkColumn col_disable;
        private System.Windows.Forms.DataGridViewLinkColumn col_reset_password;
    }
}
