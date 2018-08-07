

namespace HM.Face.Common_.EyeCool
{
    public class PeopleUpdateOutput : ResponseBase
    {
        /// <summary>
        /// 人员ID
        /// </summary>
        public string people_id { set; get; }
        /// <summary>
        /// 操作结果true/false
        /// </summary>
        public bool success { set; get; }
    }
}
