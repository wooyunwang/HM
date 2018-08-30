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
        public UserType UserType { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string UserUid { get; set; }
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
        public DateTime ActiveTime { get; set; }
        /// <summary>
        /// 是否需要审核，若有设定，则不根据RegisterType进行判断
        /// </summary>
        public bool? IsNeedAudit { get; set; }
        /// <summary>
        /// 猫编号
        /// </summary>
        public string MaoNO { get; set; }
        /// <summary>
        /// 若未指定，若是微信的，则需要审核
        /// </summary>
        /// <returns></returns>
        public bool NeedAudit(FaceVender faceVender)
        {
            if (IsNeedAudit.HasValue) return IsNeedAudit.Value;
            switch (faceVender)
            {
                case FaceVender.EyeCool:
                    return EyeCoolAndClientConverter.RegisterType_RCType(this.RegisterType) == RCType.微信注册;
                case FaceVender.VanRui:
                default:
                    return false;
            }
        }
    }
}