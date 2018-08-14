using HM.FacePlatform.BLL;
using HM.Common_;
using HM.FacePlatform.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using HM.Enum_;
using HM.Enum_.FacePlatform;
using HM.DTO;

namespace HM.FacePlatform
{
    /// <summary>
    /// 此处处理的情况，均是先同步到平台，然后同步到其他猫
    /// 1. 某猫上新增照片
    /// 2. 某猫上某张或某几张照片被删除
    /// </summary>
    [DisallowConcurrentExecution]
    public class PullJob : BaseJob, IJob
    {
        readonly string showName = "[同步]";

        HouseBLL _houseBLL;
        public PullJob()
        {
            _houseBLL = new HouseBLL();
        }

        public void Execute(IJobExecutionContext context)
        {
            //if (maos.Length < 1)
            //{
            //    jobFrom.ShowMessage("还没有配置猫，请在[基础数据]添加配置", MessageType.Warning);
            //    return;
            //}

            ExecutePull();
        }
        public void ExecutePull()
        {
            //foreach (Mao _mao in maos)
            //{
            //    DateTime lastPullDate = _mao.last_pull_date ?? DateTime.MinValue;
            //    if (lastPullDate == DateTime.MinValue) lastPullDate = GetMinDateTime();
            //    else lastPullDate = lastPullDate.AddMinutes(-10);

            //    DateTime latestStartDate = DateTime.Now;

            //    int pageNumber = 1, rowsPerPage = 50;
            //    while (true)
            //    {
            //        List<view_registed_data> registed_datas = new List<view_registed_data>();

            //        try
            //        {
            //            registed_datas = _registerBLL.GetRegistedData(lastPullDate, latestStartDate, projectCode, pageNumber, rowsPerPage, _mao, new List<int>() { 0, 2 });
            //        }
            //        catch (Exception ex)
            //        {
            //            string message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            //            jobFrom.ShowMessage(string.Format(showName + "<{0}>获取更新失败(稍后将自动重试)：{1}"
            //                , _mao.mao_name, message), MessageType.Error);
            //            break;
            //        }

            //        pageNumber++;

            //        if (registed_datas.Count < 1)
            //        {
            //            _mao.last_pull_date = latestStartDate;
            //            _maoBLL.Update(_mao);//同步结束，更新猫最后更新日期
            //            break;
            //        }

            //        foreach (view_registed_data data in registed_datas)
            //        {
            //            UserRegisterDto user_register = _registerBLL.GetUserRegisterByUid(data.guid_value);


            //            if (user_register.id < 1)
            //            {
            //                string _house_code = virtualHouseCode;
            //                if (data.user_type == UserType.工作人员)
            //                {
            //                    _house_code = propertyHouseCode;
            //                }
            //                else
            //                {
            //                    House _house = _houseBLL.Get(new { house_code = data.house_code });
            //                    if (_house == null) _house = _houseBLL.Get(new { house_name = data.house_code });//旧版本使用的house_name,在此做兼容
            //                    if (_house != null) _house_code = _house.house_code;

            //                    if (_house == null)
            //                    {
            //                        string whereConditions = string.Format("where house_name like '%{0}%'", data.house_code);
            //                        House[] houses = _houseBLL.GetList(whereConditions);
            //                        if (houses.Length > 0) _house_code = houses[0].house_code;
            //                    }
            //                }

            //                User _user = new User
            //                {
            //                    user_uid = data.guid_value,
            //                    data_from = data.data_from,
            //                    reg_time = data.reg_time,
            //                    end_time = data.end_time,
            //                    check_state = data.check_state,
            //                    check_time = data.check_time,
            //                    check_note = string.IsNullOrEmpty(data.check_note) ? "" : data.check_note,
            //                    people_id = data.people_id,
            //                    name = data.name,
            //                    sex = data.sex,
            //                    mobile = data.mobile,
            //                };

            //                UserHouse _user_house = new UserHouse
            //                {
            //                    user_uid = _user.user_uid,
            //                    house_code = _house_code,
            //                    user_type = data.user_type,
            //                };

            //                _userBLL.Add(_user, _user_house, 1, "从猫上同步");

            //                if (data.images != null && data.images.Count > 0)
            //                {
            //                    foreach (var img in data.images)
            //                    {
            //                        Register(data, img, _mao);
            //                    }
            //                }

            //                user_register = _registerBLL.GetUserRegisterByUid(_user.user_uid);

            //                jobFrom.ShowMessage(string.Format(showName + "<{0}>检测到有新增的用户<{1}>", _mao.mao_name, _user.name)
            //                    , MessageType.Information);
            //                if (user_register.id > 0)
            //                    jobFrom.ShowMessage(showName + "新增用户成功", MessageType.Success);
            //                else
            //                    jobFrom.ShowMessage(showName + "新增用户失败", MessageType.Error);
            //            }

            //            if (user_register.id > 0)
            //            {
            //                if (user_register.reg_time != data.reg_time
            //                    || user_register.end_time != data.end_time
            //                    || user_register.check_state != data.check_state
            //                    || user_register.check_time != data.check_time
            //                    || user_register.people_id != data.people_id)
            //                {
            //                    user_register.reg_time = data.reg_time;
            //                    user_register.end_time = data.end_time;
            //                    user_register.check_state = data.check_state;
            //                    user_register.check_time = data.check_time;
            //                    user_register.people_id = data.people_id;

            //                    User _user = user_register.Cast<User>();
            //                    _userBLL.UpdateUserOnly(_user);// 更新用户信息
            //                }

            //                if (data.images.Count < 1)
            //                {
            //                    //if (registers.Length < 1) continue;
            //                    continue;// 该用户所有的图片均被手动删除(猫上被删除的照片is_del=1,在下面的情况会处理到)
            //                }
            //                else
            //                {
            //                    foreach (view_registed_image image in data.images)
            //                    {
            //                        HM.FacePlatform.Model.Register[] registers = _registerBLL.GetAllList(user_register.user_uid);

            //                        HM.FacePlatform.Model.Register _platformRegister = new HM.FacePlatform.Model.Register();
            //                        if (registers.Length > 0)
            //                        {
            //                            foreach (HM.FacePlatform.Model.Register _register in registers)
            //                            {
            //                                if (image.face_id == _register.face_id)
            //                                {
            //                                    _platformRegister = _register;
            //                                    break;
            //                                }
            //                            }
            //                        }

            //                        if (_platformRegister.id == 0)
            //                        {
            //                            if (image.is_del == 1) continue;

            //                            Register(user_register, image, _mao);// 猫上有新增的图片
            //                        }
            //                        else
            //                        {
            //                            if (_platformRegister.is_del == image.is_del) continue;

            //                            if (image.is_del == 1)
            //                            {
            //                                _platformRegister.is_del = image.is_del;
            //                                Delete(user_register, _platformRegister, _mao);// 猫上的照片被删除
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }

