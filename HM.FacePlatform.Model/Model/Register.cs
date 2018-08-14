namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 人脸注册
    /// </summary>
    public partial class Register : BaseModel
    {
        public Register()
        {
            SetDefaultToProperties(this);
            create_time = change_time = DateTime.Now;
        }
        /// <summary>
        /// 小区用户唯一标识
        /// </summary>
        [Required]
        [StringLength(50)]
        public string user_uid { get; set; }
        /// <summary>
        /// 人脸特征ID
        /// </summary>
        [Required]
        [StringLength(50)]
        public string face_id { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        [Required]
        [StringLength(200)]
        public string photo_path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(200)]
        [Obsolete("此属相在项目中未用到")]
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
        /// 小区用户
        /// </summary>
        [ForeignKey("user_uid")]
        public User user { get; set; }
    }
}
