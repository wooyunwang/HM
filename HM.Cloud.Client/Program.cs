using HM.Form_;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace HM.Cloud.Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            FormHelper.SetAccess("Users", Application.StartupPath);

            string strFullPath = Application.ExecutablePath;
            string strFileName = System.IO.Path.GetFileName(strFullPath);
            Mutex m = new Mutex(false, strFileName, out bool createdNew);

            if (createdNew)
            {
                FormHelper.SetZhCnCulturInfo();

                #region 启动OWIN host 
                string baseAddress = Utils_.Config_.GetString("WebAppBaseAddress");
                baseAddress = string.IsNullOrWhiteSpace(baseAddress) ? "http://localhost:9400/" : baseAddress;
                WebApp.Start<Startup>(url: baseAddress);
                #endregion

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.Run(new FrmMain());
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is System.Exception)
            {
                HandleException((System.Exception)e.ExceptionObject);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        public static void HandleException(Exception ex)
        {
            Common_.LogHelper.Error(ex);
        }
    }
}
