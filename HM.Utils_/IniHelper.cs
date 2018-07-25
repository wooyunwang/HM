using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace HM.Utils_
{
    public partial class IniHelper
    {
        private static string iniFileName = AppDomain.CurrentDomain.BaseDirectory + @"\Config.ini";

        #region 读取INI文件
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="IniKey"></param>
        /// <returns></returns>
        public static string IniValue(string Section, string IniKey)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, IniKey, "", temp, 500, iniFileName);
            return temp.ToString();
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        #region 写INI文件
        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="IniKey"></param>
        /// <returns></returns>
        public static long WriteValue(string Section, string IniKey, string NewValue)
        {
            long i = WritePrivateProfileString(Section, IniKey, NewValue, iniFileName);
            return i;
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
            string section, string key, string val, string filePath);
        #endregion


    }
}