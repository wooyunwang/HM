using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.AutoUpdate
{
    /// <summary>
    /// 更新信息
    /// </summary>
    public class UpdateInfo
    {
        /// <summary>
        /// 更新地址
        /// </summary>
        public string UpdateUrl { get; set; }
        /// <summary>
        /// 应用信息
        /// </summary>
        public AppInfo AppInfo { get; set; }
        /// <summary>
        /// 是否强制更新
        /// </summary>
        public bool Mandatory { get; set; }
        /// <summary>
        /// 文件信息列表
        /// </summary>
        public List<ZipFileInfo> Files { get; set; }
    }

    public class BaseAppInfo
    {
        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 入口程序
        /// </summary>
        public string EntryPoint { get; set; }
    }
    /// <summary>
    /// 应用信息
    /// </summary>
    public class AppInfo : BaseAppInfo
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
    /// <summary>
    /// 压缩文件信息
    /// </summary>
    public class ZipFileInfo
    {
        /// <summary>
        /// 识别号
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public string Size { get; set; }
    }
}
