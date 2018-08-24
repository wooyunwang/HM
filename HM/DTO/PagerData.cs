using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO
{
    public class PagerData<T> where T : class
    {
        /// <summary>
        /// 总数 
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int pages { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public List<T> rows { get; set; }
    }
}
