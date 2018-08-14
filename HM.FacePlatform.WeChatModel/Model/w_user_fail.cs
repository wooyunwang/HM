namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.w_user_fail")]
    public partial class w_user_fail
    {
        public int id { get; set; }

        [StringLength(50)]
        public string user_uid { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public short? id_type { get; set; }

        [StringLength(50)]
        public string id_num { get; set; }

        [StringLength(50)]
        public string mobile { get; set; }

        public short? data_from { get; set; }

        [Column(TypeName = "bit")]
        public bool? is_temp { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? lastupdate_time { get; set; }

        [StringLength(200)]
        public string fail_info { get; set; }

        [Column(TypeName = "bit")]
        public bool? is_down { get; set; }

        [StringLength(50)]
        public string project_code { get; set; }
    }
}
