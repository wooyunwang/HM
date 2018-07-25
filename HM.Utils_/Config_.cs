using System;
using System.Configuration;
namespace HM.Utils_
{
    /// <summary>配置文件辅助类
    /// </summary>
    public sealed class Config_
    {
        /// <summary>获得配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isRefresh"></param>
        /// <returns></returns>
        public static string GetString(string key, bool isRefresh = false)
        {
            string strCacheKey = "AppSettings-" + key;
            if (isRefresh)
            {
                Cache_.ClearCache(strCacheKey);
            }
            return Cache_.GetCacheItem<string>(strCacheKey,
                delegate()
                {
                    var obj = ConfigurationManager.AppSettings[key];
                    return (obj == null) ? "" : obj.ToString();
                },
                new TimeSpan(0, 30, 0));//30分钟过期
        }
        /// <summary>刷新所有配置的缓存
        /// </summary>
        /// <returns></returns>
        public static int Refresh()
        {
            foreach (var key in ConfigurationManager.AppSettings.AllKeys)
            {
                string strCacheKey = "AppSettings-" + key;
                Cache_.ClearCache(strCacheKey);
            }
            return ConfigurationManager.AppSettings.Count;
        }
        /// <summary>获得整型配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int? GetInt(string key)
        {
            return GetString(key).ToInt_();
        }
        /// <summary>获得整型配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static int GetInt(string key, int def)
        {
            return GetString(key).ToInt_() ?? def;
        }
        /// <summary>获得布尔型配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool? GetBool(string key)
        {
            return GetString(key).ToBool_();
        }
        /// <summary>获得布尔型配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static bool GetBool(string key, bool def)
        {
            return GetString(key).ToBool_() ?? def;
        }
        /// <summary>获得decimal型配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal? GetDecimal(string key)
        {
            return GetString(key).ToDecimal_();
        }
        /// <summary>获得decimal型配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string key, decimal def)
        {
            return GetString(key).ToDecimal_() ?? def;
        }
    }
}