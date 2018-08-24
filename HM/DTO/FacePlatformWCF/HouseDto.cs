using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO.FacePlatform
{
    public class HouseDto
    {
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
        /// 楼层
        /// </summary>
        public string floor { get; set; }
        /// <summary>
        /// 房号
        /// </summary>
        public string roomnumber { get; set; }
        /// <summary>
        /// 楼栋编码
        /// </summary>
        public string building_code { get; set; }
        ///// <summary>
        ///// 数据来源
        ///// </summary>
        //public string data_from { get; set; }
    }
}
