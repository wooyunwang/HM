using System.Collections.Generic;

namespace HM.Face.Common_.EyeCool
{
    /// <summary>
    /// 操作结果true/false
    /// </summary>
    public class PersonCardSnapshotOutput
    {
        public bool success { get; set; }
        /// <summary>
        /// 返回抓拍比对图片集合
        /// </summary>
        public List<SnapShot> snapShotList { get; set; }
    }
    public class SnapShot
    {
        /// <summary>
        /// 抓拍记录ID
        /// </summary>
        public string snapShotId { get; set; }
        /// <summary>
        /// 抓拍时间
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 抓拍图片路径
        /// </summary>
        public string imageUrl { get; set; }
        /// <summary>
        /// 匹配得分
        /// </summary>
        public int? matchScore { get; set; }
    }
}