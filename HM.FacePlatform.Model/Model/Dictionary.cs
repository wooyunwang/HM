namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// ö�������ֵ�
    /// </summary>
    public partial class Dictionary : BaseModel
    {
        public Dictionary()
        {
            SetDefaultToProperties(this);
        }
        /// <summary>
        /// ö������
        /// </summary>
        [Required]
        [StringLength(50)]
        public string enum_type { get; set; }
        /// <summary>
        /// ö��ֵ
        /// </summary>
        public sbyte enum_value { get; set; }
        /// <summary>
        /// ö������
        /// </summary>
        [Required]
        [StringLength(50)]
        public string enum_name { get; set; }
        /// <summary>
        /// �Ƿ�����������ʾ
        /// </summary>
        public bool is_show { get; set; }
        /// <summary>
        /// ���򣬴�С����
        /// </summary>
        public sbyte sort_index { get; set; }
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        public IsDelType is_del { get; set; }
    }
}
