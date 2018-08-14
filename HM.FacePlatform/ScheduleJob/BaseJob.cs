using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;

namespace HM.FacePlatform
{
    public abstract class BaseJob
    {
        public static ScheduleJob jobFrom;
        public static string projectCode;
        public static string propertyHouseCode;
        public static string virtualHouseCode;
        public static string photoPath;
        public static int maxRetryTime;

        protected static readonly bool isFirstMao = false;

        protected MaoBLL _maoBLL;
        protected UserBLL _userBLL;
        protected RegisterBLL _registerBLL;
        protected MaoFailedJobBLL _maoFailedJobBLL;

        protected IList<Mao> maos;
        protected BaseJob()
        {
            _maoBLL = new MaoBLL();
            _userBLL = new UserBLL();
            _registerBLL = new RegisterBLL();
            _maoFailedJobBLL = new MaoFailedJobBLL();

            maos = FacePlatformCache.GetALL<Mao>();

            projectCode = Program._Mainform._ProjectCode;
            propertyHouseCode = Program._Mainform._PropertyHouseCode;
            virtualHouseCode = Program._Mainform._VirtualHouseCode;
            photoPath = MainForm.picturePath;
            maxRetryTime = MainForm.maxRetryTime;
        }

        protected DateTime GetMinDateTime()
        {
            return Convert.ToDateTime("2000-01-01");
        }
    }
}
