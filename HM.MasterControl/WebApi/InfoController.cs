using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HM.MasterControl.WebApi
{
    /// <summary>
    /// 消息
    /// </summary>
    [Authorize]
    public class InfoController : BaseApiController
    {
        /// <summary>
        /// 获取版本信息
        /// </summary>
        /// <returns></returns>
        public Version GetVersion()
        {
            return Assembly.GetEntryAssembly().GetName().Version;
        }
        /// <summary>
        /// 获取文件版本信息
        /// </summary>
        /// <returns></returns>
        public FileVersionInfo GetFileVersionInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = assembly.GetName();
            return FileVersionInfo.GetVersionInfo(assembly.Location);
        }
        /// <summary>
        /// 获取系统信息
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetOSInfo()
        {
            return Json(Utils_.System_.OSInfo());
        }

        public string GetConfig()
        {
            return string.Empty;
        }
    }
}
