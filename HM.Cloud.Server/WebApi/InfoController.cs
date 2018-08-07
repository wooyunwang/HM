using HM.Enum_;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HM.Cloud.Server.WebApi
{
    /// <summary>
    /// 消息
    /// </summary>
    [Authorize]
    public class InfoController : BaseApiController
    {
        ///// <summary>
        ///// 获取版本信息
        ///// </summary>
        ///// <returns></returns>
        //public Version GetVersion()
        //{
        //    return Assembly.GetEntryAssembly().GetName().Version;
        //}
        ///// <summary>
        ///// 获取文件版本信息
        ///// </summary>
        ///// <returns></returns>
        //public FileVersionInfo GetFileVersionInfo()
        //{
        //    Assembly assembly = Assembly.GetExecutingAssembly();
        //    AssemblyName assemblyName = assembly.GetName();
        //    return FileVersionInfo.GetVersionInfo(assembly.Location);
        //}
        ///// <summary>
        ///// 获取系统信息
        ///// </summary>
        ///// <returns></returns>
        //public IHttpActionResult GetOSInfo()
        //{
        //    return Json(Utils_.System_.OSInfo());
        //}
        ///// <summary>
        ///// 获取配置
        ///// </summary>
        ///// <param name="lstConfigName">配置名称</param>
        ///// <returns></returns>
        //public Dictionary<MasterControlConfigFileName, string> GetConfig([FromUri]List<MasterControlConfigFileName> lstConfigName)
        //{
        //    var dic = new Dictionary<MasterControlConfigFileName, string>();
        //    if (lstConfigName != null)
        //    {
        //        foreach (MasterControlConfigFileName configName in lstConfigName)
        //        {
        //            string strPath = Path.Combine(Environment.CurrentDirectory, "Config", configName.ToString() + ".config");
        //            if (File.Exists(strPath))
        //            {
        //                dic.Add(configName, File.ReadAllText(strPath));
        //            }
        //            else
        //            {
        //                dic.Add(configName, "");
        //            }
        //        }
        //    }
        //    return dic;
        //}

        public IHttpActionResult PostMasterControlConfig(string projectCode, byte catCode, MasterControlConfigFileName masterControlConfigFileName, [FromBody]string fileContent)
        {
            return Ok();
        }
    }
}
