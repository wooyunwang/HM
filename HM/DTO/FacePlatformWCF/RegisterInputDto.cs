using HM.Enum_.FacePlatform;
using HM.Utils_;
using System;

namespace HM.DTO.FacePlatform
{
    /// <summary>
    /// 小区用户人脸注册信息数据传输对象
    /// </summary>
    public class RegisterInputDto : RegisterDto
    {
        /// <summary>
        /// 图片Base64位字符串
        /// </summary>
        [Obsolete("待处理逻辑")]
        public string photo_string { get; set; }
    }
}
