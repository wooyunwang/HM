using System;
using System.Collections.Generic;
using System.Linq;

namespace HM.Face.Common_
{
    public class GetRegisterPageInput
    {
        public GetRegisterPageInput()
        {
            PageNumber = 1;
            PageSize = 50;
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? Endtime { get; set; }
        /// <summary>
        /// 每页记录数，为空则默认为50
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// 当前页，为空则默认为第1页
        /// </summary>
        public int? PageNumber { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// 数据类型（数组）
        /// </summary>
        public List<RegisterDataType> DataTypes { get; set; }
        /// <summary>
        /// 转换为眼神注册数据类型
        /// </summary>
        /// <returns></returns>
        public int[] GetEyeCookDataType()
        {
            return DataTypes?.Select(it => (int)it).ToArray();
        }
    }
    /// <summary>
    /// 注册数据类型
    /// </summary>
    public enum RegisterDataType
    {
        /// <summary>
        /// 注册审核已通过数据 0
        /// </summary>
        注册审核已通过数据 = 0,
        /// <summary>
        /// 注册审核未通过数据 1
        /// </summary>
        注册审核未通过数据 = 1,
        /// <summary>
        /// 注册待审核数据 2
        /// </summary>
        注册待审核数据 = 2
    }
}