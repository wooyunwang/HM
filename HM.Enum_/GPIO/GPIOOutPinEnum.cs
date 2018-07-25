using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Enum_
{
    /// <summary>
    /// GPIO板输出点枚举
    /// </summary>
    public enum GPIOOutPinEnum : byte
    {
        /// <summary>
        /// A门(电机)
        /// </summary>
        IOOUT_GPIO_MOTOR_A = 0,
        /// <summary>
        /// B门(电机)
        /// </summary>
        IOOUT_GPIO_MOTOR_B = 1,
        /// <summary>
        /// 仓内灯光
        /// </summary>
        IOOUT_GPIO_LAMP_A = 2,
        /// <summary>
        /// 预留
        /// </summary>
        IOOUT_GPIO_4 = 3
    }

}
