using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common
{
    /// <summary>
    /// 模式
    /// </summary>
    public enum SynchronizeModeCMD_Mode : byte
    {
        自动模式 = 0x00,
        /// <summary>
        /// 禁止（夜间）模式，禁止（封锁）模式
        /// </summary>
        禁止通行模式 = 0x03,
        高峰模式 = 0x01,
        正常模式 = 0x02,

        #region 新增，参考HM.Socket_.Common.ABDoorModeEnum
        消防模式 = 0x04,
        单进 = 0x06,
        单出 = 0x05,
        B门高峰模式 = 0x07 
        #endregion
    }
    /// <summary>
    /// 获同步黑猫当前运行模式命令
    /// </summary>
    public class SynchronizeModeCMD
    {
        public SynchronizeModeCMD()
        {
        }
        public SynchronizeModeCMD(byte[] data)
        {
            if (data != null && data.Length != 2)
            {
                throw new Exception("数据异常");
            }
            else
            {
                CatCode = data[0];
                Mode = (SynchronizeModeCMD_Mode)data[1];
            }
        }
        /// <summary>
        /// 黑猫编号
        /// </summary>
        public byte CatCode { get; set; }
        /// <summary>
        /// 模式
        /// </summary>
        public SynchronizeModeCMD_Mode Mode { get; set; }
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
