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
        /// 检查图片是否包含人脸
        /// </summary>
        /// <param name="faceId"></param>
        /// <param name="registerType">注册类型</param>
        /// <param name="filePath">文件路径或者下载地址</param>
        /// <param name="tip">备注</param>
        /// <returns></returns>
        public abstract ActionResult<CheckingOutput> Checking(string faceId, RegisterType registerType, string filePath, string tip = "");
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="face_id1"></param>
        /// <param name="face_id2"></param>
        /// <returns></returns>
        public abstract ActionResult MatchCompare(string face_id1, string face_id2);
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="filePath1"></param>
        /// <param name="filePath2"></param>
        /// <returns></returns>
        public abstract ActionResult MatchCompare1(string filePath1, string filePath2);
        /// <summary>
        /// 两张图片内容比较是否为同一个人
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="faceId"></param>
        /// <returns></returns>
        public abstract ActionResult MatchCompare2(string filePath, string faceId);
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
        /// <param name="checkType"></param>
        /// <param name="comments"></param>
        /// <returns></returns>
        public abstract ActionResult Review(string projectCode, string peopleId, CheckType checkType, string comments);

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
        /// <param name="faceIds"></param>
        /// <returns></returns>
        public abstract ActionResult FaceDel(string peopleId, List<string> faceIds);

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
