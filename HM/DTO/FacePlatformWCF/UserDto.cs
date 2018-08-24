using System;
using System.Collections.Generic;
using HM.Enum_.FacePlatform;

namespace HM.DTO.FacePlatform
{
    public class UserDto
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 小区用户唯一标识
        /// </summary>
        public string user_uid { get; set; }
        /// <summary>
        /// 小区用户名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? birthday { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool? sex { get; set; }
        /// <summary>
        /// id类别
        /// </summary>
        public short? id_type { get; set; }
        /// <summary>
        /// Id编号
        /// </summary>
        public string id_num { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string tel { get; set; }
        /// <summary>
        /// 数据来源
        /// </summary>
        public int data_from { get; set; }
        //public DateTime create_time { get; set; }
        //public int is_del { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? lastupdate_time { get; set; }

        //public string id_pic { get; set; }
        //public string job { get; set; }
        //public string job_number { get; set; }
        ///// <summary>
        ///// 审核时更新
        ///// </summary>
        //public DateTime change_time { get; set; }

        //public string people_id { get; set; }
        //public DateTime reg_time { get; set; }
        //public DateTime end_time { get; set; }
        //public int check_state { get; set; }
        //public DateTime check_time { get; set; }
        //public string check_note { get; set; }
        //public int check_by { get; set; }

        public List<UserHouseDto> user_houses { get; set; }
    }
}
