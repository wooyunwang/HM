using System;
using System.Drawing;
using log4net;

namespace HM.FacePlatform.Server
{
    public class CommonHelper
    {
        public static void SaveThumbnailImage(string path, string savePath, double percent)
        {
            try
            {
                Image image = Image.FromFile(path);
                int width = Convert.ToInt32(image.Width * percent);
                int height = Convert.ToInt32(image.Height * percent);

                Image imageThumbnail = image.GetThumbnailImage(width, height, ThumbnailCallback, IntPtr.Zero);
                imageThumbnail.Save(savePath);
            }
            catch (Exception exception)
            {
                Common_.LogHelper.Error("产生缩略图失败:" + path, exception);
            }
        }

        public static bool ThumbnailCallback()
        {
            return false;
        }
    }
}
