using HM.Enum_.FacePlatform;
using System;

namespace HM.DTO
{
    public class RegisterActionLogDto : ActionLogDto
    {
        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType user_type { get; set; }
        /// <summary>
        /// 小区用户名称
        /// </summary>
        public string user_name { get; set; }
    }
}