using AutoMapper;
using HM.Enum_.FacePlatform;
using HM.Face.Common_;
using HM.Face.Common_.EyeCool;
using HM.FacePlatform.Model;
using HM.Form_;
using Microsoft.Owin.Hosting;
using System;
using System.Threading;
using System.Windows.Forms;

namespace HM.FacePlatform
{
    static class Program
    {
        public static FrmLogin _Login = null;
        public static FrmMain _Mainform = null;
        /// <summary>
        /// 已登陆账号信息
        /// </summary>
        public static SystemUser _Account = null;

        /// <summary>
        /// 是否管理员
        /// </summary>
        /// <returns></returns>
        public static bool IsAdmin()
        {
            if (_Account != null)
            {
                return _Account.is_admin == IsAdminType.是;
            }
            return false;
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            FormHelper.SetAccess("Users", Application.StartupPath);

            //日志配置
            log4net.Config.XmlConfigurator.Configure();

            string strFullPath = Application.ExecutablePath;
            string strFileName = System.IO.Path.GetFileName(strFullPath);
            Mutex m = new Mutex(false, strFileName, out bool createdNew);

            if (createdNew)
            {
                FormHelper.SetZhCnCulturInfo();

                #region 映射
                AutoMapperConfiguration.Configure();
                #endregion

                #region 启动OWIN host 
                string baseAddress = Utils_.Config_.GetString("WebAppBaseAddress");
                baseAddress = string.IsNullOrWhiteSpace(baseAddress) ? "http://localhost:9200/" : baseAddress;
                WebApp.Start<Startup>(url: baseAddress);
                #endregion

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.Run(new FrmLogin());
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                HandleException((Exception)e.ExceptionObject);
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        public static void HandleException(Exception ex)
        {
            Common_.LogHelper.Error(ex);
        }
    }
}
