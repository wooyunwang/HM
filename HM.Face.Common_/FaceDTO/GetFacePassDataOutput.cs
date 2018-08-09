using HM.Face.Common_.EyeCool;
using System;
using System.Collections.Generic;

namespace HM.Face.Common_
{
    public class GetFacePassDataOutput
    {
        /// <summary>
        /// 注册猫ID
        /// </summary>
        public string CatCode { get; set; }
        /// <summary>
        /// 通行时间
        /// </summary>
        public DateTime Passtime { get; set; }
        /// <summary>
        /// 特征ID
        /// </summary>
        public string FaceId { get; set; }
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 值类型：(1-业主卡、2-身份证、3-唯一标识、4-其他卡号、5-共有卡)
        /// </summary>
        public CertificateType CertificateType { get; set; }
        /// <summary>
        /// 人脸通行集合
        /// </summary>
        public List<FacePassDataFaceObj> face_obj { get; set; }
    }

    /// <summary>
    /// 人脸通行
    /// </summary>
    public class FacePassDataFaceObj
    {
        /// <summary>
        /// 人脸图片路径
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 值
        /// <!--
        /// 接口类型有误
        /// -->
        /// </summary>
        public float Score { get; set; }
        /// <summary>
        /// 人脸ID
        /// </summary>
        public int FaceRowId { get; set; }
    }
}