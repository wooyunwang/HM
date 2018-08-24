namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// CRM楼栋
    /// </summary>
    public partial class c_building
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 楼栋编码
        /// </summary>
        [StringLength(50)]
        public string building_code { get; set; }
        /// <summary>
        /// 楼栋名称
        /// </summary>
        [StringLength(100)]
        public string building_name { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        [StringLength(50)]
        public string project_code { get; set; }
        ///// <summary>
        ///// 数据来源
        ///// </summary>
        //public string data_from { get; set; }
    }
}
