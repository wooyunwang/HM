namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 项目
    /// </summary>
    public partial class c_project
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        [StringLength(50)]
        public string project_code { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [StringLength(100)]
        public string project_name { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? lastupdate_time { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [StringLength(1)]
        public string state { get; set; }
    }
}
