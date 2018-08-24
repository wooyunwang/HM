using HM.DTO;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using System;
using System.Configuration;
using System.IO;


namespace HM.FacePlatform.Client
{
    public static class SystemParameter
    {
        public static Project _project;
        public static Building _virtualBuilding;
        public static House _virtualHouse;
        public static House _propertyHouse;
        public static string TempPhotoPath;
        public static int FaceEndDays;
        public static int MaxSleepSeconds;

        public static ActionResult Load()
        {
            ActionResult actionResult = new ActionResult();
            ProjectBLL projectBLL = new ProjectBLL();
            BuildingBLL buildingBLL = new BuildingBLL();
            HouseBLL houseBLL = new HouseBLL();

            _project = projectBLL.FirstOrDefault();
            if (_project == null)
            {
                CommonHelper.GetLogger().Error("加载项目信息失败，请检查数据库连接");
                actionResult.IsSuccess = false;
                return actionResult;
            }

            _virtualBuilding = new Building()
            {
                building_code = _project.project_code + "0123456789012",
            };

            _virtualBuilding = buildingBLL.FirstOrDefault(it => it.building_code == _virtualBuilding.building_code);
            if (_virtualBuilding == null)
            {
                CommonHelper.GetLogger().Error("加载项目信息失败，请确认数据库是否正确初始化");
                actionResult.IsSuccess = false;
                return actionResult;
            }

            _virtualHouse = new House()
            {
                house_code = "n" + _project.project_code + "0123456789012345678",
            };
            _virtualHouse = houseBLL.FirstOrDefault(it => it.house_code == _virtualHouse.house_code);
            if (_virtualHouse == null)
            {
                CommonHelper.GetLogger().Error("加载项目信息失败，请确认数据库是否正确初始化");
                actionResult.IsSuccess = false;
                return actionResult;
            }

            _propertyHouse = new House()
            {
                house_code = "w" + _project.project_code + "0123456789012345678",
            };
            _propertyHouse = houseBLL.FirstOrDefault(it => it.house_code == _propertyHouse.house_code);
            if (_propertyHouse == null)
            {
                CommonHelper.GetLogger().Error("加载项目信息失败，请确认数据库是否正确初始化");
                actionResult.IsSuccess = false;
                return actionResult;
            }

            TempPhotoPath = ConfigurationManager.AppSettings["TempPhotoPath"];
            if (!Directory.Exists(TempPhotoPath))
            {
                try
                {
                    Directory.CreateDirectory(TempPhotoPath);
                }
                catch (Exception ex)
                {
                    CommonHelper.GetLogger().Error(TempPhotoPath + " 创建失败", ex);
                    actionResult.IsSuccess = false;
                    return actionResult;
                }
            }

            FaceEndDays = Convert.ToInt32(ConfigurationManager.AppSettings["FaceEndTime"]);

            MaxSleepSeconds = Convert.ToInt32(ConfigurationManager.AppSettings["MaxSleepSeconds"]);

            return actionResult;
        }
    }
}
