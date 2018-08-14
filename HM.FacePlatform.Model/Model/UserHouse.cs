namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 小区用户与房屋关系
    /// </summary>
    public partial class UserHouse : BaseModel
    {
        public UserHouse()
        {
            SetDefaultToProperties(this);
        }
        /// <summary>
        /// 房屋编码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string house_code { get; set; }
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        [Required]
        [StringLength(50)]
        public string user_uid { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType user_type { get; set; }
        /// <summary>
        /// 与业主关系
        /// </summary>
        [Required]
        [StringLength(50)]
        public string relation { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public IsDelType is_del { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("user_uid")]
        public virtual User User { set; get; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("house_code")]
        public virtual House House { set; get; }
    }
}
