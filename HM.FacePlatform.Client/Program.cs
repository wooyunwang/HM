using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using HM.Common_;
using HM.DTO;
using HM.Utils_;
using Quartz;
using Quartz.Impl;

namespace HM.FacePlatform.Client
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
                string facePlatformDB = Config_.GetConnectionString("FacePlatformDB");
                SqlConnectionStringBuilder con = new SqlConnectionStringBuilder(facePlatformDB);
                LogHelper.Warn($"当前配置：数据库服务【{con.DataSource}】数据库【{con.InitialCatalog}】。如果不正确请退出，修改配置后重启服务");

                ActionResult actionResult = SystemParameter.Load();

                if (actionResult.IsSuccess)
                {
                    CommonHelper.GetLogger().Debug("服务启动成功, 如果需要退出, 请使用 Ctrl+C");

                    // 内部项目第一次启动时从微信端服务器初始化项目数据
                    string isInternalProject = CommonHelper.GetConfig("IsInternalProject");
                    string isInitialized = CommonHelper.GetConfig("IsInitialized");
                    if (isInternalProject == "1" && isInitialized == "0")
                    {
                        //CommonHelper.WriteConfig("LastPullDate", DateTime.Now.ToString());// 修改获取更新日期

                        PullBasicData pullBasicData = new PullBasicData();
                        pullBasicData.Execute(null);
                    }

                    IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                    scheduler.Start();
                    while (true) Console.ReadLine();
                }
                else
                {
                    LogHelper.Error(actionResult.ToAlertString());
                }
                Console.ReadLine();


                //using (WeChatService.WeChatServiceClient client = new WeChatService.WeChatServiceClient())
                //{
                //    try
                //    {
                //        string result = client.TestMethod();
                //        CommonHelper.GetLogger().Info("测试调用成功 " + result);
                //        client.Close();
                //    }
                //    catch (Exception ex)
                //    {
                //        client.Abort();
                //        CommonHelper.GetLogger().Error("测试调用失败：", ex);
                //    }

                //    Console.ReadLine();
                //}
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
