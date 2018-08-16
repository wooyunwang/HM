using HM.Enum_.FacePlatform;
using System;

namespace HM.DTO
{
    public class CheckActionLogDto: ActionLogDto
    {
        /// <summary>
        /// 小区用户名称
        /// </summary>
        public string user_name { get; set; }
        /// <summary>
        /// 房间
        /// </summary>
        public string house_name { get; set; }
    }
}