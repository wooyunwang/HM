using System;
using System.Configuration;
using log4net;

namespace HM.FacePlatform.Client
{
    public class CommonHelper
    {
        public static ILog GetLogger()
        {
            return HM.Common_.LogHelper.GetIlog();
        }

        public static string GetConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void WriteConfig(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static DateTime AddSeconds(DateTime date, int seconds = 30)
        {
            return date.AddSeconds(seconds);
        }

        public static int GetSleepTime()
        {
            Random random = new Random();
            int sleepTime = random.Next(0, SystemParameter.MaxSleepSeconds * 1000);
            return sleepTime;
        }
    }
}
