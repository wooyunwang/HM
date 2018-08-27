using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;

namespace HM.FacePlatform
{
    public abstract class BaseJob
    {
        public static ScheduleJob _JobFrom;
        public string _ProjectCode;
        public string _PropertyHouseCode;
        public string _VirtualHouseCode;
        public string _PictureDirectory;
        public int _MaxRetryTime;

        protected static readonly bool isFirstMao = false;

        protected MaoBLL _maoBLL;
        protected MaoBuildingBLL _maoBuildingBLL;
        protected UserBLL _userBLL;
        protected RegisterBLL _registerBLL;
        protected MaoFailedJobBLL _maoFailedJobBLL;
        protected ActionLogBLL _actionLogBLL;

        protected BaseJob()
        {
            _maoBLL = new MaoBLL();
            _maoBuildingBLL = new MaoBuildingBLL();
            _userBLL = new UserBLL();
            _registerBLL = new RegisterBLL();
            _maoFailedJobBLL = new MaoFailedJobBLL();
            _actionLogBLL = new ActionLogBLL();

            if (Program._Mainform != null)
            {
                _ProjectCode = Program._Mainform._ProjectCode;
                _PropertyHouseCode = Program._Mainform._PropertyHouseCode;
                _VirtualHouseCode = Program._Mainform._VirtualHouseCode;
                _PictureDirectory = FacePlatformCache.GetPictureDirectory();
                _MaxRetryTime = FacePlatformCache.GetMaxRetryTime();
            }
            else
            {
                throw new Exception("计划任务需要在主窗口中创建！");
            }
        }

        protected DateTime GetMinDateTime()
        {
            return Convert.ToDateTime("2000-01-01");
        }
    }
}
