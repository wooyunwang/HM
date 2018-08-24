namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// �����û�
    /// </summary>
    public partial class w_user : c_user
    {
        /// <summary>
        /// �û�����
        /// </summary>
        [StringLength(20)]
        public string user_type { get; set; }
        /// <summary>
        /// �Ƿ���ʱ�û�
        /// <!--
        /// ���ݿ���Ĭ��ֵ���������Ϊ�ǿ�
        /// -->
        /// </summary>
        [Column(TypeName = "bit")]
        public bool is_temp { get; set; }
        /// <summary>
        /// ͷ��
        /// </summary>
        [StringLength(100)]
        public string photo { get; set; }
        /// <summary>
        /// ������Դ
        /// </summary>
        public string data_from { get; set; }

    }
}
