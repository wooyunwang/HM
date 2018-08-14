namespace HM.FacePlatform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// ¥��
    /// <!--
    /// ԭ��������е㲻���������������ʵ�������û�취��project_code + building_code��Ϊ˫������
    /// Ϊ����ӦEntity Framework���ϸ�Ҫ��ȡ��Id��Ϊ��������building_code��Ϊ������
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
        /// ������Id��������
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// ¥������
        /// </summary>
        [Key]
        [Required]
        [StringLength(50)]
        public string building_code { get; set; }
        /// <summary>
        /// ¥������
        /// </summary>
        [Required]
        [StringLength(100)]
        public string building_name { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [Required]
        [StringLength(50)]
        public string project_code { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// ����һ�����¥����ϵ����
        /// </summary>
        public virtual ICollection<MaoBuilding> MaoBuildings { get; set; }
    }
}
