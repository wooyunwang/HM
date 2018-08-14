using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Enum_.FacePlatform
{
    /// <summary>
    /// Id卡类型
    /// </summary>
    public enum IdType
    {
        /// <summary>
        /// 0	未知
        /// </summary>
        [Description("未知")]
        未知 = 0,
        /// <summary>
        /// 1	身份证
        /// </summary>
        [Description("身份证")]
        身份证 = 1,
    }
}
