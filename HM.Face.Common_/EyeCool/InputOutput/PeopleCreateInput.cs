using System;
using System.Collections.Generic;

namespace HM.Face.Common_.EyeCool
{
    public class PeopleCreateInput : RequestBase
    {
        /// <summary>
        /// 用户对外id，万睿传插入，无uuid
        /// 一般传入CRM的用户ID，若非CRM用户，则自动产生
        /// </summary>
        public string people_id { get; set; }
        /// <summary>
        /// 人名， Name不能包含^,&=*'"等非法字符，且长度不得超过200。如果请求时不指定Name系统将随机产生一个name
        /// </summary>
        public string people_name { get; set; }
        /// <summary>
        /// 用户类型:拥有  居住  物业管理  临时人员
        /// </summary>
        public string tip { get; set; }
        /// <summary>
        /// 传入单个的项目编码
        /// <!--
        /// 按照黑猫一号与眼神之前的历史沟通结果：
        /// 需要人工在人脸一体机的Web端，系统配置-》小区门管理中，先新增对应的门，才可以调用此接口添加对应的人
        /// 若未添加，目前（2018-08-07）接口是可以添加人的。
        /// -->
        /// </summary>
        public string crowd_name { get; set; }
        /// <summary>
        /// 创建人时，唯一标识符
        /// </summary>
        public string cardNo { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public CertificateType cid { get; set; }
        /// <summary>
        /// 性别，1：男，0：女 默认1
        /// </summary>
        public int sex { get; set; }
        /// <summary>
        /// 人员所属房号,如”1205”
        /// </summary>
        public string fNo { get; set; }
        /// <summary>
        /// 出生日期(yyyy-MM-dd)
        /// </summary>
        public DateTime? birthday { get; set; }
        /// <summary>
        /// 注册渠道
        /// </summary>
        public RCType rctype { get; set; }
        /// <summary>
        /// 创建人手机号码，为精准营销做预留
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 到期日期(yyyy-MM-dd)
        /// </summary>
        public DateTime activeTime { get; set; }
        /// <summary>
        /// 猫编号
        /// </summary>
        public string cNO { get; set; }
    }
}
