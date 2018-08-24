using HM.DTO;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Forms;
using HM.FacePlatform.Model;
using HM.FacePlatform.UserControls;
using HM.Form_;
using HM.Form_.Old;
using HM.Utils_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace HM.FacePlatform
{
    public partial class UcCheck : HMUserControl
    {
        /// <summary>
        /// 提示控件
        /// </summary>
        VankeBalloonToolTip m_Tip;
        /// <summary>
        /// 
        /// </summary>
        RegisterBLL _registerBLL = new RegisterBLL();
        /// <summary>
        /// 构造函数
        /// </summary>
        public UcCheck()
        {
            InitializeComponent();
            m_Tip = new VankeBalloonToolTip(this);
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Check_Load(object sender, EventArgs e)
        {
            BindHelper.EnumBind<UserType>(CbxWait_UserType);
            BindHelper.EnumBind<UserType>(CbxHas_UserType);

            BindHelper.EnumBind<RegisterType>(CbxWait_RegisterType);
            BindHelper.EnumBind<RegisterType>(CbxHas_RegisterType);

            BindHelper.EnumBind<CheckType>(CbxHas_CheckType);

            //加一个线程刷新实时的注册数据
            Task.Run(() =>
            {
                AutoRefresh();
            });
        }
        /// <summary>
        /// 自动刷新
        /// </summary>
        private void AutoRefresh()
        {
            while (true)
            {
                LoadData();
                Thread.Sleep(1000 * 60 * 10);//10分钟自动刷一次
            }
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadData()
        {
            if (HtcMain.SelectedTab.Equals(MtpWaitReview))
            {
                pagerWaitReview.Bind();
            }
            else if (HtcMain.SelectedTab.Equals(MtpHasReview))
            {
                pagerHasReview.Bind();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int pagerWaitReview_EventPaging(EventPagingArg e)
        {
            string userName = TxtWait_Name.Text.Trim();
            UserType? userType = BindHelper.EnumValue<UserType>(CbxWait_UserType);
            RegisterType? registerType = BindHelper.EnumValue<RegisterType>(CbxHas_RegisterType);

            var result = _registerBLL.GetWithUser(pagerWaitReview.PageIndex, pagerWaitReview.PageSize,
                userName,
                userType,
                registerType,
                CheckType.待审核);
            if (!result.IsSuccess)
            {
                HMMessageBox.Show(this, result.ToAlertString());
                result.Obj = new PagerData<Register>()
                {
                    pages = 0,
                    rows = new System.Collections.Generic.List<Register>(),
                    total = 0
                };
            }
            //绑定分页控件
            pagerWaitReview.bsPager.DataSource = result.Obj.rows;
            pagerWaitReview.bnPager.BindingSource = pagerWaitReview.bsPager;
            FlpWaitReviewRender(result.Obj.rows);
            //返回总记录数
            return result.Obj.total;
        }
        /// <summary>
        /// 
        /// </summary>
        public void FlpWaitReviewRender(System.Collections.Generic.List<Register> lstRegisterWithUser)
        {
            this.UIThread(() =>
            {
                FlpWaitReview.Controls.Clear();

                if (lstRegisterWithUser == null || !lstRegisterWithUser.Any())
                {
                    ucNoData un = new ucNoData();
                    un.Note = "没有需要审核的数据";
                    FlpWaitReview.Controls.Add(un);
                }
                else
                {
                    FlpWaitReview.SuspendLayout();
                    foreach (var registerWithUser in lstRegisterWithUser)
                    {
                        ucNoCheck uc = new ucNoCheck();
                        uc._register = registerWithUser;
                        uc.CheckAction += new Action<ucNoCheck>(CheckDo);
                        FlpWaitReview.Controls.Add(uc);
                    }
                    FlpWaitReview.ResumeLayout();
                    FlpWaitReview.PerformLayout();
                }
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int pagerHasReview_EventPaging(EventPagingArg e)
        {
            string userName = TxtHas_Name.Text.Trim();
            UserType? userType = BindHelper.EnumValue<UserType>(CbxHas_UserType);
            RegisterType? registerType = BindHelper.EnumValue<RegisterType>(CbxHas_RegisterType);

            var result = _registerBLL.GetWithUser(pagerHasReview.PageIndex, pagerHasReview.PageSize,
                userName,
                userType,
                registerType,
                CheckType.待审核);
            if (!result.IsSuccess)
            {
                HMMessageBox.Show(this, result.ToAlertString());
                result.Obj = new PagerData<Register>()
                {
                    pages = 0,
                    rows = new System.Collections.Generic.List<Register>(),
                    total = 0
                };
            }
            //绑定分页控件
            pagerHasReview.bsPager.DataSource = result.Obj.rows;
            pagerHasReview.bnPager.BindingSource = pagerHasReview.bsPager;
            FlpHasReviewRender(result.Obj.rows);
            //返回总记录数
            return result.Obj.total;
        }
        /// <summary>
        /// 
        /// </summary>
        public void FlpHasReviewRender(System.Collections.Generic.List<Register> lstRegisterWithUser)
        {
            this.UIThread(() =>
            {
                FlpHasReview.Controls.Clear();

                if (lstRegisterWithUser == null || !lstRegisterWithUser.Any())
                {
                    ucNoData un = new ucNoData();
                    un.Note = "没有需要审核的数据";
                    FlpHasReview.Controls.Add(un);
                }
                else
                {
                    FlpHasReview.SuspendLayout();
                    foreach (var registerWithUser in lstRegisterWithUser)
                    {
                        ucNoCheck uc = new ucNoCheck();
                        uc._register = registerWithUser;
                        uc.CheckAction += new Action<ucNoCheck>(CheckDo);
                        FlpHasReview.Controls.Add(uc);
                    }
                    FlpHasReview.ResumeLayout();
                    FlpHasReview.PerformLayout();
                }
            });
        }
        /// <summary>
        /// 查询未审核数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnSelectWaitReview_Click(object sender, EventArgs e)
        {
            this.pagerWaitReview.Bind();
        }
        /// <summary>
        /// 查询已审核结果数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelecteHasReview_Click(object sender, EventArgs e)
        {
            pagerHasReview.Bind();
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="ucNoCheck"></param>
        private void CheckDo(ucNoCheck ucNoCheck)
        {
            CheckNote checkNote = new CheckNote(this, ucNoCheck._register.user_uid, !ucNoCheck.isForCheck);
            DialogResult dr = checkNote.ShowDialog();
            if (dr == DialogResult.OK || dr == DialogResult.No)
            {
                BtnSelectWaitReview_Click(BtnSelectWaitReview, new EventArgs());
            }
        }
        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBatchReview_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<Register> lstRegister = new System.Collections.Generic.List<Register>();
            foreach (Control ucVar in FlpWaitReview.Controls)
            {
                if (ucVar is ucNoCheck)
                {
                    ucNoCheck uc = (ucNoCheck)ucVar;
                    if (uc.IsSelect) lstRegister.Add(uc._register);
                }
            }
            if (lstRegister.Any())
            {
                CheckNote checkNote = new CheckNote(this, lstRegister, false);//wait 最后一个参数需要重新研究下
                DialogResult dr = checkNote.ShowDialog();
                if (dr == DialogResult.OK || dr == DialogResult.No)
                {
                    BtnSelectWaitReview_Click(BtnSelectWaitReview, new EventArgs());
                }
            }
            else
            {
                m_Tip.ShowItTop(BtnBatchReview, "未选择需审核的数据");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbxAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ucNoCheck uc in FlpWaitReview.Controls)
                {
                    uc.SelectCheckBox(CbxAll.Checked);
                }
            }
            catch { }
        }
        /// <summary>
        /// 标签切换时显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HtcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
