namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ����ע��
    /// </summary>
    public partial class Register : BaseModel
    {
        public Register()
        {
            SetDefaultToProperties(this);
            create_time = change_time = DateTime.Now;
        }
        /// <summary>
        /// С���û�Ψһ��ʶ
        /// </summary>
        [Required]
        [StringLength(50)]
        public string user_uid { get; set; }
        /// <summary>
        /// ��������ID
        /// </summary>
        [Required]
        [StringLength(50)]
        public string face_id { get; set; }
        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        [Required]
        [StringLength(200)]
        public string photo_path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(200)]
        [Obsolete("����������Ŀ��δ�õ�")]
        public string tc_path { get; set; }
        /// <summary>
        /// ע������
        /// </summary>
        public RegisterType register_type { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime change_time { get; set; }
        /// <summary>
        /// ���״̬
        /// </summary>
        public CheckType check_state { get; set; }
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        public IsDelType is_del { get; set; }
        /// <summary>
        /// С���û�
        /// </summary>
        [ForeignKey("user_uid")]
        public User user { get; set; }
    }
}
