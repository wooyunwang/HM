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
        BlackCat01 _BlackCat01;

        public FrmMain()
        {
            InitializeComponent();
            this.Text = this.Text + "";
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

        public Socket_.Common.ResponseBase<bool> _RealHandler(Socket_.Common.RequestBase<byte[]> request)
        {
            switch (request.CmdCode)
            {
                case Socket_.Common.CmdCode.OpenCloseDoorCMD:
                    {
                        var result = new Socket_.Common.OpenCloseDoorCMD(request.Data);
                        switch (result.DoorLocation)
                        {
                            case Socket_.Common.OpenCloseDoorCMD_DoorLocation.前门:
                                if (result.Switch == Socket_.Common.OpenCloseDoorCMD_Switch.开门)
                                {

                                }
                                else if (result.Switch == Socket_.Common.OpenCloseDoorCMD_Switch.关门)
                                {

                                }
                                break;
                            case Socket_.Common.OpenCloseDoorCMD_DoorLocation.后门:
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case Socket_.Common.CmdCode.OpenCloseDoorCMD_:
                    break;
                case Socket_.Common.CmdCode.SetTimeCMD:
                    break;
                case Socket_.Common.CmdCode.SetTimeCMD_:
                    break;
                case Socket_.Common.CmdCode.SetDateNormalCMD:
                    break;
                case Socket_.Common.CmdCode.SetDateNormalCMD_:
                    break;
                case Socket_.Common.CmdCode.SetRunModeCMD:
                    break;
                case Socket_.Common.CmdCode.SetRunModeCMD_:
                    break;
                case Socket_.Common.CmdCode.SetHighLevelCMD:
                    break;
                case Socket_.Common.CmdCode.SetHighLevelCMD_:
                    break;
                case Socket_.Common.CmdCode.SetNoticeCMD:
                    break;
                case Socket_.Common.CmdCode.SetNoticeCMD_:
                    break;
                case Socket_.Common.CmdCode.GetPeopleNumCMD:
                    break;
                case Socket_.Common.CmdCode.GetPeopleNumCMD_:
                    break;
                case Socket_.Common.CmdCode.SetDirectionCMD:
                    break;
                case Socket_.Common.CmdCode.SetDirectionCMD_:
                    break;
                case Socket_.Common.CmdCode.GetAbnormalSignalCMD:
                    break;
                case Socket_.Common.CmdCode.GetAbnormalSignalCMD_:
                    break;
                case Socket_.Common.CmdCode.SynchronizeModeCMD:
                    break;
                case Socket_.Common.CmdCode.SynchronizeModeCMD_:
                    break;
                case Socket_.Common.CmdCode.SetBlackCatBackGroundCMD:
                    break;
                case Socket_.Common.CmdCode.SetBlackCatBackGroundCMD_:
                    break;
                case Socket_.Common.CmdCode.SetBlackCatBackVideoCMD:
                    break;
                case Socket_.Common.CmdCode.SetBlackCatBackVideoCMD_:
                    break;
                case Socket_.Common.CmdCode.GetUserDefineAbnormalSignalCMD:
                    break;
                case Socket_.Common.CmdCode.GetUserDefineAbnormalSignalCMD_:
                    break;
                case Socket_.Common.CmdCode.GetConfigInfoCMD:
                    break;
                case Socket_.Common.CmdCode.GetConfigInfoCMD_:
                    break;
                case Socket_.Common.CmdCode.GetFaceEntranceDetailCMD:
                    break;
                case Socket_.Common.CmdCode.GetFaceEntranceDetailCMD_:
                    break;
                case Socket_.Common.CmdCode.GetICCardEntranceDetailCMD:
                    break;
                case Socket_.Common.CmdCode.GetICCardEntranceDetailCMD_:
                    break;
                default:
                    break;
            }
            return new Socket_.Common.ResponseBase<bool>(request.CmdCode + 1, true);
        }
    }
}
