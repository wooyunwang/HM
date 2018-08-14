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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HtcMain = new HM.Form_.HMTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnData = new System.Windows.Forms.Panel();
            this.gvSystemUser = new HM.Form_.HMDataGridView();
            this.col_user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_is_admin_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_last_login_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_disable = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_reset_password = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_is_admin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_is_del = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnToolBar = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.PagerSystemManage = new HM.Form_.HMPager();
            this.panel1.SuspendLayout();
            this.HtcMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSystemUser)).BeginInit();
            this.pnToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.HtcMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1225, 500);
            this.panel1.TabIndex = 0;
            // 
            // HtcMain
            // 
            this.HtcMain.Controls.Add(this.tabPage1);
            this.HtcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HtcMain.Location = new System.Drawing.Point(0, 0);
            this.HtcMain.Margin = new System.Windows.Forms.Padding(2);
            this.HtcMain.Name = "HtcMain";
            this.HtcMain.SelectedIndex = 0;
            this.HtcMain.Size = new System.Drawing.Size(1225, 500);
            this.HtcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.HtcMain.TabIndex = 0;
            this.HtcMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnData);
            this.tabPage1.Controls.Add(this.pnToolBar);
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1217, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "登录管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnData
            // 
            this.pnData.Controls.Add(this.gvSystemUser);
            this.pnData.Controls.Add(this.PagerSystemManage);
            this.pnData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnData.Location = new System.Drawing.Point(2, 53);
            this.pnData.Margin = new System.Windows.Forms.Padding(2);
            this.pnData.Name = "pnData";
            this.pnData.Size = new System.Drawing.Size(1213, 405);
            this.pnData.TabIndex = 1;
            // 
            // gvSystemUser
            // 
            this.gvSystemUser.AllowUserToAddRows = false;
            this.gvSystemUser.AllowUserToDeleteRows = false;
            this.gvSystemUser.AllowUserToOrderColumns = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.gvSystemUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gvSystemUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSystemUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvSystemUser.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvSystemUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvSystemUser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvSystemUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSystemUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gvSystemUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSystemUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_user_name,
            this.col_is_admin_name,
            this.col_last_login_date,
            this.col_disable,
            this.col_reset_password,
            this.col_id,
            this.col_is_admin,
            this.col_is_del});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvSystemUser.DefaultCellStyle = dataGridViewCellStyle8;
            this.gvSystemUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvSystemUser.EnableHeadersVisualStyles = false;
            this.gvSystemUser.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvSystemUser.Location = new System.Drawing.Point(0, 0);
            this.gvSystemUser.Name = "gvSystemUser";
            this.gvSystemUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSystemUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gvSystemUser.RowHeadersVisible = false;
            this.gvSystemUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSystemUser.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gvSystemUser.RowTemplate.Height = 50;
            this.gvSystemUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSystemUser.Size = new System.Drawing.Size(1213, 381);
            this.gvSystemUser.TabIndex = 67;
            this.gvSystemUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSystemUser_CellContentClick);
            this.gvSystemUser.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gvSystemUser_RowPrePaint);
            // 
            // col_user_name
            // 
            this.col_user_name.DataPropertyName = "user_name";
            this.col_user_name.FillWeight = 94.06081F;
            this.col_user_name.HeaderText = "用户名";
            this.col_user_name.Name = "col_user_name";
            this.col_user_name.ReadOnly = true;
            // 
            // col_is_admin_name
            // 
            this.col_is_admin_name.DataPropertyName = "is_admin_name";
            this.col_is_admin_name.HeaderText = "是否管理员";
            this.col_is_admin_name.Name = "col_is_admin_name";
            // 
            // col_last_login_date
            // 
            this.col_last_login_date.DataPropertyName = "last_login_date";
            this.col_last_login_date.HeaderText = "最近登录日期";
            this.col_last_login_date.Name = "col_last_login_date";
            // 
            // col_disable
            // 
            this.col_disable.HeaderText = "启用/禁用";
            this.col_disable.Name = "col_disable";
            // 
            // col_reset_password
            // 
            this.col_reset_password.HeaderText = "重置密码";
            this.col_reset_password.Name = "col_reset_password";
            this.col_reset_password.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_reset_password.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "id";
            this.col_id.Name = "col_id";
            this.col_id.Visible = false;
            // 
            // col_is_admin
            // 
            this.col_is_admin.DataPropertyName = "is_admin";
            this.col_is_admin.HeaderText = "is_admin";
            this.col_is_admin.Name = "col_is_admin";
            this.col_is_admin.Visible = false;
            // 
            // col_is_del
            // 
            this.col_is_del.DataPropertyName = "is_del";
            this.col_is_del.HeaderText = "is_del";
            this.col_is_del.Name = "col_is_del";
            this.col_is_del.Visible = false;
            // 
            // pnToolBar
            // 
            this.pnToolBar.Controls.Add(this.btnAdd);
            this.pnToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnToolBar.Location = new System.Drawing.Point(2, 2);
            this.pnToolBar.Margin = new System.Windows.Forms.Padding(2);
            this.pnToolBar.Name = "pnToolBar";
            this.pnToolBar.Size = new System.Drawing.Size(1213, 51);
            this.pnToolBar.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(1130, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 25);
            this.btnAdd.TabIndex = 110;
            this.btnAdd.Text = "新增登录用户";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // PagerSystemManage
            // 
            this.PagerSystemManage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PagerSystemManage.Location = new System.Drawing.Point(0, 381);
            this.PagerSystemManage.Name = "PagerSystemManage";
            this.PagerSystemManage.NMax = 0;
            this.PagerSystemManage.PageCount = 0;
            this.PagerSystemManage.PageCurrent = 1;
            this.PagerSystemManage.PageSize = 20;
            this.PagerSystemManage.Size = new System.Drawing.Size(1213, 24);
            this.PagerSystemManage.TabIndex = 68;
            this.PagerSystemManage.EventPaging += new HM.Form_.EventPagingHandler(this.PagerSystemManage_EventPaging);
            // 
            // SystemUserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SystemUserManage";
            this.Size = new System.Drawing.Size(1225, 500);
            this.Load += new System.EventHandler(this.SystemUserManage_Load);
            this.panel1.ResumeLayout(false);
            this.HtcMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSystemUser)).EndInit();
            this.pnToolBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private HM.Form_.HMTabControl HtcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnData;
        private System.Windows.Forms.Panel pnToolBar;
        private System.Windows.Forms.Button btnAdd;
        private HM.Form_.HMDataGridView gvSystemUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_is_admin_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_last_login_date;
        private System.Windows.Forms.DataGridViewLinkColumn col_disable;
        private System.Windows.Forms.DataGridViewLinkColumn col_reset_password;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_is_admin;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_is_del;
        private Form_.HMPager PagerSystemManage;
    }
}
