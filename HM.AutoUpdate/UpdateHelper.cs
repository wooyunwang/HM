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
    /// ��������
    /// </summary>
    public class UpdateHelper
    {
        #region ��Ա���ֶ�����
        /// <summary>
        /// ѹ���ļ�Լ����׺
        /// </summary>
        public const string _ZipSuffix = "._.zip";
        public const string _UpdateInfoFileName = "UpdateInfo.json";
        /// <summary>
        /// �����ļ�����
        /// </summary>
        //public const string _UpdateInfoFileName = "UpdateInfo.json";
        /// <summary>
        /// ���أ���ʷ�����������ļ�·��
        /// </summary>
        private string _LocalConfigFilePath { get; set; }
        /// <summary>
        /// ���أ���ʷ������������Ϣ
        /// </summary>
        private UpdateInfo _LocalUpdateInfo { get; set; }
        /// <summary>
        /// ��ʱ�ļ�Ŀ¼
        /// </summary>
        private string _TempUpdateDir { get; set; }
        /// <summary>
        /// ��Ϣ
        /// </summary>
        public Action<string> _OnError { get; set; }

        #endregion
        public UpdateHelper()
        {

        }
        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <returns></returns>
        public bool Init()
        {
            string localConfigFilePath = Path.Combine(Application.StartupPath, _UpdateInfoFileName);
            return Init(localConfigFilePath);
        }
        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="localConfigFilePath"></param>
        /// <returns></returns>
        public bool Init(string localConfigFilePath)
        {
            #region ȷ��Https�ɷ���
            ServicePointManager.ServerCertificateValidationCallback +=
(sender1, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            #endregion

            _LocalConfigFilePath = localConfigFilePath;
            try
            {
                if (File.Exists(localConfigFilePath))
                {
                    //�ӱ��ض�ȡ���������ļ���Ϣ
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
                        _OnError("���ظ��������ļ������ڣ�����ϵ������Ա����");
                    }
                }
            }
            catch (Exception ex)
            {
                if (_OnError != null)
                {
                    _OnError("��ȡ���ظ��������ļ�����" + ex.Message + "������ϵ������Ա����");
                }
            }
            return false;
        }
        /// <summary>
        /// �����ļ���ʱ�洢Ŀ¼
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
        /// ���ظ����ļ�����ʱĿ¼
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
                //��������WebRequest������WebClient����Ҫ�ǻ�����������ĺ���
                WebRequest req = WebRequest.Create(uri);
                req.Timeout = 500;//�ļ���������ӾͿ���֪�������Ƿ�ͨ���ˣ�
                req.Proxy = null;//�رմ����������
                WebResponse res = req.GetResponse();
                res.Close();
                if (res.ContentLength > 0)
                {
                    try
                    {
                        WebClient wClient = new WebClient
                        {
                            Proxy = null //�رմ����������
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
                            _OnError("WebClient���ظ��������ļ�ʱ����" + ex.Message);
                        }
                    }
                }
                else
                {
                    if (_OnError != null)
                    {
                        _OnError("���������ļ����ݶ�ʧ��");
                    }
                }
            }
            catch (Exception ex)
            {
                if (_OnError != null)
                {
                    _OnError("WebRequest���ظ��������ļ�ʱ����" + ex.Message);
                }
            }
            return null;
        }
        /// <summary>
        /// ��ʱ�����ļ���Ϣ
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
        /// ���������Ƿ��и���
        /// </summary>
        /// <param name="forceCheckRemote">Ĭ����Ҫ�ӷ��������</param>
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
        /// �������ļ����ӷ��������غ��ڱ��ؼ�飩
        /// </summary>
        /// <param name="forceCheckRemote">Ĭ�ϲ���Ҫ�ӷ��������</param>
        /// <returns>��Ҫ���µ��ļ��б�</returns>
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
        /// �Ƿ�ǿ�Ƹ���
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
        #region ����
        /// <summary>
        /// ����ȫ�ָ��½���
        /// </summary>
        public Action<int, int> _OnProgress { get; set; }
        /// <summary>
        /// ���������½���
        /// </summary>
        public Action<string, int> _OnPercent { get; set; }
        /// <summary>
        /// �������ļ�����ȡ�ĸ��µ�ַ
        /// </summary>
        string _FixUpdateUrl { get; set; }
        /// <summary>
        /// �������ļ�����ȡ���µ�ַ
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
                            //�������нڵ�
                            IEnumerable<XElement> element = doc.Element("configuration").Element("appSettings").Elements();
                            //�����ڵ�
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
        /// ���ظ����ļ�
        /// </summary>
        public List<Exception> DownUpdateFile()
        {

            List<ZipFileInfo> lstZipFileInfo = CheckForUpdate();
            UpdateInfo updateInfo = TempUpdateInfo();

            #region �ر����������
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
        /// ��ɸ���
        /// </summary>
        public void FinishUpdate()
        {
            if (!string.IsNullOrWhiteSpace(_TempUpdateDir))
            {
                //��ȡ����ǰ�İ汾
                string strRunFullPath = Application.ExecutablePath;//Assembly.GetExecutingAssembly().Location
                string strRunFileName = Path.GetFileName(strRunFullPath);
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(strRunFileName);
                //����ʱ�ļ����ļ����Ƶ���ǰĿ¼
                CopyFile(_TempUpdateDir, Directory.GetCurrentDirectory());
                //ɾ����ʱĿ¼�µ������ļ�
                Directory.Delete(_TempUpdateDir, true);
                //��������������
                ReStart(Path.Combine(Environment.CurrentDirectory, _LocalUpdateInfo.AppInfo.EntryPoint), fileVersionInfo.ProductVersion);
            }
        }
        /// <summary>
        /// �ݹ鸴���ļ�
        /// </summary>
        /// <param name="sourceDir">ԴĿ¼</param>
        /// <param name="targetDir">Ŀ��Ŀ¼</param>
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

                    if (tempFilePath.EndsWith("\\" + strRunFileName) || tempFilePath.EndsWith("\\" + strRunFileName + _ZipSuffix))//�����Լ�
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
        /// �Ƴ�����
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
