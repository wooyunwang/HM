namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ��Ŀ
    /// </summary>
    public partial class c_project
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [StringLength(50)]
        public string project_code { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [StringLength(100)]
        public string project_name { get; set; }
        /// <summary>
        /// ������ʱ��
        /// </summary>
        public DateTime? lastupdate_time { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        [StringLength(1)]
        public string state { get; set; }
    }
}
