namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.w_card")]
    public partial class w_card
    {
        public int id { get; set; }

        [StringLength(50)]
        public string user_uid { get; set; }

        [StringLength(50)]
        public string card_no { get; set; }

        [StringLength(50)]
        public string project_code { get; set; }
    }
}
