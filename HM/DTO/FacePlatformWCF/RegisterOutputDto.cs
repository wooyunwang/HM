using HM.Enum_.FacePlatform;
using HM.Utils_;
using System;

namespace HM.DTO.FacePlatform
{
    /// <summary>
    /// 小区用户人脸注册信息数据传输对象
    /// </summary>
    public class RegisterOutputDto : RegisterDto
    {
        /// <summary>
        /// 图片相对路径
        /// </summary>
        public string photo_path { get; set; }
    }
}
