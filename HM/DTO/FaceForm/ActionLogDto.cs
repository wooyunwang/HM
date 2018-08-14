using HM.Enum_.FacePlatform;
using System;

namespace HM.DTO
{
    public class ActionLogDto
    {
        public int id { get; set; }
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
        public string remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// system_user.id
        /// </summary>
        public int action_by { get; set; }
        /// <summary>
        /// 系统用户名称
        /// </summary>
        public string system_user_name { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public IsAdminType is_admin { get; set; }
    }
}