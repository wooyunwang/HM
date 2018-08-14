using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace HM.Form_.Old.Pager
{
    public partial class Pager : UserControl
    {
        public Pager()
        {
            InitializeComponent();
            this.lblLoading.Visible = false;
        }
        /// <summary>
        /// 获取总记录条数，必要的事件，线程
        /// </summary>
        public event HM.Form_.Old.Pager.EventPagingArg.GetNMaxEventHander getNMaxEvent;
        /// <summary>
        /// 获取当前页，必要的事件，线程
        /// </summary>
        public event HM.Form_.Old.Pager.EventPagingArg.DataSourceEventHandler getPageingEvent;

        //private bool _ReLoadNMax = false;
        ///// <summary>
        ///// 重新加载NMax，查询条件变了。这个就跟着变
        ///// </summary>
        //public bool ReLoadNMax
        //{
        //    get { return _ReLoadNMax; }
        //    set { _ReLoadNMax = value; }
        //}

        /// <summary>
        /// 控件是否可用,已经被重写
        /// </summary>
        public new bool Enabled
        {
            get { return this.btnFirst.Enabled; }
            set
            {

                foreach (ToolStripItem var in this.toolStrip1.Items)
                {
                    if (!var.Equals(this.lblLoading))
                        var.Enabled = value;
                    else
                        var.Visible = !value;
                }

            }
        }


        private DataGridView _dataGridView = null;
        /// <summary>
        /// 需要的datagridview一个
        /// </summary>
        [Category("必要选项")]
        public DataGridView dataGridView
        {
            get { return _dataGridView; }
            set { _dataGridView = value; }
        }

        private DataTable _OnePageDataTable;
        /// <summary>
        /// 一页的数据
        /// </summary>
        public DataTable OnePageDataTable
        {
            get { return _OnePageDataTable; }
            //set { _OnePageDataSet = value; }
        }

        /**/
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        private int _pageSize = 30;
        /**/
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                GetPageCount();
            }
        }

        private int _nMax = 0;
        /**/
        /// <summary>
        /// 总记录数
        /// </summary>
        public int NMax
        {
            get { return _nMax; }
            set
            {
                _nMax = value;
                GetPageCount();
            }
        }

        private int _pageCount = 0;
        /**/
        /// <summary>
        /// 页数=总记录数/每页显示记录数
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
            //set { _pageCount = value; }
        }

        private int _pageCurrent = 1;
        /**/
        /// <summary>
        /// 当前页号
        /// </summary>
        public int PageCurrent
        {
            get { return _pageCurrent; }
            //set { _pageCurrent = value; }
        }


        private void GetPageCount()
        {
            if (this.NMax > 0)
            {
                this._pageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.NMax) / Convert.ToDouble(this.PageSize)));
            }
            else
            {
                this._pageCount = 0;
            }
        }

        /**/
        /// <summary>
        /// 翻页控件数据绑定的方法
        /// </summary>
        private void Bind()
        {

            this.dataGridView.DataSource = this._OnePageDataTable;

            if (this.PageCurrent > this.PageCount)
            {
                this._pageCurrent = this.PageCount;
            }
            if (this.PageCount < 1)
            {
                this._pageCurrent = 1;
            }

            if (this.PageCount == 0)
            {
                this.lblpageIndex_pageCount.Text = this.PageCurrent.ToString().PadLeft(5) + @"/1";
            }
            else
            {
                this.lblpageIndex_pageCount.Text = this.PageCurrent.ToString().PadLeft(5) + @"/" + this.PageCount.ToString().PadRight(5);
            }
            //this.lblpageIndex_pageCount.Text = string.Format("{0}/{1}", this.PageCurrent, this.PageCount);
            this.lblPageSize_totalItem.Text = string.Format("每页{0}项，共{1}项", this.PageSize, this.NMax);

            if (this.PageCurrent == 1)
            {
                this.btnPrev.Enabled = false;
                this.btnFirst.Enabled = false;
            }
            else
            {
                btnPrev.Enabled = true;
                btnFirst.Enabled = true;
            }

            if (this.PageCurrent == this.PageCount)
            {
                this.btnLast.Enabled = false;
                this.btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }

            if (this.NMax == 0)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
            }

        }
        /// <summary>
        /// 第一次加载
        /// </summary>
        bool _isFirstBind = true;
        /// <summary>
        /// 第一次绑定，这次绑定会获取NMax的数量
        /// </summary>
        public void FirstBind()
        {
            this._pageCurrent = 1;
            _isFirstBind = true;
            CreateThreadAndStart();
        }
        /// <summary>
        /// 内部加载，不是第一次
        /// </summary>
        public void InnerBind()
        {
            if (this._pageCount < 1)//没有页数，表示没数据，什么工作都不用做
            {
                //MessageBoxClew.Show("没有数据！");
                return;
            }
            this._isFirstBind = false;
            CreateThreadAndStart();

        }

        private void CreateThreadAndStart()
        {
            Thread td = new Thread(new ThreadStart(getWSnmaxAndPage));
            td.IsBackground = true;
            td.Start();
            //把所有的控件变成灰色。并显示loading...
            this.Enabled = false;
        }

        private void getWSnmaxAndPage()
        {
            if (_isFirstBind && getNMaxEvent != null)
            {
                this._pageCurrent = 1;
                this.NMax = getNMaxEvent();
            }
            getWSpage();

            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            try
            {
                this.Invoke(new MethodInvoker(GetPageCompleted));
            }
            catch
            {
            }
        }

        private void getWSpage()
        {
            if (getPageingEvent != null)//如果没找到项数，就不必获取数据源
            {
                this._OnePageDataTable = getPageingEvent(this.PageCurrent, this.PageSize);
                //this.NMax = this._nMax;
            }
            else
            {
                this._OnePageDataTable = null;
            }
        }

        private void GetPageCompleted()
        {
            this.Enabled = true;
            Bind();
        }




        private void btnFirst_Click(object sender, EventArgs e)
        {
            this._pageCurrent = 1;
            this.InnerBind();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this._pageCurrent -= 1;
            if (PageCurrent <= 0)
            {
                this._pageCurrent = 1;
            }
            this.InnerBind();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this._pageCurrent += 1;
            if (PageCurrent > PageCount)
            {
                this._pageCurrent = PageCount;
            }
            this.InnerBind();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this._pageCurrent = PageCount;
            this.InnerBind();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {

            if (this.txtCurrentPage.Text != null && txtCurrentPage.Text != "")
            {
                int curPage;
                if (Int32.TryParse(txtCurrentPage.Text, out curPage))
                {
                    if (curPage < 1)
                        this._pageCurrent = 1;
                    else
                        this._pageCurrent = curPage > this._pageCount ? this._pageCount : curPage;
                    this.InnerBind();
                }
                //else
                //{
                //    this._pageCurrent = this._pageCount;
                //    this.InnerBind();
                //    //MessageBox.Show("请输入整数");
                //}
                this.txtCurrentPage.Text = "";
            }
        }

        private void txtCurrentPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //允许输入的字符
            string AstrictChar = "0123456789";

            //「BackSpace」「Delete」后退键正常删除操作
            if ((Keys)(e.KeyChar) == Keys.Back || (Keys)(e.KeyChar) == Keys.Delete)
            {
                return;
            }
            //「Ctrl+C」(3)「Ctrl+X」(24)特殊组合键正常
            //「Ctrl+Z」(26) 撤消组合键正常
            if ((e.KeyChar == 3) || (e.KeyChar == 24) || (e.KeyChar == 26))
            {
                return;
            }

            //允许输入的字符外，
            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }


    }
}
