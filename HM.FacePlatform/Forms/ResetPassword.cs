using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.Form_;
using HM.Form_.Old;
using System;
using System.Windows.Forms;

namespace HM.FacePlatform.Forms
{
    public partial class ResetPassword : HMForm
    {
        SystemUserBLL _systemUserBLL;
        VankeBalloonToolTip toolTip;
        DataCrypto dataCrypto;
        public ResetPassword()
        {
            _systemUserBLL = new SystemUserBLL();
            toolTip = new VankeBalloonToolTip();
            dataCrypto = new DataCrypto();

            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text.Trim();
            string password = txtPassword.Text.Trim();
            string passwordConfirm = txtPasswordConfirm.Text.Trim();

            if (string.IsNullOrEmpty(oldPassword))
            {
                toolTip.ShowIt(txtOldPassword, "旧密码不能为空!", TooltipIcon.Error);
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

            SystemUser user = Program._Account;
            oldPassword = dataCrypto.Encrypto(oldPassword);

            if (oldPassword != user.password)
            {
                toolTip.ShowIt(txtOldPassword, "旧密码错误!", TooltipIcon.Error);
                return;
            }

            user.password = dataCrypto.Encrypto(password);

            if (_systemUserBLL.Edit(user))
            {
                user.password = user.password;
                toolTip.ShowIt(btnSave, "修改成功", TooltipIcon.Info);
            }
            else
            {
                user.password = oldPassword;
                toolTip.ShowIt(btnSave, "修改失败!", TooltipIcon.Error);
            }
        }
    }
}
