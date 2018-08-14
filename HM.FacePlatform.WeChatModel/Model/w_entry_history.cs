namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.w_entry_history")]
    public partial class w_entry_history
    {
        public int id { get; set; }

        public int snapshot_id { get; set; }

        [Required]
        [StringLength(100)]
        public string photo_path { get; set; }

        public decimal score { get; set; }

        [Required]
        [StringLength(50)]
        public string face_uid { get; set; }

        [Required]
        [StringLength(50)]
        public string mao_no { get; set; }

        public DateTime create_date { get; set; }

        [Required]
        [StringLength(50)]
        public string project_code { get; set; }
    }
}
