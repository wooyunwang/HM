using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HM.Common_;
using HM.DTO;
using HM.FacePlatform.WeChat.BLL;
using HM.FacePlatform.WeChatModel;
using HM.Utils_;
using AutoMapper;
using HM.DTO.FacePlatform;

namespace HM.FacePlatform.Server
{
    public partial class WeChatService
    {
        /// <summary>
        /// 修改楼栋信息
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="serializedBuilding"></param>
        /// <returns></returns>
        public string PutBuilding(string project_code, string serializedBuilding)
        {
            WriteAccessLog(project_code, "更新 building 数据-->云平台");

            BuildingBLL buildingBLL = new BuildingBLL();
            JsonResponse<string> response = new JsonResponse<string>();
            BuildingDto dto = Json_.GetObject<BuildingDto>(serializedBuilding);
            c_building _c_building = Mapper.Map<BuildingDto, c_building>(dto);
            if (!buildingBLL.Any(it => it.building_code == _c_building.building_code))
            {
                ActionResult ar = buildingBLL.Add(_c_building);
                response = new JsonResponse<string>(ar);
            }
            else
            {
                //编辑，暂时忽略
            }
            return response.ToString();
        }

        public string PutHouse(string project_code, string serializedHouse)
        {
            WriteAccessLog(project_code, "更新 house 数据-->云平台");

            HouseBLL houseBLL = new HouseBLL();
            JsonResponse<string> response = new JsonResponse<string>();
            HouseDto dto = Json_.GetObject<HouseDto>(serializedHouse);
            c_house _c_house = Mapper.Map<HouseDto, c_house>(dto);

            if (!houseBLL.Any(it => it.house_code == _c_house.house_code))
            {
                ActionResult ar = houseBLL.Add(_c_house);
                response = new JsonResponse<string>(ar);
            }
            else
            {
                //编辑，暂时忽略
            }
            return response.ToString();
        }

