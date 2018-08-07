namespace HM.Face.Common_.EyeCool
{
    /// <summary>
    /// 
    /// </summary>
    public class PeopleAddInput : RequestBase
    {
        public PeopleAddInput()
        {
            is_audit = true;
        }
        /// <summary>
        /// 人员ID
        /// People的id
        /// </summary>
        public string people_id { get; set; }
        /// <summary>
        /// 脸部特征ID
        /// face的id
        /// </summary>
        public string face_id { get; set; }
        /// <summary>
        /// 是否需要审核
        /// true:需要审核
        /// false:不需要审核  
        /// 默认需要审核
        /// </summary>
        [System.Obsolete("根据黑猫一号特别需要添加的属性", false)]
        public bool is_audit { get; set; }
    }
}