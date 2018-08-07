using System;
using System.ComponentModel.DataAnnotations;

namespace HM.Face.Common_.EyeCool
{
    public class PeopleUpdateInput : RequestBase
    {
        /// <summary>
        /// 人员id
        /// </summary>
        public string people_id { set; get; }
        /// <summary>
        /// 人名
        /// <!--
        /// Name不能包含^,&=*'"等非法字符，且长度不得超过200。如果请求时不指定Name系统将随机产生一个name。
        /// -->
        /// </summary>
        [MaxLengthAttribute(200, ErrorMessage = "长度不得超过{0}")]
        public string people_name { set; get; }
        /// <summary>
        /// 可为组ID或组名称
        /// <!--
        /// 可以用一组逗号分割的crowd id或者crowd name列表。如果指定为crowd id或者crowd name列表，People将被create之后就会被加入到这些crowd中。
        /// -->
        /// </summary>
        public string crowd_name { set; get; }
        /// <summary>
        /// 创建人时，唯一标识符
        /// </summary>
        public string cardNo { set; get; }
        /// <summary>
        /// 唯一标识符类型(1-业主卡、2-身份证、3-唯一标识、4-其他卡号、5-共有卡)
        /// </summary>
        public string cid { set; get; }
        /// <summary>
        /// 性别，1：男，0：女 默认1
        /// </summary>
        public string sex { set; get; }
        /// <summary>
        /// 房号
        /// </summary>
        public string fNo { set; get; }
        /// <summary>
        /// 出生日期(yyyy-MM-dd)
        /// </summary>
        public string birthday { set; get; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string phone { set; get; }
        /// <summary>
        /// 到期日期(yyyy-MM-dd)
        /// </summary>
        public string activeTime { set; get; }
        /// <summary>
        /// 猫编号
        /// </summary>
        public string cNO { set; get; }
    }
}
