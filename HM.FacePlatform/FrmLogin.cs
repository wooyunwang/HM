using System;
using System.Windows.Forms;
using System.Diagnostics;

using HM.FacePlatform.Model;
using HM.FacePlatform.BLL;
using HM.Common_;
using HM.Form_.Old;
using HM.Utils_;
using HM.DTO;
using System.Threading;
using HM.Form_;
using System.Threading.Tasks;

namespace HM.FacePlatform
{
    public partial class FrmLogin : Form
    {
        SystemUserBLL _systemUserBLL;
        VankeBalloonToolTip m_Tip;
        private DataCrypto dataCrypto;

        public FrmLogin()
        {
            _systemUserBLL = new SystemUserBLL();
            InitializeComponent();
            m_Tip = new VankeBalloonToolTip(this);
            dataCrypto = new DataCrypto();//加解密
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //允许线程直接访问控件
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                string regName = Config_.GetString("RegName", true);
                string regPass = Config_.GetString("RegPass", true);
                if (!string.IsNullOrWhiteSpace(regName))
                {
                    txtUserName.Text = regName;
                    if (txtUserName.Text != "")
                    {
                        cbxUserName.Checked = true;
                    }
                }
                if (!string.IsNullOrWhiteSpace(regPass))
                {
                    txtPassword.Text = regPass;
                    if (txtPassword.Text != "")
                    {
                        cbxPassword.Checked = true;
                    }
                }
                if (!(cbxUserName.Checked))
                {
                    cbxPassword.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            if (string.IsNullOrWhiteSpace(userName))
            {
                m_Tip.ShowIt(txtUserName, "请输入您的账号！", TooltipIcon.Error);
                txtUserName.Text = "";
                txtUserName.Focus();
                return;
            }
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(password))
            {
                m_Tip.ShowIt(txtPassword, "请输入您的密码！", TooltipIcon.Error);
                txtPassword.Text = "";
                txtPassword.Focus();
                return;
            }

            btnLogin.Enabled = false;
            btnExit.Enabled = false;

            try
            {
                ActionResult<SystemUser> result = _systemUserBLL.Login(userName, dataCrypto.Encrypto(password));
                if (result.IsSuccess)
                {
                    if (cbxUserName.Checked) Config_.SaveConfig("RegName", userName);
                    else Config_.SaveConfig("RegName", "");
                    if (cbxPassword.Checked) Config_.SaveConfig("RegPass", password);
                    else Config_.SaveConfig("RegPass", "");

                    Task.Run(() =>
                    {
                        Login(result.Obj);
                    });
                }
                else
                {
                    m_Tip.ShowIt(btnLogin, result.ToAlertString(), TooltipIcon.Error);
                }
            }
            catch (Exception ex)
            {
                m_Tip.ShowIt(btnLogin, Exception_.GetInnerException(ex).Message, TooltipIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnExit.Enabled = true;
            }
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="obj"></param>
        void Login(object obj)
        {
            var result = obj as SystemUser;

            var project = new ProjectBLL().FirstOrDefault(it => 1 == 1);
            if (project == null)
            {
                MessageBox.Show("数据库未初始化项目信息！", "严重错误");
            }
            else
            {
                Program._Account = result;
                Program._Mainform = new FrmMain();
                Program._Mainform._ClosingHandler += new closingHandler(FrmLoginClosing);
                Program._Mainform._ProjectCode = project.project_code;
                Program._Mainform._ProjectName = project.project_name;
                Program._Mainform._PropertyHouseCode = "w" + project.project_code + "0123456789012345678";
                Program._Mainform._VirtualHouseCode = "n" + project.project_code + "0123456789012345678";
                this.Hide();
                Program._Mainform.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Process p = Process.GetCurrentProcess();
            if (p != null)
            {
                p.Kill();
            }
        }

        private void cbxUserName_Click(object sender, EventArgs e)
        {
            if (!(cbxUserName.Checked))
            {
                cbxPassword.Checked = false;
                cbxPassword.Enabled = false;
            }
            else
            {
                cbxPassword.Enabled = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnLogin_Click(null, null);
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnLogin_Click(null, null);
            }
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnLogin_Click(null, null);
            }
        }

        /// <summary>
        /// 关闭窗口触发的事件
        /// </summary>
        public event closingHandler _ClosingHandler;
        /// <summary>
        /// 
        /// </summary>
        private void FrmLoginClosing()
        {
            _ClosingHandler?.Invoke();
            Close();
        }
    }
}
