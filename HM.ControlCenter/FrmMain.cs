using HM.Form_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.ControlCenter
{
    public partial class FrmMain : HMForm
    {
        public FrmMain()
        {
            InitializeComponent();
            //设置名称
            this.Text = FormHelper.GetAppName();
            //设置主题
            this._Msm.Style = MetroFramework.MetroColorStyle.Pink;
            //默认最大化
            this.WindowState = FormWindowState.Maximized;
            //选中第一项
            this.HtcMain.SelectedIndex = 0;
        }
    }
}