        public string PutUser(string project_code, string serializedUser)
        {
            WriteAccessLog(project_code, "人脸平台 更新 user 数据-->云平台");

            User_W_BLL userBLL = new User_W_BLL();
            UserHouseBLL userHouseBLL = new UserHouseBLL();
            JsonResponse<string> response = new JsonResponse<string>();

            UserDto dto = Json_.GetObject<UserDto>(serializedUser);
            w_user user = Mapper.Map<UserDto, w_user>(dto);

            //user_uid, id_num, moblie
            List<w_user> users = userBLL.Get(it => it.user_uid == user.user_uid);
            if (!users.Any())
            {
                if (!string.IsNullOrEmpty(user.id_num))
                    users = userBLL.Get(it => it.id_num == user.id_num);
                if (!users.Any())
                {
                    if (!string.IsNullOrEmpty(user.mobile))
                        users = userBLL.Get(it => it.mobile == user.mobile);
                }
            }

            if (!users.Any())
            {
                userBLL.Add(user);
                if (user.user_houses != null && user.user_houses.Any())
                {
                    var userHouses = user.user_houses;
                    var lstHouseCode = userHouses.Select(it => it.house_code).Distinct();
                    List<c_user_house> lstUserHouse = userHouseBLL.Get(it => it.user_uid == user.user_uid && lstHouseCode.Contains(it.house_code));
                    foreach (var userHouse in userHouses)
                    {
                        var dbUserHouse = lstUserHouse.Where(it => it.house_code == userHouse.house_code).FirstOrDefault();
                        if (dbUserHouse != null)
                        {
                            if (dbUserHouse.lastupdate_time < userHouse.lastupdate_time)
                            {
                                dbUserHouse.is_del = userHouse.is_del;
                                dbUserHouse.house_code = userHouse.house_code;
                                dbUserHouse.lastupdate_time = userHouse.lastupdate_time;
                                dbUserHouse.project_code = userHouse.project_code;
                                dbUserHouse.relation = userHouse.relation;
                                dbUserHouse.user_uid = userHouse.user_uid;
                                userHouseBLL.Edit(dbUserHouse);
                            }
                        }
                        else
                        {
                            userHouseBLL.Add(userHouse);
                        }
                    }
                }
            }
            else
            {
                if (users.Count > 0)
                {
                    LogHelper.Error($"{ project_code }用户{ user.name }【{ user.user_uid }】数据重复！");
                }
                var dbUser = users[0];
                if (dbUser.lastupdate_time < user.lastupdate_time)
                {
                    dbUser.birthday = user.birthday;
                    dbUser.data_from = user.data_from;
                    dbUser.id_num = user.id_num;
                    dbUser.id_type = user.id_type;
                    dbUser.is_temp = user.is_temp;
                    dbUser.lastupdate_time = user.lastupdate_time;
                    dbUser.mobile = user.mobile;
                    dbUser.name = user.name;
                    dbUser.photo = user.photo;
                    dbUser.sex = user.sex;
                    dbUser.tel = user.tel;
                    dbUser.user_type = dbUser.user_type;
                    dbUser.user_uid = dbUser.user_uid;
                    userBLL.Edit(dbUser);
                    if (user.user_houses != null && user.user_houses.Any())
                    {
                        var userHouses = user.user_houses;
                        var lstHouseCode = userHouses.Select(it => it.house_code).Distinct();
                        List<c_user_house> lstUserHouse = userHouseBLL.Get(it => it.user_uid == user.user_uid && lstHouseCode.Contains(it.house_code));
                        foreach (var userHouse in userHouses)
                        {
                            var dbUserHouse = lstUserHouse.Where(it => it.house_code == userHouse.house_code).FirstOrDefault();
                            if (dbUserHouse != null)
                            {
                                if (dbUserHouse.lastupdate_time < userHouse.lastupdate_time)
                                {
                                    dbUserHouse.is_del = userHouse.is_del;
                                    dbUserHouse.house_code = userHouse.house_code;
                                    dbUserHouse.lastupdate_time = userHouse.lastupdate_time;
                                    dbUserHouse.project_code = userHouse.project_code;
                                    dbUserHouse.relation = userHouse.relation;
                                    dbUserHouse.user_uid = userHouse.user_uid;
                                    userHouseBLL.Edit(dbUserHouse);
                                }
                            }
                            else
                            {
                                userHouseBLL.Add(userHouse);
                            }
                        }
                    }
                }
            }
            return response.ToString();
        }

