using Newtonsoft.Json;
using System;

namespace HM.Face.Common_.EyeCool
{
    public class CurrentDetailInput : RequestBase
    {
        public CurrentDetailInput()
        {
            pageSize = 50;
            pageNumber = 1;
            crowd_name = null;
        }
        /// <summary>
        /// 组名，黑猫一号以项目编号作为组名，为null时此字段不筛选
        /// </summary>
        public string crowd_name { set; get; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [JsonConverter(typeof(EyeCoolDateTimeConverter))]
        public DateTime updateTime { set; get; }
        /// <summary>
        /// 截止时间
        /// </summary>
        [JsonConverter(typeof(EyeCoolDateTimeConverter))]
        public DateTime? endtime { set; get; }
        /// <summary>
        /// 每页展示数量，为空则默认为50
        /// </summary>
        public int pageSize { set; get; }
        /// <summary>
        /// 当前页，为空则默认为第1页
        /// </summary>
        public int pageNumber { set; get; }
    }
}
