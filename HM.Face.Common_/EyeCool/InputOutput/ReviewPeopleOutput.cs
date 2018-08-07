namespace HM.Face.Common_.EyeCool
{
    /// <summary>
    /// 审核输出
    /// </summary>
    public class ReviewPeopleOutput : ResponseBase
    {
        /// <summary>
        /// 人员ID
        /// </summary>
        public string people_id { set; get; }
        /// <summary>
        /// 操作结果 true/false
        /// </summary>
        public bool success { get; set; }
    }
}