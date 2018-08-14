namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.w_user")]
    public partial class w_user
    {
        public int id { get; set; }

        [StringLength(50)]
        public string user_uid { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(20)]
        public string user_type { get; set; }

        public DateTime? birthday { get; set; }

        [Column(TypeName = "bit")]
        public bool? sex { get; set; }

        public short? id_type { get; set; }

        [StringLength(50)]
        public string id_num { get; set; }

        [StringLength(50)]
        public string mobile { get; set; }

        [StringLength(50)]
        public string tel { get; set; }

        public short? data_from { get; set; }

        [Column(TypeName = "bit")]
        public bool? is_temp { get; set; }

        [StringLength(100)]
        public string photo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? lastupdate_time { get; set; }
    }
}
