namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.w_register_bak")]
    public partial class w_register_bak
    {
        public int id { get; set; }

        [StringLength(50)]
        public string guid_value { get; set; }

        public short? guid_type { get; set; }

        [StringLength(50)]
        public string face_uid { get; set; }

        [StringLength(100)]
        public string photo_path { get; set; }

        public short? register_type { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? reg_time { get; set; }

        public DateTime? end_time { get; set; }

        public short? register_state { get; set; }

        public DateTime? check_time { get; set; }

        [StringLength(100)]
        public string check_note { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? create_time { get; set; }

        [Column(TypeName = "bit")]
        public bool? is_del { get; set; }

        [StringLength(50)]
        public string people_id { get; set; }

        [StringLength(50)]
        public string project_code { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? lastupdate_time { get; set; }

        public short? is_down { get; set; }
    }
}
