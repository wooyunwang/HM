using HM.FacePlatform.Forms;
using HM.Form_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.FacePlatform
{
    public partial class FrmMain : HMForm
    {
        /// <summary>
        /// 项目编码
        /// </summary>
        public string _ProjectCode;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string _ProjectName;
        /// <summary>
        /// 房屋编码
        /// </summary>
        public string _PropertyHouseCode;
        /// <summary>
        /// 虚拟房屋编码
        /// </summary>
        public string _VirtualHouseCode;
        /// <summary>
        /// 关闭窗口触发的事件
        /// </summary>
        public event closingHandler _ClosingHandler;

        public FrmMain()
        {
            InitializeComponent();
            //设置名称
            this.Text = FormHelper.GetAppName();
            //设置主题
            //this._Msm.Style = MetroFramework.MetroColorStyle.Green;
            //默认最大化
            this.WindowState = FormWindowState.Maximized;
            //选中第一项
            this.HtcMain.SelectedIndex = 0;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            if (!Program.IsAdmin())
            {
                HtcMain.TabPages.Remove(MtpSystemUserManage);
            }
            //foreach (TabPage item in HtcMain.TabPages)
            //{
            //    NavigationButtonClick(HtcMain, new TabControlEventArgs(
            //        item, HtcMain.TabPages.IndexOf(item), new TabControlAction()
            //    ));
            //}
            if (HtcMain.SelectedTab != MtpDataBase)
            {
                HtcMain.SelectedTab = MtpDataBase;
            }
            else
            {
                HtcMain_Selected(HtcMain, new TabControlEventArgs(MtpDataBase, HtcMain.TabPages.IndexOf(MtpDataBase), new TabControlAction()));
            }
        }
        private void HtcMain_Selected(object sender, TabControlEventArgs e)
        {
            NavigationButtonClick(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private Control NavigationButtonClick(object sender, TabControlEventArgs e)
        {
            var htc = (HMTabControl)sender;
            var tp = htc.TabPages[e.TabPageIndex];
            var strTag = (tp.Tag ?? "").ToString();
            if (string.IsNullOrWhiteSpace(strTag))
            {
                HMMessageBox.Show(this, "该菜单未配置页面，请联系管理员！");
                return null;
            }
            #region 根据按钮的Tag，实例化控件
            if (!tp.Controls.ContainsKey(strTag))
            {
                string executablePath = Path.GetFileName(Application.ExecutablePath);
                Assembly a = Assembly.LoadFrom(executablePath);
                Type type = a.GetType(strTag);
                UserControl uc = Activator.CreateInstance(type) as UserControl;
                if (uc != null)
                {
                    uc.Width = this.Width;
                    uc.Height = this.Height;
                    uc.Dock = DockStyle.Fill;
                    tp.Controls.Add(uc);
                    uc.Visible = true;
                }
                return uc;
            }
            else
            {
                return tp.Controls[0];
            }
            #endregion
        }
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileResetPassword_Click(object sender, EventArgs e)
        {
            ResetPassword form = new ResetPassword();
            form.Show();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HMMessageBox.Show(this, "确定退出程序？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Process p = Process.GetCurrentProcess();
                if (p != null)
                {
                    p.Kill();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
