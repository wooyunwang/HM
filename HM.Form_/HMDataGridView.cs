using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HM.Form_
{
    public class HMDataGridView : DataGridView
    {
        public HMDataGridView()
            : base()
        {
            this.EnableHeadersVisualStyles = false;
            this.AllowUserToOrderColumns = true;
            this.AllowUserToAddRows = false;
            this.AutoGenerateColumns = false;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        protected override void OnCreateControl()
        {
            //统一设置，实际release此部分无效
#if DEBUG
            this.ColumnHeadersHeight = 36;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(239, 243, 250);
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;//Raised
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            this.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.RowHeadersDefaultCellStyle.BackColor = SystemColors.Window;
            this.RowHeadersDefaultCellStyle.ForeColor = SystemColors.WindowText;
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.DefaultCellStyle.SelectionBackColor = Color.Wheat;
            this.DefaultCellStyle.SelectionForeColor = Color.DarkSlateBlue;
            this.GridColor = SystemColors.GradientActiveCaption;
            this.BackgroundColor = SystemColors.Window;
            this.BorderStyle = BorderStyle.None;//Fixed3D
            this.RowsDefaultCellStyle.ForeColor = Color.Black;
            //奇数行的颜色
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(239, 243, 250);
#endif

            base.OnCreateControl();
        }

        //protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        //{
        //    //自动编号，与数据无关
        //    Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
        //       e.RowBounds.Location.Y,
        //       this.RowHeadersWidth - 4,
        //       e.RowBounds.Height);
        //    TextRenderer.DrawText(e.Graphics,
        //          (e.RowIndex + 1).ToString(),
        //           this.RowHeadersDefaultCellStyle.Font,
        //           rectangle,
        //           this.RowHeadersDefaultCellStyle.ForeColor,
        //           TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

        //    base.OnRowPostPaint(e);
        //}
    }
}
