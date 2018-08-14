namespace HM.FacePlatform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ����һ�����¥����ϵ
    /// </summary>
    public partial class MaoBuilding : BaseModel
    {
        public MaoBuilding()
        {
            SetDefaultToProperties(this);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int mao_id { get; set; }
        /// <summary>
        /// ¥������
        /// </summary>
        [Required]
        [StringLength(50)]
        public string building_code { get; set; }
        /// <summary>
        /// ����һ���
        /// </summary>
        [ForeignKey("mao_id")]
        public virtual Mao Mao { set; get; }
        /// <summary>
        /// ¥��
        /// </summary>
        [ForeignKey("building_code")]
        public virtual Building Building { set; get; }
    }
}
