using System;
using System.IO;
using Aliyun.OSS;

namespace HM.FacePlatform.Server
{
    public class AliyunOssHelper
    {
        public static string bucketName = SystemParameter.ali_bucketName;

        public static OssClient ossClient = new OssClient(SystemParameter.ali_endpoint
            , SystemParameter.ali_accessKeyId, SystemParameter.ali_accessKeySecret);

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="toSavePath">存储路径</param>
        /// <param name="fileToUpload">本地路径</param>
        public static void Upload(string toSavePath, string fileToUpload)
        {
            ossClient.PutObject(bucketName, toSavePath, fileToUpload);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="savedPath">存储路径</param>
        /// <param name="fileToDownload">本地保存路径</param>
        public static void Download(string savedPath, string fileToDownload)
        {
            var file = ossClient.GetObject(bucketName, savedPath);
            using (var requestStream = file.Content)
            {
                byte[] buf = new byte[1024];
                var fs = File.Open(fileToDownload, FileMode.OpenOrCreate);
                var len = 0;
                while ((len = requestStream.Read(buf, 0, 1024)) != 0)
                {
                    fs.Write(buf, 0, len);
                }
                fs.Close();
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="savedPath">存储路径</param>
        /// <returns>Base64String</returns>
        public static string Download(string savedPath)
        {
            var file = ossClient.GetObject(bucketName, savedPath);
            if (file.ContentLength > 0)
            {
                using (var ms = file.Content)
                {
                    byte[] arr = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(arr, 0, (int)ms.Length);
                    ms.Close();
                    return Convert.ToBase64String(arr);
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="toDeletePath">存储路径</param>
        public static void Delete(string toDeletePath)
        {
            ossClient.DeleteObject(bucketName, toDeletePath);
        }
    }
}
