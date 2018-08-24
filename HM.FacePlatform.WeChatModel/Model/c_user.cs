namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// CRM�û�
    /// </summary>
    public partial class c_user
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// С���û�Ψһ��ʶ
        /// </summary>
        [Required]
        [StringLength(50)]
        public string user_uid { get; set; }
        /// <summary>
        /// С���û�����
        /// </summary>
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public DateTime? birthday { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        [Column(TypeName = "bit")]
        public bool? sex { get; set; }
        /// <summary>
        /// id���
        /// </summary>
        public short? id_type { get; set; }
        /// <summary>
        /// Id���
        /// </summary>
        [StringLength(50)]
        public string id_num { get; set; }
        /// <summary>
        /// �ֻ�
        /// </summary>
        [StringLength(50)]
        public string mobile { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        [StringLength(50)]
        public string tel { get; set; }
        /// <summary>
        /// ������ʱ��
        /// <!--
        /// ���ݿ���Ĭ��ֵ���������Ϊ�ǿ�
        /// -->
        /// </summary>
        public DateTime lastupdate_time { get; set; }
        /// <summary>
        /// �û����ݹ�ϵ
        /// </summary>
        public ICollection<c_user_house> user_houses { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public bool? is_del { get; set; }
    }
}
