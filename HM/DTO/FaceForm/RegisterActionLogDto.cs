using HM.Enum_.FacePlatform;
using System;

namespace HM.DTO
{
    public class RegisterActionLogDto: ActionLogDto
    {
        /// <summary>
        /// 小区用户名称
        /// </summary>
        public string user_name { get; set; }
    }
}