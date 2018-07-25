using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_
{
    /// <summary>
    /// 通行方式
    /// </summary>
    public enum SetDirectionCMD_Way
    {
        双向 = 0x01,
        单向进 = 0x02,
        单向出 = 0x03
    }
    /// <summary>
    /// 通行方向切换命令
    /// </summary>
    public class SetDirectionCMD
    {
        /// <summary>
        /// 黑猫编号
        /// 例如：Constant.catCode0x01
        /// </summary>
        public byte CatCode { get; set; }
        /// <summary>
        /// 通行方式
        /// </summary>
        public SetDirectionCMD_Way Way { get; set; }

        /// <summary>
        /// 将对象以Byte[]输出
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return new byte[] { CatCode, (byte)Way };
        }
    }
}
