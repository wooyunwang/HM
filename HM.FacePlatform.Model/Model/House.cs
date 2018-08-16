namespace HM.FacePlatform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 房屋
    /// </summary>
    public partial class House : BaseModelNotId
    {
        public House()
        {
            SetDefaultToProperties(this);
            create_date = DateTime.Now;
        }
        /// <summary>
        /// 自增长Id，非主键
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// 房屋编码
        /// </summary>
        [Key]
        [Required]
        [StringLength(50)]
        public string house_code { get; set; }
        /// <summary>
        /// 房屋名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string house_name { get; set; }
        /// <summary>
        /// 单元
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string unit { get; set; }
        /// <summary>
        /// 楼栋编码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string building_code { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string floor { get; set; }
        /// <summary>
        /// 房号
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string roomnumber { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// 小区用户与房屋关系集合
        /// </summary>
        public virtual ICollection<UserHouse> UserHouses { get; set; }
    }
}
