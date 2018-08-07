namespace HM.Face.Common_.EyeCool
{
    public class MatchCompareInput : RequestBase
    {
        /// <summary>
        /// 人脸特征ID 第一个face的Id
        /// </summary>
        public string face_id1 { get; set; }
        /// <summary>
        /// 人脸特征ID 第二个face的Id
        /// </summary>
        public string face_id2 { get; set; }
    }
}