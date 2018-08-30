using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HM.Enum_.FacePlatform;
using HM.Face.Common_.EyeCool;
using HM.Common_;

namespace HM.Face.Common_
{
    public abstract class Face
    {
        public Face()
        { }
        /// <summary>
        /// 供应商
        /// </summary>
        public abstract FaceVender Vendor { get; }
        /// <summary>
        /// 获取供应商ID
        /// </summary>
        /// <returns></returns>
        public abstract int GetVendorID();
        /// <summary>
        /// 获取供应商Key
        /// </summary>
        /// <returns></returns>
        public abstract string GetVendorKey();

        protected System.Net.IPEndPoint _IPEndPoint;
        /// <summary>
        /// Telnet，可用于批量处理前做网络检测
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool VisualTelnet(string ip, int port)
        {
            return Utils_.NetWork_.VisualTelnet(ip, port);
        }
        /// <summary>
        /// 获取根链接
        /// </summary>
        /// <returns></returns>
        public abstract Uri GetRootUri();
        /// <summary>
        /// 获取人脸一体机上时间
        /// </summary>
        /// <returns></returns>
        public abstract ClockInfo GetClockInfo(TimeSpan? ts = null);
        /// <summary>
        /// 获取人脸版本信息
        /// </summary>
        /// <returns></returns>
        public abstract FaceVersion GetFaceVersion(TimeSpan? ts = null);
        /// <summary>
        /// 检查图片是否包含人脸
        /// </summary>
        /// <param name="faceId"></param>
        /// <param name="registerType">注册类型</param>
        /// <param name="imageBase64">imageBase64</param>
        /// <param name="tip">备注</param>
        /// <returns></returns>
        public abstract ActionResult<CheckingOutput> Checking(string faceId, RegisterType registerType, string imageBase64, string tip = "");
        /// <summary>
        /// 检查图片是否包含人脸
        /// </summary>
        /// <param name="faceId"></param>
        /// <param name="registerType">注册类型</param>
        /// <param name="filePath">文件路径或者下载地址</param>
        /// <param name="tip">备注</param>
        /// <returns></returns>
        public abstract ActionResult<CheckingOutput> Checking2(string faceId, RegisterType registerType, string filePath, string tip = "");
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="face_id1"></param>
        /// <param name="face_id2"></param>
        /// <returns></returns>
        public abstract ActionResult<bool> MatchCompare(string face_id1, string face_id2);
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="filePath1"></param>
        /// <param name="filePath2"></param>
        /// <returns></returns>
        public abstract ActionResult<bool> MatchCompare1(string filePath1, string filePath2);
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="imageBase64"></param>
        /// <param name="registerType"></param>
        /// <param name="faceId"></param>
        /// <returns></returns>
        public abstract ActionResult<bool> MatchCompare2(string imageBase64, RegisterType registerType, string faceId);
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="registerType"></param>
        /// <param name="faceId"></param>
        /// <returns></returns>
        public abstract ActionResult<bool> MatchCompare3(string filePath, RegisterType registerType, string faceId);
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract ActionResult<RegisterOutput> Register(RegisterInput input);

        /// <summary>
        /// 获取已注册的数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public abstract ActionResult<List<GetRegisterPageOutput>> GetRegisterPage(GetRegisterPageInput input);

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="projectCode"></param>
        /// <param name="peopleId"></param>
        /// <param name="faceId"></param>
        /// <param name="checkType"></param>
        /// <param name="comments"></param>
        /// <returns></returns>
        public abstract ActionResult Review(string projectCode, string peopleId, string faceId, CheckType checkType, string comments);

        /// <summary>
        /// 获取人脸通行明细
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract ActionResult<List<GetFacePassDataOutput>> GetFacePassData(GetFacePassDataInput input);

        /// <summary>
        /// 人脸删除操作
        /// </summary>
        /// <param name="peopleId"></param>
        /// <param name="faceId"></param>
        /// <returns></returns>
        public abstract ActionResult FaceDel(string peopleId, string faceId);

        /// <summary>
        /// 人员删除操作
        /// </summary>
        /// <param name="peopleId"></param>
        /// <returns></returns>
        public abstract ActionResult UserDel(string peopleId);

        /// <summary>
        /// 设置人脸有效期
        /// </summary>
        /// <param name="people_id"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public abstract ActionResult UpdateActiveTime(string peopleId, DateTime endTime);
        /// <summary>
        /// 人证合一认证接口
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public abstract ActionResult PersonCardSnapshot(string filePath);
    }
}
