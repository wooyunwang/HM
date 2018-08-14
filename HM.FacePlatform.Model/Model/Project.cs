namespace HM.FacePlatform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 项目
    /// </summary>
    public partial class Project : BaseModel
    {
        public Project()
        {
            SetDefaultToProperties(this);
        }
        /// <summary>
        /// 项目编码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string project_code { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string project_name { get; set; }
    }
}
