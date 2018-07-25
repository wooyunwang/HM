using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Enum_
{
    /// <summary>
    /// GPIO板输入点枚举
    /// </summary>
    public enum GPIOInPinEnum : byte //这里的顺序需与IOPortReg数组对应
    {
        /// <summary>
        /// A门对讲开锁
        /// </summary>
        IN_A_DOOR_TALK_UNLOCK = 0,
        /// <summary>
        /// 仓内刷卡开锁
        /// </summary>
        IN_ROOM_CARD_READER_UNLOCK = 1,
        /// <summary>
        /// A门读卡开锁
        /// </summary>
        IN_A_DOOR_CARD_READER_UNLOCK = 2,
        /// <summary>
        /// 吸顶红外检测
        /// </summary>
        IN_ROOM_IR_DETECTION = 3,
        /// <summary>
        /// B门红外对射
        /// </summary>
        IN_B_DOOR_IR_DETECTION = 4,
        /// <summary>
        /// A门红外对射
        /// </summary>
        IN_A_DOOR_IR_DETECTION = 5,
        /// <summary>
        /// B门关门状态
        /// </summary>
        IN_B_DOOR_CLOSED_STATUS = 6,
        /// <summary>
        /// A门关门状态
        /// </summary>
        IN_A_DOOR_CLOSED_STATUS = 7,
        /// <summary>
        /// 仓内对讲开锁
        /// </summary>
        IN_ROOM_TALK_UNLOCK = 8,
        /// <summary>
        /// A门开门按钮
        /// </summary>
        IN_A_DOOR_BUTTON_UNLOCK = 9,
        /// <summary>
        /// B门开门按钮
        /// </summary>
        IN_B_DOOR_BUTTON_UNLOCK = 10,
        /// <summary>
        /// A门蓝牙开锁
        /// </summary>
        IN_A_DOOR_BLUETOOTH_UNLOCK = 11,
        /// <summary>
        /// 高峰模式检测      保留5
        /// </summary>
        IN_PEAK_MODE_DETECTION = 18,
        /// <summary>
        /// 周界报警            保留4
        /// </summary>
        IN_PREIMETER_DETECTION = 17,

        //RESV5 = 18,
        //RESV4 = 19
    }

}
