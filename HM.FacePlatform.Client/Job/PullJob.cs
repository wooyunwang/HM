using System;
using System.Collections.Generic;
using System.Threading;
using Quartz;
using System.Linq;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Client.WeChatService;
using HM.Utils_;
using HM.DTO;
using HM.DTO.FacePlatform;
using HM.FacePlatform.Model;
using HM.Common_;
using HM.Enum_.FacePlatform;
using AutoMapper;

namespace HM.FacePlatform.Client
{
    /// <summary>
    /// 定时获取微信端服务器上更新的数据
    /// 1.user
    /// 2.register(推送到猫)
    /// </summary>
    [DisallowConcurrentExecution]
    public class PullJob : IJob
    {
        UserBLL userBLL;
        HouseBLL houseBLL;
        RegisterBLL registerBLL;
        MaoBLL maoBLL;

        public PullJob()
        {
            userBLL = new UserBLL();
            houseBLL = new HouseBLL();
            registerBLL = new RegisterBLL();
            maoBLL = new MaoBLL();
        }
        public void Execute(IJobExecutionContext context)
        {
#if !DEBUG
            Thread.Sleep(CommonHelper.GetSleepTime());//随机等待，减轻并发压力
#endif
            PullBasicData pullBasicData = new PullBasicData();
            if (!pullBasicData.GetBuilding()) return;

            DateTime lastPullDate = Convert.ToDateTime(CommonHelper.GetConfig("LastPullDate"));
            lastPullDate = lastPullDate.AddMinutes(-10);//时差处理
            DateTime latestStartDate = DateTime.Now;

            if (!PullUser(lastPullDate, latestStartDate)) return;

            if (!PullRegister(lastPullDate, latestStartDate)) return;

            CommonHelper.WriteConfig("LastPullDate", latestStartDate.ToString());
        }

