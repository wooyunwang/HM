using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common
{
    /// <summary>
    /// 前后门
    /// </summary>
    public enum OpenCloseDoorCMD_DoorLocation : byte
    {
        /// <summary>
        /// 前门，即A门
        /// </summary>
        前门 = 0x00,
        /// <summary>
        /// 后门，即B门
        /// </summary>
        后门 = 0x01
    }
    /// <summary>
    /// 开门方式
    /// </summary>
    public enum OpenCloseDoorCMD_Switch : byte
    {
        开门 = 0x00,
        关门 = 0x01
    }
    /// <summary>
    /// 黑猫编号：01H
    /// 前后门：00H 前门，01H后门
    /// 开门方式：00H 开门，01H关门
    /// </summary>
    public class OpenCloseDoorCMD
    {
        /// <summary>
        /// 黑猫编号
        /// </summary>
        public byte CatCode { get; set; }
        /// <summary>
        /// 前后门
        /// </summary>
        public OpenCloseDoorCMD_DoorLocation DoorLocation { get; set; }
        /// <summary>
        /// 开门方式
        /// </summary>
        public OpenCloseDoorCMD_Switch Switch { get; set; }
        /// <summary>
        /// 将对象以Byte[]输出
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return new byte[] { (byte)CatCode, (byte)DoorLocation, (byte)Switch };
        }
    }
}
