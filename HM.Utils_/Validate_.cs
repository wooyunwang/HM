using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
namespace HM.Utils_
{
    /// <summary>
    /// 验证类
    /// </summary>
    public static class Validate_
    {
        #region 用户输入验证
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
        private static Regex RegEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        private static Regex RegMobile = new Regex(@"^1[3|4|5|7|8][0-9]\d{4,8}$");
        /// <summary>是否数字字符串
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }
        /// <summary>是否数字字符串 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }
        /// <summary>是否是浮点数
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }
        /// <summary>是否是浮点数 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }
        /// <summary>检测是否有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }
        /// <summary>中文
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsCHZN(string source)
        {
            return Regex.IsMatch(source, @"^[\u4e00-\u9fa5]+$", RegexOptions.IgnoreCase);
        }
        /// <summary>验证邮箱
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEmail(string source)
        {
            return Regex.IsMatch(source, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", RegexOptions.IgnoreCase);
        }
        /// <summary>验证网址
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsUrl(string source)
        {
            return Regex.IsMatch(source, @"^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$", RegexOptions.IgnoreCase);
        }
        /// <summary>验证手机号
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsMobile(string source)
        {
            return RegMobile.IsMatch(source);
        }
        /// <summary>是不是中国电话，格式010-85849685
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsTel(string source)
        {
            return Regex.IsMatch(source, @"^\d{3,4}-?\d{6,8}$", RegexOptions.IgnoreCase);
        }
        /// <summary>验证身份证是否有效
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool IsIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = IsIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = IsIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }
        /// <summary>是否18位的有效身份证
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool IsIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }
        /// <summary>是否15位的有效身份证
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool IsIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }
        /// <summary>邮政编码 6个数字
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsPostCode(string source)
        {
            return Regex.IsMatch(source, @"^\d{6}$", RegexOptions.IgnoreCase);
        }
        #endregion
        /// <summary>  
        /// 判断一个字符串是否为合法整数(不限制长度)  
        /// </summary>  
        /// <param name="s">字符串</param>  
        /// <returns></returns>  
        public static bool IsInteger(string s)
        {
            string pattern = @"^\d*$";
            return Regex.IsMatch(s, pattern);
        }
        /// <summary>
        /// 是否有效IP地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPAddress(string ip)
        {
            //^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$
            if (string.IsNullOrEmpty(ip) || ip.Length < 7 || ip.Length > 15) return false;
            string regformat = @"^((25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))$";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(ip);
        }
        /// <summary>
        /// 是否有效IP端口
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool IsIPPort(string port)
        {
            bool isPort = false;
            int portNum = 0;
            isPort = Int32.TryParse(port, out portNum);
            if (isPort && portNum >= 0 && portNum <= 65535)
            {
                isPort = true;
            }
            else
            {
                isPort = false;
            }
            return isPort;
        }
        /// <summary>
        /// 非法字符转换
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSafeString(ControlType conType, string str)
        {
            if (conType == ControlType.姓名类)
            {
                str = str.Replace("&", "");
                str = str.Replace("!", "");
                //str = str.Replace("'", "");
                str = str.Replace(":", "");
                str = str.Replace("/", "");
                str = str.Replace("?", "");
                str = str.Replace("<", "");
                str = str.Replace(">", "");
                str = str.Replace("#", "");
                str = str.Replace("%", "");
                str = str.Replace("^", "");
                str = str.Replace("//", "");
                str = str.Replace("@", "");
                str = str.Replace("*", "");
                str = str.Replace("~", "");
                str = str.Replace("`", "");
                str = str.Replace("$", "");

                //全角
                str = str.Replace("＆", "");
                str = str.Replace("！", "");
                str = str.Replace("’", "");
                str = str.Replace("：", "");
                str = str.Replace("？", "");
                str = str.Replace("＃", "");
                str = str.Replace("％", "");
                str = str.Replace("＠", "");
                str = str.Replace("×", "");
                str = str.Replace("～", "");
                str = str.Replace("￥", "");

                str = str.Replace("\"", "");
                str = str.Replace("'", "");
                str = str.Replace("“", "");
                return str;
            }
            else if (conType == ControlType.证件号类)
            {
                str = str.Replace("&", "");
                str = str.Replace("!", "");
                str = str.Replace(" ", "");
                //str = str.Replace("'", "");
                str = str.Replace(";", "");
                str = str.Replace(":", "");
                str = str.Replace("/", "");
                str = str.Replace("?", "");
                str = str.Replace("<", "");
                str = str.Replace(">", "");
                str = str.Replace(".", "");
                str = str.Replace("#", "");
                str = str.Replace("%", "");
                str = str.Replace("^", "");
                str = str.Replace("//", "");
                str = str.Replace("@", "");
                str = str.Replace("*", "");
                str = str.Replace("~", "");
                str = str.Replace("`", "");
                str = str.Replace("$", "");

                //全角
                str = str.Replace("＆", "");
                str = str.Replace("！", "");
                str = str.Replace(" ", "");
                str = str.Replace("‘", "");
                str = str.Replace("；", "");
                str = str.Replace("：", "");
                str = str.Replace("？", "");
                str = str.Replace("。", "");
                str = str.Replace("＃", "");
                str = str.Replace("％", "");
                str = str.Replace("＠", "");
                str = str.Replace("×", "");
                str = str.Replace("～", "");
                str = str.Replace("￥", "");

                str = str.Replace("\"", "");
                str = str.Replace("'", "");
                str = str.Replace("“", "");
                return str;
            }
            else//备注类
            {
                //str = str.Replace("'", "");
                //str = str.Replace(";", "");
                //str = str.Replace(":", "");
                str = str.Replace("/", "");
                str = str.Replace("?", "");
                str = str.Replace("<", "");
                str = str.Replace(">", "");
                //str = str.Replace(".", "");
                str = str.Replace("#", "");
                str = str.Replace("%", "");
                str = str.Replace("^", "");
                str = str.Replace("//", "");
                //str = str.Replace("@", "");
                str = str.Replace("*", "");
                str = str.Replace("~", "");
                str = str.Replace("`", "");
                //str = str.Replace("$", "");


                str = str.Replace("？", "");
                str = str.Replace("＃", "");
                str = str.Replace("％", "");
                str = str.Replace("×", "");
                str = str.Replace("～", "");

                str = str.Replace("\"", "");
                str = str.Replace("'", "");
                str = str.Replace("“", "");
                return str;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldString"></param>
        /// <returns></returns>
        public static string StringFilter(string oldString)
        {
            string NewString;
            //oldString = oldString.Replace("'", "''");
            oldString = oldString.Replace("[", "[[]");
            //oldString = oldString.Replace("]", "[]]");
            oldString = oldString.Replace("_", "[_]");
            oldString = oldString.Replace("*", "[*]");
            oldString = oldString.Replace("&", "[&]");
            oldString = oldString.Replace("%", "[%]");
            oldString = oldString.Replace("(", "[(]");
            oldString = oldString.Replace("\"", "");
            oldString = oldString.Replace("'", "");
            NewString = oldString.Replace("^", "");

            return NewString;
        }
    }

    public enum ControlType
    {
        姓名类,
        证件号类,
        备注类
    }
}
