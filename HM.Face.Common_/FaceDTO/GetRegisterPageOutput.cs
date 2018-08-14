using HM.Face.Common_.EyeCool;
using System;
using System.Collections.Generic;
using HM.Enum_.FacePlatform;

namespace HM.Face.Common_
{
    public class GetRegisterPageOutput
    {
        /// <summary>
        /// 所有已经注册的记录条数
        /// </summary>
        public int MaxNumber { set; get; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public CertificateType CertificateType { set; get; }
        /// <summary>
        /// 用户唯一值（包括userID）
        /// </summary>
        public string CardNo { set; get; }
        /// <summary>
        /// 注册方式
        /// </summary>
        public RegisterType RegisterType { set; get; }
        /// <summary>
        /// 注册猫ID
        /// <!--
        /// 猫编号catid-->cNo
        /// -->
        /// </summary>
        public string CatCode { set; get; }
        /// <summary>
        /// 注册房号
        /// </summary>
        public string RoomNo { set; get; }
        /// <summary>
        /// 注册时间(格式: yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public string RegisterTime { set; get; }
        /// <summary>
        /// 有效期(格式: yyyy-MM-dd)
        /// </summary>
        public string ActiveTime { set; get; }
        /// <summary>
        /// 审核状态
        /// <!--
        /// 0待审核、1通过、2不通过
        /// -->
        /// </summary>
        public ReviewState? CheckState { set; get; }
        /// <summary>
        /// 审核时间(格式: yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public DateTime? CheckTime { set; get; }
        /// <summary>
        /// 审核备注
        /// <!--
        /// checkMessage-->comments-->_checkMessage
        /// -->
        /// </summary>
        public string CheckMessage { set; get; }
        /// <summary>
        /// 更新时间(格式: yyyy-MM-dd HH:mm:ss)
        /// <!--
        /// 增、删、改的时间(数据同步用)change_time-->updateTime
        /// -->
        /// </summary>
        public DateTime? UpdateTime { set; get; }
        /// <summary>
        /// 图片属性对象
        /// </summary>
        public List<HMFaceObj> HMFaceObj { get; set; } = new List<HMFaceObj>();
        /// <summary>
        /// 人员ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 人员名称
        /// </summary>
        public string PeopleName { get; set; }
        /// <summary>
        /// 对外公布人员ID
        /// </summary>
        public string PeopleId { set; get; }
        /// <summary>
        /// 性别，1：男，0：女
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 人员手机号码
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string tag { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public enum HMFaceState
    {
        正常使用 = 0,
        删除的数据 = 1,
        待审核或禁用数据 = 2
    }
    /// <summary>
    /// 
    /// </summary>
    public class HMFaceObj
    {
        /// <summary>
        /// 图片注册来源
        /// </summary>
        public RegisterType RegisterType { get; set; }
        /// <summary>
        /// 人脸状态
        /// </summary>
        public HMFaceState FaceState { set; get; }
        /// <summary>
        /// 用户照片访问URL地址
        /// </summary>
        public string ImageUrl { set; get; }
        /// <summary>
        /// 照片Id
        /// </summary>
        public string FaceId { set; get; }
        /// <summary>
        /// 图片文件名(只读)
        /// </summary>
        public string PicFileName
        {
            get { return System.IO.Path.GetFileName(ImageUrl); }
        }
        /// <summary>
        /// 照片注册时间
        /// </summary>
        public DateTime ImageRegisterTime { set; get; }
    }
}