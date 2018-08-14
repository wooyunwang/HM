namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wechatface.c_house")]
    public partial class c_house
    {
        public int id { get; set; }

        [StringLength(50)]
        public string house_code { get; set; }

        [StringLength(100)]
        public string house_name { get; set; }

        [StringLength(20)]
        public string unit { get; set; }

        [StringLength(20)]
        public string floor { get; set; }

        [StringLength(20)]
        public string roomnumber { get; set; }

        [StringLength(50)]
        public string building_code { get; set; }
    }
}
