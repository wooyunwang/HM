namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.w_face_sysparamter")]
    public partial class w_face_sysparamter
    {
        [Key]
        [StringLength(20)]
        public string ParamterCode { get; set; }

        [Required]
        [StringLength(50)]
        public string ParamterName { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string ParamterValue { get; set; }

        public int ValueType { get; set; }

        [StringLength(50)]
        public string CheckRegx { get; set; }

        public int ParamterType { get; set; }

        [StringLength(1073741823)]
        public string Remark { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
