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
        /// ��ȡ�ܼ�¼��������Ҫ���¼����߳�
        /// </summary>
        public event HM.Form_.Old.Pager.EventPagingArg.GetNMaxEventHander getNMaxEvent;
        /// <summary>
        /// ��ȡ��ǰҳ����Ҫ���¼����߳�
        /// </summary>
        public event HM.Form_.Old.Pager.EventPagingArg.DataSourceEventHandler getPageingEvent;

        //private bool _ReLoadNMax = false;
        ///// <summary>
        ///// ���¼���NMax����ѯ�������ˡ�����͸��ű�
        ///// </summary>
        //public bool ReLoadNMax
        //{
        //    get { return _ReLoadNMax; }
        //    set { _ReLoadNMax = value; }
        //}

        /// <summary>
        /// �ؼ��Ƿ����,�Ѿ�����д
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
        /// ��Ҫ��datagridviewһ��
        /// </summary>
        [Category("��Ҫѡ��")]
        public DataGridView dataGridView
        {
            get { return _dataGridView; }
            set { _dataGridView = value; }
        }

        private DataTable _OnePageDataTable;
        /// <summary>
        /// һҳ������
        /// </summary>
        public DataTable OnePageDataTable
        {
            get { return _OnePageDataTable; }
            //set { _OnePageDataSet = value; }
        }

        /**/
        /// <summary>
        /// ÿҳ��ʾ��¼��
        /// </summary>
        private int _pageSize = 30;
        /**/
        /// <summary>
        /// ÿҳ��ʾ��¼��
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
        /// �ܼ�¼��
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
        /// ҳ��=�ܼ�¼��/ÿҳ��ʾ��¼��
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
            //set { _pageCount = value; }
        }

        private int _pageCurrent = 1;
        /**/
        /// <summary>
        /// ��ǰҳ��
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
        /// ��ҳ�ؼ����ݰ󶨵ķ���
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
            this.lblPageSize_totalItem.Text = string.Format("ÿҳ{0}���{1}��", this.PageSize, this.NMax);

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
        /// ��һ�μ���
        /// </summary>
        bool _isFirstBind = true;
        /// <summary>
        /// ��һ�ΰ󶨣���ΰ󶨻��ȡNMax������
        /// </summary>
        public void FirstBind()
        {
            this._pageCurrent = 1;
            _isFirstBind = true;
            CreateThreadAndStart();
        }
        /// <summary>
        /// �ڲ����أ����ǵ�һ��
        /// </summary>
        public void InnerBind()
        {
            if (this._pageCount < 1)//û��ҳ������ʾû���ݣ�ʲô������������
            {
                //MessageBoxClew.Show("û�����ݣ�");
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
            //�����еĿؼ���ɻ�ɫ������ʾloading...
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
            if (getPageingEvent != null)//���û�ҵ��������Ͳ��ػ�ȡ����Դ
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
                //    //MessageBox.Show("����������");
                //}
                this.txtCurrentPage.Text = "";
            }
        }

        private void txtCurrentPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //����������ַ�
            string AstrictChar = "0123456789";

            //��BackSpace����Delete�����˼�����ɾ������
            if ((Keys)(e.KeyChar) == Keys.Back || (Keys)(e.KeyChar) == Keys.Delete)
            {
                return;
            }
            //��Ctrl+C��(3)��Ctrl+X��(24)������ϼ�����
            //��Ctrl+Z��(26) ������ϼ�����
            if ((e.KeyChar == 3) || (e.KeyChar == 24) || (e.KeyChar == 26))
            {
                return;
            }

            //����������ַ��⣬
            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }


    }
}
