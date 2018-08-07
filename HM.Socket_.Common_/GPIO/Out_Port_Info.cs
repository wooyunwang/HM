using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common_
{
    public class Out_Port_Info
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        public GPIOLevelEnum _cur_status;
        /// <summary>
        /// 当前状态时间
        /// </summary>
        public DateTime _cur_time;
        /// <summary>
        /// 
        /// </summary>
        public GPIOOutPinEnum _pin;
        public Out_Port_Info(GPIOOutPinEnum pin)
        {
            _pin = pin;
            _cur_status = GPIOLevelEnum.LEVEL_LOW;
            _cur_time = DateTime.Now;
        }
    }
}
