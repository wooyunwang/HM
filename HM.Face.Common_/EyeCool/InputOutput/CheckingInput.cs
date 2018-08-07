namespace HM.Face.Common_.EyeCool
{
    /// <summary>
    /// 检测
    /// </summary>
    public class CheckingInput : RequestBase
    {
        /// <summary>
        /// 认证图片
        /// 通过base64编码方式，原始图片大小不能大于3M；
        /// </summary>
        public string file { set; get; }
        /// <summary>
        /// tip字符串，不能包含^,&=*'"等非法字符，长度不能超过255，系统预留字段。
        /// </summary>
        public string tip { set; get; }
        /// <summary>
        /// 来源
        /// </summary>
        public RCType rctype { set; get; }
        /// <summary>
        /// 特征ID
        /// 万睿传插入，无uuid
        /// </summary>
        public string face_id { set; get; }

    }
}