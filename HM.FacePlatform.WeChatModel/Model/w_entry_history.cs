namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ������ʷ��¼
    /// </summary>
    public partial class w_entry_history
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// ץȡid
        /// </summary>
        public int snapshot_id { get; set; }
        /// <summary>
        /// ��Ƭ·��
        /// </summary>
        [Required]
        [StringLength(100)]
        public string photo_path { get; set; }
        /// <summary>
        /// �÷�
        /// </summary>
        public decimal score { get; set; }
        /// <summary>
        /// ����Ψһ��ʶ
        /// </summary>
        [Required]
        [StringLength(50)]
        public string face_uid { get; set; }
        /// <summary>
        /// ����һ������
        /// </summary>
        [Required]
        [StringLength(50)]
        public string mao_no { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [Required]
        [StringLength(50)]
        public string project_code { get; set; }
    }
}
