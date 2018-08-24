
using System;

namespace HM.DTO.FacePlatform
{
    public class UserHouseDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 房屋编码
        /// </summary>
        public string house_code { get; set; }
        /// <summary>
        /// 小区用户唯一标识
        /// </summary>
        public string user_uid { get; set; }
        /// <summary>
        /// 关系
        /// </summary>
        public string relation { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool? is_del { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? lastupdate_time { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string project_code { get; set; }
    }
}
