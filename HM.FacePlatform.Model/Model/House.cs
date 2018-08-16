namespace HM.FacePlatform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ����
    /// </summary>
    public partial class House : BaseModelNotId
    {
        public House()
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
        /// ���ݱ���
        /// </summary>
        [Key]
        [Required]
        [StringLength(50)]
        public string house_code { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [Required]
        [StringLength(100)]
        public string house_name { get; set; }
        /// <summary>
        /// ��Ԫ
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string unit { get; set; }
        /// <summary>
        /// ¥������
        /// </summary>
        [Required]
        [StringLength(50)]
        public string building_code { get; set; }
        /// <summary>
        /// ¥��
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string floor { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string roomnumber { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// С���û��뷿�ݹ�ϵ����
        /// </summary>
        public virtual ICollection<UserHouse> UserHouses { get; set; }
    }
}
