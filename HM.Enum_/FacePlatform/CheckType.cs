using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Enum_.FacePlatform
{
    /// <summary>
    /// 审核类型
    /// </summary>
    public enum CheckType
    {
        /// <summary>
        /// 审核不通过 0
        /// </summary>
        审核不通过 = 0,
        /// <summary>
        /// 审核通过 1
        /// </summary>
        审核通过 = 1,
        /// <summary>
        /// 待审核 2
        /// </summary>
        待审核 = 2,
    }
}
