using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Enum_.FacePlatform
{
    /// <summary>
    /// 注册途径
    /// </summary>
    public enum RegisterType
    {
        /// <summary>
        /// 未知
        /// </summary>
        未知 = 0,
        /// <summary>
        /// 
        /// </summary>
        微信注册 = 1,
        /// <summary>
        /// 手动注册（一般为Winform上注册）
        /// </summary>
        手动注册 = 2,
        /// <summary>
        /// 刷卡注册
        /// </summary>
        [Obsolete("2018-08-09与黑猫一号产品经理@邱洪波确认，因效果不好，弃用")]
        刷卡注册 = 3,
        /// <summary>
        /// 人脸一体机（猫）自动注册
        /// </summary>
        [Obsolete("非弃用，识别为此值，是因数据从人脸一体机上同步下来的")]
        人脸一体机自动注册 = 4,
        /// <summary>
        /// 人脸一体机（猫）手动注册
        /// </summary>
        [Obsolete("非弃用，识别为此值，是因数据从人脸一体机上同步下来的")]
        人脸一体机手动注册 = 5,
    }
}
