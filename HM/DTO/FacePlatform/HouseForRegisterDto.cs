using System;

namespace HM.DTO.FacePlatform
{
    /// <summary>
    /// 房屋信息，用户注册管理界面
    /// </summary>
    public class HouseForRegisterDto
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
        /// 房屋名称
        /// </summary>
        public string house_name { get; set; }
        /// <summary>
        /// 单元
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 楼栋编码
        /// </summary>
        public string building_code { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        public string floor { get; set; }
        /// <summary>
        /// 房号
        /// </summary>
        public string roomnumber { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// 访客数量
        /// </summary>
        public int guest_count { get; set; }
        /// <summary>
        /// 家庭成员数量
        /// </summary>
        public int family_count { get; set; }
        /// <summary>
        /// 业主
        /// </summary>
        public string users_string { get; set; }
    }
}