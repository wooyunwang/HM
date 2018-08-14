namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// 枚举类型字典
    /// </summary>
    public partial class Dictionary : BaseModel
    {
        public Dictionary()
        {
            SetDefaultToProperties(this);
        }
        /// <summary>
        /// 枚举类型
        /// </summary>
        [Required]
        [StringLength(50)]
        public string enum_type { get; set; }
        /// <summary>
        /// 枚举值
        /// </summary>
        public sbyte enum_value { get; set; }
        /// <summary>
        /// 枚举名字
        /// </summary>
        [Required]
        [StringLength(50)]
        public string enum_name { get; set; }
        /// <summary>
        /// 是否在下拉框显示
        /// </summary>
        public bool is_show { get; set; }
        /// <summary>
        /// 排序，从小到大
        /// </summary>
        public sbyte sort_index { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public IsDelType is_del { get; set; }
    }
}
