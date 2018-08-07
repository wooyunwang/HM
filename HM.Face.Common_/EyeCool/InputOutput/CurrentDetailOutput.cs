using System;
using System.Collections.Generic;
namespace HM.Face.Common_.EyeCool
{
    public class CurrentDetailOutput
    {
        /// <summary>
        /// 注册猫ID
        /// </summary>
        public string cNo { get; set; }
        /// <summary>
        /// 通行时间
        /// </summary>
        public DateTime passtime { get; set; }
        /// <summary>
        /// 特征ID
        /// </summary>
        public string face_id { get; set; }
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string cardNo { get; set; }
        /// <summary>
        /// 值类型：(1-业主卡、2-身份证、3-唯一标识、4-其他卡号、5-共有卡)
        /// </summary>
        public CertificateType cid { get; set; }
        /// <summary>
        /// 人脸通行集合
        /// </summary>
        public List<CurrentDetailFaceObj> face_obj { get; set; }
    }
    /// <summary>
    /// 人脸通行
    /// </summary>
    public class CurrentDetailFaceObj
    {
        /// <summary>
        /// 人脸图片路径
        /// </summary>
        public string cat_image { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? createtime { get; set; }
        /// <summary>
        /// 值
        /// <!--
        /// 接口类型有误
        /// -->
        /// </summary>
        public float score { get; set; }
        /// <summary>
        /// 人脸ID
        /// </summary>
        public int face_id { get; set; }
    }
}
