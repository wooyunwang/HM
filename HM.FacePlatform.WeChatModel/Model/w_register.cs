namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 人脸注册信息
    /// </summary>
    public partial class w_register
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 小区用户唯一标识
        /// </summary>
        [StringLength(50)]
        public string guid_value { get; set; }
        /// <summary>
        /// 唯一标识类型
        /// </summary>
        public short? guid_type { get; set; }
        /// <summary>
        /// 人脸uid
        /// </summary>
        [StringLength(50)]
        public string face_uid { get; set; }
        /// <summary>
        /// 图片地址（不包含前缀）
        /// </summary>
        [StringLength(100)]
        public string photo_path { get; set; }
        /// <summary>
        /// 注册类型
        /// <!--
        /// 数据库有默认值，所以设计为非空
        /// -->
        /// </summary>
        public short register_type { get; set; }
        /// <summary>
        /// 注册时间
        /// <!--
        /// 数据库有默认值，所以设计为非空
        /// -->
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [StringLength(100)]
        public string check_note { get; set; }
        /// <summary>
        /// 创建时间
        /// <!--
        /// 数据库有默认值，所以设计为非空
        /// -->
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime create_time { get; set; }
        /// <summary>
        /// 删除标识
        /// <!--
        /// 数据库有默认值，所以设计为非空
        /// -->
        /// </summary>
        [Column(TypeName = "bit")]
        public bool is_del { get; set; }
        /// <summary>
        /// people_id一般同guid_value
        /// </summary>
        [StringLength(50)]
        public string people_id { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        [StringLength(50)]
        public string project_code { get; set; }
        /// <summary>
        /// 最后更新时间
        /// <!--
        /// 数据库有默认值，所以设计为非空
        /// -->
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime lastupdate_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public short? is_down { get; set; }
    }
}
