namespace HM.Face.Common_.EyeCool
{
    public class MatchCompareOutput : ResponseBase
    {
        /// <summary>
        /// 一个0~100之间的实数，表示两个face的相似性(值越大匹配度越高)
        /// </summary>
        public float similarity { get; set; }
        /// <summary>
        /// 操作是否成功标识true/false
        /// </summary>
        public bool success { get; set; }
    }
}