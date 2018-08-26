namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 人脸一体机与楼栋关系
    /// </summary>
    public partial class MaoBuilding : BaseModel
    {
        public MaoBuilding()
        {
            SetDefaultToProperties(this);
        }
        /// <summary>
        /// 人脸一体机编号
        /// </summary>
        public int mao_id { get; set; }
        /// <summary>
        /// 楼栋编码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string building_code { get; set; }
        /// <summary>
        /// 人脸一体机
        /// </summary>
        [ForeignKey("mao_id")]
        public virtual Mao Mao { set; get; }
        /// <summary>
        /// 楼栋
        /// </summary>
        [ForeignKey("building_code")]
        public virtual Building Building { set; get; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// 是否已删除:1,是;0,否
        /// </summary>
        public IsDelType is_del { get; set; }
        /// <summary>
        /// 最后修改日期
        /// </summary>
        public DateTime change_time { get; set; }
    }
}
