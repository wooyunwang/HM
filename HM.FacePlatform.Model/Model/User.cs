namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using HM.Utils_;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// С���û�
    /// </summary>
    public partial class User : BaseModelNotId
    {
        public User()
        {
            SetDefaultToProperties(this);

            user_uid = people_id = Key_.SequentialGuid();

            sex = SexType.δ֪;
            birthday = DateTime.MinValue;
            id_type = IdType.���֤;
            data_from = DataFromType.δ֪;
            create_time = change_time = DateTime.Now;
            is_del = IsDelType.��;

            reg_time = end_time = check_time = DateTime.MinValue;
            check_state = CheckType.�����;
        }
        /// <summary>
        /// ������Id��������
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// С���û�Ψһ��ʶ
        /// </summary>
        [Key]
        [Required]
        [StringLength(50)]
        public string user_uid { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        /// <summary>
        /// �Ա�:1,��;2,Ů;0,δ֪
        /// </summary>
        public SexType sex { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime birthday { get; set; }
        /// <summary>
        /// ֤������
        /// </summary>
        public IdType id_type { get; set; }
        /// <summary>
        /// ֤������
        /// </summary>
        [Required]
        [StringLength(50)]
        public string id_num { get; set; }
        /// <summary>
        /// ֤��ͼƬ
        /// </summary>
        [Required]
        [StringLength(100)]
        public string id_pic { get; set; }
        /// <summary>
        /// �ֻ�
        /// </summary>
        [Required]
        [StringLength(50)]
        public string mobile { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        [Required]
        [StringLength(50)]
        public string tel { get; set; }
        /// <summary>
        /// �û���Դ
        /// </summary>
        public DataFromType data_from { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// �Ƿ���ɾ��:1,��;0,��
        /// </summary>
        public IsDelType is_del { get; set; }
        /// <summary>
        /// ����޸�����
        /// </summary>
        public DateTime change_time { get; set; }
        /// <summary>
        /// �������ҷ��ص���id
        /// </summary>
        [Required]
        [StringLength(50)]
        public string people_id { get; set; }
        /// <summary>
        /// ע��ʱ��
        /// </summary>
        public DateTime reg_time { get; set; }
        /// <summary>
        /// ��Ч����
        /// </summary>
        public DateTime end_time { get; set; }
        /// <summary>
        /// ���״̬
        /// </summary>
        public CheckType check_state { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime check_time { get; set; }
        /// <summary>
        /// ��˱�ע
        /// </summary>
        [Required]
        [StringLength(500)]
        public string check_note { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        public int check_by { get; set; }
        /// <summary>
        /// ְλ
        /// </summary>
        [Required]
        [StringLength(50)]
        public string job { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [Required]
        [StringLength(50)]
        public string job_number { get; set; }
        /// <summary>
        /// ע�������
        /// </summary>
        public virtual ICollection<Register> Registers { get; set; }
        /// <summary>
        /// С���û��뷿�ݹ�ϵ����
        /// </summary>
        public virtual ICollection<UserHouse> UserHouses { get; set; }
    }
}
