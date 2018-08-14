namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 客户端系统用户
    /// </summary>
    public partial class SystemUser : BaseModel
    {
        public SystemUser()
        {
            SetDefaultToProperties(this);
        }
        /// <summary>
        /// 系统用户名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string user_name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(100)]
        public string password { get; set; }
        /// <summary>
        /// 是否为管理员
        /// </summary>
        public IsAdminType is_admin { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? last_login_date { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public IsDelType is_del { get; set; }
    }
}
