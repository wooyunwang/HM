namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 微信用户账号
    /// </summary>
    public partial class w_account
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        [Required]
        [StringLength(50)]
        public string account { get; set; }
        /// <summary>
        /// 小区用户唯一标识
        /// </summary>
        [Required]
        [StringLength(50)]
        public string user_uid { get; set; }
        /// <summary>
        /// 微信用户唯一标识
        /// </summary>
        [StringLength(50)]
        public string wechat_uid { get; set; }
        /// <summary>
        /// 微信绑定时间
        /// </summary>

        public DateTime? wechat_bind_time { get; set; }
    }
}
