using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Enum_
{
    /// <summary>
    /// 主控程序配置文件名称
    /// </summary>
    public enum MasterControlConfigFileName
    {
        /// <summary>
        /// 人流量
        /// </summary>
        [Description("人流量")]
        PeoplecounterInfo,
        /// <summary>
        /// 广告机
        /// </summary>
        [Description("广告机")]
        TVConfigInfo,
        /// <summary>
        /// 语音板
        /// </summary>
        [Description("语音板")]
        VoiceConfigInfo,
        /// <summary>
        /// GPIO板
        /// </summary>
        [Description("GPIO板")]
        GPIOConfigInfo,
        /// <summary>
        /// Ping
        /// </summary>
        [Description("Ping")]
        PingEntity,
        /// <summary>
        /// 人流量
        /// </summary>
        [Description("人流量")]
        AppTimer
    }
}
