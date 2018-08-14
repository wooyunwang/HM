using HM.Enum_.FacePlatform;

namespace HM.FacePlatform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 操作记录
    /// </summary>
    public partial class ActionLog : BaseModel
    {
        public ActionLog()
        {
            SetDefaultToProperties(this);
            create_date = DateTime.Now;
        }
        /// <summary>
        /// 关联的表id: user.id,register.id
        /// </summary>
        public int table_id { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public ActionType action_type { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public ActionName action { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Required]
        [StringLength(500)]
        public string remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// system_user.id
        /// </summary>
        public int action_by { get; set; }
    }
}
