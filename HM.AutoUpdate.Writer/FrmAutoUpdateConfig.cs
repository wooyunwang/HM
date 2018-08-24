using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Linq;

namespace HM.AutoUpdate.Writer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmAutoUpdateConfig : Form
    {
        /// <summary>
        /// 源信息
        /// </summary>
        SourceInfo _SourceInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FrmAutoUpdateConfig()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FrmAutoUpdateConfig_Load(object sender, System.EventArgs e)
        {
            this.dgvExclude.AutoGenerateColumns = false;

            btnProduce.Enabled = false;
            btnPublish.Enabled = false;
            #region 验证及数据初始化
            string path = Path.Combine(Environment.CurrentDirectory, "SourceInfo.json");

            if (!File.Exists(path))
            {
                OnMessage($"配置文件{path}不存在，初始化失败！");
                return;
            }

            string sourceJson = File.ReadAllText(path);

            try
            {
                _SourceInfo = AutoUpdate.Json_.GetObject<SourceInfo>(sourceJson);
            }
            catch (Exception ex)
            {
                OnMessage($"配置文件{path}解析失败：{ex.Message}");
                return;
            }

            Uri uri = new Uri(_SourceInfo.HostUrl);
            if (string.IsNullOrWhiteSpace(uri.AbsoluteUri))
            {
                OnMessage($"{lblHostUrl.Text}不是合法的Url地址");
                return;
            }

            txtHostUrl.Text = _SourceInfo.HostUrl;

            if (!string.IsNullOrWhiteSpace(_SourceInfo.DefaultSourceRootDirectory))
            {
                if (!Directory.Exists(_SourceInfo.DefaultSourceRootDirectory))
                {
                    Directory.CreateDirectory(_SourceInfo.DefaultSourceRootDirectory);
                }
            }
            else
            {
                _SourceInfo.DefaultSourceRootDirectory = Environment.CurrentDirectory;
                OnMessage($"默认程序源根{_SourceInfo.DefaultSourceRootDirectory}");
            }

            if (!string.IsNullOrWhiteSpace(_SourceInfo.DefaultPublishRootDirectory))
            {
                if (!Directory.Exists(_SourceInfo.DefaultPublishRootDirectory))
                {
                    Directory.CreateDirectory(_SourceInfo.DefaultPublishRootDirectory);
                }
            }
            else
            {
                _SourceInfo.DefaultPublishRootDirectory = Environment.CurrentDirectory;
                OnMessage($"默认程序源根{_SourceInfo.DefaultPublishRootDirectory}");
            }

            if (_SourceInfo.ZipInfos != null && !_SourceInfo.ZipInfos.Any(it => it.EntryPoint.EndsWith(".exe")))
            {
                OnMessage($"入口程序必须是.exe可执行文件");
                return;
            }

            cbxSource.DataSource = null;
            cbxSource.DataSource = _SourceInfo.ZipInfos;
            cbxSource.DisplayMember = "Name";
            cbxSource.ValueMember = "EntryPoint";
            #endregion
            btnProduce.Enabled = true;

            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSaveExclude.Visible = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        void OnMessage(string msg)
        {
            UIThread(() =>
            {
                if ((lstMsg.Text.Length + (msg ?? "").Length) > lstMsg.MaxLength)
                {
                    lstMsg.Text = DateTime.Now.ToString() + " " + msg;
                }
                else
                {
                    lstMsg.Text = DateTime.Now.ToString() + " " + msg
                        + Environment.NewLine + Environment.NewLine
                        + lstMsg.Text;
                }
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_SourceInfo == null)
            {
                dgvExclude.DataSource = null;
                dgvExclude.Refresh();
            }
            else
            {
                if (cbxSource.SelectedItem != null)
                {
                    btnPublish.Enabled = false;
                    var source = cbxSource.SelectedItem as ZipInfo;
                    dgvExclude.DataSource = source.Excludes;
                    dgvExclude.Refresh();
                    var sourceDirectory = GetSourceDirectory();
                    if (!Directory.Exists(sourceDirectory))
                    {
                        Directory.CreateDirectory(sourceDirectory);
                        OnMessage($"请将要发布的程序放至{sourceDirectory}目录下！");
                    }
                    else
                    {
                        DirectoryInfo dif = new DirectoryInfo(sourceDirectory);
                        if (!(dif.GetDirectories()?.Any() ?? false) && !(dif.GetFiles()?.Any() ?? false))
                        {
                            OnMessage($"请将要发布的程序放至{sourceDirectory}目录下！");
                        }
                    }
                }
                else
                {
                    OnMessage($"请选择程序类型！");
                    dgvExclude.DataSource = null;
                    dgvExclude.Refresh();
                }
            }
        }
        /// <summary>
        /// 获取源文件目录
        /// </summary>
        string GetSourceDirectory()
        {
            var source = cbxSource.SelectedItem as ZipInfo;
            string directoryName = Path.GetFileNameWithoutExtension(source.EntryPoint);
            return Path.Combine(_SourceInfo.DefaultSourceRootDirectory, "sources", directoryName);
        }
        /// <summary>
        /// 获取保存目录
        /// </summary>
        /// <returns></returns>
        string GetSaveDirectory()
        {
            var source = cbxSource.SelectedItem as ZipInfo;
            var entryPointPath = Path.Combine(GetSourceDirectory(), source.EntryPoint);
            if (File.Exists(entryPointPath))
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(entryPointPath);
                return Path.Combine(_SourceInfo.DefaultPublishRootDirectory, "updates", source.AppId, GetVersionStr(fvi));
            }
            else
            {
                OnMessage($"未能找到入口程序{entryPointPath},请确定已将文件放至指定目录！");
                return string.Empty;
            }
        }
        /// <summary>
        /// 获取版本字符串
        /// </summary>
        /// <param name="fvi"></param>
        /// <returns></returns>
        string GetVersionStr(FileVersionInfo fvi)
        {
            return fvi.ProductVersion;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未实现");
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未实现");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未实现");
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveExclude_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未实现");
        }
        /// <summary>
        /// 生成并自动批量改名(&G)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProduce_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnProduce.Enabled = false;

            var sourceDirectory = GetSourceDirectory();
            var saveDirectory = GetSaveDirectory();
            if (!string.IsNullOrWhiteSpace(saveDirectory))
            {
                DeleteFolder(saveDirectory);
                CopyFiles(sourceDirectory, saveDirectory, dgvExclude.DataSource == null ? null : dgvExclude.DataSource as List<Exclude>);
                WriteConfig(saveDirectory);
                btnPublish.Enabled = true;
            }
            btnProduce.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// 递归复制文件
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="targetDir"></param>
        /// <param name="lstExcludes"></param>
        private void CopyFiles(string sourceDir, string targetDir, List<Exclude> lstExcludes = null)
        {
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            foreach (string path in Directory.GetFileSystemEntries(sourceDir))
            {
                if (Directory.Exists(path))
                {
                    if (lstExcludes?.Any(it => it.AsExcludeType == ExcludeType.Directory && string.Compare(it.Expression, path.Replace(sourceDir, ""), true) == 0) ?? false)
                    {
                        OnMessage($"跳过目录：{path}");
                    }
                    else
                    {
                        DirectoryInfo dif = new DirectoryInfo(path);
                        var dir = path.Replace(sourceDir, targetDir);
                        CopyFiles(path, dir, lstExcludes);
                    }
                }
                else if (File.Exists(path))
                {
                    if (lstExcludes?.Any(it => it.AsExcludeType == ExcludeType.File && string.Compare(it.Expression, path.Replace(sourceDir, ""), true) == 0) ?? false)
                    {
                        OnMessage($"跳过文件：{path}");
                    }
                    else
                    {
                        File.Copy(path, path.Replace(sourceDir, targetDir) + AutoUpdate.UpdateHelper._ZipSuffix);
                    }
                }
            }
        }
        /// <summary>
        /// 递归清空文件夹
        /// </summary>
        /// <param name="dir"></param>
        void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir))
            {
                foreach (string str in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(str))
                    {
                        FileInfo fif = new FileInfo(str);
                        if (fif.Attributes != FileAttributes.Normal)
                        {
                            //避免文件属性为Readonly或Hidden时无权限问题
                            fif.Attributes = FileAttributes.Normal;
                        }
                        File.Delete(str);
                    }
                    else
                    {
                        DeleteFolder(str);
                    }
                }
                Directory.Delete(dir);
            }
        }
        /// <summary>
        /// 递归获取文件路劲集合
        /// </summary>
        /// <param name="rootdir"></param>
        /// <returns></returns>
        private StringCollection GetAllFiles(string rootdir)
        {
            StringCollection result = new StringCollection();
            GetAllFiles(rootdir, result);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentDir"></param>
        /// <param name="result"></param>
        private void GetAllFiles(string parentDir, StringCollection result)
        {
            int num;
            string[] directories = Directory.GetDirectories(parentDir);
            for (num = 0; num < directories.Length; num++)
            {
                this.GetAllFiles(directories[num], result);
            }
            string[] files = Directory.GetFiles(parentDir);
            for (num = 0; num < files.Length; num++)
            {
                result.Add(files[num]);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string MD5_hash(string path)
        {
            try
            {
                string strMD5 = ""; FileStream inputStream1 = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read); byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(inputStream1);
                inputStream1.Flush();
                inputStream1.Close();
                strMD5 = BitConverter.ToString(buffer).Replace("-", ""); long strlen;
                FileStream inputStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                strlen = inputStream.Length;
                inputStream.Flush();
                inputStream.Close();
                strMD5 += GetMD5(strlen.ToString());
                return strMD5;
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sDataIn"></param>
        /// <returns></returns>
        string GetMD5(string sDataIn)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveDir"></param>
        void WriteConfig(string saveDir)
        {
            var source = cbxSource.SelectedItem as ZipInfo;
            var entryPointPath = Path.Combine(GetSourceDirectory(), source.EntryPoint);
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(entryPointPath);
            FileInfo fileInfo = new FileInfo(entryPointPath);
            var appInfo = new AutoUpdate.AppInfo()
            {
                AppId = source.AppId,
                EntryPoint = fileInfo.Name,
                Version = fileVersionInfo.ProductVersion,
                Description = txtMemo.Text.Trim()
            };

            AutoUpdate.UpdateInfo updateInfo = new AutoUpdate.UpdateInfo
            {
                Mandatory = chkAllow.Checked,
                UpdateUrl = new Uri(new Uri(_SourceInfo.HostUrl), $@"updates/{ source.AppId }/").OriginalString,
                AppInfo = appInfo
            };

            string updateInfoFilePath = Path.Combine(saveDir, AutoUpdate.UpdateHelper._UpdateInfoFileName);
            if (File.Exists(updateInfoFilePath)) File.Delete(updateInfoFilePath);

            updateInfo.Files = new List<AutoUpdate.ZipFileInfo>();
            StringCollection allFiles = GetAllFiles(saveDir);
            this.prbProd.Visible = true;
            this.prbProd.Minimum = 0;
            this.prbProd.Maximum = allFiles.Count;
            for (int i = 0; i < allFiles.Count; i++)
            {
                var filePath = allFiles[i];
                FileInfo info = new FileInfo(filePath);
                AutoUpdate.ZipFileInfo zipFileInfo = new AutoUpdate.ZipFileInfo
                {
                    Key = MD5_hash(filePath.Trim()),
                    Name = info.FullName.Replace(saveDir, "").TrimStart('\\'),
                    Size = string.Format("{0} KB", new FileInfo(filePath).Length / 0x400L)
                };
                updateInfo.Files.Add(zipFileInfo);
                this.prbProd.Value = i;
            }
            File.WriteAllText(updateInfoFilePath, AutoUpdate.Json_.GetString(updateInfo));
            OnMessage("自动更新文件生成成功!");
            this.prbProd.Value = 0;
            this.prbProd.Visible = false;
        }

        /// <summary>
        /// 在需要的情况下，开辟新的线程更新UI
        /// </summary>
        /// <param name="methodInvoker"></param>
        public void UIThread(MethodInvoker methodInvoker)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(methodInvoker);
            }
            else methodInvoker();
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            var saveDir = GetSaveDirectory();
            var zipInfo = cbxSource.SelectedItem as ZipInfo;
            string updateInfoFilePath = Path.Combine(saveDir, AutoUpdate.UpdateHelper._UpdateInfoFileName);
            if (!File.Exists(updateInfoFilePath))
            {
                btnPublish.Enabled = false;
                OnMessage($"您所需要发布的{ AutoUpdate.UpdateHelper._UpdateInfoFileName }文件未生成！");
            }
            else
            {
                var publishPath = Path.Combine(_SourceInfo.DefaultPublishRootDirectory, $"updates", zipInfo.AppId, AutoUpdate.UpdateHelper._UpdateInfoFileName);
                var publishDirectory = new FileInfo(publishPath).Directory;
                if (!publishDirectory.Exists)
                {
                    publishDirectory.Create();
                }
                File.Copy(updateInfoFilePath, publishPath, true);
                OnMessage($"已将文件{updateInfoFilePath}复制至{publishPath}");
                OnMessage("开始下载测试");
                //测试下载
                AutoUpdate.UpdateHelper updateHelper = new AutoUpdate.UpdateHelper()
                {
                    _OnError = OnMessage
                };
                updateHelper.Init(publishPath);
                var updateInfo = updateHelper.DownAutoUpdateConfigFile();
                if (updateInfo != null)
                {
                    OnMessage("下载测试通过！");
                }
                else
                {
                    OnMessage("下载测试失败！");
                }
            }
        }
    }
}
