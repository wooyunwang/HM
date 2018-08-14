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
    public partial class Log : HMUserControl
    {
        ActionLogBLL _actionLogBLL;
        UserBLL _userBLL;
        SystemUserBLL _systemUserBLL;
        public Log()
        {
            InitializeComponent();

            HtcMain.SelectedTab = MtpRegisterLog;
            //HtcMain.TabPages.RemoveAt(HtcMain.TabPages.IndexOf(MtpCheckLog));
            //HtcMain.TabPages.RemoveAt(HtcMain.TabPages.IndexOf(MtpBaseDataLog));


            _actionLogBLL = new ActionLogBLL();
            _userBLL = new UserBLL();
            _systemUserBLL = new SystemUserBLL();

            dgRegisterLog.AllowUserToAddRows = false;
            dgRegisterLog.AutoGenerateColumns = false;
            dgRegisterLog.RowHeadersVisible = false;
        }
        private void Log_Load(object sender, EventArgs e)
        {
            DtpFrom.Value = DateTime.Now.AddMonths(-1);
            DtpTo.Value = DateTime.Now;
            DtpFromCheck.Value = DateTime.Now.AddMonths(-1);
            DtpToCheck.Value = DateTime.Now;
            DtpFromBaseData.Value = DateTime.Now.AddMonths(-1);
            DtpToBaseData.Value = DateTime.Now;

            BindHelper.EnumBind<UserType>(CbxUserTypeRegister);
            BindHelper.EnumBind<ActionType>(CbxActionTypeRegister);
            BindHelper.SystemUserBind(CbxSystemUserRegister);

            BindHelper.EnumBind<IsAdminType>(CbxAdminTypeCheck);
            BindHelper.EnumBind<ActionName>(CbxActionNameCheck);

            BindHelper.EnumBind<IsAdminType>(CbxAdminTypeBaseData);
            BindHelper.EnumBind<ActionName>(CbxActionNameBaseData);
            PagerRegisterLog.Bind();
        }
        /// <summary>
        /// 分页加载数据
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int PagerRegisterLog_EventPaging(EventPagingArg e)
        {
            DateTime from = DtpFrom.Value;
            DateTime to = DtpTo.Value;
            string name = TxtUserName.Text.Trim();
            UserType? user_type = BindHelper.EnumValue<UserType>(CbxUserTypeRegister);
            ActionType? action_type = BindHelper.EnumValue<ActionType>(CbxActionTypeRegister);
            int? system_user_id = BindHelper.EnumValue<int>(CbxSystemUserRegister);

            ActionResult<PagerData<RegisterActionLogDto>> result = _actionLogBLL.GetRegisterLog(PagerRegisterLog.PageIndex, PagerRegisterLog.PageSize,
                 from, to, name, "", user_type, null, system_user_id);

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ToAlertString());
                result.Obj = new PagerData<RegisterActionLogDto>()
                {
                    pages = 0,
                    rows = new List<RegisterActionLogDto>(),
                    total = 0
                };
            }
            //绑定分页控件
            PagerRegisterLog.bsPager.DataSource = result.Obj.rows;
            PagerRegisterLog.bnPager.BindingSource = PagerRegisterLog.bsPager;
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
            DateTime from = DtpFromCheck.Value;
            DateTime to = DtpToCheck.Value;
            string key = TxtKeyBaseData.Text.Trim();
            IsAdminType? admin_type = BindHelper.EnumValue<IsAdminType>(CbxAdminTypeCheck);
            ActionName? action_name = BindHelper.EnumValue<ActionName>(CbxActionNameCheck);

            //int? system_user_id = BindHelper.EnumValue<int>(CbxSystemUserCheck);

            ActionResult<PagerData<ActionLogDto>> result = _actionLogBLL.GetLogButRegister(PagerCheckLog.PageIndex, PagerCheckLog.PageSize,
                 from, to, key, admin_type, ActionType.审核, action_name, null);

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ToAlertString());
                result.Obj = new PagerData<ActionLogDto>()
                {
                    pages = 0,
                    rows = new List<ActionLogDto>(),
                    total = 0
                };
            }
            //绑定分页控件
            PagerRegisterLog.bsPager.DataSource = result.Obj.rows;
            PagerRegisterLog.bnPager.BindingSource = PagerRegisterLog.bsPager;
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
            DateTime from = DtpFromBaseData.Value;
            DateTime to = DtpToBaseData.Value;
            string key = TxtKeyBaseData.Text.Trim();
            IsAdminType? admin_type = BindHelper.EnumValue<IsAdminType>(CbxAdminTypeBaseData);
            ActionName? action_name = BindHelper.EnumValue<ActionName>(CbxActionNameBaseData);

            //int? system_user_id = BindHelper.EnumValue<int>(CbxSystemUserBaseData);

            ActionResult<PagerData<ActionLogDto>> result = _actionLogBLL.GetLogButRegister(PagerBaseDataLog.PageIndex, PagerBaseDataLog.PageSize,
                 from, to, key, admin_type, ActionType.审核, action_name, null);

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ToAlertString());
                result.Obj = new PagerData<ActionLogDto>()
                {
                    pages = 0,
                    rows = new List<ActionLogDto>(),
                    total = 0
                };
            }
            //绑定分页控件
            PagerRegisterLog.bsPager.DataSource = result.Obj.rows;
            PagerRegisterLog.bnPager.BindingSource = PagerRegisterLog.bsPager;
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
