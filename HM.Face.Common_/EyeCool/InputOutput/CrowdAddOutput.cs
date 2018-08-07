namespace HM.Face.Common_.EyeCool
{
    public class CrowdAddOutput : ResponseBase
    {
        /// <summary>
        /// 成功加入的people数量
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 操作是否成功标识true/false
        /// </summary>
        public bool success { get; set; }
    }
}