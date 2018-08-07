using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Socket_.Common_
{
    /// <summary>
    /// 输出点
    /// <![CDATA[
    /// 主控程序相关枚举
    /// ]]>
    /// </summary>
    public enum GPIOOutPinEnum : byte  
    {

        /// <summary>
        /// A门
        /// </summary>
        IOOUT_GPIO_MOTOR_A,//A门电机
        /// <summary>
        /// B门
        /// </summary>
        IOOUT_GPIO_MOTOR_B,//B门电机
        /// <summary>
        /// 仓内灯
        /// </summary>
        IOOUT_GPIO_LAMP_A,//仓内灯光
        /// <summary>
        /// 预留
        /// </summary>
        IOOUT_GPIO_4//输出保留
    }

}
