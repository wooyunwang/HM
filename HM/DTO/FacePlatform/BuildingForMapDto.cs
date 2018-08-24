using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO.FacePlatform
{
    /// <summary>
    /// 楼栋，用户关联猫
    /// </summary>
    public class BuildingForMapDto
    {
        public int id { get; set; }
        /// <summary>
        /// 楼栋编码
        /// </summary>
        public string building_code { get; set; }
        /// <summary>
        /// 楼栋名称
        /// </summary>
        public string building_name { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string project_code { get; set; }
        /// <summary>
        /// 是否已关联
        /// </summary>
        public bool has_map { get; set; }
        /// <summary>
        /// 是否已选中
        /// </summary>
        public bool is_selected { get; set; }
    }
}
