

namespace HM.Face.Common_.EyeCool
{
    public class PeopleAddOutput : ResponseBase
    {
        public string face_added { get; set; }
        /// <summary>
        /// 表示操作是否成功 true/false
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 空为成功
        /// 不为空提示此照片已绑定用户***
        /// </summary>
        public string tip { get; set; }
        /// <summary>
        /// 人员ID
        /// </summary>
        public string people_id { get; set; }
        /// <summary>
        /// 人员名称
        /// </summary>
        public string people_name { get; set; }
        /// <summary>
        /// 1:已审核,0:未审核
        /// </summary>
        [System.Obsolete("根据黑猫一号特别需要添加的属性", false)]
        public int? is_audited { get; set; }
    }
}