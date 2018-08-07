using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common_
{
    /// <summary>
    /// 设置黑猫背景图片
    /// </summary>
    public class SetBlackCatBackGroundCMD
    {
        /// <summary>
        /// 猫编号
        /// 例如: BlackCatId="01"
        /// 请使用：
        /// Constant.blackCatId
        /// </summary>
        public int BlackCatId { get; set; }
        /// <summary>
        /// 图片地址
        /// 例如：path=\\10.1.250.149\\file-pdwy\scan\A.jpg
        /// </summary>
        public string ImagePath { get; set; }
    }
}
