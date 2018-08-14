using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Enum_.FacePlatform
{
    /// <summary>
    /// 数据来源
    /// </summary>
    public enum DataFromType
    {
        /// <summary>
        /// 未知
        /// </summary>
        未知 = 0,
        /// <summary>
        /// CRM
        /// </summary>
        CRM = 1,
        /// <summary>
        /// 导入
        /// </summary>
        导入 = 2,
        /// <summary>
        /// 手动添加
        /// </summary>
        手动添加 = 3,
        /// <summary>
        /// 人脸一体机自动添加
        /// </summary>
        人脸一体机自动添加 = 4,
        /// <summary>
        /// 微信添加
        /// </summary>
        微信添加 = 5,
        /// <summary>
        /// 人脸一体机手动添加
        /// </summary>
        人脸一体机手动添加 = 6,
    }
}
