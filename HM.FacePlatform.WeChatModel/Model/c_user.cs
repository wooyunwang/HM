namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// CRM用户
    /// </summary>
    public partial class c_user
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 小区用户唯一标识
        /// </summary>
        [Required]
        [StringLength(50)]
        public string user_uid { get; set; }
        /// <summary>
        /// 小区用户名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? birthday { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Column(TypeName = "bit")]
        public bool? sex { get; set; }
        /// <summary>
        /// id类别
        /// </summary>
        public short? id_type { get; set; }
        /// <summary>
        /// Id编号
        /// </summary>
        [StringLength(50)]
        public string id_num { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [StringLength(50)]
        public string mobile { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [StringLength(50)]
        public string tel { get; set; }
        /// <summary>
        /// 最后更新时间
        /// <!--
        /// 数据库有默认值，所以设计为非空
        /// -->
        /// </summary>
        public DateTime lastupdate_time { get; set; }
        /// <summary>
        /// 用户房屋关系
        /// </summary>
        public ICollection<c_user_house> user_houses { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public bool? is_del { get; set; }
    }
}
