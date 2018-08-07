using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common_
{
    /// <summary>
    /// 人脸通行明细
    /// </summary>
    public class GetFaceEntranceDetailCMD
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
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// 人脸识别ID
        /// </summary>
        public string FaceID { get; set; }
        /// <summary>
        /// 个人ID？
        /// </summary>
        public string PersonID { get; set; }
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
