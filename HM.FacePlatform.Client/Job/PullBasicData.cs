using System;
using System.Collections.Generic;
using HM.Common_;
using HM.DTO;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Client.WeChatService;
using HM.FacePlatform.Model;
using Quartz;
using System.Linq;
using HM.DTO.FacePlatform;
using HM.Utils_;
using AutoMapper;

namespace HM.FacePlatform.Client
{
    /// <summary>
    /// 内部项目第一次运行时同步基础数据
    /// 1.builing
    /// 2.house
    /// 3.user
    /// </summary>
    [DisallowConcurrentExecution]
    public class PullBasicData : IJob
    {
        BuildingBLL buildingBLL;
        HouseBLL houseBLL;
        UserBLL userBLL;
        RegisterBLL registerBLL;

        public PullBasicData()
        {
            buildingBLL = new BuildingBLL();
            houseBLL = new HouseBLL();
            userBLL = new UserBLL();
            registerBLL = new RegisterBLL();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            LogHelper.Debug("开始同步基础数据...");

            bool isSuccess = GetBuilding();
            if (isSuccess) isSuccess = GetUser();

            if (isSuccess)
            {
                CommonHelper.WriteConfig("IsInitialized", "1");

                LogHelper.Debug("同步基础数据成功");
            }
            else
            {
                LogHelper.Warn("同步基础数据失败");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetBuilding()
        {
            string response = string.Empty;
            bool isSuccess;

            using (WeChatServiceClient client = new WeChatServiceClient())
            {
                try
                {
                    response = client.GetBuildingListByProject(SystemParameter._project.project_code);
                    client.Close();
                    isSuccess = true;
                }
                catch (Exception buildingException)
                {
                    client.Abort();
                    isSuccess = false;
                    LogHelper.Error("获取楼栋数据失败：", buildingException);
                }
            }

            if (!isSuccess) return false;
            JsonResponse<Building[]> buildings = HM.Utils_.Json_.GetObject<JsonResponse<Building[]>>(response);
            if (buildings.status == 0)
            {
                LogHelper.Error("服务器返回错误：" + buildings.message);
                return false;
            }
            if (buildings.data.Length < 1)
            {
                LogHelper.Debug("没有需要同步的基础数据，同步基础数据结束");
                return true;
            }

            foreach (var _c_building in buildings.data)
            {
                string building_code = _c_building.building_code;
                if (_c_building.building_code == SystemParameter._virtualBuilding.building_code)
                {
                    building_code = SystemParameter._virtualBuilding.building_code; //虚拟楼栋
                }
                else
                {
                    Building _building = buildingBLL.FirstOrDefault(it => it.building_code == building_code);
                    if (_building == null)
                    {
                        _building = new Building()
                        {
                            building_code = _c_building.building_code,
                            building_name = _c_building.building_name,
                            project_code = _c_building.project_code,
                            create_date = DateTime.MinValue,
                        };

                        buildingBLL.Add(_building);

                        LogHelper.Info("building：" + _building.building_name);
                    }
                    else
                    {
                        LogHelper.Debug("building：" + _building.building_name + " -->已同步，本次无需同步");
                    }
                }

                isSuccess = GetHouse(_c_building, building_code);
                if (!isSuccess) return false;
            }

            return true;
        }


        private bool GetHouse(Building _c_building, string building_code)
        {
            string response = string.Empty;
            bool isSuccess;

            using (WeChatServiceClient client = new WeChatServiceClient())
            {
                try
                {
                    response = client.GetHouseListByBuilding(SystemParameter._project.project_code, _c_building.building_code);
                    client.Close();
                    isSuccess = true;
                }
                catch (Exception houseException)
                {
                    client.Abort();
                    isSuccess = false;
                    LogHelper.Error("获取房屋数据失败：", houseException);
                }
            }

            if (!isSuccess) return false;

            JsonResponse<List<HouseDto>> houses = Json_.GetObject<JsonResponse<List<HouseDto>>>(response);
            if (houses.status == 0)
            {
                LogHelper.Error("服务器返回错误：" + houses.message);
                return false;
            }
            if (!houses.data.Any()) return true;

            foreach (var _c_hosue in houses.data)
            {
                string house_code = _c_hosue.house_code;
                if (_c_hosue.house_code == SystemParameter._virtualHouse.house_code)
                {
                    house_code = SystemParameter._virtualHouse.house_code;//虚拟房屋
                }
                else if (_c_hosue.house_code == SystemParameter._propertyHouse.house_name)
                {
                    house_code = SystemParameter._propertyHouse.house_code;//物业管理处
                }
                else
                {
                    House _house = houseBLL.FirstOrDefault(it => it.house_code == house_code);
                    if (_house == null)
                    {
                        _house = new House()
                        {
                            house_code = _c_hosue.house_code,
                            house_name = _c_hosue.house_name,
                            unit = _c_hosue.unit ?? "",
                            building_code = building_code,
                            floor = _c_hosue.floor ?? "",
                            roomnumber = _c_hosue.roomnumber ?? "",
                            create_date = DateTime.MinValue,
                        };

                        houseBLL.Add(_house);

                        LogHelper.Info("house：" + _house.house_name);
                    }
                    else
                    {
                        LogHelper.Debug("house：" + _house.house_name + " -->已同步，本次无需同步");
                    }
                }

                //GetUser(_c_hosue, house_code);
            }
            return true;
        }


        private bool GetUser()
        {
            string response = string.Empty;
            bool isSuccess;

            int pageNumber = 1;
            int rowsPerPage = 200;

            while (true)
            {
                using (WeChatServiceClient client = new WeChatServiceClient())
                {
                    try
                    {
                        response = client.GetPagedUserListByProject(SystemParameter._project.project_code, pageNumber, rowsPerPage);
                        pageNumber++;
                        client.Close();
                        isSuccess = true;
                    }
                    catch (Exception userException)
                    {
                        client.Abort();
                        isSuccess = false;
                        LogHelper.Error("获取用户数据失败", userException);
                    }
                }

                if (!isSuccess) return false;

                JsonResponse<List<UserDto>> jsonResponse = Json_.GetObject<JsonResponse<List<UserDto>>>(response);
                if (jsonResponse.status == 0)
                {
                    LogHelper.Error("服务器返回错误：" + jsonResponse.message);
                    return false;
                }
                if (!jsonResponse.data.Any()) return true;

                foreach (var dto in jsonResponse.data)
                {
                    User dbUser = userBLL.GetUserWithUserHouse(dto.user_uid);
                    if (dbUser == null)
                    {
                        dbUser = Mapper.Map<User>(dto);
                        dbUser.id = 0;
                        if (dbUser.user_houses != null && dbUser.user_houses.Any())
                        {
                            foreach (var user_house in dbUser.user_houses)
                            {
                                user_house.id = 0;
                            }
                        }
                        userBLL.Add(dbUser);

                        LogHelper.Info("user：" + dbUser.name);
                    }
                    else
                    {
                        if (dto.birthday.HasValue) dbUser.birthday = dto.birthday.Value;
                        if (dto.lastupdate_time.HasValue) dbUser.change_time = dto.lastupdate_time.Value;
                        dbUser.data_from = ClientAndServerConverter.NullableIntToUserDataFromType(dto.data_from, dbUser.data_from);
                        if (!string.IsNullOrEmpty(dto.id_num)) dbUser.id_num = dto.id_num;
                        dbUser.id_type = ClientAndServerConverter.NullableShortToIdType(dto.id_type);
                        if (!string.IsNullOrEmpty(dto.mobile)) dbUser.mobile = dto.mobile;
                        dbUser.name = dto.name;
                        dbUser.sex = ClientAndServerConverter.NullableBoolToSexType(dto.sex);
                        if (!string.IsNullOrEmpty(dto.tel)) dbUser.tel = dto.tel;
                        //dbUser.user_uid = dto.user_uid;

                        if (dto.user_houses != null && dto.user_houses.Any())
                        {
                            foreach (var dtoUserHouse in dto.user_houses)
                            {
                                var dbUserHouse = dbUser.user_houses.Where(it => it.house_code == dtoUserHouse.house_code).FirstOrDefault();
                                if (dbUserHouse == null)
                                {
                                    dbUserHouse = Mapper.Map<UserHouse>(dtoUserHouse);
                                    dbUser.user_houses.Add(dbUserHouse);
                                }
                                else
                                {
                                    dbUserHouse.house_code = dtoUserHouse.house_code;
                                    //dbUserHouse.id = dbUserHouse.id;
                                    dbUserHouse.is_del = ClientAndServerConverter.BoolToIsDelType(dtoUserHouse.is_del);
                                    dbUserHouse.relation = dtoUserHouse.relation;
                                    dbUserHouse.user_type = ClientAndServerConverter.RelationToUserType(dtoUserHouse.relation);
                                    dbUserHouse.user_uid = dbUserHouse.user_uid;
                                }
                            }
                        }
                        LogHelper.Debug("修改 user：" + dbUser.name);

                        userBLL.Edit(dbUser);
                    }
                }
            }
        }
    }
}
