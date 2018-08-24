using HM.FacePlatform.BLL;
using HM.Utils_;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.FacePlatform.BLL
{
    public partial class FacePlatformCache
    {
        /// <summary>
        /// 过期时间
        /// </summary>
        static TimeSpan _TimeOut = new TimeSpan(0, 30, 0);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<T> GetALL<T>() where T : class, new()
        {
            return Cache_.GetCacheItem<List<T>>(typeof(T).Name,
             delegate ()
             {
                 BaseBLL<T> bll = new BaseBLL<T>();
                 return bll.Get();
             },
             _TimeOut);
        }
        /// <summary>
        /// 获取重试次数，默认3次
        /// </summary>
        /// <returns></returns>
        public static int GetMaxRetryTime()
        {
            return Config_.GetInt("MaxRetryTime") ?? 3;
        }
        /// <summary>
        /// 获取图片最大大小，默认为2，返回值为 n* 1024 * 1024
        /// </summary>
        /// <returns></returns>
        public static int GetPictureMaxSize()
        {
            return (Config_.GetInt("PictureMaxSize") ?? 2) * 1024 * 1024;
        }
        /// <summary>
        /// 获取抓拍图片存储根目录
        /// </summary>
        /// <returns></returns>
        public static string GetCaptureDirectory()
        {
            string capturePath = Config_.GetString("CaptureDirectory");
            if (!string.IsNullOrWhiteSpace(capturePath))
            {
                capturePath = @"Photo\Capture";
            }
            capturePath = Path.Combine(Environment.CurrentDirectory, capturePath);
            if (!Directory.Exists(capturePath))
            {
                Directory.CreateDirectory(capturePath);
            }
            return capturePath;
        }
        /// <summary>
        /// 获取图片存储根目录
        /// </summary>
        /// <returns></returns>
        public static string GetPictureDirectory()
        {
            string picturePath = Config_.GetString("PictureDirectory");
            if (!string.IsNullOrWhiteSpace(picturePath))
            {
                picturePath = @"Photo\Picture";
            }
            picturePath = Path.Combine(Environment.CurrentDirectory, picturePath);
            if (!Directory.Exists(picturePath))
            {
                Directory.CreateDirectory(picturePath);
            }
            return picturePath;
        }
        /// <summary>
        /// 获取图片存储根目录
        /// </summary>
        /// <returns></returns>
        public static string GetCompressDirectory()
        {
            string picturePath = Config_.GetString("CompressDirectory");
            if (!string.IsNullOrWhiteSpace(picturePath))
            {
                picturePath = @"Photo\Picture";
            }
            picturePath = Path.Combine(Environment.CurrentDirectory, picturePath);
            if (!Directory.Exists(picturePath))
            {
                Directory.CreateDirectory(picturePath);
            }
            return picturePath;
        }
    }
}
