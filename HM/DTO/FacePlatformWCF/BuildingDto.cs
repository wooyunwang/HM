using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO.FacePlatform
{
    public class BuildingDto
    {
        public string building_code { get; set; }
        /// <summary>
        /// 楼栋名称
        /// </summary>
        public string building_name { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string project_code { get; set; }
        ///// <summary>
        ///// 数据来源
        ///// </summary>
        //public string data_from { get; set; }
    }
}
