namespace HM.Face.Common_.EyeCool
{
    public class CrowdCreateInput : RequestBase
    {
        /// <summary>
        /// Crowd的Name信息，必须在App中全局唯一。Name不能包含&=*'"等非法字符，且长度不得超过200。Crowd_name也可为空，此时系统将随机产生一个crowd_name。
        /// </summary>
        public string crowd_name { get; set; }
        /// <summary>
        /// tip字符串，不能包含^,&=*'"等非法字符，长度不能超过255，系统预留字段。
        /// </summary>
        public string tip { get; set; }
    }
}