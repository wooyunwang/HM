namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// С���û��뷿�ݹ�ϵ
    /// </summary>
    public partial class UserHouse : BaseModel
    {
        public UserHouse()
        {
            SetDefaultToProperties(this);
        }
        /// <summary>
        /// ���ݱ���
        /// </summary>
        [Required]
        [StringLength(50)]
        public string house_code { get; set; }
        /// <summary>
        /// �û�Ψһ��ʶ
        /// </summary>
        [Required]
        [StringLength(50)]
        public string user_uid { get; set; }
        /// <summary>
        /// �û�����
        /// </summary>
        public UserType user_type { get; set; }
        /// <summary>
        /// ��ҵ����ϵ
        /// </summary>
        [Required]
        [StringLength(50)]
        public string relation { get; set; }
        /// <summary>
        /// �Ƿ�ɾ��
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