        public string PutRegister(string project_code, string serializedRegister)
        {
            WriteAccessLog(project_code, "更新 register 数据-->云平台");

            RegisterBLL registerBLL = new RegisterBLL();
            JsonResponse<string> response = new JsonResponse<string>();

            try
            {
                RegisterInputDto dto = Json_.GetObject<RegisterInputDto>(serializedRegister);
                w_register register = Mapper.Map<RegisterDto, w_register>(dto);

                IList<w_register> registers;
                if (register.id > 0)
                {
                    registers = new List<w_register>();
                    var model = registerBLL.FirstOrDefault(it => it.id == register.id);
                    registers.Add(model);
                }
                else
                {
                    //wait face_uid这个应该创建唯一索引
                    registers = registerBLL.Get(it => it.face_uid == register.face_uid);
                }

                if (!registers.Any())
                {
                    string photo_path = Key_.SequentialGuid() + ".jpg";
                    string photoFinalPath = Path.Combine(SystemParameter.tempPhotoPath, photo_path);

                    if (Image_.Base64StringToImage(register.photo_path, photoFinalPath))
                    {
                        string toSavePath = string.Format("{0}{1}/{2}{3}"
                        , SystemParameter.parentDirectory, project_code, SystemParameter.photoFolder, photo_path);

                        AliyunOssHelper.Upload(toSavePath, photoFinalPath);

                        register.photo_path = photo_path;
                        ActionResult ar = registerBLL.Add(register);
                    }

                    if (File.Exists(photoFinalPath))
                    {
                        string thumbnail_photo_path = Key_.SequentialGuid() + ".jpg";
                        string thumbnailFinalPath = Path.Combine(SystemParameter.tempPhotoPath, thumbnail_photo_path);

                        FileInfo fileInfo = new FileInfo(photoFinalPath);

                        bool compressResult = Image_.CompressImage(photoFinalPath, thumbnailFinalPath, size: 520);
                        if (compressResult)
                        {
                            string toSavePath = string.Format("{0}{1}/{2}{3}"
                        , SystemParameter.parentDirectory, project_code, SystemParameter.photoZipFolder, photo_path);

                            AliyunOssHelper.Upload(toSavePath, thumbnailFinalPath);
                        }
                        else
                        {

                        }
                        File.Delete(photoFinalPath);
                        File.Delete(thumbnailFinalPath);
                    }
                }
                else
                {
                    w_register existRegister = registers[0];

                    if (existRegister.is_del == true) return response.ToString();// 如果已经是删除状态，直接返回

                    if (register.register_state == existRegister.register_state
                        && register.check_note == existRegister.check_note
                        && register.is_del == existRegister.is_del)
                    {
                        // 没有更改，不作处理
                    }
                    else
                    {
                        register.id = existRegister.id;
                        register.guid_type = existRegister.guid_type;
                        register.photo_path = existRegister.photo_path;
                        registerBLL.Edit(register);

                        if (register.is_del == true && SystemParameter.isDeleteFromOss == true)
                        {
                            string toDeletePath = string.Format("{0}{1}/{2}{3}"
                                , SystemParameter.parentDirectory, project_code, SystemParameter.photoFolder, register.photo_path);
                            AliyunOssHelper.Delete(toDeletePath);

                            toDeletePath = string.Format("{0}{1}/{2}{3}"
                                , SystemParameter.parentDirectory, project_code, SystemParameter.photoZipFolder, register.photo_path);

                            try
                            {
                                AliyunOssHelper.Delete(toDeletePath);
                            }
                            catch (Exception ex)
                            {
                                // 处理重复删除问题
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.status = 0;
                response.message = ex.Message;

                WriteException(project_code, MethodBase.GetCurrentMethod().ToString(), ex);
            }

            return response.ToString();
        }
        /// <summary>
        /// 通信记录
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="serializedEntryHistory"></param>
        /// <returns></returns>
        public string PutEntryHistory(string project_code, string serializedEntryHistory)
        {
            WriteAccessLog(project_code, "更新 entry history 数据-->云平台");

            EntryHistoryBLL entryHistoryBLL = new EntryHistoryBLL();
            JsonResponse<string> response = new JsonResponse<string>();

            EntryHistoryDto dto = Json_.GetObject<EntryHistoryDto>(serializedEntryHistory);

            w_entry_history entry_history = entryHistoryBLL.FirstOrDefault(it =>
                        it.snapshot_id == dto.snapshot_id
                        && it.mao_no == dto.mao_no
                        && it.project_code == dto.project_code);

            if (entry_history == null)
            {
                entry_history = Mapper.Map<w_entry_history>(dto);

                string photo_path = Key_.SequentialGuid() + ".jpg";
                string photoFinalPath = Path.Combine(SystemParameter.tempPhotoPath, photo_path);

                if (Image_.Base64StringToImage(entry_history.photo_path, photoFinalPath))
                {
                    string toSavePath = string.Format("{0}{1}/{2}{3}"
                    , SystemParameter.parentDirectory, project_code, SystemParameter.snapshotFolder, photo_path);
                    AliyunOssHelper.Upload(toSavePath, photoFinalPath);

                    entry_history.photo_path = photo_path;
                    entryHistoryBLL.Add(entry_history);

                    File.Delete(photoFinalPath);
                }
            }
            else
            {
                //暂不处理
            }
            return response.ToString();
        }
    }
}
