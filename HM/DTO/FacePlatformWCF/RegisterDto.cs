using HM.Enum_.FacePlatform;
using HM.Utils_;
using System;

namespace HM.DTO.FacePlatform
{
    /// <summary>
    /// 小区用户人脸注册信息数据传输对象
    /// </summary>
    public class RegisterDto
    {
        public int id { get; set; }
        /// <summary>
        /// 小区用户唯一标识
        /// </summary>
        public string guid_value { get; set; }
        /// <summary>
        /// 唯一标识类型
        /// </summary>
        public short guid_type { get; set; }
        /// <summary>
        /// 人脸uid
        /// </summary>
        public string face_uid { get; set; }
        /// <summary>
        /// 注册类型
        /// </summary>
        public short register_type { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime reg_time { get; set; }
        /// <summary>
        /// 有效时间
        /// </summary>
        public DateTime? end_time { get; set; }
        /// <summary>
        /// 注册状态
        /// </summary>
        public short? register_state { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? check_time { get; set; }
        /// <summary>
        /// 审核批注
        /// </summary>
        public string check_note { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public bool is_del { get; set; }
        /// <summary>
        /// people_id一般同guid_value
        /// </summary>
        public string people_id { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string project_code { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? lastupdate_time { get; set; }
    }
}
