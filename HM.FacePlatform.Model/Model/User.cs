namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using HM.Utils_;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 小区用户
    /// </summary>
    public partial class User : BaseModelNotId
    {
        public User()
        {
            SetDefaultToProperties(this);

            user_uid = people_id = Key_.SequentialGuid();

            sex = SexType.未知;
            birthday = DateTime.MinValue;
            id_type = IdType.身份证;
            data_from = DataFromType.未知;
            create_time = change_time = DateTime.Now;
            is_del = IsDelType.否;

            reg_time = end_time = check_time = DateTime.MinValue;
            check_state = CheckType.待审核;
        }
        /// <summary>
        /// 自增长Id，非主键
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// 小区用户唯一标识
        /// </summary>
        [Key]
        [Required]
        [StringLength(50)]
        public string user_uid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        /// <summary>
        /// 性别:1,男;2,女;0,未知
        /// </summary>
        public SexType sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime birthday { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public IdType id_type { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string id_num { get; set; }
        /// <summary>
        /// 证件图片
        /// </summary>
        [Required]
        [StringLength(100)]
        public string id_pic { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [Required]
        [StringLength(50)]
        public string mobile { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Required]
        [StringLength(50)]
        public string tel { get; set; }
        /// <summary>
        /// 用户来源
        /// </summary>
        public DataFromType data_from { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// 是否已删除:1,是;0,否
        /// </summary>
        public IsDelType is_del { get; set; }
        /// <summary>
        /// 最后修改日期
        /// </summary>
        public DateTime change_time { get; set; }
        /// <summary>
        /// 人脸厂家返回的人id
        /// </summary>
        [Required]
        [StringLength(50)]
        public string people_id { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime reg_time { get; set; }
        /// <summary>
        /// 有效日期
        /// </summary>
        public DateTime end_time { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public CheckType check_state { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime check_time { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        [Required]
        [StringLength(500)]
        public string check_note { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public int check_by { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        [Required]
        [StringLength(50)]
        public string job { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        [Required]
        [StringLength(50)]
        public string job_number { get; set; }
        /// <summary>
        /// 注册的人脸
        /// </summary>
        public virtual ICollection<Register> Registers { get; set; }
        /// <summary>
        /// 小区用户与房屋关系集合
        /// </summary>
        public virtual ICollection<UserHouse> UserHouses { get; set; }
    }
}
