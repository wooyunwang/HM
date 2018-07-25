using HM.Form_;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNetty.Transport.Bootstrapping;
using HM.Socket_;

namespace HM.MasterControl
{
    public partial class FrmMain : HMForm
    {
        BlackCat01 blackCat01 = new BlackCat01();

        public FrmMain()
        {
            InitializeComponent();
            this.Text = this.Text + "";
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        #region 输出控制
        private void BtnOpenADoor_Click(object sender, EventArgs e)
        {

        }
        private void BtnCloseADoor_Click(object sender, EventArgs e)
        {

        }
        private void BtnOpenBDoor_Click(object sender, EventArgs e)
        {

        }
        private void BtnCloseBDoor_Click(object sender, EventArgs e)
        {

        }
        private void BtnOpenLamp_Click(object sender, EventArgs e)
        {

        }
        private void BtnCloseLamp_Click(object sender, EventArgs e)
        {

        }
        private void BtnSetRed_Click(object sender, EventArgs e)
        {

        }
        private void BtnSetGreen_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void TogStartScan_CheckStateChanged(object sender, EventArgs e)
        {
            if (TogStartScan.Checked)
            {

            }
            else
            {

            }
        }

        #region 测试、设置喇叭音量
        private void btnF_Click(object sender, EventArgs e)
        {

        }

        private void btnV1_Click(object sender, EventArgs e)
        {

        }

        private void btnM_Click(object sender, EventArgs e)
        {

        }

        private void btnV2_Click(object sender, EventArgs e)
        {

        }

        private void btnB_Click(object sender, EventArgs e)
        {

        }

        private void btnV3_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region TV测试
        private void BtnTestTVSmile_Click(object sender, EventArgs e)
        {

        }

        private void BtnTestTVCry_Click(object sender, EventArgs e)
        {

        }

        private void BtnTestTVSleep_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void BtnPeakMode_Click(object sender, EventArgs e)
        {

        }

        private void BtnCloseMode_Click(object sender, EventArgs e)
        {

        }

        private void BtnFireMode_Click(object sender, EventArgs e)
        {

        }

        private void BtnBothDirection_Click(object sender, EventArgs e)
        {

        }

        private void BtnOutDirection_Click(object sender, EventArgs e)
        {

        }

        private void BtnInDirection_Click(object sender, EventArgs e)
        {

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {

        }


    }
}
