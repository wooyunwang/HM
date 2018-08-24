using Newtonsoft.Json;

namespace HM.Face.Common_.EyeCool
{
    /// <summary>
    /// 审核输入
    /// </summary>
    public class ReviewPeopleInput : RequestBase
    {
        /// <summary>
        /// 人员编号
        /// <!--
        /// 人的people_id
        /// -->
        /// </summary>
        public string people_id { set; get; }
        /// <summary>
        /// 人脸特征值Id，为空，则按照people_id审核，不为空，则按照face_id审核
        /// </summary>
        public string face_id { set; get; }
        /// <summary>
        /// 审核状态
        /// <!--
        /// 0.待审核1通过2不通过（不通过代表禁用，可激活使用。）
        /// -->
        /// </summary>
        public ReviewState? state { set; get; }
        /// <summary>
        /// 组名称，黑猫一号以项目编号ProjectCode作为组名称
        /// </summary>
        public string crowd_name { set; get; }
        /// <summary>
        /// 审核描述(不超过200汉字,可以为空字符串)
        /// </summary>
        public string comments { set; get; }
    }
}
