using System;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.ServiceModel;
using Quartz;
using Quartz.Impl;
using HM.Common_;
using HM.Utils_;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;

namespace HM.FacePlatform.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net.config"));

            string strFullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strFileName = System.IO.Path.GetFileName(strFullPath);
            Mutex m = new Mutex(false, strFileName, out bool createdNew);

            if (createdNew)
            {
                Console.Title = GetAppName(strFileName);
                DllImportHelper.DeleteMenuForPlatformConsoleWindow();
                DllImportHelper.DisbleMouseClick();

                SystemParameter.Init();

                string weChatDB = Config_.GetConnectionString("WeChatDB");
                SqlConnectionStringBuilder con = new SqlConnectionStringBuilder(weChatDB);

                LogHelper.Warn($"当前配置：数据库服务【{con.DataSource}】数据库【{con.InitialCatalog}】。如果不正确请退出，修改配置后重启服务");

                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                scheduler.Start();

                using (ServiceHost host = new ServiceHost(typeof(WeChatService)))
                {
                    host.Opened += (sender, e) => LogHelper.Info("服务启动成功, 如果需要退出, 请使用 Ctrl+C");
                    try
                    {
                        host.Open();

                        while (true) Console.ReadLine();

                        // host.Close();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error("服务启动失败：", ex);
                    }
                }

                Console.ReadLine();
            }
        }

        /// <summary>
        /// 获取应用名称
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        static string GetAppName(string strFileName)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(strFileName);
            return fvi.ProductName + " · v" + fvi.ProductVersion;
        }
    }
}
