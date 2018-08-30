using AutoMapper;
using Flurl.Http;
using HM.Common_;
using HM.DTO;
using HM.Enum_.FacePlatform;
using HM.Face.Common_.EyeCool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HM.Face.Common_
{

    public class EyeCoolFace : Face
    {
        /// <summary>
        /// 标准相似度
        /// </summary>
        int similarity = 80;
        /// <summary>
        /// 
        /// </summary>
        EyeCoolAPI _API { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public EyeCoolFace(string ip, int port)
        {
            _API = new EyeCoolAPI(ip, port);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootUrl"></param>
        public EyeCoolFace(string rootUrl)
        {
            _API = new EyeCoolAPI(new Uri(rootUrl));
        }
        /// <summary>
        /// 供应商
        /// </summary>
        public override FaceVender Vendor
        {
            get
            {
                return FaceVender.EyeCool;
            }
        }
        /// <summary>
        /// 获取供应商ID
        /// </summary>
        /// <returns></returns>
        public override int GetVendorID()
        {
            return (int)Vendor;
        }
        /// <summary>
        /// 获取供应商名称
        /// </summary>
        /// <returns></returns>
        public override String GetVendorKey()
        {
            return Vendor.ToString();
        }
        public override Uri GetRootUri()
        {
            return _API.ROOT_URL;
        }
        /// <summary>
        /// 获取人脸一体机上时间
        /// </summary>
        /// <param name="timeSpan">超时时间</param>
        /// <returns></returns>
        public override ClockInfo GetClockInfo(TimeSpan? timeSpan = null)
        {
            try
            {
                return _API.GetClockInfo(timeSpan);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return null;
            }
        }
        /// <summary>
        /// 获取人脸版本信息
        /// </summary>
        /// <param name="timeSpan">超时时间</param>
        /// <returns></returns>
        public override FaceVersion GetFaceVersion(TimeSpan? timeSpan = null)
        {
            try
            {
                return _API.GetFaceVersion(timeSpan);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return null;
            }
        }
        /// <summary>
        /// 检查图片是否包含人脸
        /// </summary>
        /// <param name="faceId"></param>
        /// <param name="registerType">注册类型</param>
        /// <param name="imageBase64">imageBase64</param>
        /// <param name="tip">备注</param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult<CheckingOutput> Checking(string faceId, RegisterType registerType, string imageBase64, string tip = "")
        {
            ActionResult<CheckingOutput> result = new ActionResult<CheckingOutput>();
            CheckingOutput output = _API.Checking(new CheckingInput()
            {
                face_id = faceId,
                file = imageBase64,
                rctype = Mapper.Map<RCType>(registerType),
                tip = tip
            });
            result.Obj = output;
            return result;
        }
        /// <summary>
        /// 检查图片是否包含人脸
        /// </summary>
        /// <param name="faceId"></param>
        /// <param name="registerType">注册类型</param>
        /// <param name="filePath">文件路径或者下载地址</param>
        /// <param name="tip">备注</param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult<CheckingOutput> Checking2(string faceId, RegisterType registerType, string filePath, string tip = "")
        {
            ActionResult<CheckingOutput> result = new ActionResult<CheckingOutput>();
            if (string.IsNullOrWhiteSpace(filePath))
            {
                result.IsSuccess = false;
                result.Add("图片路径不能为空！");
                return result;
            }
            else
            {
                string imageBase64 = string.Empty;
                if (filePath.StartsWith("http"))
                {
                    try
                    {
                        Uri uri = new Uri(filePath);
                        Stream stream = uri.AbsoluteUri.GetStreamAsync().Result;
                        StreamReader reader = new StreamReader(stream);
                        imageBase64 = reader.ReadToEnd();
                    }
                    catch (Exception ex)
                    {
                        result.IsSuccess = false;
                        result.Add($"图片下载失败，Url【{filePath}】！");
                        result.Add(ex);
                        return result;
                    }
                }
                else if (!File.Exists(filePath))
                {
                    result.IsSuccess = false;
                    result.Add($"找不到对应的文件，路径【{filePath}】！");
                    return result;
                }
                else
                {
                    imageBase64 = Utils_.Image_.ImageToBase64(filePath);
                }

                CheckingOutput output = _API.Checking(new CheckingInput()
                {
                    face_id = faceId,
                    file = imageBase64,
                    rctype = Mapper.Map<RCType>(registerType),
                    tip = tip
                });
                result.Obj = output;
                return result;
            }
        }
        /// <summary>
        /// 检查路径参数是否正确
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <param name="paramName">路径的参数名称</param>
        /// <returns></returns>
        ActionResult CheckPath(string filePath, string paramName = "")
        {
            ActionResult result = new ActionResult();
            //常用图片格式为【"png", "bmp", "jpg", "gif" , "jpeg" 】，但眼神只支持jpg
            List<string> lstExtension = new List<string>() { "jpg" };
            if (string.IsNullOrWhiteSpace(filePath))
            {
                result.IsSuccess = false;
                result.Add($"参数【{paramName}】不能为空！");
            }
            else if (!File.Exists(filePath))
            {
                result.IsSuccess = false;
                result.Add($"文件【{filePath}】不存在！");
            }
            else if (!lstExtension.Any(it => it?.ToLower() == new FileInfo(filePath).Extension?.ToLower()))
            {
                result.IsSuccess = false;
                result.Add($"文件【{filePath}】非指定的图片格式【{string.Join(",", lstExtension)}】！");
            }
            return result;
        }
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="face_id1"></param>
        /// <param name="face_id2"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult<bool> MatchCompare(string face_id1, string face_id2)
        {
            ActionResult<bool> result = new ActionResult<bool>();
            if (string.IsNullOrWhiteSpace(face_id1))
            {
                result.IsSuccess = false;
                result.Add("参数face_id1不能为空！");
            }
            if (string.IsNullOrWhiteSpace(face_id2))
            {
                result.IsSuccess = false;
                result.Add("参数face_id2不能为空！");
            }

            if (result.IsSuccess)
            {
                MatchCompareOutput matchCompareOutput = _API.MatchCompare(new MatchCompareInput()
                {
                    face_id1 = face_id1,
                    face_id2 = face_id2
                });
                if (matchCompareOutput.res_code_enum == ResponseCode._0000 && matchCompareOutput.similarity >= similarity)
                {
                    result.IsSuccess = true;
                    result.Obj = true;//表示同一个人
                    result.Add(matchCompareOutput.res_msg);
                }
                else
                {
                    result.IsSuccess = true;
                    result.Obj = false;//表示非同一个人
                    result.Add($"两张照片的匹配度为【{matchCompareOutput.similarity} < {similarity}】，判定为非同一个人！");
                    result.Add(matchCompareOutput.res_msg);
                }
            }
            return result;
        }
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="filePath1"></param>
        /// <param name="filePath2"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult<bool> MatchCompare1(string filePath1, string filePath2)
        {
            ActionResult<bool> result = new ActionResult<bool>();
            result.Add(CheckPath(filePath1, "filePath1"));
            result.Add(CheckPath(filePath2, "filePath2"));
            if (result.IsSuccess)
            {
                Task<CheckingOutput> task1 = _API.CheckingAsync(new CheckingInput()
                {
                    face_id = Utils_.Key_.SequentialGuid(),
                    file = Utils_.Image_.ImageToBase64(filePath1),
                    rctype = RCType.自动注册,
                    tip = "图片比较"
                });

                Task<CheckingOutput> task2 = _API.CheckingAsync(new CheckingInput()
                {
                    face_id = Utils_.Key_.SequentialGuid(),
                    file = Utils_.Image_.ImageToBase64(filePath1),
                    rctype = RCType.自动注册,
                    tip = "图片比较"
                });

                Task.WaitAll(task1, task2);

                CheckingOutput output1 = task1.Result;
                CheckingOutput output2 = task2.Result;

                if (string.IsNullOrEmpty(output1?.face?[0].face_id))
                {
                    result.IsSuccess = false;
                    result.Add($"图片【{filePath1}】不包含人脸信息！");
                }
                if (string.IsNullOrEmpty(output2?.face?[0].face_id))
                {
                    result.IsSuccess = false;
                    result.Add($"图片【{filePath2}】不包含人脸信息！");
                }
                if (result.IsSuccess)
                {
                    result.Add(MatchCompare(output1?.face?[0].face_id, output2?.face?[0].face_id));
                }
            }
            return result;
        }
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="imageBase64"></param>
        /// <param name="faceId"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult<bool> MatchCompare2(string imageBase64, RegisterType registerType, string faceId)
        {
            ActionResult<bool> result = new ActionResult<bool>();
            CheckingOutput output = _API.Checking(new CheckingInput()
            {
                face_id = Utils_.Key_.SequentialGuid(),
                file = imageBase64,
                rctype = EyeCoolAndClientConverter.RegisterType_RCType(registerType),
                tip = "图片比较"
            });

            if (output.res_code_enum == ResponseCode._0000)
            {
                if (string.IsNullOrEmpty(output?.face?[0].face_id))
                {
                    result.IsSuccess = false;
                    result.Add($"图片不包含人脸信息！");
                }
            }
            else
            {
                result.IsSuccess = false;
                result.Add(output.res_msg);
            }

            if (result.IsSuccess)
            {
                result.Add(MatchCompare(output?.face?[0].face_id, faceId));
            }
            return result;
        }
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="registerType"></param>
        /// <param name="faceId"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult<bool> MatchCompare3(string filePath, RegisterType registerType, string faceId)
        {
            ActionResult<bool> result = new ActionResult<bool>();
            result.Add(CheckPath(filePath, "filePath"));
            if (result.IsSuccess)
            {
                var file = Utils_.Image_.ImageToBase64(filePath);
                result.Add(MatchCompare2(file, registerType, faceId));
            }
            return result;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult<RegisterOutput> Register(RegisterInput input)
        {
            ActionResult<RegisterOutput> result = new ActionResult<RegisterOutput>();
            PeopleCreateOutput peopleCreateOutput = _API.PeopleCreate(new PeopleCreateInput()
            {
                activeTime = input.ActiveTime,
                birthday = input.Birthday,
                cardNo = input.UserUid,
                cid = input.CertificateType,
                cNO = input.MaoNO,
                crowd_name = input.ProjectCode,
                fNo = input.RoomNo,
                people_id = input.PeopleId,
                people_name = input.Name,
                phone = input.Phone,
                rctype = EyeCoolAndClientConverter.RegisterType_RCType(input.RegisterType),
                sex = EyeCoolAndClientConverter.SexType_Sex(input.Sex),
                tip = EyeCoolAndClientConverter.UserType_Tip(input.UserType)
            });
            if (peopleCreateOutput.res_code_enum == ResponseCode._0000)
            {
                PeopleAddOutput peopleAddOutput = _API.PeopleAdd(new PeopleAddInput()
                {
                    face_id = input.FaceId,
                    is_audit = input.NeedAudit(Vendor),
                    people_id = input.PeopleId
                });
                if (peopleAddOutput.res_code_enum == ResponseCode._0000)
                {
                    result.IsSuccess = true;
                    result.Obj = new RegisterOutput()
                    {
                        IsAudited = peopleAddOutput.is_audited == 1,
                        IsAuditedOK = peopleAddOutput.face_added > 0
                    };
                }
                else
                {
                    result.Add(peopleAddOutput.ToActionResult());
                }
            }
            else
            {
                result.Add(peopleCreateOutput.ToActionResult());
            }
            return result;
        }
        /// <summary>
        /// 获取已注册的数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult<List<GetRegisterPageOutput>> GetRegisterPage(GetRegisterPageInput input)
        {
            ActionResult<List<GetRegisterPageOutput>> result = new ActionResult<List<GetRegisterPageOutput>>();
            var output = _API.GetRegisterData(new GetRegisterDataInput()
            {
                crowd_name = input.ProjectCode,
                dataType = input.GetEyeCookDataType(),
                endtime = input.Endtime,
                pageNumber = input.PageNumber,
                pageSize = input.PageSize,
                //rctype
                updateTime = input.UpdateTime
            });
            result.IsSuccess = true;
            result.Obj = Mapper.Map<List<GetRegisterPageOutput>>(output);
            return result;
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="projectCode"></param>
        /// <param name="peopleId"></param>
        /// <param name="state"></param>
        /// <param name="comments"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult Review(string projectCode, string peopleId, string faceId, CheckType state, string comments)
        {
            ActionResult result = new ActionResult();
            ReviewPeopleOutput output = _API.ReviewPeople(new ReviewPeopleInput
            {
                comments = comments,
                crowd_name = projectCode,
                people_id = peopleId,
                face_id = faceId,
                state = EyeCoolAndClientConverter.CheckType_ReviewState(state)
            });

            if (output.res_code_enum == ResponseCode._0000)
            {
                //未返回审核结果
                return output.ToActionResult();
            }
            else
            {
                return output.ToActionResult();
            }
        }
        /// <summary>
        /// 获取人脸通行明细
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult<List<GetFacePassDataOutput>> GetFacePassData(GetFacePassDataInput input)
        {
            List<CurrentDetailOutput> output = _API.CurrentDetail(new CurrentDetailInput()
            {
                crowd_name = input.ProjectCode,
                endtime = input.EndTime,
                pageNumber = input.PageNumber,
                pageSize = input.PageSize,
                updateTime = input.UpdateTime
            });

            return new ActionResult<List<GetFacePassDataOutput>>()
            {
                IsSuccess = true,
                Obj = Mapper.Map<List<GetFacePassDataOutput>>(output)
            };
        }

        /// <summary>
        /// 人脸删除操作
        /// </summary>
        /// <param name="peopleId"></param>
        /// <param name="faceId"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult FaceDel(string peopleId, string faceId)
        {
            ActionResult result = new ActionResult();

            if (String.IsNullOrWhiteSpace(peopleId))
            {
                result.IsSuccess = false;
                result.Add("参数peopleId不能为空！");
            }
            if (String.IsNullOrWhiteSpace(faceId))
            {
                result.IsSuccess = false;
                result.Add("参数faceIds不能为空！");
            }
            if (result.IsSuccess)
            {
                PeopleRemoveInput input = new PeopleRemoveInput()
                {
                    people_id = peopleId,
                    face_id = faceId
                };
                PeopleRemoveOutput output = _API.PeopleRemove(input);
                if (output.res_code_enum != ResponseCode._0000)
                {
                    //未查询到对应的人员数据
                    //未查询到对应的人脸
                    if ((output.res_msg ?? "").Contains("未查询到"))
                    {
                        output.res_code = ResponseCode._0000.ToString().TrimStart('_');
                    }
                }
                result.Add(output.ToActionResult());
            }
            return result;
        }
        /// <summary>
        /// 人员删除操作
        /// </summary>
        /// <param name="peopleId"></param>
        /// <returns></returns>
        public override ActionResult UserDel(string peopleId)
        {
            ActionResult result = new ActionResult();

            if (String.IsNullOrEmpty(peopleId))
            {
                result.IsSuccess = false;
                result.Add("参数peopleId不能为空！");
            }
            if (result.IsSuccess)
            {
                var output = _API.PeopleDelete(new PeopleDeleteInput()
                {
                    people_id = peopleId
                });
                if (output.res_code_enum != ResponseCode._0000)
                {
                    //未查询到对应的用户模板数据
                    //未查询到对应的用户数据
                    if ((output.res_msg ?? "").Contains("未查询到"))
                    {
                        output.res_code = ResponseCode._0000.ToString().TrimStart('_');
                    }
                }
                result.Add(output.ToActionResult());
            }
            return result;
        }

        /// <summary>
        /// 设置人脸有效期
        /// </summary>
        /// <param name="peopleId"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult UpdateActiveTime(string peopleId, DateTime endTime)
        {
            ActionResult result = new ActionResult();

            if (string.IsNullOrEmpty(peopleId))
            {
                result.IsSuccess = false;
                result.Add("参数peopleId不能为空");
            }
            if (result.IsSuccess)
            {
                PeopleUpdateOutput output = _API.PeopleUpdate(new PeopleUpdateInput()
                {
                    people_id = peopleId,
                    activeTime = endTime
                });
                result.Add(output.ToActionResult());
            }
            return result;
        }
        /// <summary>
        /// 人证合一认证接口
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult PersonCardSnapshot(string filePath)
        {
            ActionResult result = new ActionResult();
            result.Add(CheckPath(filePath, "filePath"));
            if (result.IsSuccess)
            {
                PersonCardSnapshotOutput output = _API.PersonCardSnapshot(new PersonCardSnapshotInput(filePath));
                if (output.success)
                {
                    int? count = output?.snapShotList.Where(it => (it.matchScore ?? 0) > similarity).Count();
                    if (count > 0)
                    {
                        result.IsSuccess = true;
                        result.Add($"近几分钟内匹配的通行人脸数为{count}");
                    }
                    else
                    {
                        result.Add($"近几分钟内匹配的通行人脸数为{count}");
                    }
                }
                else
                {
                    result.Add($"接口返回success字段为{output.success}！");
                }
            }
            return result;
        }
    }
}
