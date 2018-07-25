using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HM.Socket_.Common
{
    public enum ABDoorModeEnum : byte
    {
        AUTO = 0x00,
        /// <summary>
        /// 正常模式
        /// </summary>
        NORMAL = 0x02,
        /// <summary>
        /// 火警模式
        /// </summary>
        FIRE = 0x04,
        /// <summary>
        /// 高峰模式
        /// </summary>
        PEAK = 0x01,
        /// <summary>
        /// 闭锁模式
        /// </summary>
        CLOSE = 0x03,
        //自动模式：00H
        //禁止（夜间）模式：03H
        //高峰模式：01H
        //正常模式：02H
        //消防 04H
        ENTER = 0x06,//单进
        EXIT = 0x05,//单出
        BPEAK = 0x07,//B门高峰模式； 

    }
    /// <summary>
    /// 自定义报警GPIO映射对象，主控程序使用的是Dictionary序列化的结果
    /// </summary>
    public class GPIO_DicKey_Map
    {
        /// <summary>
        /// A门刷卡器
        /// </summary>
        [JsonProperty(PropertyName = "_IN_IC_A（A门刷卡器）")]
        public In_Port_Info _IN_IC_A { get; set; }
        /// <summary>
        /// 舱内补卡器
        /// </summary>
        [JsonProperty(PropertyName = "_IN_IC_B（舱内补卡器）")]
        public In_Port_Info _IN_IC_B { get; set; }
        /// <summary>
        /// A栏红外
        /// </summary>
        [JsonProperty(PropertyName = "_IN_IR_A（A栏红外）")]
        public In_Port_Info _IN_IR_A { get; set; }
        /// <summary>
        /// B栏红外
        /// </summary>
        [JsonProperty(PropertyName = "_IN_IR_B（B栏红外）")]
        public In_Port_Info _IN_IR_B { get; set; }
        /// <summary>
        /// 舱内红外
        /// </summary>
        [JsonProperty(PropertyName = "_IN_IR_ROOM（舱内红外）")]
        public In_Port_Info _IN_IR_ROOM { get; set; }
        /// <summary>
        /// 摇控器
        /// </summary>
        [JsonProperty(PropertyName = "_IN_PEAK_MODE_DETECTION（摇控器）")]
        public In_Port_Info _IN_PEAK_MODE_DETECTION { get; set; }
        /// <summary>
        /// 闸机对讲
        /// </summary>
        [JsonProperty(PropertyName = "_IN_TALK_A（闸机对讲）")]
        public In_Port_Info _IN_TALK_A { get; set; }
        /// <summary>
        /// 舱内对讲
        /// </summary>
        [JsonProperty(PropertyName = "_IN_TALK_ROOM（舱内对讲）")]
        public In_Port_Info _IN_TALK_ROOM { get; set; }
        /// <summary>
        /// 闸机控制
        /// </summary>
        [JsonProperty(PropertyName = "_OUT_MOTOR_A（闸机控制）")]
        public Out_Port_Info _OUT_MOTOR_A { get; set; }
        /// <summary>
        /// 玻璃门控制
        /// </summary>
        [JsonProperty(PropertyName = "_OUT_MOTOR_B（玻璃门控制）")]
        public Out_Port_Info _OUT_MOTOR_B { get; set; }
        /// <summary>
        /// A门磁状态
        /// </summary>
        [JsonProperty(PropertyName = "_IN_DOOR_A_CLOSE_STATUS（A门磁状态）")]
        public In_Port_Info _IN_DOOR_A_CLOSE_STATUS { get; set; }
        /// <summary>
        /// B门磁状态
        /// </summary>
        [JsonProperty(PropertyName = "_IN_DOOR_B_CLOSE_STATUS（B门磁状态）")]
        public In_Port_Info _IN_DOOR_B_CLOSE_STATUS { get; set; }
        /// <summary>
        /// 蓝牙开门
        /// </summary>
        [JsonProperty(PropertyName = "_IN_BLUETOOTH_A（蓝牙开门）")]
        public In_Port_Info _IN_BLUETOOTH_A { get; set; }
        /// <summary>
        /// A门按钮
        /// </summary>
        [JsonProperty(PropertyName = "_IN_BUTTON_A（A门按钮）")]
        public In_Port_Info _IN_BUTTON_A { get; set; }
        /// <summary>
        /// B门按钮
        /// </summary>
        [JsonProperty(PropertyName = "_IN_BUTTON_B（B门按钮）")]
        public In_Port_Info _IN_BUTTON_B { get; set; }
        /// <summary>
        /// 手自动(AUTO HAND)
        /// </summary>
        [JsonProperty(PropertyName = "AUTO_HAND(手自动)")]
        public string AUTO_HAND { get; set; }
        /// <summary>
        /// 是否自动
        /// </summary>
        public bool IsAuto
        {
            get
            {
                return AUTO_HAND == "AUTO";
            }
        }
        /// <summary>
        /// 模式
        /// </summary>
        [JsonProperty(PropertyName = "Mode(模式)")]
        public string Mode { get; set; }
    }
}
