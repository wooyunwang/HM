namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// �ͻ���ϵͳ�û�
    /// </summary>
    public partial class SystemUser : BaseModel
    {
        public SystemUser()
        {
            SetDefaultToProperties(this);
        }
        /// <summary>
        /// ϵͳ�û�����
        /// </summary>
        [Required]
        [StringLength(50)]
        public string user_name { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [Required]
        [StringLength(100)]
        public string password { get; set; }
        /// <summary>
        /// �Ƿ�Ϊ����Ա
        /// </summary>
        public IsAdminType is_admin { get; set; }
        /// <summary>
        /// ����¼ʱ��
        /// </summary>
        public DateTime? last_login_date { get; set; }
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        public IsDelType is_del { get; set; }
    }
}
