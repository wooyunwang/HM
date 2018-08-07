using System.Collections.Generic;
using Newtonsoft.Json;

namespace HM.Face.Common_.EyeCool
{
    public class PeopleRemoveInput : RequestBase
    {
        /// <summary>
        /// 人员ID
        /// <!--
        /// 人的people_id
        /// -->
        /// </summary>
        public string people_id { get; set; }
        /// <summary>
        /// 人脸特征ID
        /// </summary>
        public string face_id
        {
            get
            {
                if (faceIds != null && faceIds.Count > 0)
                {
                    return string.Join(",", faceIds);
                }
                else
                {
                    //不能返回Null，单元测试api报错
                    return "";
                }
            }
        }
        /// <summary>
        /// 人脸特征ID集合
        /// </summary>
        [System.Obsolete("此属性非接口参数", false)]
        [JsonIgnore]
        public List<string> faceIds { get; set; }
    }
}