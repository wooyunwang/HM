using System;
using System.Collections.Generic;
using System.IO;
using HM.FacePlatform.Model;
using HM.Common_;
using System.Net;

namespace HM.FacePlatform.BLL
{
    public partial class RegisterBLL
    {
        /// 调用 Register 方法之前动作：
        /// 1.检测是否存在人脸新接口
        /// 2.如果已注册检测是否为同一人
        /// 3.保存图片到本地
        /// 4.保存数据到 register 表
        /// 
        /// Register 方法内部动作：
        /// 1.检测是否存在人脸旧接口->手动传入 face_id
        /// 2.调用注册接口->手动传入 people_id
        /// 3.更新 user 审核状态(isFirstMao=true)
        /// 4.写日志(isFirstMao=true)
        /// 
        /// 调用 Register 方法之后动作：
        /// 1.如果返回结果为false，保存数据到 mao_failed_job 表



        public string FileSaveAs(string sourceFilePath, string targetFilePath)
        {
            try
            {
                string fileExtension = Path.GetExtension(sourceFilePath);
                string targetFileName = Utils_.Key_.SequentialGuid() + fileExtension;
                File.Copy(sourceFilePath, Path.Combine(targetFilePath, targetFileName), true);
                return targetFileName;
            }
            catch (Exception ex)
            {
                LogHelper.Error("RegisterBLL.FileSaveAs: " + ex.Message);
                return string.Empty;
            }
        }


        public bool DownloadFaceFile(string sourcePath, string objectPath)
        {
            try
            {
                string fileName = Path.GetFileName(sourcePath);
                string finalObjectPath = Path.Combine(objectPath, fileName);
                WebClient webClient = new WebClient();
                webClient.DownloadFile(sourcePath, finalObjectPath);
            }
            catch (Exception ex)
            {
                LogHelper.Error("RegisterBLL.DownloadFaceFile: " + ex.Message);
                return false;
            }

            return true;
        }
    }
}
