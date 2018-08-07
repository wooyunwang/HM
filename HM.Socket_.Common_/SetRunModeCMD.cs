using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common_
{
    /// <summary>
    /// 模式
    /// </summary>
    public enum SetRunModeCMD_Mode
    {
        自动模式 = 0x00,
        /// <summary>
        /// 禁止（夜间）模式，封锁模式 
        /// </summary>
        封锁模式 = 0x03,
        高峰模式 = 0x01,
        正常模式 = 0x02,

        单进 = 0x06,
        单出 = 0x05,
        B门高峰模式 = 0x07,
    }
    /// <summary>
    /// 设置模式：禁止（夜间）、高峰、正常（假期）、自动
    /// </summary>
    public class SetRunModeCMD
    {
        /// <summary>
        /// 黑猫编号
        /// </summary>
        public byte CatCode { get; set; }
        /// <summary>
        /// 模式
        /// </summary>
        public SetRunModeCMD_Mode Mode { get; set; }
        /// <summary>
        /// 将对象以Byte[]输出
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return new byte[] { CatCode, (byte)Mode };
        }
    }
}
