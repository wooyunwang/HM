namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// 人脸用户
    /// </summary>
    public partial class w_user : c_user
    {
        /// <summary>
        /// 用户类型
        /// </summary>
        [StringLength(20)]
        public string user_type { get; set; }
        /// <summary>
        /// 是否临时用户
        /// <!--
        /// 数据库有默认值，所以设计为非空
        /// -->
        /// </summary>
        [Column(TypeName = "bit")]
        public bool is_temp { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [StringLength(100)]
        public string photo { get; set; }
        /// <summary>
        /// 数据来源
        /// </summary>
        public string data_from { get; set; }

    }
}
