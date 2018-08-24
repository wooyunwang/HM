namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// �û����ݹ�ϵ
    /// </summary>
    public partial class c_user_house
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// ���ݱ���
        /// </summary>
        [StringLength(50)]
        public string house_code { get; set; }
        /// <summary>
        /// С���û�Ψһ��ʶ
        /// </summary>
        [StringLength(50)]
        public string user_uid { get; set; }
        /// <summary>
        /// ��ϵ
        /// </summary>
        [StringLength(50)]
        public string relation { get; set; }
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        [Column(TypeName = "bit")]
        public bool? is_del { get; set; }
        /// <summary>
        /// ������ʱ��
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? lastupdate_time { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [StringLength(50)]
        public string project_code { get; set; }
    }
}
