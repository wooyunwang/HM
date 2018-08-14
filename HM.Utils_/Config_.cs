using System;
using System.Configuration;
using System.Xml;

namespace HM.Utils_
{
    /// <summary>配置文件辅助类
    /// </summary>
    public sealed class Config_
    {
        #region 获取
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
                delegate ()
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
        #endregion

        #region 设置
        /// <summary>
        /// 保存配置文件的内容(这种方法需重启后才更新)
        /// </summary>
        /// <param name="configFileName"></param>
        /// <param name="configNodeName"></param>
        /// <param name="configValue"></param>
        public static void SaveConfig(string configFileName, string configNodeName, string configValue)
        {
            XmlDocument doc = new XmlDocument();
            //获得配置文件的全路径
            doc.Load(configFileName);
            //找出名称为“add”的所有元素
            XmlNodeList nodes = doc.GetElementsByTagName("add");
            for (int i = 0; i < nodes.Count; i++)
            {
                //获得将当前元素的key属性
                XmlAttribute att = nodes[i].Attributes["key"];
                if (att == null)
                    continue;
                //根据元素的第一个属性来判断当前的元素是不是目标元素
                if (att.Value == configNodeName)
                {
                    //对目标元素中的第二个属性赋值
                    att = nodes[i].Attributes["value"];
                    att.Value = configValue;
                    break;
                }
            }
            //保存上面的修改
            doc.Save(configFileName);
        }

        /// <summary>
        /// 保存配置文件的内容(这种方法保存后立刻更新)
        /// </summary>
        /// <param name="configNodeName"></param>
        /// <param name="configValue"></param>
        public static void SaveConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        #endregion
    }
}