using System;
using HM.Enum_.FacePlatform;

namespace HM.DTO.FacePlatform
{
    public class UserForDataBaseDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 小区用户唯一标识
        /// </summary>
        public string user_uid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public SexType sex { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public IdType id_type { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string id_num { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public DataFromType data_from { get; set; }
        /// <summary>
        /// 关系
        /// </summary>
        public string relation { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType user_type { get; set; }
    }
}
