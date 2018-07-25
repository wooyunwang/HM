using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HM.Socket_.Common
{
    /// <summary>
    /// IC卡通行明细
    /// </summary>
    public class GetICCardEntranceDetailCMD
    {
        /// <summary>
        /// 原始json
        /// </summary>
        public string json { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// 猫编号
        /// </summary>
        public string CatCode { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string PersonName { get; set; }
        /// <summary>
        /// 房号
        /// </summary>
        public string RoomNo { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 服务端IP？
        /// </summary>
        public string ServerIP { get; set; }
        /// <summary>
        /// 服务端端口？
        /// </summary>
        public string ServerPort { get; set; }
    }
}
