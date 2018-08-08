using Newtonsoft.Json;
using System;

namespace HM.Face.Common_.EyeCool
{
    public class GetRegisterDataInput : RequestBase
    {
        public GetRegisterDataInput()
        {
            pageNumber = 1;
            pageSize = 50;
            app_id = Constant.APP_ID;
            app_key = Constant.APP_KEY;
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonConverter(typeof(EyeCoolDateTimeConverter))]
        public DateTime updateTime { get; set; }
        /// <summary>
        /// 结束时间，为空则查询到当前时间
        /// </summary>
        [JsonConverter(typeof(EyeCoolDateTimeConverter))]
        public DateTime? endtime { get; set; }
        /// <summary>
        /// 创建人来源，0自动注册、1微信注册、2手动注册，为空则为所有类型
        /// </summary>
        [Obsolete("2018-08-08此属性已确认作废")]
        public RCType? rctype { get; set; }
        /// <summary>
        /// 每页记录数，为空则默认为50
        /// </summary>
        public int? pageSize { get; set; }
        /// <summary>
        /// 当前页，为空则默认为第1页
        /// </summary>
        public int? pageNumber { get; set; }
        /// <summary>
        /// 组名称
        /// </summary>
        public string crowd_name { get; set; }
        /// <summary>
        /// 数据类型（数组）
        /// <!--
        /// 数据类型 ：0-注册审核已通过数据，1-注册审核未通过数据，2-注册待审核数据
        /// -->
        /// </summary>
        [System.Obsolete("根据黑猫一号特别需要添加的属性", false)]
        public int[] dataType { get; set; }
    }
}