using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common
{
    /// <summary>
    /// 正常设置日期命令-节假日设置某天全天为正常模式 
    /// </summary>
    public class SetDateNormalCMD
    {
        /// <summary>
        /// 例如: BlackCatId="01"
        /// </summary>
        public int BlackCatId { get; set; }
        /// <summary>
        /// 例如：20160412,20160413,20160414
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 设置假期
        /// </summary>
        /// <param name="tuple"></param>
        public void SetDate(IEnumerable<DateTime> lstDate)
        {
            Date = string.Join(",", lstDate.Select(it => it.ToString("yyyyMMdd")));
        }
    }
}
