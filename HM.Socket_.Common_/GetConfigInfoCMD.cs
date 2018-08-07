using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common_
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public class GetConfigInfoCMD
    {
        /// <summary>
        /// 猫编号
        /// </summary>
        public int BlackCatId { get; set; }
        /// <summary>
        /// 软件版本
        /// </summary>
        public string SoftVersion { get; set; }
        /// <summary>
        /// 系统信息
        /// </summary>
        public string OSInfo { get; set; }
        /// <summary>
        /// 硬件信息
        /// </summary>
        public string HardwareInfo { get; set; }
        /// <summary>
        /// 启动时间
        /// </summary>
        public string PowerOnTime { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        public string RunTimes { get; set; }
        /// <summary>
        /// 声卡配置信息
        /// </summary>
        public string VoiceConfigInfo { get; set; }
        /// <summary>
        /// 电视配置信息
        /// </summary>
        public string TVConfigInfo { get; set; }
        /// <summary>
        /// GPIO配置信息
        /// </summary>
        public string GPIOConfigInfo { get; set; }
        /// <summary>
        /// 人脸配置信息
        /// </summary>
        public string FaceConfigInfo { get; set; }
        /// <summary>
        /// ABDoor
        /// </summary>
        public string ABDoor { get; set; }
        /// <summary>
        /// ？
        /// </summary>
        public string UpdateRuntime { get; set; }
        /// <summary>
        /// ？
        /// </summary>
        public DateTime Date { get; set; }
    }
}
