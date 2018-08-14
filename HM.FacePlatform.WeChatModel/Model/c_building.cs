namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 
    /// </summary>
    public partial class c_building
    {
        public int id { get; set; }

        [StringLength(50)]
        public string building_code { get; set; }

        [StringLength(100)]
        public string building_name { get; set; }

        [StringLength(50)]
        public string project_code { get; set; }
    }
}
