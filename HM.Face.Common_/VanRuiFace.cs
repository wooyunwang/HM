using HM.DTO;
using HM.Enum_.FacePlatform;
using System;
using System.Collections.Generic;
using HM.Face.Common_.EyeCool;
using HM.Common_;

namespace HM.Face.Common_
{
    public class VanRuiFace : Face
    {
        /// <summary>
        /// 标准相似度
        /// </summary>
        int similarity = 80;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public VanRuiFace(string ip, int port)
        {
            //_API = new EyeCoolAPI(ip, port);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootUrl"></param>
        public VanRuiFace(string rootUrl)
        {
            //_API = new EyeCoolAPI(new Uri(rootUrl));
        }
        /// <summary>
        /// 供应商
        /// </summary>
        public override FaceVender Vendor
        {
            get
            {
                return FaceVender.VanRui;
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
            throw new NotImplementedException("未对接");
        }

        /// <summary>
        /// 获取人脸版本信息
        /// </summary>
        /// <returns></returns>
        public override FaceVersion GetFaceVersion()
        {
            throw new NotImplementedException("未对接");
        }
        /// <summary>
        /// 检查图片是否包含人脸
        /// </summary>
        /// <param name="faceId"></param>
        /// <param name="registerType">注册类型</param>
        /// <param name="imageBase64">imageBase64</param>
        /// <param name="tip">备注</param>
        /// <returns></returns>
        public override ActionResult<CheckingOutput> Checking(string faceId, RegisterType registerType, string imageBase64, string tip = "")
        {
            throw new NotImplementedException("未对接");
        }
        /// <summary>
        /// 检查图片是否包含人脸
        /// </summary>
        /// <param name="faceId"></param>
        /// <param name="registerType">注册类型</param>
        /// <param name="filePath">文件路径或者下载地址</param>
        /// <param name="tip">备注</param>
        /// <returns></returns>
        public override ActionResult<CheckingOutput> Checking2(string faceId, RegisterType registerType, string imageBase64, string tip = "")
        {
            throw new NotImplementedException("未对接");
        }
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="face_id1"></param>
        /// <param name="face_id2"></param>
        /// <returns></returns>
        public override ActionResult<bool> MatchCompare(string face_id1, string face_id2)
        {
            throw new NotImplementedException("未对接");
        }
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="filePath1"></param>
        /// <param name="filePath2"></param>
        /// <returns></returns>
        public override ActionResult<bool> MatchCompare1(string filePath1, string filePath2)
        {
            throw new NotImplementedException("未对接");
        }
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="faceId"></param>
        /// <returns></returns>
        public override ActionResult<bool> MatchCompare2(string imageBase64, RegisterType registerType, string faceId)
        {
            throw new NotImplementedException("未对接");
        }
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="registerType"></param>
        /// <param name="faceId"></param>
        /// <returns></returns>
        public override ActionResult<bool> MatchCompare3(string filePath, RegisterType registerType, string faceId)
        {
            throw new NotImplementedException("未对接");
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override ActionResult<RegisterOutput> Register(RegisterInput input)
        {
            throw new NotImplementedException("未对接");
        }

        /// <summary>
        /// 获取已注册的数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public override ActionResult<List<GetRegisterPageOutput>> GetRegisterPage(GetRegisterPageInput input)
        {
            throw new NotImplementedException("未对接");
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="projectCode"></param>
        /// <param name="peopleId"></param>
        /// <param name="faceId"></param>
        /// <param name="state"></param>
        /// <param name="comments"></param>
        /// <returns></returns>
        public override ActionResult Review(string projectCode, string peopleId, string faceId, CheckType state, string comments)
        {
            throw new NotImplementedException("未对接");
        }

        /// <summary>
        /// 获取人脸通行明细
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override ActionResult<List<GetFacePassDataOutput>> GetFacePassData(GetFacePassDataInput input)
        {
            throw new NotImplementedException("未对接");
        }
        /// <summary>
        /// 人脸删除操作
        /// </summary>
        /// <param name="peopleId"></param>
        /// <param name="faceId"></param>
        /// <returns></returns>
        public override ActionResult FaceDel(string peopleId, string faceId)
        {
            throw new NotImplementedException("未对接");
        }
        /// <summary>
        /// 人员删除操作
        /// </summary>
        /// <param name="peopleId"></param>
        /// <returns></returns>
        public override ActionResult UserDel(string peopleId)
        {
            throw new NotImplementedException("未对接");
        }
        /// <summary>
        /// 设置人脸有效期
        /// </summary>
        /// <param name="people_id"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public override ActionResult UpdateActiveTime(string peopleId, DateTime endTime)
        {
            throw new NotImplementedException("未对接");
        }
        /// <summary>
        /// 人证合一认证接口
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public override ActionResult PersonCardSnapshot(string filePath)
        {
            throw new NotImplementedException("未对接");
        }
    }
}