namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// CRM房屋
    /// </summary>
    public partial class c_house
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 房屋编码
        /// </summary>
        [StringLength(50)]
        public string house_code { get; set; }
        /// <summary>
        /// 房屋名称
        /// </summary>
        [StringLength(100)]
        public string house_name { get; set; }
        /// <summary>
        /// 单元
        /// </summary>
        [StringLength(20)]
        public string unit { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        [StringLength(20)]
        public string floor { get; set; }
        /// <summary>
        /// 房号
        /// </summary>
        [StringLength(20)]
        public string roomnumber { get; set; }
        /// <summary>
        /// 楼栋编码
        /// </summary>
        [StringLength(50)]
        public string building_code { get; set; }
        ///// <summary>
        ///// 数据来源
        ///// </summary>
        //public string data_from { get; set; }
    }
}
