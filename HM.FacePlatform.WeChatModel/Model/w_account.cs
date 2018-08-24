namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ΢���û��˺�
    /// </summary>
    public partial class w_account
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// �˺�
        /// </summary>
        [Required]
        [StringLength(50)]
        public string account { get; set; }
        /// <summary>
        /// С���û�Ψһ��ʶ
        /// </summary>
        [Required]
        [StringLength(50)]
        public string user_uid { get; set; }
        /// <summary>
        /// ΢���û�Ψһ��ʶ
        /// </summary>
        [StringLength(50)]
        public string wechat_uid { get; set; }
        /// <summary>
        /// ΢�Ű�ʱ��
        /// </summary>

        public DateTime? wechat_bind_time { get; set; }
    }
}
