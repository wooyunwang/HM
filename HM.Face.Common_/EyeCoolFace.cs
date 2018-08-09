using System;
using System.Collections.Generic;
using System.IO;
using HM.Common_.DTO;
using HM.Face.Common_.EyeCool;
using Newtonsoft.Json;
using Flurl;
using Flurl.Http;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

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
            DTOMapConfig.EyeCoolToFace();
            _API = new EyeCoolAPI(ip, port);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootUrl"></param>
        public EyeCoolFace(string rootUrl)
        {
            DTOMapConfig.EyeCoolToFace();
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
        /// <summary>
        /// 检查图片是否包含人脸
        /// </summary>
        /// <param name="faceId"></param>
        /// <param name="registerType">注册类型</param>
        /// <param name="filePath">文件路径或者下载地址</param>
        /// <param name="tip">备注</param>
        /// <returns></returns>
        [FaceActionResult]
        public override ActionResult Checking(string faceId, RegisterType registerType, string filePath, string tip = "")
        {
            ActionResult result = new ActionResult();
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
                    imageBase64 = Utils_.Image_.ImageToBase64(File.ReadAllText(filePath));
                }

                CheckingOutput output = _API.Checking(new CheckingInput()
                {
                    face_id = faceId,
                    file = imageBase64,
                    rctype = Mapper.Map<RCType>(registerType),
                    tip = tip
                });
                return output.ToActionResult();
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
        [FaceActionResult]
        public override ActionResult MatchCompare(string face_id1, string face_id2)
        {
            ActionResult result = new ActionResult();
            if (!string.IsNullOrWhiteSpace(face_id1))
            {
                result.IsSuccess = false;
                result.Add("参数face_id1不能为空！");
            }
            if (!string.IsNullOrWhiteSpace(face_id2))
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
                    result.Add(matchCompareOutput.res_msg);
                }
                else
                {
                    result.IsSuccess = false;
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
        [FaceActionResult]
        public override ActionResult MatchCompare1(string filePath1, string filePath2)
        {
            ActionResult result = new ActionResult();
            result.Add(CheckPath(filePath1, "filePath1"));
            result.Add(CheckPath(filePath2, "filePath2"));
            if (result.IsSuccess)
            {
                Task<CheckingOutput> task1 = _API.CheckingAsync(new CheckingInput()
                {
                    face_id = RandomGenerator.SequentialGuid(),
                    file = Utils_.Image_.ImageToBase64(File.ReadAllText(filePath1)),
                    rctype = RCType.自动注册,
                    tip = "图片比较"
                });

                Task<CheckingOutput> task2 = _API.CheckingAsync(new CheckingInput()
                {
                    face_id = Common_.RandomGenerator.SequentialGuid(),
                    file = Utils_.Image_.ImageToBase64(File.ReadAllText(filePath1)),
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
        /// <param name="filePath"></param>
        /// <param name="faceId"></param>
        /// <returns></returns>
        [FaceActionResult]
        public override ActionResult MatchCompare2(string filePath, string faceId)
        {
            ActionResult result = new ActionResult();
            result.Add(CheckPath(filePath, "filePath"));
            if (result.IsSuccess)
            {
                CheckingOutput output = _API.Checking(new CheckingInput()
                {
                    face_id = RandomGenerator.SequentialGuid(),
                    file = Utils_.Image_.ImageToBase64(File.ReadAllText(filePath)),
                    rctype = RCType.自动注册,
                    tip = "图片比较"
                });

                if (string.IsNullOrEmpty(output?.face?[0].face_id))
                {
                    result.IsSuccess = false;
                    result.Add($"图片【{filePath}】不包含人脸信息！！");
                }

                if (result.IsSuccess)
                {
                    result.Add(MatchCompare(output?.face?[0].face_id, faceId));
                }
            }
            return result;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [FaceActionResult]
        public override ActionResult<RegisterOutput> Register(RegisterInput input)
        {
            ActionResult<RegisterOutput> result = new ActionResult<RegisterOutput>();
            PeopleCreateOutput peopleCreateOutput = _API.PeopleCreate(new PeopleCreateInput()
            {
                activeTime = input.activeTime,
                birthday = input.Birthday,
                cardNo = input.CRMId,
                cid = input.CertificateType,
                cNO = input.cNO,
                crowd_name = input.ProjectCode,
                fNo = input.RoomNo,
                people_id = input.PeopleId,
                people_name = input.Name,
                phone = input.Phone,
                rctype = input.GetEyeCoolRCType(),
                sex = input.GetEyeCoolSex(),
                tip = input.UserType
            });
            if (peopleCreateOutput.res_code_enum == ResponseCode._0000)
            {
                PeopleAddOutput peopleAddOutput = _API.PeopleAdd(new PeopleAddInput()
                {
                    face_id = input.FaceId,
                    is_audit = input.IsNeedAudit(Vendor),
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
        [FaceActionResult]
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
            result.Obj = Mapper.Map<List<GetRegisterPageOutput>>(output) ;
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
        [FaceActionResult]
        public override ActionResult Review(string projectCode, string peopleId, string state, string comments)
        {
            ActionResult result = new ActionResult();
            ReviewPeopleOutput output = _API.ReviewPeople(new ReviewPeopleInput
            {
                comments = comments,
                crowd_name = projectCode,
                people_id = peopleId,
                //state = state
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
        [FaceActionResult]
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
        /// <param name="faceIds"></param>
        /// <returns></returns>
        [FaceActionResult]
        public override ActionResult FaceDel(string peopleId, List<string> faceIds)
        {
            ActionResult result = new ActionResult();

            if (String.IsNullOrEmpty(peopleId))
            {
                result.IsSuccess = false;
                result.Add("参数peopleId不能为空！");
            }
            if (faceIds == null || !faceIds.Any())
            {
                result.IsSuccess = false;
                result.Add("参数faceIds不能为空！");
            }
            if (result.IsSuccess)
            {
                PeopleRemoveInput input = new PeopleRemoveInput()
                {
                    people_id = peopleId,
                    faceIds = faceIds
                };
                PeopleRemoveOutput ouput = _API.PeopleRemove(input);
                result.Add(ouput.ToActionResult());
            }
            return result;
        }

        /// <summary>
        /// 设置人脸有效期
        /// </summary>
        /// <param name="peopleId"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [FaceActionResult]
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
        [FaceActionResult]
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
