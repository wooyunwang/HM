using HM.Enum_.FacePlatform;

namespace HM.FacePlatform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ������¼
    /// </summary>
    public partial class ActionLog : BaseModel
    {
        public ActionLog()
        {
            SetDefaultToProperties(this);
            create_date = DateTime.Now;
        }
        /// <summary>
        /// �����ı�id: user.id,register.id
        /// </summary>
        public int table_id { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public ActionType action_type { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public ActionName action { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        [Required]
        [StringLength(500)]
        public string remark { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// system_user.id
        /// </summary>
        public int action_by { get; set; }
    }
}
