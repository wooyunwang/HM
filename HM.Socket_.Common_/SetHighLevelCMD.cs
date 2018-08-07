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
    public enum SetHighLevelCMD_Mode
    {
        /// <summary>
        /// 禁止（夜间）模式 
        /// </summary>
        封锁模式 = 0x04,
        消防模式 = 0x05
    }
    /// <summary>
    /// 禁止(封锁)模式、消防模式命令
    /// </summary>
    public class SetHighLevelCMD
    {
        /// <summary>
        /// 模式
        /// </summary>
        public SetHighLevelCMD_Mode Mode { get; set; }
        /// <summary>
        /// 将对象以Byte[]输出
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return new byte[] { (byte)Mode };
        }
    }
}
