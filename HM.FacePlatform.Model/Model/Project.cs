namespace HM.FacePlatform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ��Ŀ
    /// </summary>
    public partial class Project : BaseModel
    {
        public Project()
        {
            SetDefaultToProperties(this);
        }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [Required]
        [StringLength(50)]
        public string project_code { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [Required]
        [StringLength(100)]
        public string project_name { get; set; }
    }
}
