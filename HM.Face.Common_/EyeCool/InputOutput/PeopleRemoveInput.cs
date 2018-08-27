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
        public string face_id { get; set; }
    }
}