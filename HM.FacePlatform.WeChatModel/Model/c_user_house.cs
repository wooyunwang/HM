namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.c_user_house")]
    public partial class c_user_house
    {
        public int id { get; set; }

        [StringLength(50)]
        public string house_code { get; set; }

        [StringLength(50)]
        public string user_uid { get; set; }

        [StringLength(50)]
        public string relation { get; set; }

        [Column(TypeName = "bit")]
        public bool? is_del { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? lastupdate_time { get; set; }

        [StringLength(50)]
        public string project_code { get; set; }
    }
}
