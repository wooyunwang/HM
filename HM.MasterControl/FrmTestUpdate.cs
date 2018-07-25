using HM.AutoUpdate;
using HM.Form_;
using HM.MasterControl.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HM.MasterControl
{
    public partial class FrmTestUpdate : HMForm
    {
        public FrmTestUpdate()
        {
            InitializeComponent();
            labelVersion.Text = string.Format("当前版本：", Assembly.GetEntryAssembly().GetName().Version);
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            //处理非XML AppCast文件的解析逻辑。
            //AutoUpdater.ParseUpdateInfoEvent += AutoUpdaterOnParseUpdateInfoEvent;
            //AutoUpdater.Start("https://rbsoft.org/updates/AutoUpdaterTest.json");
            //使用非管理员帐户运行更新过程
            //AutoUpdater.RunUpdateAsAdmin = false;
            //使用俄语版本
            //Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ru");
            //如果你想在用户点击下载按钮时打开下载页面
            //AutoUpdater.OpenDownloadPage = true;
            //若不想让用户在自动更新提醒窗口选择下次提醒时间，下面3行默认为两天后提醒
            //AutoUpdater.LetUserSelectRemindLater = false;
            //AutoUpdater.RemindLaterTimeSpan = RemindLaterFormat.Days;
            //AutoUpdater.RemindLaterAt = 2;
            //隐藏跳过按钮
            //AutoUpdater.ShowSkipButton = false;
            //隐藏下次提醒按钮
            //AutoUpdater.ShowRemindLaterButton = false;
            //设置个性化标题
            //AutoUpdater.AppTitle = "My Custom Application Title";
            //显示错误报告
            //AutoUpdater.ReportErrors = true;
            //完成下载后退出事件
            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
            //检查更新事件
            //AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            //通过代理访问xml更新文件
            //var proxy = new WebProxy("localproxyIP:8080", true) {Credentials = new NetworkCredential("domain\\user", "password")};
            //AutoUpdater.Proxy = proxy;
            //定时检查更新
            //System.Timers.Timer timer = new System.Timers.Timer
            //{
            //    Interval = 2 * 60 * 1000,
            //    SynchronizingObject = this
            //};
            //timer.Elapsed += delegate
            //{
            //    AutoUpdater.Start("https://rbsoft.org/updates/AutoUpdaterTest.xml");
            //};
            //timer.Start();
            AutoUpdater.Start("https://rbsoft.org/updates/AutoUpdaterTest.xml");
        }
        private void AutoUpdater_ApplicationExitEvent()
        {
            Text = @"Closing application...";
            Thread.Sleep(5000);
            Application.Exit();
        }

        private void AutoUpdaterOnParseUpdateInfoEvent(ParseUpdateInfoEventArgs args)
        {
            dynamic json = HM.Utils_.Json_.GetObject<dynamic>(args.RemoteData);
            args.UpdateInfo = new UpdateInfoEventArgs
            {
                CurrentVersion = json.version,
                ChangelogURL = json.changelog,
                Mandatory = json.mandatory,
                DownloadURL = json.url
            };
        }
        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args != null)
            {
                if (args.IsUpdateAvailable)
                {
                    DialogResult dialogResult;
                    if (args.Mandatory)
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"There is new version {args.CurrentVersion} available. You are using version {args.InstalledVersion}. This is required update. Press Ok to begin updating the application.", @"Update Available",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"There is new version {args.CurrentVersion} available. You are using version {
                                        args.InstalledVersion
                                    }. Do you want to update the application now?", @"Update Available",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);
                    }

                    if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                    {
                        try
                        {
                            //You can use Download Update dialog used by AutoUpdater.NET to download the update.
                            if (AutoUpdater.DownloadUpdate())
                            {
                                Application.Exit();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"There is no update available. Please try again later.", @"Update Unavailable",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(
                       @"There is a problem reaching update server. Please check your internet connection and try again later.",
                       @"Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCheckForUpdate_Click(object sender, EventArgs e)
        {
            //Uncomment below lines to select download path where update is saved.
            //FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //if (folderBrowserDialog.ShowDialog().Equals(DialogResult.OK))
            //{
            //    AutoUpdater.DownloadPath = folderBrowserDialog.SelectedPath;
            //    AutoUpdater.Mandatory = true;
            //    AutoUpdater.Start("https://rbsoft.org/updates/AutoUpdaterTest.xml");
            //}
            AutoUpdater.Mandatory = true;
            AutoUpdater.Start("https://rbsoft.org/updates/AutoUpdaterTest.xml");
        }
    }
}
