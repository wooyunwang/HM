using HM.DTO;
using HM.Utils_;
using System;
using System.Configuration;
using System.IO;

namespace HM.FacePlatform.Server
{
    /// <summary>
    /// 系统参数
    /// </summary>
    public class SystemParameter
    {
        #region 阿里云OSS配置
        /// <summary>
        /// 阿里云OSS配置·端点
        /// </summary>
        public static string ali_endpoint
        {
            get
            {
                return Config_.GetString("ali_endpoint");
            }
        }
        /// <summary>
        /// 阿里云OSS配置·accessKeyId
        /// </summary>
        public static string ali_accessKeyId
        {
            get
            {
                return Config_.GetString("ali_accessKeyId");
            }
        }
        /// <summary>
        /// 阿里云OSS配置·accessKeySecret
        /// </summary>
        public static string ali_accessKeySecret
        {
            get
            {
                return Config_.GetString("ali_accessKeySecret");
            }
        }
        /// <summary>
        /// 阿里云OSS配置·bucketName
        /// </summary>
        public static string ali_bucketName
        {
            get
            {
                return Config_.GetString("ali_bucketName");
            }
        }
        #endregion

        /// <summary>
        /// 父目录
        /// </summary>
        public static string parentDirectory
        {
            get
            {
                return Config_.GetString("parentDirectory");
            }
        }
        /// <summary>
        /// 图片文件夹
        /// </summary>
        public static string photoFolder
        {
            get
            {
                return Config_.GetString("photoFolder");
            }
        }
        /// <summary>
        /// 压缩图片文件夹
        /// </summary>
        public static string photoZipFolder
        {
            get
            {
                return Config_.GetString("photoZipFolder");
            }
        }
        /// <summary>
        /// 抓拍图片文件夹
        /// </summary>
        public static string snapshotFolder
        {
            get
            {
                return Config_.GetString("snapshotFolder");
            }
        }
        /// <summary>
        /// 是否从OSS上删除
        /// </summary>
        public static bool isDeleteFromOss
        {
            get
            {
                return Config_.GetBool("isDeleteFromOss") ?? true;
            }
        }
        /// <summary>
        /// 临时文件路径
        /// </summary>
        public static string tempPhotoPath
        {
            get
            {
                return Config_.GetString("tempPhotoPath");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static decimal thumbnailPercent
        {
            get
            {
                return Config_.GetDecimal("thumbnailPercent") ?? 0.5M;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static ActionResult Init()
        {
            ActionResult actionResult = new ActionResult();
            if (!Directory.Exists(tempPhotoPath))
            {
                try
                {
                    Directory.CreateDirectory(tempPhotoPath);
                }
                catch (Exception ex)
                {
                    actionResult.Add(ex);
                }
            }
            else
            {
                try
                {
                    DirectoryInfo directory = new DirectoryInfo(tempPhotoPath);
                    foreach (FileInfo file in directory.GetFiles("*.*")) file.Delete();//清除缓存图片
                }
                catch (Exception ex)
                {
                    actionResult.Add(ex);
                }
            }
            return actionResult;
        }
    }
}
