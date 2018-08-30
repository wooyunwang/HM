namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 人脸一体机失败任务
    /// </summary>
    public partial class MaoFailedJob : BaseModel
    {
        public MaoFailedJob()
        {
            SetDefaultToProperties(this);

            create_date = DateTime.Now;
            last_retry_date = DateTime.MinValue;
        }
        /// <summary>
        /// 注册Id或者用户Id  f_register.id
        /// </summary>
        public int register_or_user_id { get; set; }
        /// <summary>
        /// 人脸一体机编号 f_mao.id
        /// </summary>
        public int mao_id { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public JobType job_type { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// 重试次数
        /// </summary>
        public int retry_time { get; set; }
        /// <summary>
        /// 最后重试时间
        /// </summary>
        public DateTime last_retry_date { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public IsDelType is_del { get; set; }
        /// <summary>
        /// 失败缘由
        /// </summary>
        [MaxLength(1024)]
        public string failed_message { get; set; }
        /// <summary>
        /// 重试结果信息
        /// </summary>
        [MaxLength(1024)]
        public string retry_message { get; set; }
    }
}
