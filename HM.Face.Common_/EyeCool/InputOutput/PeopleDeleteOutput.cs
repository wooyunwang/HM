namespace HM.Face.Common_.EyeCool
{
    public class PeopleDeleteOutput : ResponseBase
    {
        /// <summary>
        /// 成功删除的people数量
        /// </summary>
        public int deleted { get; set; }
        /// <summary>
        /// 操作是否成功标识true/false
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 成功删除的人脸数
        /// </summary>
        public int face_removed { get; set; }
    }
}