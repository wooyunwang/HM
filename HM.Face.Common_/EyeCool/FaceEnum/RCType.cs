using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Face.Common_.EyeCool
{
    /// <summary>
    /// 注册渠道
    /// </summary>
    public enum RCType
    {
        /// <summary>
        /// 自动注册
        /// </summary>
        [Obsolete("此类型2018-08-09与眼神@邱水银确认，已经不用")]
        自动注册 = 0,
        /// <summary>
        /// 微信注册
        /// <!--
        /// 代表从微信端注册
        /// ]]>
        /// </summary>
        微信注册 = 1,
        /// <summary>
        /// 手动注册
        /// <!--
        /// 代表从万科客户端注册
        /// -->
        /// </summary>
        手动注册 = 2,
    }
}
