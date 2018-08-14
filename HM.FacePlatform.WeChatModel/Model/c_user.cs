namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.c_user")]
    public partial class c_user
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string user_uid { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

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

        public DateTime? lastupdate_time { get; set; }
    }
}