        private bool PullUser(DateTime from, DateTime to)
        {
            string response = string.Empty;
            bool isSuccess;

            using (WeChatServiceClient client = new WeChatServiceClient())
            {
                try
                {
                    response = client.GetUpdatedUserListByProject(SystemParameter._project.project_code, from, to, null);
                    client.Close();
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    client.Abort();
                    isSuccess = false;
                    LogHelper.Error("获取user更新数据失败：", ex);
                }
            }

            if (!isSuccess) return false;

            JsonResponse<List<UserDto>> result = Json_.GetObject<JsonResponse<List<UserDto>>>(response);

            if (result.status == 0)
            {
                LogHelper.Error("服务器返回错误：" + result.message);
                return false;
            }
            if (!result.data.Any()) return true;

            foreach (UserDto dto in result.data)
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
                    var resultAdd = userBLL.Add(dbUser);
                    LogHelper.Info("新增 user：" + dbUser.name);
                }
                else
                {
                    if (dbUser.change_time < dto.lastupdate_time)
                    {

                        if (dto.birthday.HasValue) dbUser.birthday = dto.birthday.Value;
                        if (dto.lastupdate_time.HasValue) dbUser.change_time = dto.lastupdate_time.Value;
                        dbUser.data_from = ClientAndServerConverter.NullableIntToUserDataFromType(dto.data_from, dbUser.data_from);
                        if (!string.IsNullOrEmpty(dto.id_num)) dbUser.id_num = dto.id_num;
                        dbUser.id_type = ClientAndServerConverter.NullableShortToIdType(dto.id_type);
                        dbUser.sex = ClientAndServerConverter.NullableBoolToSexType(dto.sex);
                        if (!string.IsNullOrEmpty(dto.mobile)) dbUser.mobile = dto.mobile;
                        if (!string.IsNullOrEmpty(dto.tel)) dbUser.tel = dto.tel;
                        dbUser.name = dto.name;
                        if (dbUser.user_houses != null && dbUser.user_houses.Any())
                        {
                            foreach (var user_house in dto.user_houses)
                            {
                                var dbUserHouse = dbUser.user_houses.Where(it => it.house_code == user_house.house_code).FirstOrDefault();
                                if (dbUserHouse == null)
                                {
                                    dbUser.user_houses.Add(new UserHouse()
                                    {
                                        house_code = user_house.house_code,
                                        is_del = ClientAndServerConverter.BoolToIsDelType(user_house.is_del),
                                        relation = user_house.relation,
                                        user_type = ClientAndServerConverter.RelationToUserType(user_house.relation),
                                        user_uid = user_house.user_uid
                                    });
                                }
                                else
                                {
                                    dbUserHouse.house_code = user_house.house_code;
                                    dbUserHouse.is_del = ClientAndServerConverter.BoolToIsDelType(user_house.is_del);
                                    dbUserHouse.relation = user_house.relation;
                                    dbUserHouse.user_type = ClientAndServerConverter.RelationToUserType(user_house.relation);
                                    dbUserHouse.user_uid = user_house.user_uid;
                                }
                            }
                        }
                        userBLL.Edit(dbUser);
                    }

                    LogHelper.Info("修改 user：" + dbUser.name);
                }
            }
            return true;
        }

        private bool PullRegister(DateTime from, DateTime to)
        {
            string response = string.Empty;
            bool isSuccess;

            int pageNumber = 1;
            int rowsPerPage = 20;

            List<Mao> maos = maoBLL.Get();
            if (!maos.Any())
            {
                LogHelper.Error("没有配置人脸设备！");
                return false;
            }

            while (true)
            {
                using (WeChatServiceClient client = new WeChatServiceClient())
                {
                    try
                    {
                        response = client.GetPagedUpdatedRegisterListByProject(SystemParameter._project.project_code, pageNumber, rowsPerPage, from, to);
                        pageNumber++;
                        client.Close();
                        isSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        client.Abort();
                        isSuccess = false;
                        LogHelper.Error("获取register更新数据失败：", ex);
                    }
                }

                if (!isSuccess) return false;

                JsonResponse<List<RegisterOutputDto>> jsonResponse = Json_.GetObject<JsonResponse<List<RegisterOutputDto>>>(response);

                if (jsonResponse.status == 0)
                {
                    LogHelper.Error("服务器返回错误：" + jsonResponse.message);
                    return false;
                }
                if (!jsonResponse.data.Any()) return true;


                DateTime faceEndDate = Convert.ToDateTime(DateTime.Now.AddDays(SystemParameter.FaceEndDays).ToString("yyyy-MM-dd 23:59:59"));

                var lstUserRegisterDto = jsonResponse.data;

                foreach (var dto in lstUserRegisterDto)
                {
                    Register dbRegister = registerBLL.GetWithUser(dto.guid_value, dto.face_uid);
                    if (dbRegister == null)
                    {
                        //验证用户是否存在
                        var userWithUserHouse = userBLL.GetUserWithUserHouse(dto.guid_value);
                        if (userWithUserHouse != null)
                        {
                            //若用户存在，下载图片
                            if (string.IsNullOrEmpty(dto.photo_path))
                            {
                                LogHelper.Warn($"用户【{ dto.guid_value }】云人脸注册Id【{ dto.id }】无图片信息！");
                            }
                            else
                            {

                                ActionResult actionResult = PullToMao(userWithUserHouse, dto);

                                if (actionResult.IsSuccess)
                                {
                                    Register register = new Register()
                                    {
                                        change_time = dto.create_time,
                                        check_state = ClientAndServerConverter.NullableShortToCheckType(dto.register_state),
                                        create_time = dto.create_time,
                                        face_id = dto.face_uid,
                                        is_del = ClientAndServerConverter.BoolToIsDelType(dto.is_del),
                                        photo_path = dto.photo_path,
                                        register_type = ClientAndServerConverter.NullableShortToRegisterType(dto.register_type),
                                        //tc_path
                                        user_uid = dto.guid_value
                                    };
                                    registerBLL.Add(register);
                                }
                                else
                                {

                                }
                            }
                        }
                        else
                        {
                            LogHelper.Warn($"用户【{ dto.guid_value }】未成功同步至项目，请核实！");
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
        ActionResult PullToMao(User userWithHouse, RegisterOutputDto dto)
        {
            ActionResult result = new ActionResult();
            Register _register = null;
            if (!string.IsNullOrEmpty(dto.face_uid))
                _register = registerBLL.FirstOrDefault(it => it.face_id == dto.face_uid);

            if (_register == null)
            {
                // 本地数据库不存在此数据 && (审核未通过 || 已删除) => 跳过处理
                if (ClientAndServerConverter.NullableShortToCheckType(dto.register_state) == CheckType.审核不通过
                    || dto.is_del == true)
                {
                    result.IsSuccess = false;
                    result.Add($"用户【{ dto.guid_value }】审核不通过或已删除，无需要处理");
                    return result;
                }

                if (string.IsNullOrEmpty(dto.photo_path))
                {
                    result.IsSuccess = false;
                    result.Add($"照片不存在，w_register.id: { dto.id }");
                    return result;
                }
                string imageBase64 = string.Empty;

                try
                {
                    using (WeChatServiceClient client = new WeChatServiceClient())
                    {
                        imageBase64 = client.GetRegisterPhoto(dto.project_code, dto.photo_path);
                    }
                }
                catch (Exception ex)
                {
                    result.IsSuccess = false;
                    result.Add($"下载云端图片【{ dto.photo_path }】【w_register.id:{ dto.id }】时发生异常", ex);
                    return result;
                }

                string faceId = string.IsNullOrEmpty(dto.face_uid)
                            ? Key_.SequentialGuid()
                            : dto.face_uid;

                var checkResult = maoBLL.CheckMao();
                var lstGoodMao = checkResult.Obj.Where(it => it.Value.Item1 == true).Select(it => it.Value);
                if (lstGoodMao.Any())
                {
                    var lstCheckedMao = checkResult.Obj;

                    foreach (var checkedMao in lstCheckedMao)
                    {
                        var maoItem = checkedMao.Value.Item2;
                        var faceItem = checkedMao.Value.Item3;

                        RegisterType registerType = ClientAndServerConverter.NullableShortToRegisterType(dto.register_type);
                        var arChecking = faceItem.Checking(faceId, registerType, imageBase64);
                        if (!arChecking.IsSuccess)
                        {
                            result.Add(arChecking);
                            return result;
                        }
                        if (!string.IsNullOrWhiteSpace(dto.face_uid))
                        {
                            var arCompare = faceItem.MatchCompare(faceId, dto.face_uid);
                            if (!arCompare.IsSuccess)
                            {
                                result.Add(arCompare);
                                return result;
                            }
                            else if (!arCompare.Obj)
                            {
                                //非用一个人
                                result.Add(arCompare);
                                result.IsSuccess = false;
                                return result;
                            }
                        }

                        var registerResult = faceItem.Register(new Face.Common_.RegisterInput()
                        {
                            ActiveTime = dto.end_time ?? dto.create_time,
                            Birthday = userWithHouse.birthday,
                            CertificateType = Face.Common_.EyeCool.CertificateType.唯一标识,
                            MaoNO = maoItem.mao_no,
                            UserUid = userWithHouse.user_uid,
                            FaceId = faceId,
                            Name = userWithHouse.name,
                            PeopleId = userWithHouse.people_id,
                            Phone = userWithHouse.mobile,
                            ProjectCode = SystemParameter._project.project_code,
                            RegisterType = ClientAndServerConverter.NullableShortToRegisterType(dto.register_type),
                            RoomNo = "",//wait
                            Sex = userWithHouse.sex,
                            UserType = userBLL.GetUserType(userWithHouse.user_uid)
                        });

                        if (registerResult.IsSuccess)
                        {
                            result.Add($" 【{ maoItem.mao_name }】上照片【w_register.id：{ dto.id }】添加成功");
                            bool isAudited = registerResult.Obj.IsAudited;
                        }
                        else
                        {
                            result.Add($" 【{ maoItem.mao_name }】上照片【w_register.id：{ dto.id }】添加失败：{ result.ToAlertString() }");
                        }
                    }
                }
                var lstBadMao = checkResult.Obj.Where(it => it.Value.Item1 == false).Select(it => it.Value);
                if (lstBadMao.Any())
                {
                    foreach (var badMao in lstBadMao)
                    {
                        //wait
                    }
                }

                // 回写w_register
                dto.face_uid = faceId;
                dto.register_state = ClientAndServerConverter.CheckTypeToNullableShort(CheckType.审核通过);//wait
                dto.check_time = DateTime.Now;
                dto.check_note = result.ToAlertString();

                if (dto.check_note.IndexOf("此照片已绑定") > -1) dto.check_note = "此照片已绑定其他用户";

                string request = Json_.GetString(dto);
                using (WeChatServiceClient client = new WeChatServiceClient())
                {
                    try
                    {
                        var putRegisterResponse = client.PutRegister(SystemParameter._project.project_code, request);
                        client.Close();

                        JsonResponse<string> responseResult = Json_.GetObject<JsonResponse<string>>(putRegisterResponse);
                        if (responseResult.status == 0)
                            LogHelper.Error("照片状态更新到微信端服务器失败：" + responseResult.message
                                 + "，w_register.id：" + dto.id);
                    }
                    catch (Exception ex)
                    {
                        client.Abort();
                        LogHelper.Error("照片状态更新到微信端服务器失败：" + "，w_register.id：" + dto.id, ex);
                    }
                }
            }
            else
            {
                //if (_register.is_del == _w_register.is_del) continue;
                //if (_register.change_time >= _w_register.lastupdate_time) continue;
                var checkResult = maoBLL.CheckMao();
                var lstCheckedMao = checkResult.Obj;
                foreach (var checkedMao in lstCheckedMao)
                {
                    var mao = checkedMao.Value.Item2;
                    var face = checkedMao.Value.Item3;
                    if (dto.is_del)
                    {
                        ActionResult delResult = face.FaceDel(dto.people_id, dto.face_uid);

                        if (delResult.IsSuccess)
                            LogHelper.Info($"【{ mao.mao_name }】上照片【{ dto.face_uid }】删除成功");
                        else
                            LogHelper.Error($"【{ mao.mao_name }】上照片删除失败：{ result.ToAlertString() }");
                    }
                    else
                    {
                        //照片延期
                        if ((dto.end_time ?? dto.create_time).AddDays(-1) > (dto.end_time ?? dto.create_time))//wait
                        {
                            userWithHouse.change_time = DateTime.Now;
                            var activeResult = face.UpdateActiveTime(userWithHouse.people_id, dto.end_time ?? dto.create_time);


                            if (activeResult.IsSuccess)
                                LogHelper.Info(string.Format("<{0}>上照片延期成功", mao.mao_name));
                            else
                            {
                                LogHelper.Error(string.Format("<{0}>上照片延期失败：{1}", mao.mao_name, result.ToAlertString()));
                            }
                        }
                    }
                }
            }

            return result;
        }


        private bool GetUser(string user_uid)
        {
            string response = string.Empty;
            bool isSuccess;

            using (WeChatServiceClient client = new WeChatServiceClient())
            {
                try
                {
                    response = client.GetUser(SystemParameter._project.project_code, user_uid);
                    client.Close();
                    isSuccess = true;
                }
                catch (Exception userException)
                {
                    client.Abort();
                    isSuccess = false;
                    LogHelper.Error("获取用户数据失败, user_uid:" + user_uid, userException);
                }
            }

            if (!isSuccess) return false;

            JsonResponse<UserDto> jsonResponse = Json_.GetObject<JsonResponse<UserDto>>(response);
            if (jsonResponse.status == 0)
            {
                LogHelper.Error("服务器返回错误：" + jsonResponse.message);
                return false;
            }

            UserDto dto = jsonResponse.data;

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
            return true;
        }
    }
}
