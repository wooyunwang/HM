using System;

namespace HM.Face.Common_
{
    /// <summary>
    /// 人脸版本
    /// </summary>
    public class FaceVersion
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime updateTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public Version version { get; set; }
    }
}