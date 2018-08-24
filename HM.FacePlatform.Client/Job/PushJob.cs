using AutoMapper;
using HM.Common_;
using HM.DTO;
using HM.DTO.FacePlatform;
using HM.Face.Common_;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Client.WeChatService;
using HM.FacePlatform.Model;
using HM.Utils_;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HM.FacePlatform.Client
{
    /// <summary>
    /// 定时将平台操作更新失败数据推送到微信端服务器
    /// 1.building
    /// 2.house
    /// 3.user
    /// 4.register(从猫获取)
    /// 5.entry_history(暂时没有用处，预留以后功能扩展)
    /// </summary>
    [DisallowConcurrentExecution]
    public class PushJob : IJob
    {
        BuildingBLL buildingBLL;
        HouseBLL houseBLL;
        UserBLL userBLL;
        RegisterBLL registerBLL;
        MaoBLL maoBLL;

        public PushJob()
        {
            buildingBLL = new BuildingBLL();
            houseBLL = new HouseBLL();
            userBLL = new UserBLL();
            registerBLL = new RegisterBLL();
            maoBLL = new MaoBLL();
        }
        public void Execute(IJobExecutionContext context)
        {
#if !DEBUG
            Thread.Sleep(CommonHelper.GetSleepTime());//随机等待，减轻并发压力
#endif
            DateTime lastPushDate = Convert.ToDateTime(CommonHelper.GetConfig("LastPushDate"));
            lastPushDate = lastPushDate.AddMinutes(-10);
            DateTime latestStartDate = DateTime.Now;
            bool isSuccess = true;

            PushBuilding(lastPushDate, latestStartDate);

            PushHouse(lastPushDate, latestStartDate);

            PushUser(lastPushDate, latestStartDate);

            PushRegister(lastPushDate, latestStartDate);

            isSuccess = PushEntryHistory(lastPushDate, latestStartDate);

            DirectoryInfo directory = new DirectoryInfo(SystemParameter.TempPhotoPath);
            foreach (FileInfo file in directory.GetFiles("*.*")) file.Delete();//清除缓存图片

            if (isSuccess) CommonHelper.WriteConfig("LastPushDate", latestStartDate.ToString());
        }

        private void PushBuilding(DateTime from, DateTime to)
        {
            List<Building> buildings = buildingBLL.Get(it => it.create_date >= from && it.create_date < to);
            if (!buildings.Any()) return;

            LogHelper.Debug("检测到人脸平台building数据有新增，更新到微信端服务器...");

            foreach (var _building in buildings)
            {
                bool isSuccess = false;

                //if(_building.building_code == SystemParameter.VirtualBuilding.building_code) continue;

                Building _c_building = new Building()
                {
                    building_code = _building.building_code,
                    building_name = _building.building_name,
                    project_code = _building.project_code,
                };

                string request = Json_.GetString(_c_building);

                using (WeChatServiceClient client = new WeChatServiceClient())
                {
                    try
                    {
                        string response = client.PutBuilding(SystemParameter._project.project_code, request);
                        client.Close();

                        JsonResponse<string> result = Json_.GetObject<JsonResponse<string>>(response);
                        if (result.status == 1)
                        {
                            isSuccess = true;
                            LogHelper.Info(_building.building_name + " 更新到微信端服务器成功");
                        }
                        else LogHelper.Error("building更新到微信端服务器失败：" + result.message);
                    }
                    catch (Exception ex)
                    {
                        client.Abort();
                        LogHelper.Error("building更新到微信端服务器失败：", ex);
                    }
                }

                if (!isSuccess)
                {
                    _building.create_date = CommonHelper.AddSeconds(_building.create_date);
                    buildingBLL.Edit(_building);
                }
            }
        }

        private void PushHouse(DateTime from, DateTime to)
        {
            List<House> houses = houseBLL.Get(it => it.create_date >= from && it.create_date < to);
            if (!houses.Any()) return;

            LogHelper.Info("检测到人脸平台hosue数据有新增，更新到微信端服务器...");

            foreach (var _house in houses)
            {
                bool isSuccess = false;

                //if(_house.house_code == SystemParameter.VirtualHouse.house_code 
                //    || _house.house_code == SystemParameter.PropertyHouse.house_code) continue;

                House _c_house = new House()
                {
                    building_code = _house.building_code,
                    floor = _house.floor,
                    house_code = _house.house_code,
                    house_name = _house.house_name,
                    roomnumber = _house.roomnumber,
                    unit = _house.unit,
                };

                string request = Json_.GetString(_c_house);

                using (WeChatServiceClient client = new WeChatServiceClient())
                {
                    try
                    {
                        string response = client.PutHouse(SystemParameter._project.project_code, request);
                        client.Close();

                        JsonResponse<string> result = Json_.GetObject<JsonResponse<string>>(response);
                        if (result.status == 1)
                        {
                            isSuccess = true;
                            LogHelper.Info(_house.house_name + " 更新到微信端服务器成功");
                        }
                        else LogHelper.Error("house更新到微信端服务器失败：" + result.message);
                    }
                    catch (Exception ex)
                    {
                        client.Abort();
                        LogHelper.Error("house更新到微信端服务器失败：", ex);
                    }
                }

                if (!isSuccess)
                {
                    _house.create_date = CommonHelper.AddSeconds(_house.create_date);
                    houseBLL.Edit(_house);
                }
            }
        }

        private void PushUser(DateTime from, DateTime to)
        {
            List<User> lstUser = userBLL.GetUserForPushToCloud(from, to);
            if (!lstUser.Any()) return;

            LogHelper.Debug("检测到人脸平台user数据有修改，更新到微信端服务器...");


            foreach (var user in lstUser)
            {
                UserDto dto = Mapper.Map<UserDto>(user);
                bool isSuccess = false;

                string request = Json_.GetString(dto);

                using (WeChatServiceClient client = new WeChatServiceClient())
                {
                    try
                    {
                        string response = client.PutUser(SystemParameter._project.project_code, request);
                        client.Close();

                        JsonResponse<string> result = Json_.GetObject<JsonResponse<string>>(response);
                        if (result.status == 1)
                        {
                            isSuccess = true;
                            LogHelper.Info(dto.name + " 更新到微信端服务器成功");
                        }
                        else LogHelper.Error("user更新到微信端服务器失败：" + result.message);
                    }
                    catch (Exception ex)
                    {
                        client.Abort();
                        LogHelper.Error("user更新到微信端服务器失败：", ex);
                    }
                }

                if (!isSuccess)
                {
                    user.change_time = CommonHelper.AddSeconds(user.change_time);
                    userBLL.Edit(user);
                }
            }
        }

        private void PushRegister(DateTime from, DateTime to)
        {
            var checkResult = maoBLL.CheckMao();
            if (checkResult.IsSuccess)
            {
                var goodMaos = checkResult.Obj.Where(it => it.Value.Item1 == true).Select(it => it.Value);
                if (goodMaos.Any())
                {
                    Parallel.ForEach(goodMaos,
                        new ParallelOptions { MaxDegreeOfParallelism = Config_.GetInt("MaxDegreeOfParallelism") ?? 2 },
                        tplMao =>
                        {
                            Mao mao = tplMao.Item2;
                            Face.Common_.Face face = tplMao.Item3;
                            int pageNumber = 1, rowsPerPage = 50;
                            while (true)
                            {
                                ActionResult<List<GetRegisterPageOutput>> getResult = face.GetRegisterPage(new GetRegisterPageInput()
                                {
                                    DataTypes = new List<RegisterDataType>() {
                                            RegisterDataType.注册审核已通过数据,
                                            RegisterDataType.注册审核未通过数据,
                                            RegisterDataType.注册待审核数据
                                        },
                                    Endtime = to,
                                    PageNumber = pageNumber,
                                    PageSize = rowsPerPage,
                                    ProjectCode = SystemParameter._project.project_code,
                                    UpdateTime = from
                                });
                                if (getResult.IsSuccess)
                                {
                                    pageNumber++;

                                    if (getResult.Obj == null || !getResult.Obj.Any()) break;

                                    List<GetRegisterPageOutput> lstOutput = getResult.Obj;

                                    foreach (GetRegisterPageOutput data in lstOutput)
                                    {
                                        foreach (HMFaceObj faceObj in data.HMFaceObj)
                                        {
                                            Uri rootUri = face.GetRootUri();
                                            string fileName = Path.GetFileName(faceObj.ImageUrl);
                                            Uri sourcePath = new Uri(rootUri, faceObj.ImageUrl);
                                            if (registerBLL.DownloadFaceFile(sourcePath, SystemParameter.TempPhotoPath))
                                            {
                                                string base64 = Image_.ImageToBase64(Path.Combine(SystemParameter.TempPhotoPath, fileName));

                                                RegisterInputDto dto = new RegisterInputDto()
                                                {
                                                    ///1-业主卡、2-身份证、3-唯一标识、4-其他卡号、5-共有卡
                                                    guid_value = data.CardNo,
                                                    guid_type = 3,//3-唯一标识
                                                    face_uid = faceObj.FaceId,
                                                    photo_string = base64,
                                                    register_type = Mapper.Map<short>(data.RegisterType),
                                                    reg_time = data.RegisterTime,
                                                    end_time = data.ActiveTime,
                                                    register_state = Mapper.Map<short?>(faceObj.FaceState),//wait
                                                    check_time = data.CheckTime,
                                                    check_note = data.CheckMessage,
                                                    create_time = faceObj.ImageRegisterTime,
                                                    is_del = false,
                                                    people_id = data.PeopleId,
                                                    project_code = SystemParameter._project.project_code,
                                                    lastupdate_time = data.UpdateTime,
                                                };

                                                if (dto.check_note.IndexOf("此照片已绑定") > -1) dto.check_note = "此照片已绑定其他用户";

                                                string request = Json_.GetString(dto);

                                                using (WeChatServiceClient client = new WeChatServiceClient())
                                                {
                                                    try
                                                    {
                                                        string response = client.PutRegister(SystemParameter._project.project_code, request);
                                                        client.Close();

                                                        JsonResponse<string> result = Json_.GetObject<JsonResponse<string>>(response);
                                                        if (result.status == 1)
                                                            LogHelper.Info(dto.guid_value + " 照片 " + dto.face_uid + " 更新到微信端服务器成功");
                                                        else
                                                        {
                                                            LogHelper.Error("register更新到微信端服务器失败：" + result.message
                                                                + "face_id: " + dto.face_uid);
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        client.Abort();
                                                        LogHelper.Error("register更新到微信端服务器失败：" + "face_id: " + dto.face_uid, ex);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                LogHelper.Error("register下载图片失败：" + sourcePath);
                                                //return false;//如果图片下载失败，则是天诚返回数据有问题，跳过处理
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    LogHelper.Error(getResult.ToAlertString());
                                }
                            }
                        });
                }
                else
                {
                    LogHelper.Error("没有配置人脸设备！");
                }
            }
            else
            {
                var badMaos = checkResult.Obj.Where(it => it.Value.Item1 == false)
                 .Select(it => it.Value).Select(it => it.Item2);
                foreach (var mao in badMaos)
                {
                    LogHelper.Warn($"人脸一体机【{mao.mao_name}】IP【{mao.ip}】端口【{mao.port}】连接失败！");
                }
                LogHelper.Warn("这将导致删除失败！");
            }
        }

        private bool PushEntryHistory(DateTime from, DateTime to)
        {
            var checkResult = maoBLL.CheckMao();
            if (checkResult.IsSuccess)
            {
                var goodMaos = checkResult.Obj.Where(it => it.Value.Item1 == true).Select(it => it.Value);
                if (goodMaos.Any())
                {
                    Parallel.ForEach(goodMaos,
                        new ParallelOptions { MaxDegreeOfParallelism = Config_.GetInt("MaxDegreeOfParallelism") ?? 2 },
                        tplMao =>
                        {
                            Mao mao = tplMao.Item2;
                            Face.Common_.Face face = tplMao.Item3;

                            int pageNumber = 1, rowsPerPage = 50;
                            while (true)
                            {
                                var actionResult = face.GetFacePassData(new Face.Common_.GetFacePassDataInput()
                                {
                                    EndTime = to,
                                    PageNumber = pageNumber,
                                    PageSize = rowsPerPage,
                                    ProjectCode = SystemParameter._project.project_code,
                                    UpdateTime = from
                                });

                                if (!actionResult.IsSuccess)
                                {
                                    return;
                                }

                                pageNumber++;

                                if (actionResult.Obj == null || !actionResult.Obj.Any()) break;

                                foreach (Face.Common_.GetFacePassDataOutput output in actionResult.Obj)
                                {
                                    EntryHistoryDto dto = new EntryHistoryDto()
                                    {
                                        face_uid = output.FaceId,
                                        mao_no = mao.mao_no,
                                        create_date = output.Passtime,
                                        project_code = SystemParameter._project.project_code,
                                        user_uid = output.CardNo,
                                        //mao_id = mao.id,
                                        //mao_name = mao.mao_name,
                                        //mao_ip = mao.ip,
                                        //mao_port = mao.port,
                                    };

                                    if (output.FaceObj != null && output.FaceObj.Any())
                                    {
                                        var lstFaceObj = output.FaceObj.OrderByDescending(a => a.Score).ToList();

                                        foreach (var faceObj in lstFaceObj)
                                        {
                                            //string rootUrl = registerBLL.GetRootUrl(_mao);
                                            string fileName = Path.GetFileName(faceObj.ImageUrl);
                                            string sourcePath = faceObj.ImageUrl;
                                            if (registerBLL.DownloadFaceFile(sourcePath, SystemParameter.TempPhotoPath))
                                            {
                                                string base64 = Image_.ImageToBase64(Path.Combine(SystemParameter.TempPhotoPath, fileName));

                                                dto.snapshot_id = faceObj.FaceRowId;
                                                dto.photo_path = base64;
                                                dto.score = (decimal)faceObj.Score;

                                                break;
                                            }

                                            LogHelper.Error("entry_history下载图片失败：" + sourcePath);
                                        }
                                    }

                                    if (string.IsNullOrEmpty(dto.photo_path))
                                    {
                                        LogHelper.Warn(output.CardNo + " entry_history没有图片, 通行时间："
                                            + output.Passtime + "设备: " + mao.mao_name);
                                        continue;
                                    }

                                    string request = Json_.GetString(dto);

                                    using (WeChatServiceClient client = new WeChatServiceClient())
                                    {
                                        try
                                        {
                                            string response = client.PutEntryHistory(SystemParameter._project.project_code, request);
                                            client.Close();

                                            JsonResponse<string> result = Json_.GetObject<JsonResponse<string>>(response);
                                            if (result.status == 1)
                                                LogHelper.Info(dto.user_uid + " 通行记录 " + dto.face_uid + " 更新到微信端服务器成功");
                                            else
                                            {
                                                LogHelper.Error(dto.user_uid + " entry_history更新到微信端服务器失败：" + result.message
                                                    + "face_id: " + dto.face_uid);
                                                return;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            client.Abort();
                                            LogHelper.Error(dto.user_uid + " entry_history更新到微信端服务器失败："
                                                + "face_id: " + dto.face_uid, ex);
                                            return;
                                        }
                                    }
                                }
                            }
                        });
                }
                else
                {
                    LogHelper.Error("没有配置人脸设备！");
                }
                return true;
            }
            else
            {
                var badMaos = checkResult.Obj.Where(it => it.Value.Item1 == false)
                 .Select(it => it.Value).Select(it => it.Item2);
                foreach (var mao in badMaos)
                {
                    LogHelper.Warn($"人脸一体机【{mao.mao_name}】IP【{mao.ip}】端口【{mao.port}】连接失败！");
                }
                LogHelper.Warn("这将导致删除失败！");
                return false;
            }
        }
    }
}