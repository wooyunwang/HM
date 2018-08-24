using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.AutoUpdate.Writer
{
    /// <summary>
    /// 排除类型
    /// </summary>
    public enum ExcludeType
    {
        /// <summary>
        /// 文件夹
        /// </summary>
        Directory = 0,
        /// <summary>
        /// 文件
        /// </summary>
        File = 1
        /// <summary>
        /// 正则表达式,暂不支持
        /// </summary>
        //Regex = 2
    }
    /// <summary>
    /// 源
    /// </summary>
    public class ZipInfo : AutoUpdate.BaseAppInfo
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排除内容
        /// </summary>
        public List<Exclude> Excludes { get; set; }
    }
    /// <summary>
    /// 排除
    /// </summary>
    public class Exclude
    {
        /// <summary>
        /// 排除类型
        /// </summary>
        public string ExcludeType { get; set; }
        /// <summary>
        /// 排除表达式
        /// </summary>
        public string Expression { get; set; }
        /// <summary>
        /// 排除表达式描述
        /// </summary>
        public string ExpressionComment { get; set; }
        /// <summary>
        /// 排除类型（枚举）
        /// </summary>
        public ExcludeType AsExcludeType
        {
            get
            {
                ExcludeType result = HM.AutoUpdate.Writer.ExcludeType.File;
                if (Enum.TryParse<ExcludeType>(ExcludeType, true, out result)) { return result; }
                else
                {
                    return HM.AutoUpdate.Writer.ExcludeType.File;
                }
            }
        }
    }
    /// <summary>
    /// 源信息
    /// </summary>
    public class SourceInfo
    {
        /// <summary>
        /// 主机链接
        /// </summary>
        public string HostUrl { get; set; }
        /// <summary>
        /// 默认源根文件夹
        /// </summary>
        public string DefaultSourceRootDirectory { get; set; }
        /// <summary>
        /// 默认发布路径根文件夹
        /// </summary>
        public string DefaultPublishRootDirectory { get; set; }
        /// <summary>
        /// 源
        /// </summary>
        public List<ZipInfo> ZipInfos { get; set; }
    }
}