        //private void Register(Register user_register, view_registed_image image, Mao excluedMao)
        //{
        //    string rootUrl = _registerBLL.GetRootUrl(excluedMao);

        //    string fileName = Path.GetFileName(image.photo_path);
        //    string sourcePath = string.Format(@"{0}/{1}", rootUrl, image.photo_path);
        //    if (_registerBLL.DownloadFaceFile(sourcePath, photoPath))
        //    {
        //        HM.FacePlatform.Model.Register _register = new HM.FacePlatform.Model.Register
        //        {
        //            user_uid = user_register.user_uid,
        //            face_id = image.face_id,
        //            photo_path = fileName,
        //            register_type = image.register_type,
        //            check_state = user_register.check_state// (int)CheckType.ToDo,
        //        };
        //        _register.id = _registerBLL.Add(_register);

        //        if (_register.id > 0)
        //        {
        //            jobFrom.ShowMessage(string.Format(showName + "<{0}>检测到<{1}>的照片有新增", excluedMao.mao_name, user_register.name)
        //                , MessageType.Information);
        //            jobFrom.ShowMessage(showName + "同步到人脸平台成功", MessageType.Success);

        //            fileName = Path.Combine(photoPath, fileName);
        //            foreach (Mao _mao in maos)
        //            {
        //                if (_mao.id == excluedMao.id) continue;

        //                ActionResult result = _registerBLL.Register(user_register
        //                    , fileName, _register.face_id, user_register.end_time, image.register_type, projectCode
        //                    , _mao, isFirstMao, _register.id, 0);

        //                if (result.IsSuccess)
        //                {
        //                    jobFrom.ShowMessage(string.Format("**" + showName + "照片同步到<{0}>成功", _mao.mao_name), MessageType.Success);
        //                }
        //                else
        //                {
        //                    MaoFailedJob job = new MaoFailedJob
        //                    {
        //                        register_or_user_id = _register.id,
        //                        mao_id = _mao.id,
        //                        job_type = JobType.注册,
        //                    };
        //                    _maoFailedJobBLL.AddOrUpdate(job);

        //                    jobFrom.ShowMessage(string.Format("**" + showName + "照片同步到<{0}>失败(稍后将自动重试)：{1}"
        //                        , _mao.mao_name, result.ToAlertString()), MessageType.Error);
        //                }
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 从设备上拉人脸信息的情况
        ///// </summary>
        ///// <param name="registed_data"></param>
        ///// <param name="image"></param>
        ///// <param name="excluedMao"></param>
        //private void Register(view_registed_data registed_data, view_registed_image image, Mao excluedMao)
        //{
        //    string rootUrl = _registerBLL.GetRootUrl(excluedMao);

