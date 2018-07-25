using HM.Form_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.AutoUpdate
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
