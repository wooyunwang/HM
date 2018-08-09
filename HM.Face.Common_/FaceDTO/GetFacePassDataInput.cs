using System;

namespace HM.Face.Common_
{
    public class GetFacePassDataInput
    {
        /// <summary>
        /// 项目编号作为组名，为null时此字段不筛选
        /// </summary>
        public string ProjectCode { set; get; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime UpdateTime { set; get; }
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime? EndTime { set; get; }
        /// <summary>
        /// 每页展示数量
        /// </summary>
        public int PageSize { set; get; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageNumber { set; get; }
    }
}