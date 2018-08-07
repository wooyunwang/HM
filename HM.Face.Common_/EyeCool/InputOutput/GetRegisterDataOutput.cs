using System.Collections.Generic;

namespace HM.Face.Common_.EyeCool
{
    public class GetRegisterDataOutput : ResponseBase
    {
        /// <summary>
        /// 所有已经注册的记录条数
        /// </summary>
        public int maxnumber { set; get; }
        /// <summary>
        /// 卡类型：1-业主卡、2-身份证、3-唯一标识、4-其他卡号、5-共有卡
        /// </summary>
        public int cid { set; get; }
        /// <summary>
        /// 用户唯一值（包括userID）
        /// </summary>
        public string cardNo { set; get; }
        /// <summary>
        /// 注册方式
        /// <!--
        /// 0自动注册、1微信注册、2手动注册
        /// -->
        /// </summary>
        public int rctype { set; get; }
        /// <summary>
        /// 注册猫ID
        /// <!--
        /// 猫编号catid-->cNo
        /// -->
        /// </summary>
        public string cNo { set; get; }
        /// <summary>
        /// 注册房号
        /// </summary>
        public string fNo { set; get; }
        /// <summary>
        /// 注册时间(格式: yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public string regTime { set; get; }
        /// <summary>
        /// 有效期(格式: yyyy-MM-dd)
        /// </summary>
        public string activeTime { set; get; }
        /// <summary>
        /// 审核状态
        /// <!--
        /// 0待审核、1通过、2不通过
        /// -->
        /// </summary>
        public string state { set; get; }
        /// <summary>
        /// 审核时间(格式: yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public string checkTime { set; get; }
        /// <summary>
        /// 审核备注
        /// <!--
        /// checkMessage-->comments-->_checkMessage
        /// -->
        /// </summary>
        public string checkMessage { set; get; }
        /// <summary>
        /// 更新时间(格式: yyyy-MM-dd HH:mm:ss)
        /// <!--
        /// 增、删、改的时间(数据同步用)change_time-->updateTime
        /// -->
        /// </summary>
        public string updateTime { set; get; }
        /// <summary>
        /// 图片属性对象
        /// </summary>
        public List<FaceObj> face_obj { get; set; } = new List<FaceObj>();
        /// <summary>
        /// 人员ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 人员名称
        /// </summary>
        public string people_name { get; set; }
        /// <summary>
        /// 对外公布人员ID
        /// </summary>
        public string people_id { set; get; }
        /// <summary>
        /// 性别，1：男，0：女
        /// </summary>
        public int sex { get; set; }
        /// <summary>
        /// 人员手机号码
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string tag { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class FaceObj
    {
        /// <summary>
        /// 图片注册来源（0自动注册、1微信注册、2手动注册）
        /// </summary>
        public int face_type { get; set; }
        /// <summary>
        /// 0:正常使用；1:删除的数据2:待审核、禁用数据
        /// </summary>
        public int is_del { set; get; }
        /// <summary>
        /// 用户照片访问URL地址
        /// </summary>
        public string imageUrl { set; get; }
        /// <summary>
        /// 照片Id
        /// </summary>
        public string face_id { set; get; }
        /// <summary>
        /// 图片文件名(只读)
        /// </summary>
        public string picFileName
        {
            get { return System.IO.Path.GetFileName(imageUrl); }
        }
        /// <summary>
        /// 照片注册时间(格式: yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public string imgRegTime { set; get; }
    }
}