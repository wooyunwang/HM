namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.w_account")]
    public partial class w_account
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string account { get; set; }

        [Required]
        [StringLength(50)]
        public string user_uid { get; set; }

        [StringLength(50)]
        public string wechat_uid { get; set; }

        public DateTime? wechat_bind_time { get; set; }
    }
}
