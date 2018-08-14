namespace HM.FacePlatform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// 楼栋
    /// <!--
    /// 原来的设计有点不合理，鉴于其他表的实际情况，没办法将project_code + building_code作为双主键）
    /// 为了适应Entity Framework的严格要求，取消Id作为主键，将building_code作为主键。
    /// -->
    /// </summary>
    public partial class Building : BaseModelNotId
    {
        public Building()
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
        /// 楼栋编码
        /// </summary>
        [Key]
        [Required]
        [StringLength(50)]
        public string building_code { get; set; }
        /// <summary>
        /// 楼栋名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string building_name { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string project_code { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// 人脸一体机与楼栋关系集合
        /// </summary>
        public virtual ICollection<MaoBuilding> MaoBuildings { get; set; }
    }
}
