using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO.FacePlatform
{
    /// <summary>
    /// 进出历史数据传输对象
    /// </summary>
    public class EntryHistoryDto
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 抓取id
        /// </summary>
        public int snapshot_id { get; set; }
        /// <summary>
        /// 照片路径
        /// </summary>
        public string photo_path { get; set; }
        /// <summary>
        /// 得分
        /// </summary>
        public decimal score { get; set; }
        /// <summary>
        /// 人脸唯一标识
        /// </summary>
        public string face_uid { get; set; }
        /// <summary>
        /// 人脸一体机编号
        /// </summary>
        public string mao_no { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string project_code { get; set; }
        /// <summary>
        /// 小区用户唯一标识
        /// </summary>
        public string user_uid { get; set; }

        //public int mao_id { get; set; }
        //public string mao_name { get; set; }
        //public string mao_ip { get; set; }
        //public string mao_port { get; set; }
    }
}
