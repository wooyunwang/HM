using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace HM.AutoUpdate
{
    /// <summary>
    /// 更新助手
    /// </summary>
    public class UpdateHelper
    {
        #region 成员与字段属性
        /// <summary>
        /// 压缩文件约定后缀
        /// </summary>
        public const string _ZipSuffix = "._.zip";
        public const string _UpdateInfoFileName = "UpdateInfo.json";
        /// <summary>
        /// 更新文件名称
        /// </summary>
        //public const string _UpdateInfoFileName = "UpdateInfo.json";
        /// <summary>
        /// 本地（历史）更新配置文件路径
        /// </summary>
        private string _LocalConfigFilePath { get; set; }
        /// <summary>
        /// 本地（历史）更新配置信息
        /// </summary>
        private UpdateInfo _LocalUpdateInfo { get; set; }
        /// <summary>
        /// 临时文件目录
        /// </summary>
        private string _TempUpdateDir { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public Action<string> _OnError { get; set; }

        #endregion
        public UpdateHelper()
        {

        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public bool Init()
        {
            string localConfigFilePath = Path.Combine(Application.StartupPath, _UpdateInfoFileName);
            return Init(localConfigFilePath);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="localConfigFilePath"></param>
        /// <returns></returns>
        public bool Init(string localConfigFilePath)
        {
            #region 确保Https可访问
            ServicePointManager.ServerCertificateValidationCallback +=
(sender1, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            #endregion

            _LocalConfigFilePath = localConfigFilePath;
            try
            {
                if (File.Exists(localConfigFilePath))
                {
                    //从本地读取更新配置文件信息
                    var strJson = File.ReadAllText(localConfigFilePath);
                    var updateInfo = Json_.GetObject<UpdateInfo>(strJson);
                    FixUpdateUrl(updateInfo);
                    _LocalUpdateInfo = updateInfo;
                    return true;
                }
                else
                {
                    if (_OnError != null)
                    {
                        _OnError("本地更新配置文件不存在，请联系技术人员处理！");
                    }
                }
            }
            catch (Exception ex)
            {
                if (_OnError != null)
                {
                    _OnError("读取本地更新配置文件出错：" + ex.Message + "，请联系技术人员处理！");
                }
            }
            return false;
        }
        /// <summary>
        /// 更新文件临时存储目录
        /// </summary>
        private string DefaultTempUpdateDir
        {
            get
            {
                var dirName = _LocalUpdateInfo?.AppInfo?.AppId?.Replace(".", "_");
                if (string.IsNullOrWhiteSpace(dirName))
                {
                    dirName = "VS" + DateTime.Today.ToString("yyyyMMdd");
                }
                return Path.Combine(System.Environment.GetEnvironmentVariable("TEMP"), dirName);
            }
        }
        /// <summary>
        /// 下载更新文件至临时目录
        /// </summary>
        /// <param name="downDir"></param>
        /// <returns></returns>
        public UpdateInfo DownAutoUpdateConfigFile(string downDir = null)
        {
            _TempUpdateDir = downDir ?? DefaultTempUpdateDir;

            if (!Directory.Exists(_TempUpdateDir))
            {
                Directory.CreateDirectory(_TempUpdateDir);
            }

            try
            {
                string updateUrl = _LocalUpdateInfo.UpdateUrl.TrimEnd('/') + "/";
                Uri uri = new Uri(new Uri(updateUrl), _UpdateInfoFileName);
                //关于先用WebRequest，再用WebClient，主要是基于性能问题的衡量
                WebRequest req = WebRequest.Create(uri);
                req.Timeout = 500;//文件不大半秒钟就可以知道网络是否通畅了！
                req.Proxy = null;//关闭代理，提高性能
                WebResponse res = req.GetResponse();
                res.Close();
                if (res.ContentLength > 0)
                {
                    try
                    {
                        WebClient wClient = new WebClient
                        {
                            Proxy = null //关闭代理，提高性能
                        };
                        string tempUpdateInfoFilePath = Path.Combine(_TempUpdateDir, _UpdateInfoFileName);
                        wClient.DownloadFile(uri, tempUpdateInfoFilePath);

                        var strJson = File.ReadAllText(tempUpdateInfoFilePath);
                        var updateInfo = Json_.GetObject<UpdateInfo>(strJson);
                        FixUpdateUrl(updateInfo);
                        return updateInfo;

                    }
                    catch (Exception ex)
                    {
                        if (_OnError != null)
                        {
                            _OnError("WebClient下载更新配置文件时出错：" + ex.Message);
                        }
                    }
                }
                else
                {
                    if (_OnError != null)
                    {
                        _OnError("更新配置文件内容丢失！");
                    }
                }
            }
            catch (Exception ex)
            {
                if (_OnError != null)
                {
                    _OnError("WebRequest下载更新配置文件时出错：" + ex.Message);
                }
            }
            return null;
        }
        /// <summary>
        /// 临时更新文件信息
        /// </summary>
        /// <param name="downDir"></param>
        /// <returns></returns>
        public UpdateInfo TempUpdateInfo(string downDir = null)
        {
            _TempUpdateDir = downDir ?? DefaultTempUpdateDir;
            string tempUpdateInfoFilePath = Path.Combine(_TempUpdateDir, _UpdateInfoFileName);
            if (File.Exists(tempUpdateInfoFilePath))
            {
                var strJson = File.ReadAllText(tempUpdateInfoFilePath);
                var updateInfo = Json_.GetObject<UpdateInfo>(strJson);
                FixUpdateUrl(updateInfo);
                return updateInfo;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 检查服务器是否有更新
        /// </summary>
        /// <param name="forceCheckRemote">默认需要从服务器检查</param>
        /// <returns></returns>
        public bool QuickVersionUpdate(bool forceCheckRemote = true)
        {
            UpdateInfo updateInfo = forceCheckRemote ? DownAutoUpdateConfigFile(DefaultTempUpdateDir) : TempUpdateInfo();
            if (updateInfo != null)
            {
                return updateInfo.AppInfo?.Version != _LocalUpdateInfo.AppInfo?.Version;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 检查更新文件（从服务器下载后在本地检查）
        /// </summary>
        /// <param name="forceCheckRemote">默认不需要从服务器检查</param>
        /// <returns>需要更新的文件列表</returns>
        public List<ZipFileInfo> CheckForUpdate(bool forceCheckRemote = true)
        {
            UpdateInfo updateInfo = forceCheckRemote ? DownAutoUpdateConfigFile(DefaultTempUpdateDir) : TempUpdateInfo();
            if (updateInfo != null)
            {
                var newFileInfos = updateInfo.Files ?? new List<ZipFileInfo>();
                var oldFileInfos = _LocalUpdateInfo.Files ?? new List<ZipFileInfo>();
                if (newFileInfos.Any() && !oldFileInfos.Any())
                {
                    return newFileInfos;
                }
                else
                {
                    return newFileInfos.Where(n => !oldFileInfos.Any(o => o.Name == n.Name && o.Key == n.Key)).ToList();
                }
            }
            else
            {
                return new List<ZipFileInfo>();
            }
        }
        /// <summary>
        /// 是否强制更新
        /// </summary>
        /// <param name="forceCheckRemote"></param>
        /// <returns></returns>
        public bool IsMandatoryUpdate(bool forceCheckRemote = false)
        {
            UpdateInfo updateInfo = forceCheckRemote ? DownAutoUpdateConfigFile(DefaultTempUpdateDir) : TempUpdateInfo();
            if (updateInfo != null)
            {
                if (updateInfo.AppInfo?.Version != _LocalUpdateInfo.AppInfo?.Version)
                {
                    return updateInfo.Mandatory;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #region 下载
        /// <summary>
        /// 处理全局更新进度
        /// </summary>
        public Action<int, int> _OnProgress { get; set; }
        /// <summary>
        /// 处理单个更新进度
        /// </summary>
        public Action<string, int> _OnPercent { get; set; }
        /// <summary>
        /// 从配置文件中提取的更新地址
        /// </summary>
        string _FixUpdateUrl { get; set; }
        /// <summary>
        /// 从配置文件中提取更新地址
        /// </summary>
        /// <param name="updateInfo"></param>
        public void FixUpdateUrl(UpdateInfo updateInfo)
        {
            if (updateInfo != null)
            {
                if (!string.IsNullOrWhiteSpace(_FixUpdateUrl))
                {
                    updateInfo.UpdateUrl = _FixUpdateUrl;
                }
                else
                {
                    var entryPoint = updateInfo?.AppInfo?.EntryPoint;
                    if (!string.IsNullOrWhiteSpace(entryPoint))
                    {
                        var configFileName = entryPoint + ".config";
                        var configFileFullName = Path.Combine(Environment.CurrentDirectory, configFileName);
                        if (File.Exists(configFileFullName))
                        {
                            XDocument doc = XDocument.Load(configFileFullName);
                            //查找所有节点
                            IEnumerable<XElement> element = doc.Element("configuration").Element("appSettings").Elements();
                            //遍历节点
                            foreach (XElement item in element)
                            {
                                if (item.Attribute("key") != null && item.Attribute("key").Value == "FixUpdateUrl")
                                {
                                    if (item.Attribute("value") != null)
                                    {
                                        string fixUpdateUrl = item.Attribute("value").Value;
                                        if (!string.IsNullOrWhiteSpace(fixUpdateUrl))
                                        {
                                            _FixUpdateUrl = fixUpdateUrl;
                                            updateInfo.UpdateUrl = _FixUpdateUrl;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 下载更新文件
        /// </summary>
        public List<Exception> DownUpdateFile()
        {

            List<ZipFileInfo> lstZipFileInfo = CheckForUpdate();
            UpdateInfo updateInfo = TempUpdateInfo();

            #region 关闭主程序进程
            var lstProcess = Process.GetProcesses().Where(it => it.ProcessName.ToLower() + ".exe" == updateInfo.AppInfo.EntryPoint.ToLower());
            if (lstProcess.Any())
            {
                foreach (Process p in lstProcess)
                {
                    for (int i = 0; i < p.Threads.Count; i++)
                        p.Threads[i].Dispose();
                    p.Kill();
                }
            }
            #endregion

            Stream srm = null;
            StreamReader srmReader = null;
            FileStream fs = null;
            string tempPath = string.Empty;
            List<Exception> lstMsg = new List<Exception>();
            var updateUrl = updateInfo.UpdateUrl.TrimEnd('/') + "/";

            foreach (var item in lstZipFileInfo)
            {
                try
                {
                    long fileLength = 0;
                    WebRequest webReq = WebRequest.Create(new Uri(new Uri(updateUrl), updateInfo.AppInfo.Version + "/" + item.Name.Replace("\\", "/")));
                    webReq.Proxy = null;
                    WebResponse webRes = webReq.GetResponse();
                    fileLength = webRes.ContentLength;
                    int hasDownByte = 0;
                    if (_OnProgress != null)
                    {
                        _OnProgress(hasDownByte, (int)fileLength);
                    }
                    srm = webRes.GetResponseStream();
                    srmReader = new StreamReader(srm);
                    byte[] bufferbyte = new byte[fileLength];
                    int allByte = (int)bufferbyte.Length;
                    int startByte = 0;

                    while (fileLength > 0)
                    {
                        int downByte = srm.Read(bufferbyte, startByte, allByte);
                        if (downByte == 0) { break; };
                        startByte += downByte;
                        allByte -= downByte;
                        hasDownByte += downByte;
                        if (_OnProgress != null)
                        {
                            _OnProgress(hasDownByte, (int)fileLength);
                        }
                        float part = (float)startByte / 1024;
                        float total = (float)bufferbyte.Length / 1024;
                        int percent = Convert.ToInt32((part / total) * 100);
                        if (_OnPercent != null)
                        {
                            _OnPercent(item.Key, percent);
                        }
                    }
                    tempPath = Path.Combine(_TempUpdateDir, item.Name);
                    var dir = new FileInfo(tempPath).Directory;
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }
                    fs = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Write(bufferbyte, 0, bufferbyte.Length);
                }
                catch (Exception ex)
                {
                    lstMsg.Add(ex);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                        fs.Dispose();
                    }
                    if (srmReader != null)
                    {
                        srmReader.Close();
                        srmReader.Dispose();
                    }
                    if (srm != null)
                    {
                        srm.Close();
                        srm.Dispose();
                    }
                }
            }
            return lstMsg;
        }
        #endregion
        /// <summary>
        /// 完成更新
        /// </summary>
        public void FinishUpdate()
        {
            if (!string.IsNullOrWhiteSpace(_TempUpdateDir))
            {
                //获取更新前的版本
                string strRunFullPath = Application.ExecutablePath;//Assembly.GetExecutingAssembly().Location
                string strRunFileName = Path.GetFileName(strRunFullPath);
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(strRunFileName);
                //将临时文件夹文件复制到当前目录
                CopyFile(_TempUpdateDir, Directory.GetCurrentDirectory());
                //删除临时目录下的所有文件
                Directory.Delete(_TempUpdateDir, true);
                //重新启动主程序
                ReStart(Path.Combine(Environment.CurrentDirectory, _LocalUpdateInfo.AppInfo.EntryPoint), fileVersionInfo.ProductVersion);
            }
        }
        /// <summary>
        /// 递归复制文件
        /// </summary>
        /// <param name="sourceDir">源目录</param>
        /// <param name="targetDir">目标目录</param>
        private void CopyFile(string sourceDir, string targetDir)
        {
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            string[] files = Directory.GetFiles(sourceDir);
            try
            {
                string strRunFullPath = Application.ExecutablePath;//Assembly.GetExecutingAssembly().Location
                string strRunFileName = Path.GetFileName(strRunFullPath);

                for (int i = 0; i < files.Length; i++)
                {
                    var tempFilePath = files[i];

                    if (tempFilePath.EndsWith("\\" + strRunFileName) || tempFilePath.EndsWith("\\" + strRunFileName + _ZipSuffix))//更新自己
                    {
                        string getExtension = Path.GetExtension(strRunFullPath);
                        string deletedFile = strRunFullPath.Replace(getExtension, ".delete");
                        if (File.Exists(deletedFile))
                        {
                            File.Delete(deletedFile);
                        }
                        File.Move(strRunFullPath, deletedFile);
                        File.Copy(tempFilePath, strRunFullPath);
                    }
                    else
                    {
                        FileInfo fif = new FileInfo(tempFilePath);
                        File.Copy(tempFilePath, Path.Combine(targetDir, fif.FullName?.Replace(sourceDir, targetDir))?.Replace(_ZipSuffix, ""), true);
                    }
                }
                string[] dirs = Directory.GetDirectories(sourceDir);
                for (int i = 0; i < dirs.Length; i++)
                {
                    DirectoryInfo dir = new DirectoryInfo(dirs[i]);
                    CopyFile(dirs[i], Path.Combine(targetDir, dir.Name));
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 推出程序
        /// </summary>
        /// <param name="processPath"></param>
        /// <param name="productVersion"></param>
        public void ReStart(string processPath, string productVersion)
        {
            var processName = Path.GetFileNameWithoutExtension(processPath);
            foreach (var process in Process.GetProcessesByName(processName))
            {
                if (process.MainModule.FileName == processPath)
                {
                    if (process.CloseMainWindow())
                    {
                        process.WaitForExit((int)TimeSpan.FromSeconds(10).TotalMilliseconds);
                    }
                    if (!process.HasExited)
                    {
                        process.Kill();
                    }
                }
            }
            Process.Start(processPath, productVersion);
        }
    }
}
