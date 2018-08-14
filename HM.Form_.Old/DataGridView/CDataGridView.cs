using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace HM.Form_.Old
{
    public partial class CDataGridView : System.Windows.Forms.DataGridView
    {
        public CDataGridView()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            this.AllowUserToAddRows = false;           
        }
       
        protected override void OnCreateControl()
        {
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(247, 246, 239);
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;//Raised
            this.ColumnHeadersHeight = 26;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.RowHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.RowHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            this.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DefaultCellStyle.SelectionBackColor = Color.Wheat;
            this.DefaultCellStyle.SelectionForeColor = Color.DarkSlateBlue;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;//Fixed3D
            this.AllowUserToOrderColumns = true;
            this.AutoGenerateColumns = false;

            //奇数行的颜色
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(216, 229, 248);

           

            base.OnCreateControl();



        }

      



        /// <summary>
        /// 创建新的菜单项
        /// </summary>
        /// <param name="name">菜单名</param>
        /// <param name="Text">显示文字</param>
        /// <param name="objEh">绑定事件</param>
        /// <returns>返一个ToolStripMenuItem对象</returns>
        private ToolStripMenuItem createItem(string name, string Text, EventHandler objEh)
        {
            System.Windows.Forms.ToolStripMenuItem lolumns = new System.Windows.Forms.ToolStripMenuItem();
            lolumns.ForeColor = System.Drawing.Color.Black;
            lolumns.Name = name;
            lolumns.Size = new System.Drawing.Size(152, 24);
            lolumns.Text = Text;
            lolumns.Click += objEh;
            return lolumns;
        }

        //Button单击事件
        void objpb_Click(object sender, EventArgs e)
        {
            Button objbootn = (Button)sender;
            //显示菜单的位置
            objbootn.ContextMenuStrip.Show(Control.MousePosition.X, Control.MousePosition.Y);
        }

        #region 鼠标颜色
        Color defaultcolor;

        //移到单元格时的颜色
        protected override void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
        {
            base.OnCellMouseMove(e);
            try
            {
                Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.YellowGreen;
            }
            catch { }
        }

        //进入单元格时保存当前的颜色

        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);
            try
            {
                defaultcolor = Rows[e.RowIndex].DefaultCellStyle.BackColor;
            }
            catch { }
        }

        //离开时还原颜色
        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseLeave(e);
            try
            {
                Rows[e.RowIndex].DefaultCellStyle.BackColor = defaultcolor;
            }
            catch { }
        }     

        #endregion

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // CDataGridView
            // 
            this.RowTemplate.Height = 23;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}