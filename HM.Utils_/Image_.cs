using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Utils_
{
    public class Image_
    {
        /// <summary>
        /// 图片通过base64编码转为字符串
        /// </summary>
        /// <param name="picturePath"></param>
        /// <returns></returns>
        public static string ImageToBase64(string picturePath)
        {
            try
            {
                return Convert.ToBase64String(File.ReadAllBytes(picturePath)).Replace("+", "%2B");
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
