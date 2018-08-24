namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 用户房屋关系
    /// </summary>
    public partial class c_user_house
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 房屋编码
        /// </summary>
        [StringLength(50)]
        public string house_code { get; set; }
        /// <summary>
        /// 小区用户唯一标识
        /// </summary>
        [StringLength(50)]
        public string user_uid { get; set; }
        /// <summary>
        /// 关系
        /// </summary>
        [StringLength(50)]
        public string relation { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Column(TypeName = "bit")]
        public bool? is_del { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? lastupdate_time { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        [StringLength(50)]
        public string project_code { get; set; }
    }
}
