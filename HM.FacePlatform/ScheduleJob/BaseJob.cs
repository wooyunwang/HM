using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;

namespace HM.FacePlatform
{
    public abstract class BaseJob
    {
        public static ScheduleJob jobFrom;
        public string projectCode;
        public string propertyHouseCode;
        public string virtualHouseCode;
        public string pictureDirectory;
        public int maxRetryTime;

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
            pictureDirectory = FacePlatformCache.GetPictureDirectory();
            maxRetryTime = FacePlatformCache.GetMaxRetryTime();
        }

        protected DateTime GetMinDateTime()
        {
            return Convert.ToDateTime("2000-01-01");
        }
    }
}
