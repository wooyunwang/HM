using HM.Enum_.FacePlatform;
using HM.Face.Common_.EyeCool;
using System;

namespace HM.Face.Common_
{
    public class RegisterInput
    {
        /// <summary>
        /// 将图片上传给供应商检查接口时，返回的人脸特征值Id
        /// </summary>
        public string FaceId { get; set; }
        /// <summary>
        /// 用户唯一标识【无uuid】
        /// </summary>
        public string PeopleId { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户类型:拥有、居住、物业管理、临时人员
        /// </summary>
        public string UserType { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// CRM唯一标识
        /// </summary>
        public string CRMId { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public CertificateType CertificateType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SexType Sex { get; set; }
        /// <summary>
        /// 人员所属房号
        /// </summary>
        public string RoomNo { get; set; }
        /// <summary>
        /// 出生日期(yyyy-MM-dd)
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 注册渠道
        /// </summary>
        public RegisterType RegisterType { get; set; }
        /// <summary>
        /// 创建人手机号码
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime activeTime { get; set; }
        /// <summary>
        /// 猫编号
        /// </summary>
        public string cNO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Obsolete("此转换存在一定问题")]
        public RCType GetEyeCoolRCType()
        {
            switch (RegisterType)
            {
                case RegisterType.未知:
                    return RCType.手动注册;
                case RegisterType.微信注册:
                    return RCType.微信注册;
                case RegisterType.手动注册:
                    return RCType.手动注册;
                case RegisterType.刷卡注册:
                    return RCType.手动注册;
                case RegisterType.人脸一体机自动注册:
                    return RCType.自动注册;
                case RegisterType.人脸一体机手动注册:
                    return RCType.手动注册;
                default:
                    return RCType.手动注册;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Obsolete("此转换存在一定问题")]
        public int GetEyeCoolSex()
        {
            //性别，1：男，0：女 默认1
            switch (Sex)
            {
                case SexType.未知:
                    return 1;
                case SexType.男:
                    return 1;
                case SexType.女:
                    return 0;
                default:
                    return 1;
            }
        }
        /// <summary>
        /// 若是微信的，需要审核
        /// </summary>
        /// <returns></returns>
        public bool IsNeedAudit(FaceVender faceVender)
        {
            switch (faceVender)
            {
                case FaceVender.EyeCool:
                    return GetEyeCoolRCType() == RCType.微信注册;
                case FaceVender.VanRui:
                default:
                    return false;
            }
        }
    }
}