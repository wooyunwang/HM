using System;
using HM.Enum_.FacePlatform;

namespace HM.DTO.FacePlatform
{
    public class UserDto
    {
        public int id { get; set; }
        public string user_uid { get; set; }
        public string name { get; set; }
        public SexType sex { get; set; }
        public DateTime birthday { get; set; }
        public int id_type { get; set; }
        public string id_num { get; set; }
        public string id_pic { get; set; }
        public string job { get; set; }
        public string job_number { get; set; }
        public string mobile { get; set; }
        public string tel { get; set; }
        public int data_from { get; set; }
        public DateTime create_time { get; set; }
        public int is_del { get; set; }

        /// <summary>
        /// 审核时更新
        /// </summary>
        public DateTime change_time { get; set; }

        public string people_id { get; set; }
        public DateTime reg_time { get; set; }
        public DateTime end_time { get; set; }
        public int check_state { get; set; }
        public DateTime check_time { get; set; }
        public string check_note { get; set; }
        public int check_by { get; set; }
    }
}
