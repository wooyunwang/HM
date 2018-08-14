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

        UcSystemUserManage form;

        public AddOrUpdateSystemUser(UcSystemUserManage form)
        {
            _systemUserBLL = new SystemUserBLL();
            toolTip = new VankeBalloonToolTip();
            dataCrypto = new DataCrypto();

            this.form = form;

            InitializeComponent();
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
                systemUser = _systemUserBLL.Add(systemUser);
                if (systemUser != null)
                {
                    toolTip.ShowIt(btnSave, "添加成功", TooltipIcon.Info);
                    form.BindData();
                    Close();
                }
                else
                {
                    toolTip.ShowIt(btnSave, "添加失败", TooltipIcon.Error);
                }
            }
            else
            {
                systemUser.user_name = userName;
                systemUser.password = dataCrypto.Encrypto(password);
                var result = _systemUserBLL.Edit(systemUser);
                if (result)
                {
                    toolTip.ShowIt(btnSave, "更新成功", TooltipIcon.Info);
                    form.BindData();
                    Close();
                }
                else
                {
                    toolTip.ShowIt(btnSave, "更新失败！", TooltipIcon.Error);
                }
            }
        }
    }
}
