using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common
{
    /// <summary>
    /// 禁止(夜间)模式、高峰模式时间段、周期设置命令 
    /// </summary>
    public class SetTimeCMD
    {
        /// <summary>
        /// 例如: BlackCatId="01"
        /// </summary>
        public byte BlackCatId { get; set; }
        /// <summary>
        /// 例如：ForbidTime="23:00-07:00"
        /// </summary>
        public string ForbidTime { get; set; }
        /// <summary>
        /// 例如：HighTime="07:00-09:00&17:00-19:00"
        /// </summary>
        public string HighTime { get; set; }
        /// <summary>
        /// 例如：Week=1,2,4(禁止、高峰二者共用 )
        /// </summary>
        public string Week { get; set; }
        /// <summary>
        /// 设置禁行时间
        /// </summary>
        /// <param name="tuple"></param>
        public void SetForbidTime(Tuple<DateTime, DateTime> tuple)
        {
            ForbidTime = tuple.Item1.ToString("HH:mm") + "|" + tuple.Item2.ToString("HH:mm");//协议文档分隔符是“-”，主控程序实际解析是“|”
        }
        /// <summary>
        /// 设置高峰时间
        /// </summary>
        /// <param name="lstTuple"></param>
        public void SetHighTime(List<Tuple<DateTime, DateTime>> lstTuple)
        {
            List<string> lst = new List<string>();
            foreach (var tuple in lstTuple)
            {
                lst.Add(tuple.Item1.ToString("HH:mm") + "|" + tuple.Item2.ToString("HH:mm"));//协议文档分隔符是“-”，主控程序实际解析是“|”
            }
            HighTime = string.Join(",", lst);//协议文档分隔符是“&”，主控程序实际解析是“,”
        }
        /// <summary>
        /// 设置重复日
        /// </summary>
        /// <param name="weeks"></param>
        public void SetWeek(List<DayOfWeek> weeks)
        {
            //主控程序周日接收的是7，不是0
            Week = string.Join(",", weeks.Select(it => it == DayOfWeek.Sunday ? 7 : (int)it));
        }
    }
}
