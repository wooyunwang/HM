namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.c_project")]
    public partial class c_project
    {
        public int id { get; set; }

        [StringLength(50)]
        public string project_code { get; set; }

        [StringLength(100)]
        public string project_name { get; set; }

        public DateTime? lastupdate_time { get; set; }

        [StringLength(1)]
        public string state { get; set; }
    }
}
