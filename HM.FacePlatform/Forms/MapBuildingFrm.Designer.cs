namespace HM.FacePlatform.Forms
{
    partial class MapBuildingFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlInfo = new System.Windows.Forms.Panel();
            this.LblMaoInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GbxMap = new System.Windows.Forms.GroupBox();
            this.RbnAll = new HM.Form_.HMRadioButton();
            this.RbnNoMap = new HM.Form_.HMRadioButton();
            this.RbnHasMap = new HM.Form_.HMRadioButton();
            this.BtnBatchMap = new HM.Form_.HMTile();
            this.BtnSearch = new HM.Form_.HMTile();
            this.TxtBuildingName = new HM.Form_.Old.TextBox.RTextBox();
            this.LblBuildingName = new System.Windows.Forms.Label();
            this.DgvBuilding = new HM.Form_.HMDataGridView();
            this.PagerBuilding = new HM.Form_.HMPager();
            this.colCB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_building_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_building_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_has_map_text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PnlInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GbxMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBuilding)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlInfo
            // 
            this.PnlInfo.Controls.Add(this.LblMaoInfo);
            this.PnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlInfo.Location = new System.Drawing.Point(20, 60);
            this.PnlInfo.Name = "PnlInfo";
            this.PnlInfo.Size = new System.Drawing.Size(967, 67);
            this.PnlInfo.TabIndex = 0;
            // 
            // LblMaoInfo
            // 
            this.LblMaoInfo.AutoSize = true;
            this.LblMaoInfo.BackColor = System.Drawing.Color.Transparent;
            this.LblMaoInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblMaoInfo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.LblMaoInfo.ForeColor = System.Drawing.Color.Black;
            this.LblMaoInfo.Location = new System.Drawing.Point(42, 21);
            this.LblMaoInfo.Name = "LblMaoInfo";
            this.LblMaoInfo.Size = new System.Drawing.Size(58, 21);
            this.LblMaoInfo.TabIndex = 1;
            this.LblMaoInfo.Text = "猫信息";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GbxMap);
            this.panel1.Controls.Add(this.BtnBatchMap);
            this.panel1.Controls.Add(this.BtnSearch);
            this.panel1.Controls.Add(this.TxtBuildingName);
            this.panel1.Controls.Add(this.LblBuildingName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 67);
            this.panel1.TabIndex = 1;
            // 
            // GbxMap
            // 
            this.GbxMap.Controls.Add(this.RbnAll);
            this.GbxMap.Controls.Add(this.RbnNoMap);
            this.GbxMap.Controls.Add(this.RbnHasMap);
            this.GbxMap.Location = new System.Drawing.Point(265, 3);
            this.GbxMap.Name = "GbxMap";
            this.GbxMap.Size = new System.Drawing.Size(236, 54);
            this.GbxMap.TabIndex = 123;
            this.GbxMap.TabStop = false;
            // 
            // RbnAll
            // 
            this.RbnAll.AutoSize = true;
            this.RbnAll.Checked = true;
            this.RbnAll.Location = new System.Drawing.Point(24, 23);
            this.RbnAll.Name = "RbnAll";
            this.RbnAll.Size = new System.Drawing.Size(49, 15);
            this.RbnAll.TabIndex = 2;
            this.RbnAll.TabStop = true;
            this.RbnAll.Text = "全部";
            this.RbnAll.UseVisualStyleBackColor = true;
            // 
            // RbnNoMap
            // 
            this.RbnNoMap.AutoSize = true;
            this.RbnNoMap.Location = new System.Drawing.Point(153, 23);
            this.RbnNoMap.Name = "RbnNoMap";
            this.RbnNoMap.Size = new System.Drawing.Size(62, 15);
            this.RbnNoMap.TabIndex = 1;
            this.RbnNoMap.Text = "未关联";
            this.RbnNoMap.UseVisualStyleBackColor = true;
            // 
            // RbnHasMap
            // 
            this.RbnHasMap.AutoSize = true;
            this.RbnHasMap.Location = new System.Drawing.Point(82, 23);
            this.RbnHasMap.Name = "RbnHasMap";
            this.RbnHasMap.Size = new System.Drawing.Size(62, 15);
            this.RbnHasMap.TabIndex = 0;
            this.RbnHasMap.TabStop = true;
            this.RbnHasMap.Text = "已关联";
            this.RbnHasMap.UseVisualStyleBackColor = true;
            // 
            // BtnBatchMap
            // 
            this.BtnBatchMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBatchMap.Location = new System.Drawing.Point(759, 22);
            this.BtnBatchMap.Name = "BtnBatchMap";
            this.BtnBatchMap.Size = new System.Drawing.Size(89, 25);
            this.BtnBatchMap.TabIndex = 122;
            this.BtnBatchMap.Text = "批量关联";
            this.BtnBatchMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnBatchMap.Click += new System.EventHandler(this.BtnBatchMap_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearch.Location = new System.Drawing.Point(662, 22);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(77, 25);
            this.BtnSearch.TabIndex = 121;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtBuildingName
            // 
            this.TxtBuildingName.BackColor = System.Drawing.SystemColors.Window;
            this.TxtBuildingName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBuildingName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.TxtBuildingName.HotBackColor = System.Drawing.Color.White;
            this.TxtBuildingName.HotBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.TxtBuildingName.Location = new System.Drawing.Point(106, 22);
            this.TxtBuildingName.LostBackColor = System.Drawing.SystemColors.Window;
            this.TxtBuildingName.LostBorderColor = System.Drawing.Color.Transparent;
            this.TxtBuildingName.MaxLength = 50;
            this.TxtBuildingName.Name = "TxtBuildingName";
            this.TxtBuildingName.Size = new System.Drawing.Size(141, 23);
            this.TxtBuildingName.TabIndex = 69;
            // 
            // LblBuildingName
            // 
            this.LblBuildingName.AutoSize = true;
            this.LblBuildingName.BackColor = System.Drawing.Color.Transparent;
            this.LblBuildingName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblBuildingName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.LblBuildingName.ForeColor = System.Drawing.Color.Black;
            this.LblBuildingName.Location = new System.Drawing.Point(26, 22);
            this.LblBuildingName.Name = "LblBuildingName";
            this.LblBuildingName.Size = new System.Drawing.Size(74, 21);
            this.LblBuildingName.TabIndex = 1;
            this.LblBuildingName.Text = "楼栋名称";
            // 
            // DgvBuilding
            // 
            this.DgvBuilding.AllowUserToAddRows = false;
            this.DgvBuilding.AllowUserToDeleteRows = false;
            this.DgvBuilding.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.DgvBuilding.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvBuilding.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvBuilding.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvBuilding.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DgvBuilding.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvBuilding.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgvBuilding.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvBuilding.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvBuilding.ColumnHeadersHeight = 36;
            this.DgvBuilding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvBuilding.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCB,
            this.col_building_code,
            this.col_building_name,
            this.col_has_map_text});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvBuilding.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvBuilding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvBuilding.EnableHeadersVisualStyles = false;
            this.DgvBuilding.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DgvBuilding.Location = new System.Drawing.Point(20, 194);
            this.DgvBuilding.Name = "DgvBuilding";
            this.DgvBuilding.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvBuilding.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvBuilding.RowHeadersVisible = false;
            this.DgvBuilding.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvBuilding.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvBuilding.RowTemplate.Height = 50;
            this.DgvBuilding.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvBuilding.Size = new System.Drawing.Size(967, 541);
            this.DgvBuilding.TabIndex = 68;
            this.DgvBuilding.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DgvBuilding_RowPrePaint);
            // 
            // PagerBuilding
            // 
            this.PagerBuilding.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PagerBuilding.Location = new System.Drawing.Point(20, 735);
            this.PagerBuilding.Name = "PagerBuilding";
            this.PagerBuilding.NMax = 0;
            this.PagerBuilding.PageCount = 0;
            this.PagerBuilding.PageCurrent = 1;
            this.PagerBuilding.PageSize = 20;
            this.PagerBuilding.Size = new System.Drawing.Size(967, 24);
            this.PagerBuilding.TabIndex = 69;
            this.PagerBuilding.EventPaging += new HM.Form_.EventPagingHandler(this.PagerBuilding_EventPaging);
            // 
            // colCB
            // 
            this.colCB.DataPropertyName = "is_selected";
            this.colCB.FillWeight = 1F;
            this.colCB.HeaderText = "";
            this.colCB.MinimumWidth = 100;
            this.colCB.Name = "colCB";
            this.colCB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_building_code
            // 
            this.col_building_code.DataPropertyName = "building_code";
            this.col_building_code.FillWeight = 70F;
            this.col_building_code.HeaderText = "楼栋编码";
            this.col_building_code.MinimumWidth = 150;
            this.col_building_code.Name = "col_building_code";
            // 
            // col_building_name
            // 
            this.col_building_name.DataPropertyName = "building_name";
            this.col_building_name.FillWeight = 80F;
            this.col_building_name.HeaderText = "楼栋名称";
            this.col_building_name.MinimumWidth = 300;
            this.col_building_name.Name = "col_building_name";
            this.col_building_name.ReadOnly = true;
            // 
            // col_has_map_text
            // 
            this.col_has_map_text.FillWeight = 30F;
            this.col_has_map_text.HeaderText = "是否已关联";
            this.col_has_map_text.Name = "col_has_map_text";
            // 
            // MapBuildingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 779);
            this.Controls.Add(this.DgvBuilding);
            this.Controls.Add(this.PagerBuilding);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PnlInfo);
            this.Name = "MapBuildingFrm";
            this.Text = "关联楼栋";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapBuildingFrm_FormClosed);
            this.Load += new System.EventHandler(this.MapBuildingFrm_Load);
            this.PnlInfo.ResumeLayout(false);
            this.PnlInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GbxMap.ResumeLayout(false);
            this.GbxMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBuilding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlInfo;
        private System.Windows.Forms.Label LblMaoInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblBuildingName;
        private Form_.HMDataGridView DgvBuilding;
        private Form_.HMPager PagerBuilding;
        private Form_.Old.TextBox.RTextBox TxtBuildingName;
        private Form_.HMTile BtnSearch;
        private Form_.HMTile BtnBatchMap;
        private System.Windows.Forms.GroupBox GbxMap;
        private Form_.HMRadioButton RbnAll;
        private Form_.HMRadioButton RbnNoMap;
        private Form_.HMRadioButton RbnHasMap;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCB;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_building_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_building_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_has_map_text;
    }
}