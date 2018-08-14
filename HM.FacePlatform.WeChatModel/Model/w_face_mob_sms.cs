namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.w_face_mob_sms")]
    public partial class w_face_mob_sms
    {
        [Key]
        [StringLength(60)]
        public string sms_uid { get; set; }

        [StringLength(10)]
        public string sms_code { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime create_time { get; set; }

        [StringLength(20)]
        public string receive_num { get; set; }

        [StringLength(32)]
        public string msg_id { get; set; }

        [StringLength(20)]
        public string sendstate { get; set; }

        [StringLength(80)]
        public string reason { get; set; }

        public bool? is_used { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? used_time { get; set; }

        [StringLength(250)]
        public string sms_content { get; set; }
    }
}
