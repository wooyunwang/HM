namespace HM.Face.Common_.EyeCool
{
    public class PeopleCreateOutput : ResponseBase
    {
        /// <summary>
        /// 成功被加入的crowd数量
        /// </summary>
        public int added_crowd { get; set; }
        /// <summary>
        /// 成功加入的face数量
        /// </summary>
        public int added_face { get; set; }
        /// <summary>
        /// 操作结果提示
        /// </summary>
        public string tip { get; set; }
        /// <summary>
        /// people的name
        /// </summary>
        public string people_name { get; set; }
        /// <summary>
        /// people的id
        /// </summary>
        public string people_id { get; set; }
    }
}
