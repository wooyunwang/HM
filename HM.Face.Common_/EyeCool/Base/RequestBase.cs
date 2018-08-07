using Newtonsoft.Json;

namespace HM.Face.Common_.EyeCool
{
    /// <summary>
    /// 请求基类
    /// </summary>
    public class RequestBase
    {
        /// <summary>
        /// APP调用EyeKey API 的唯一标识
        /// </summary>
        public string app_id { get; set; }
        /// <summary>
        /// APP调用Eyekey API 时需要的密钥
        /// </summary>
        public string app_key { get; set; }
    }
}
