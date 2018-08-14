namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.v_register")]
    public partial class v_register
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string guid_value { get; set; }

        public short? guid_type { get; set; }

        [StringLength(50)]
        public string face_uid { get; set; }

        [StringLength(100)]
        public string photo_path { get; set; }

        public short? register_type { get; set; }

        public DateTime? reg_time { get; set; }

        public DateTime? end_time { get; set; }

        public short? register_state { get; set; }

        public DateTime? check_time { get; set; }

        [StringLength(100)]
        public string check_note { get; set; }

        public DateTime? create_time { get; set; }

        [StringLength(50)]
        public string people_id { get; set; }

        [StringLength(50)]
        public string project_code { get; set; }

        [Column(TypeName = "bit")]
        public bool? is_del { get; set; }
    }
}
