namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.c_crm_data")]
    public partial class c_crm_data
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string project_code { get; set; }

        [Required]
        [StringLength(50)]
        public string building_code { get; set; }

        [Required]
        [StringLength(50)]
        public string house_code { get; set; }

        [Required]
        [StringLength(50)]
        public string customer_code { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string mobile { get; set; }

        [Required]
        [StringLength(50)]
        public string id_num { get; set; }

        public int id_type { get; set; }

        [Required]
        [StringLength(10)]
        public string relation { get; set; }

        public int is_del { get; set; }

        public DateTime create_time { get; set; }

        public DateTime update_time { get; set; }
    }
}
