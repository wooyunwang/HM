namespace HM.Form_
{
    partial class HMPager
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
            this.components = new System.ComponentModel.Container();
            this.bsPager = new System.Windows.Forms.BindingSource(this.components);
            this.bnPager = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPrev = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.lblcurentpage = new System.Windows.Forms.ToolStripTextBox();
            this.lblPageCount = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbPagecount = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPageCount1 = new System.Windows.Forms.ToolStripLabel();
            this.lblMaxPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecordCount = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bsPager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnPager)).BeginInit();
            this.bnPager.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnPager
            // 
            this.bnPager.AddNewItem = null;
            this.bnPager.AutoSize = false;
            this.bnPager.CanOverflow = false;
            this.bnPager.CountItem = null;
            this.bnPager.CountItemFormat = "";
            this.bnPager.DeleteItem = null;
            this.bnPager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bnPager.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.bnPager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.btnFirst,
            this.btnPrev,
            this.bindingNavigatorSeparator,
            this.lblcurentpage,
            this.lblPageCount,
            this.bindingNavigatorSeparator1,
            this.btnNext,
            this.btnLast,
            this.bindingNavigatorSeparator2,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cmbPagecount,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.lblPageCount1,
            this.lblMaxPage,
            this.toolStripSeparator3,
            this.lblRecordCount});
            this.bnPager.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.bnPager.Location = new System.Drawing.Point(0, 0);
            this.bnPager.Margin = new System.Windows.Forms.Padding(0, 0, 33, 0);
            this.bnPager.MoveFirstItem = null;
            this.bnPager.MoveLastItem = null;
            this.bnPager.MoveNextItem = null;
            this.bnPager.MovePreviousItem = null;
            this.bnPager.Name = "bnPager";
            this.bnPager.PositionItem = null;
            this.bnPager.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bnPager.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bnPager.Size = new System.Drawing.Size(822, 24);
            this.bnPager.TabIndex = 3;
            this.bnPager.Text = "BindingNavigator控件";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(20, 17);
            this.toolStripLabel2.Text = "   ";
            // 
            // btnFirst
            // 
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirst.Image = Properties.Resources.page_first;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.RightToLeftAutoMirrorImage = true;
            this.btnFirst.Size = new System.Drawing.Size(28, 28);
            this.btnFirst.Text = "转到第一页";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrev.Image = Properties.Resources.page_pre;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.RightToLeftAutoMirrorImage = true;
            this.btnPrev.Size = new System.Drawing.Size(28, 28);
            this.btnPrev.Text = "转到上一页";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 23);
            // 
            // lblcurentpage
            // 
            this.lblcurentpage.AccessibleName = "位置";
            this.lblcurentpage.AutoSize = false;
            this.lblcurentpage.Font = new System.Drawing.Font("宋体", 9F);
            this.lblcurentpage.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.lblcurentpage.Name = "lblcurentpage";
            this.lblcurentpage.Size = new System.Drawing.Size(30, 21);
            this.lblcurentpage.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblcurentpage.ToolTipText = "Location";
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = false;
            this.lblPageCount.Font = new System.Drawing.Font("宋体", 9F);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(50, 20);
            this.lblPageCount.ToolTipText = "总页数";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = Properties.Resources.page_next;
            this.btnNext.Name = "btnNext";
            this.btnNext.RightToLeftAutoMirrorImage = true;
            this.btnNext.Size = new System.Drawing.Size(28, 28);
            this.btnNext.Text = "Move to next page";
            this.btnNext.ToolTipText = "转到下一页";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLast.Image = Properties.Resources.page_last;
            this.btnLast.Name = "btnLast";
            this.btnLast.RightToLeftAutoMirrorImage = true;
            this.btnLast.Size = new System.Drawing.Size(28, 28);
            this.btnLast.Text = "Moved to the last page";
            this.btnLast.ToolTipText = "转到最后一页";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Font = new System.Drawing.Font("宋体", 9F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(50, 20);
            this.toolStripLabel1.Text = "当前页";
            // 
            // cmbPagecount
            // 
            this.cmbPagecount.AutoSize = false;
            this.cmbPagecount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPagecount.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbPagecount.Name = "cmbPagecount";
            this.cmbPagecount.Size = new System.Drawing.Size(60, 20);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = Properties.Resources.page_refresh;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "跳转";
            this.toolStripButton1.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // lblPageCount1
            // 
            this.lblPageCount1.AutoSize = false;
            this.lblPageCount1.Font = new System.Drawing.Font("宋体", 9F);
            this.lblPageCount1.Name = "lblPageCount1";
            this.lblPageCount1.Size = new System.Drawing.Size(200, 20);
            this.lblPageCount1.Text = "页数";
            // 
            // lblMaxPage
            // 
            this.lblMaxPage.Name = "lblMaxPage";
            this.lblMaxPage.Size = new System.Drawing.Size(0, 0);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = false;
            this.lblRecordCount.Font = new System.Drawing.Font("宋体", 9F);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(140, 20);
            this.lblRecordCount.Text = "总记录数";
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucPager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bnPager);
            this.Name = "ucPager";
            this.Size = new System.Drawing.Size(822, 24);
            ((System.ComponentModel.ISupportInitialize)(this.bsPager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnPager)).EndInit();
            this.bnPager.ResumeLayout(false);
            this.bnPager.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingSource bsPager;
        public System.Windows.Forms.BindingNavigator bnPager;
        private System.Windows.Forms.ToolStripLabel lblPageCount;
        private System.Windows.Forms.ToolStripButton btnFirst;
        private System.Windows.Forms.ToolStripButton btnPrev;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox lblcurentpage;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnLast;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbPagecount;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblMaxPage;
        private System.Windows.Forms.ToolStripLabel lblPageCount1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblRecordCount;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}
