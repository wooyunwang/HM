using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HM.DTO;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.Form_;
using HM.Utils_;

namespace HM.FacePlatform
{
    public partial class UcLog : HMUserControl
    {
        ActionLogBLL _actionLogBLL;
        UserBLL _userBLL;
        SystemUserBLL _systemUserBLL;
        public UcLog()
        {
            InitializeComponent();

            _actionLogBLL = new ActionLogBLL();
            _userBLL = new UserBLL();
            _systemUserBLL = new SystemUserBLL();

            DgvRegisterLog.AllowUserToAddRows = false;
            DgvRegisterLog.AutoGenerateColumns = false;
            DgvRegisterLog.RowHeadersVisible = false;
        }
        private void Log_Load(object sender, EventArgs e)
        {
            DtpFrom.Value = DateTime.Today.AddMonths(-1);
            DtpTo.Value = DateTime.Today;
            DtpFromCheck.Value = DateTime.Today.AddMonths(-1);
            DtpToCheck.Value = DateTime.Today;
            DtpFromBaseData.Value = DateTime.Today.AddMonths(-1);
            DtpToBaseData.Value = DateTime.Today;

            BindHelper.EnumBind<UserType>(CbxUserTypeRegister);
            BindHelper.EnumBind<ActionName>(CbxActionNameRegister);
            BindHelper.SystemUserBind(CbxSystemUserRegister);

            BindHelper.EnumBind<IsAdminType>(CbxAdminTypeCheck);
            BindHelper.EnumBind<ActionName>(CbxActionNameCheck);

            BindHelper.EnumBind<IsAdminType>(CbxAdminTypeBaseData);
            BindHelper.EnumBind<ActionName>(CbxActionNameBaseData);

            if (HtcMain.SelectedTab != MtpRegisterLog)
            {
                HtcMain.SelectedTab = MtpRegisterLog;
            }
            else
            {
                HtcMain_SelectedIndexChanged(HtcMain, new TabControlEventArgs(MtpRegisterLog, HtcMain.TabPages.IndexOf(MtpRegisterLog), new TabControlAction()));
            }
        }
        /// <summary>
        /// 标签切换绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HtcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HtcMain.SelectedTab.Equals(MtpRegisterLog))
            {
                PagerRegisterLog.Bind();
            }
            else if (HtcMain.SelectedTab.Equals(MtpBaseDataLog))
            {
                PagerBaseDataLog.Bind();
            }
            else if (HtcMain.SelectedTab.Equals(MtpCheckLog))
            {
                PagerCheckLog.Bind();
            }
            else
            {
                throw new Exception("添加一个Tab,请在此方法添加对应的处理！");
            }
        }
        /// <summary>
        /// 分页加载数据
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int PagerRegisterLog_EventPaging(EventPagingArg e)
        {
            DateTime from = DtpFrom.Value.Date;
            DateTime to = DtpTo.Value.Date;
            string name = TxtUserName.Text.Trim();
            int? system_user_id = BindHelper.EnumValue<int>(CbxSystemUserRegister);
            ActionName? action_name = BindHelper.EnumValue<ActionName>(CbxActionNameRegister);
            UserType? user_type = BindHelper.EnumValue<UserType>(CbxUserTypeRegister);

            ActionResult<PagerData<RegisterActionLogDto>> result = _actionLogBLL.GetRegisterLog(PagerRegisterLog.PageIndex, PagerRegisterLog.PageSize,
                 from, to, name, user_type, action_name, system_user_id);

            if (!result.IsSuccess)
            {
                HMMessageBox.Show(this, result.ToAlertString());
                result.Obj = new PagerData<RegisterActionLogDto>()
                {
                    pages = 0,
                    rows = new System.Collections.Generic.List<RegisterActionLogDto>(),
                    total = 0
                };
            }
            //绑定分页控件
            PagerRegisterLog.bsPager.DataSource = result.Obj.rows;
            PagerRegisterLog.bnPager.BindingSource = PagerRegisterLog.bsPager;
            //分页控件绑定DataGridView
            DgvRegisterLog.DataSource = PagerRegisterLog.bsPager;
            //返回总记录数
            return result.Obj.total;
        }
        /// <summary>
        /// 分页加载数据
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int PagerCheckLog_EventPaging(EventPagingArg e)
        {
            DateTime from = DtpFromCheck.Value.Date;
            DateTime to = DtpToCheck.Value.Date;
            string key = TxtKeyCheck.Text.Trim();
            IsAdminType? admin_type = BindHelper.EnumValue<IsAdminType>(CbxAdminTypeCheck);
            ActionName? action_name = BindHelper.EnumValue<ActionName>(CbxActionNameCheck);

            //int? system_user_id = BindHelper.EnumValue<int>(CbxSystemUserCheck);

            ActionResult<PagerData<CheckActionLogDto>> result = _actionLogBLL.GetCheckLog(PagerCheckLog.PageIndex, PagerCheckLog.PageSize,
                 from, to, key, admin_type, action_name, null);

            if (!result.IsSuccess)
            {
                HMMessageBox.Show(this, result.ToAlertString());
                result.Obj = new PagerData<CheckActionLogDto>()
                {
                    pages = 0,
                    rows = new System.Collections.Generic.List<CheckActionLogDto>(),
                    total = 0
                };
            }
            //绑定分页控件
            PagerCheckLog.bsPager.DataSource = result.Obj.rows;
            PagerCheckLog.bnPager.BindingSource = PagerRegisterLog.bsPager;
            //分页控件绑定DataGridView
            DgvCheckLog.DataSource = PagerCheckLog.bsPager;
            //返回总记录数
            return result.Obj.total;
        }
        /// <summary>
        /// 分页加载数据
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int PagerBaseDataLog_EventPaging(EventPagingArg e)
        {
            DateTime from = DtpFromBaseData.Value.Date;
            DateTime to = DtpToBaseData.Value.Date;
            string key = TxtKeyBaseData.Text.Trim();
            IsAdminType? admin_type = BindHelper.EnumValue<IsAdminType>(CbxAdminTypeBaseData);
            ActionName? action_name = BindHelper.EnumValue<ActionName>(CbxActionNameBaseData);

            //int? system_user_id = BindHelper.EnumValue<int>(CbxSystemUserBaseData);

            ActionResult<PagerData<BaseDataActionLogDto>> result = _actionLogBLL.GetBaseDataLog(PagerBaseDataLog.PageIndex, PagerBaseDataLog.PageSize,
                 from, to, key, admin_type, action_name, null);

            if (!result.IsSuccess)
            {
                HMMessageBox.Show(this, result.ToAlertString());
                result.Obj = new PagerData<BaseDataActionLogDto>()
                {
                    pages = 0,
                    rows = new System.Collections.Generic.List<BaseDataActionLogDto>(),
                    total = 0
                };
            }
            //绑定分页控件
            PagerBaseDataLog.bsPager.DataSource = result.Obj.rows;
            PagerBaseDataLog.bnPager.BindingSource = PagerRegisterLog.bsPager;
            //分页控件绑定DataGridView
            DgvBaseData.DataSource = PagerBaseDataLog.bsPager;
            //返回总记录数
            return result.Obj.total;
        }
        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectRegister_Click(object sender, EventArgs e)
        {
            PagerRegisterLog.Bind();
        }

        /// <summary>
        /// 查询审核日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectCheck_Click(object sender, EventArgs e)
        {
            PagerCheckLog.Bind();
        }
        /// <summary>
        /// 查询基础数据修改日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectBaseData_Click(object sender, EventArgs e)
        {
            PagerBaseDataLog.Bind();
        }
    }
}
