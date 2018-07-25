using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common
{
    public class In_Port_Info
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
        /// 上次状态
        /// </summary>
        public GPIOLevelEnum _last_status;
        /// <summary>
        /// 上次状态时间
        /// </summary>
        public DateTime _last_time;
        /// <summary>
        /// 端口
        /// </summary>
        public GPIOInPinEnum _pin;
        public In_Port_Info(GPIOInPinEnum pin)
        {
            _pin = pin;
            _cur_status = GPIOLevelEnum.LEVEL_HIGH;
            _cur_time = DateTime.Now;
            _last_status = GPIOLevelEnum.LEVEL_HIGH;
            _last_time = DateTime.Now;
        }
    }
}
