namespace HM.Face.Common_.EyeCool
{
    public class CrowdAddInput : RequestBase
    {
        /// <summary>
        /// 相应Crowd的 name
        /// </summary>
        public string crowd_name { get; set; }
        /// <summary>
        /// 人的people_id
        /// </summary>
        public string people_id { get; set; }
    }
}