        //    string fileName = Path.GetFileName(image.photo_path);
        //    string sourcePath = string.Format(@"{0}/{1}", rootUrl, image.photo_path);
        //    if (_registerBLL.DownloadFaceFile(sourcePath, photoPath))
        //    {
        //        HM.FacePlatform.Model.Register _register = new HM.FacePlatform.Model.Register
        //        {
        //            user_uid = registed_data.guid_value,
        //            face_id = image.face_id,
        //            photo_path = fileName,
        //            register_type = image.register_type,
        //            check_state = registed_data.check_state //(int)CheckType.ToDo,
        //        };
        //        _register.id = _registerBLL.Add(_register);
        //        if (_register.id > 0)
        //        {
        //            UserRegisterDto user_register = _registerBLL.GetUserRegisterByUid(_register.user_uid);

        //            jobFrom.ShowMessage(string.Format(showName + "<{0}>检测到<{1}>的照片有新增", excluedMao.mao_name, registed_data.name)
        //                , MessageType.Information);
        //            jobFrom.ShowMessage(showName + "同步到人脸平台成功", MessageType.Success);

        //            fileName = Path.Combine(photoPath, fileName);
        //            foreach (Mao _mao in maos)
        //            {
        //                if (_mao.id == excluedMao.id) continue;

        //                ActionResult result = _registerBLL.Register(user_register
        //                    , fileName, _register.face_id, registed_data.end_time, image.register_type, projectCode
        //                    , _mao, isFirstMao, _register.id, 0);

        //                if (result.IsSuccess)
        //                {
        //                    jobFrom.ShowMessage(string.Format("**" + showName + "照片同步到<{0}>成功", _mao.mao_name), MessageType.Success);
        //                }
        //                else
        //                {
        //                    MaoFailedJob job = new MaoFailedJob
        //                    {
        //                        register_or_user_id = _register.id,
        //                        mao_id = _mao.id,
        //                        job_type = JobType.注册,
        //                    };
        //                    _maoFailedJobBLL.AddOrUpdate(job);

        //                    jobFrom.ShowMessage(string.Format("**" + showName + "照片同步到<{0}>失败(稍后将自动重试)：{1}"
        //                        , _mao.mao_name, result.ToAlertString()), MessageType.Error);
        //                }
        //            }
        //        }
        //    }
        //}

        //private void Delete(UserRegisterDto user_register, HM.FacePlatform.Model.Register _register, Mao excluedMao)
        //{
        //    jobFrom.ShowMessage(string.Format(showName + "<{0}>检测到<{1}>的照片{2}被删除"
        //        , excluedMao.mao_name, user_register.name, _register.photo_path), MessageType.Information);

        //    _registerBLL.Update(_register);//更新数据库
        //    string filePath = Path.Combine(photoPath, _register.photo_path);
        //    if (File.Exists(filePath))
        //    {
        //        try
        //        {
        //            File.Delete(filePath);
        //        }
        //        catch (Exception ex) { }
        //    }

        //    jobFrom.ShowMessage(showName + "从人脸平台删除成功", MessageType.Success);

        //    foreach (Mao _mao in maos)
        //    {
        //        if (_mao.id == excluedMao.id) continue;

        //        ActionResult result = _registerBLL.DeleteRegistedPhoto(user_register.people_id, _register, "", _mao, isFirstMao, 0);
        //        if (result.IsSuccess)
        //        {
        //            jobFrom.ShowMessage(string.Format("**" + showName + "<{0}>上照片删除成功", _mao.mao_name), MessageType.Success);
        //        }
        //        else
        //        {
        //            MaoFailedJob job = new MaoFailedJob
        //            {
        //                register_or_user_id = _register.id,
        //                mao_id = _mao.id,
        //                job_type = JobType.注册,
        //            };
        //            _maoFailedJobBLL.AddOrUpdate(job);

        //            jobFrom.ShowMessage(string.Format("**" + showName + "<{0}>照片上删除失败(稍后将自动重试)：{1}"
        //                , _mao.mao_name, result.ToAlertString()), MessageType.Error);
        //        }
        //    }

        //    HM.FacePlatform.Model.Register[] registers = _registerBLL.GetList(user_register.user_uid);
        //    if (registers.Length < 1)
        //    {
        //        User _user = user_register.Cast<User>();
        //        _user.check_state = CheckType.待审核;
        //        _userBLL.UpdateUserOnly(_user);
        //    }
        //}
    }
}
