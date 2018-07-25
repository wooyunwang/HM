using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common
{
    /// <summary>
    /// 常量
    /// </summary>
    public static class Constant
    {
        /// <summary>
        /// 后同步信号
        /// </summary>
        public static byte[] postamble = new byte[] { 0xFF };
        /// <summary>
        /// 万科黑猫【VKHM】
        /// </summary>
        public static byte[] VKHM = new byte[] { 0x56, 0x4B, 0x42, 0x4D };
        /// <summary>
        /// 黑猫一号（编号）
        /// </summary>
        public static string blackCatId01 = "01";
        /// <summary>
        /// 黑猫一号（编号）
        /// </summary>
        public static byte catCode0x01 = 0x01;
        /// <summary>
        /// 有效
        /// </summary>
        public static string valid = "00";
        /// <summary>
        /// 无效
        /// </summary>
        public static string inValid = "01";

        /// <summary>
        /// 00H 成功
        /// </summary>
        public static byte ok = 0x00;
        /// <summary>
        /// 01H 失败
        /// </summary>
        public static byte bad = 0x01;
    }
}
