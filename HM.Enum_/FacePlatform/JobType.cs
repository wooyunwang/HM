using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Enum_.FacePlatform
{
    /// <summary>
    /// 任务类型
    /// </summary>
    public enum JobType
    {
        /// <summary>
        /// 注册
        /// </summary>
        注册 = 1,
        /// <summary>
        /// 审核
        /// </summary>
        审核 = 2,
        /// <summary>
        /// 删除
        /// </summary>
        删除 = 3,
        /// <summary>
        /// 
        /// </summary>
        审核不通过 = 4
    }
}
