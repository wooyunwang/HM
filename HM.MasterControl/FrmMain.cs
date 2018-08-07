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
using HM.Socket_.Common_;

namespace HM.MasterControl
{
    public partial class FrmMain : HMForm
    {
        BlackCat01 _BlackCat01;

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

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _BlackCat01 = new BlackCat01();
            _BlackCat01._RealHandler = _RealHandler;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _BlackCat01.Dispose();
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

        ResponseBase<bool> _RealHandler(RequestBase<byte[]> request)
        {
            switch (request.CmdCode)
            {
                case CmdCode.OpenCloseDoorCMD:
                    {
                        var result = new OpenCloseDoorCMD(request.Data);
                        switch (result.DoorLocation)
                        {
                            case OpenCloseDoorCMD_DoorLocation.前门:
                                if (result.Switch == OpenCloseDoorCMD_Switch.开门)
                                {

                                }
                                else if (result.Switch == OpenCloseDoorCMD_Switch.关门)
                                {

                                }
                                break;
                            case OpenCloseDoorCMD_DoorLocation.后门:
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case CmdCode.OpenCloseDoorCMD_:
                    break;
                case CmdCode.SetTimeCMD:
                    break;
                case CmdCode.SetTimeCMD_:
                    break;
                case CmdCode.SetDateNormalCMD:
                    break;
                case CmdCode.SetDateNormalCMD_:
                    break;
                case CmdCode.SetRunModeCMD:
                    break;
                case CmdCode.SetRunModeCMD_:
                    break;
                case CmdCode.SetHighLevelCMD:
                    break;
                case CmdCode.SetHighLevelCMD_:
                    break;
                case CmdCode.SetNoticeCMD:
                    break;
                case CmdCode.SetNoticeCMD_:
                    break;
                case CmdCode.GetPeopleNumCMD:
                    break;
                case CmdCode.GetPeopleNumCMD_:
                    break;
                case CmdCode.SetDirectionCMD:
                    break;
                case CmdCode.SetDirectionCMD_:
                    break;
                case CmdCode.GetAbnormalSignalCMD:
                    break;
                case CmdCode.GetAbnormalSignalCMD_:
                    break;
                case CmdCode.SynchronizeModeCMD:
                    break;
                case CmdCode.SynchronizeModeCMD_:
                    break;
                case CmdCode.SetBlackCatBackGroundCMD:
                    break;
                case CmdCode.SetBlackCatBackGroundCMD_:
                    break;
                case CmdCode.SetBlackCatBackVideoCMD:
                    break;
                case CmdCode.SetBlackCatBackVideoCMD_:
                    break;
                case CmdCode.GetUserDefineAbnormalSignalCMD:
                    break;
                case CmdCode.GetUserDefineAbnormalSignalCMD_:
                    break;
                case CmdCode.GetConfigInfoCMD:
                    break;
                case CmdCode.GetConfigInfoCMD_:
                    break;
                case CmdCode.GetFaceEntranceDetailCMD:
                    break;
                case CmdCode.GetFaceEntranceDetailCMD_:
                    break;
                case CmdCode.GetICCardEntranceDetailCMD:
                    break;
                case CmdCode.GetICCardEntranceDetailCMD_:
                    break;
                default:
                    break;
            }
            return new ResponseBase<bool>(request.CmdCode + 1, true);
        }
    }
}
