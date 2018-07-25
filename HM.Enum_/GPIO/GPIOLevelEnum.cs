using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Enum_
{
    /// <summary>
    /// GPIO信号等级枚举
    /// </summary>
    public enum GPIOLevelEnum : byte
    {
        /// <summary>
        /// 低
        /// </summary>
        LEVEL_LOW = 0,
        /// <summary>
        /// 高
        /// </summary>
        LEVEL_HIGH = 1,
        /// <summary>
        /// ？
        /// </summary>
        LEVEL_BUTT
    }

}
