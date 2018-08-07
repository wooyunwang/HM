using HM.Form_;
using HM.Socket_.Common_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HM.Cloud.Server
{
    public partial class FrmMain : HMForm
    {
        /// <summary>
        /// 
        /// </summary>
        Socket_.BlackCat01CloudServer _BlackCat01CloudServer { get; set; }
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _BlackCat01CloudServer = new Socket_.BlackCat01CloudServer();
            _BlackCat01CloudServer._RealHandler = _RealHandler;
            _BlackCat01CloudServer._OnMessage = _OnMessage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ResponseBase<bool> _RealHandler(RequestBase<byte[]> request)
        {
            switch (request.CmdCode)
            {
                case CmdCode.OpenCloseDoorCMD:
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

        void _OnMessage(string msg)
        {
            FormHelper.OnMessage(TxtConsole, msg);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _BlackCat01CloudServer.Dispose();
        }
    }
}
