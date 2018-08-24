namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 进出历史记录
    /// </summary>
    public partial class w_entry_history
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 抓取id
        /// </summary>
        public int snapshot_id { get; set; }
        /// <summary>
        /// 照片路径
        /// </summary>
        [Required]
        [StringLength(100)]
        public string photo_path { get; set; }
        /// <summary>
        /// 得分
        /// </summary>
        public decimal score { get; set; }
        /// <summary>
        /// 人脸唯一标识
        /// </summary>
        [Required]
        [StringLength(50)]
        public string face_uid { get; set; }
        /// <summary>
        /// 人脸一体机编号
        /// </summary>
        [Required]
        [StringLength(50)]
        public string mao_no { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string project_code { get; set; }
    }
}
