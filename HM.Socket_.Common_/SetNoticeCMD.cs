using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common
{
    /// <summary>
    /// 设置通告命令 
    /// </summary>
    public class SetNoticeCMD
    {
        /// <summary>
        /// 例如: BlackCatId="01"
        /// 请使用：
        /// Constant.blackCatId
        /// </summary>
        public int BlackCatId { get; set; }
        /// <summary>
        /// 例如：Data="XXX"
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 例如：valid="00" 00:有效 01：无效
        /// 请使用：
        /// Constant.valid || Constant.inValid
        /// </summary>
        public string Valid { get; set; }
    }
}
