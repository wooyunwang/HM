namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ����ע����Ϣ
    /// </summary>
    public partial class w_register
    {
        /// <summary>
        /// ���
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// С���û�Ψһ��ʶ
        /// </summary>
        [StringLength(50)]
        public string guid_value { get; set; }
        /// <summary>
        /// Ψһ��ʶ����
        /// </summary>
        public short? guid_type { get; set; }
        /// <summary>
        /// ����uid
        /// </summary>
        [StringLength(50)]
        public string face_uid { get; set; }
        /// <summary>
        /// ͼƬ��ַ��������ǰ׺��
        /// </summary>
        [StringLength(100)]
        public string photo_path { get; set; }
        /// <summary>
        /// ע������
        /// <!--
        /// ���ݿ���Ĭ��ֵ���������Ϊ�ǿ�
        /// -->
        /// </summary>
        public short register_type { get; set; }
        /// <summary>
        /// ע��ʱ��
        /// <!--
        /// ���ݿ���Ĭ��ֵ���������Ϊ�ǿ�
        /// -->
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime reg_time { get; set; }
        /// <summary>
        /// ��Чʱ��
        /// </summary>
        public DateTime? end_time { get; set; }
        /// <summary>
        /// ע��״̬
        /// </summary>
        public short? register_state { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? check_time { get; set; }
        /// <summary>
        /// �����ע
        /// </summary>
        [StringLength(100)]
        public string check_note { get; set; }
        /// <summary>
        /// ����ʱ��
        /// <!--
        /// ���ݿ���Ĭ��ֵ���������Ϊ�ǿ�
        /// -->
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime create_time { get; set; }
        /// <summary>
        /// ɾ����ʶ
        /// <!--
        /// ���ݿ���Ĭ��ֵ���������Ϊ�ǿ�
        /// -->
        /// </summary>
        [Column(TypeName = "bit")]
        public bool is_del { get; set; }
        /// <summary>
        /// people_idһ��ͬguid_value
        /// </summary>
        [StringLength(50)]
        public string people_id { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [StringLength(50)]
        public string project_code { get; set; }
        /// <summary>
        /// ������ʱ��
        /// <!--
        /// ���ݿ���Ĭ��ֵ���������Ϊ�ǿ�
        /// -->
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime lastupdate_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public short? is_down { get; set; }
    }
}
