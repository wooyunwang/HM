using HM.DTO;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.Form_;
using HM.Form_.Old;
using System;
using System.Windows.Forms;

namespace HM.FacePlatform.Forms
{
    public partial class AddOrUpdateSystemUser : HMForm
    {
        SystemUserBLL _systemUserBLL;
        VankeBalloonToolTip toolTip;
        DataCrypto dataCrypto;

        UcSystemUserManage _ucSystemUserManage;
        SystemUser _systemUser;
        public AddOrUpdateSystemUser(UcSystemUserManage ucSystemUserManage, SystemUser systemUser = null)
        {
            _systemUserBLL = new SystemUserBLL();
            toolTip = new VankeBalloonToolTip();
            dataCrypto = new DataCrypto();
            this._ucSystemUserManage = ucSystemUserManage;
            _systemUser = systemUser;
            InitializeComponent();
        }

        private void AddOrUpdateSystemUser_Load(object sender, EventArgs e)
        {
            if (_systemUser == null) //新增
            {
                this.Text = "新增登陆用户";
                txtUserName.Enabled = true;
            }
            else
            {
                this.Text = "修改登陆用户";
                txtUserName.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string passwordConfirm = txtPasswordConfirm.Text.Trim();

            if (string.IsNullOrEmpty(userName))
            {
                toolTip.ShowIt(txtUserName, "用户名不能为空!", TooltipIcon.Error);
                return;
            }
            if (_systemUser == null && _systemUserBLL.Any(it => it.user_name == userName))
            {
                toolTip.ShowIt(txtUserName, "此已存在用户!", TooltipIcon.Error);
            }
            if (string.IsNullOrEmpty(password))
            {
                toolTip.ShowIt(txtPassword, "密码不能为空!", TooltipIcon.Error);
                return;
            }
            if (password != passwordConfirm)
            {
                toolTip.ShowIt(txtPasswordConfirm, "两次密码输入不一致!", TooltipIcon.Error);
                return;
            }

            var systemUser = _systemUserBLL.FirstOrDefault(it => it.user_name == userName);
            if (systemUser == null)
            {
                systemUser = new SystemUser
                {
                    user_name = userName,
                    password = dataCrypto.Encrypto(password),
                    is_admin = IsAdminType.否,
                    is_del = IsDelType.否,
                };
                var result_add = _systemUserBLL.Add(systemUser);
                if (result_add.IsSuccess)
                {
                    systemUser = result_add.Obj;
                    toolTip.ShowIt(btnSave, "添加成功", TooltipIcon.Info);
                    _ucSystemUserManage.BindData();
                    Close();
                }
                else
                {
                    toolTip.ShowIt(btnSave, result_add.ToAlertString(), TooltipIcon.Error);
                }
            }
            else
            {
                systemUser.user_name = userName;
                systemUser.password = dataCrypto.Encrypto(password);
                var result_edit = _systemUserBLL.Edit(systemUser);
                if (result_edit.IsSuccess)
                {
                    toolTip.ShowIt(btnSave, "更新成功", TooltipIcon.Info);
                    _ucSystemUserManage.BindData();
                    Close();
                }
                else
                {
                    toolTip.ShowIt(btnSave, result_edit.ToAlertString(), TooltipIcon.Error);
                }
            }
        }
    }
}
