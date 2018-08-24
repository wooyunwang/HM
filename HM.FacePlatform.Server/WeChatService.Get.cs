using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AutoMapper;
using Common;
using HM.DTO;
using HM.DTO.FacePlatform;
using HM.FacePlatform.WeChat.BLL;
using HM.FacePlatform.WeChatModel;
using HM.Utils_;

namespace HM.FacePlatform.Server
{
    /// <summary>
    /// Get
    /// </summary>
    public partial class WeChatService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="project_code"></param>
        /// <returns></returns>
        public string GetBuildingListByProject(string project_code)
        {
            WriteAccessLog(project_code, "初始化， building");
            BuildingBLL buildingBLL = new BuildingBLL();

            var lstBuilding = buildingBLL.Get(it => it.project_code == project_code);

            JsonResponse<List<BuildingDto>> response = new JsonResponse<List<BuildingDto>>
            {
                data = Mapper.Map<List<BuildingDto>>(lstBuilding)
            };
            return response.ToString();
        }

        public string GetHouseListByBuilding(string project_code, string building_code)
        {
            WriteAccessLog(project_code, "初始化，获取 building-" + building_code + " 的 house");
            HouseBLL houseBLL = new HouseBLL();

            var lstHouse = houseBLL.Get(it => it.building_code == building_code);
            JsonResponse<List<HouseDto>> response = new JsonResponse<List<HouseDto>>
            {
                data = Mapper.Map<List<HouseDto>>(lstHouse)
            };
            return response.ToString();
        }

        public string GetPagedUserListByProject(string project_code, int pageNumber, int rowsPerPage)
        {
            WriteAccessLog(project_code, "初始化，获取 user 第 " + pageNumber + " 页");
            User_W_BLL userBLL = new User_W_BLL();
            PagerData<w_user> pagerData = userBLL.GetUserWithUserHouse(project_code, pageNumber - 1, rowsPerPage);

            PagerData<UserDto> pagerData2 = new PagerData<UserDto>()
            {
                pages = pagerData.pages,
                rows = Mapper.Map<List<UserDto>>(pagerData.rows),
                total = pagerData.total
            };

            var response = new JsonResponse<PagerData<UserDto>>(pagerData2);

            return response.ToString();
        }

        public string GetUpdatedUserListByProject(string project_code, DateTime from, DateTime to, int? top)
        {
            WriteAccessLog(project_code, "云平台 更新 user 数据-->人脸平台");

            User_W_BLL userBLL = new User_W_BLL();
            List<w_user> lstUser = userBLL.GetUserWithUserHouse(project_code, from, to, top);
            var lstUserDto = Mapper.Map<List<UserDto>>(lstUser);
            var response = new JsonResponse<List<UserDto>>(lstUserDto);

            return response.ToString();
        }
        /// <summary>
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public string GetPagedUpdatedRegisterListByProject(string project_code, int pageIndex, int pageSize, DateTime from, DateTime to)
        {
            WriteAccessLog(project_code, "云平台 更新 register 数据-->人脸平台, ");

            RegisterBLL registerBLL = new RegisterBLL();
            var lstRegister = registerBLL.Get(project_code, pageIndex, pageSize, from, to);
            JsonResponse<List<RegisterOutputDto>> response = new JsonResponse<List<RegisterOutputDto>>();
            response.data = Mapper.Map<List<RegisterOutputDto>>(lstRegister);
            return response.ToString();
        }
        /// <summary>
        /// 获取人脸图片
        /// </summary>
        /// <param name="photo_path"></param>
        /// <returns></returns>
        public string GetRegisterPhoto(string project_code, string photo_path)
        {
            string savedPath = string.Format("{0}{1}/{2}{3}",
                SystemParameter.parentDirectory, project_code,
                SystemParameter.photoZipFolder, photo_path);
            return AliyunOssHelper.Download(savedPath);
        }

        public string GetUser(string project_code, string user_uid)
        {
            WriteAccessLog(project_code, "云平台 获取 user: " + user_uid + "-->人脸平台");
            User_W_BLL userBLL = new User_W_BLL();
            var user = userBLL.GetUserWithUserHouse(project_code, user_uid);
            var userDto = Mapper.Map<UserDto>(user);
            var response = new JsonResponse<UserDto>(userDto);
            return response.ToString();
        }
    }
}
