namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;

    /// <summary>
    /// 人脸注册
    /// </summary>
    public partial class RegisterManageDto
    {
        /// <summary>
        /// f_Register的id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 小区用户唯一标识
        /// </summary>
        public string user_uid { get; set; }
        /// <summary>
        /// 人脸特征ID
        /// </summary>
        public string face_id { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string photo_path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tc_path { get; set; }
        /// <summary>
        /// 注册类型
        /// </summary>
        public RegisterType register_type { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// 变更时间
        /// </summary>
        public DateTime change_time { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public CheckType check_state { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public IsDelType is_del { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string user_name { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime end_time { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 住址(房屋名称)
        /// </summary>
        public string house_name { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType user_type { get; set; }
        /// <summary>
        /// 小区用户与房屋的关系
        /// </summary>
        public string relation { get; set; }
    }
}
