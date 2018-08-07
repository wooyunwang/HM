namespace HM.Face.Common_.EyeCool
{
    public class PeopleRemoveOutput : ResponseBase
    {
        /// <summary>
        /// 成功删除的face数量
        /// </summary>
        public int face_removed { get; set; }
        /// <summary>
        /// 操作是否成功标识true/false
        /// </summary>
        public bool success { get; set; }
    }
}