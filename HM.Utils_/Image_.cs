using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace HM.Utils_
{
    /// <summary>
    /// 图压缩片、转换辅助类
    /// </summary>
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
        /// <summary>
        /// base64编码的文本 转为    图片
        /// </summary>
        /// <param name="inputStr"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool Base64StringToImage(string inputStr, string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                byte[] arr = Convert.FromBase64String(inputStr);
                using (MemoryStream ms = new MemoryStream(arr))
                {
                    Bitmap bmp = new Bitmap(ms);
                    bmp.Save(filePath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 读取图片，避免修改的时候提示被占用
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Image ReadImage(string path)
        {
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        return new Bitmap(ms);
                    }
                }
            }
            else
            {
                return null;
            }
        }
        #region 图片格式转换
        /// <summary>
        /// 图片格式转换
        /// </summary>
        /// <param name="originFileName">原始文件相对路径</param>
        /// <param name="desiredFilename">生成目标文件相对路径</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// JPG采用的是有损压缩所以JPG图像有可能会降低图像清晰度，而像素是不会降低的
        /// GIF采用的是无损压缩所以GIF图像是不会降低原图图像清晰度和像素的，但是GIF格式只支持256色图像。
        public static bool ConvertImage(string originFileName, string desiredFilename)
        {
            if (string.IsNullOrWhiteSpace(originFileName) || !File.Exists(originFileName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(desiredFilename) || !File.Exists(desiredFilename))
            {
                return false;
            }
            FileInfo fif = new FileInfo(originFileName);
            ImageFormat DesiredFormat;
            //根据扩张名，指定ImageFormat
            switch (fif.Extension)
            {
                case ".bmp":
                    DesiredFormat = ImageFormat.Bmp;
                    break;
                case ".gif":
                    DesiredFormat = ImageFormat.Gif;
                    break;
                case ".jpeg":
                    DesiredFormat = ImageFormat.Jpeg;
                    break;
                case ".ico":
                    DesiredFormat = ImageFormat.Icon;
                    break;
                case ".png":
                    DesiredFormat = ImageFormat.Png;
                    break;
                default:
                    DesiredFormat = ImageFormat.Jpeg;
                    break;
            }
            try
            {
                Image imgFile = Image.FromFile(originFileName);
                imgFile.Save(desiredFilename, DesiredFormat);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 图片缩放
        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片地址</param>
        /// <param name="dFile">压缩后保存图片地址</param>
        /// <param name="flag">压缩质量（数字越小压缩率越高）1-100</param>
        /// <param name="size">压缩后图片的最大大小</param>
        /// <param name="sfsc">是否是第一次调用</param>
        /// <returns></returns>
        public static bool CompressImage(string sFile, string dFile, int flag = 90, int size = 300, bool sfsc = true)
        {
            //如果是第一次调用，原始图像的大小小于要压缩的大小，则直接复制文件，并且返回true
            FileInfo firstFileInfo = new FileInfo(sFile);
            if (sfsc == true && firstFileInfo.Length < size * 1024)
            {
                firstFileInfo.CopyTo(dFile);
                return true;
            }
            Image iSource = ReadImage(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int dHeight = iSource.Height / 2;
            int dWidth = iSource.Width / 2;
            int sW = 0, sH = 0;
            //按比例缩放
            Size tem_size = new Size(iSource.Width, iSource.Height);
            if (tem_size.Width > dHeight || tem_size.Width > dWidth)
            {
                if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (tem_size.Width * dHeight) / tem_size.Height;
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }

            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            g.Dispose();

            //以下代码为保存图片时，设置压缩质量
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100
            EncoderParameter eParam = new EncoderParameter(Encoder.Quality, qy);
            ep.Param[0] = eParam;

            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径
                    FileInfo fi = new FileInfo(dFile);
                    if (fi.Length > 1024 * size)
                    {
                        flag = flag - 10;
                        CompressImage(sFile, dFile, flag, size, false);
                    }
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }
        /// <summary>
        /// 图片固定大小缩放
        /// </summary>
        /// <param name="originFileName">源文件相对地址</param>
        /// <param name="desiredFilename">目标文件相对地址</param>
        /// <param name="intWidth">目标文件宽</param>
        /// <param name="intHeight">目标文件高</param>
        /// <param name="imageFormat">图片文件格式</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ChangeImageSize(string originFileName, string desiredFilename, int intWidth, int intHeight, ImageFormat imageFormat)
        {
            if (string.IsNullOrWhiteSpace(originFileName) || !File.Exists(originFileName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(desiredFilename) || !File.Exists(desiredFilename))
            {
                return false;
            }

            FileStream myOutput = null;
            try
            {
                Image.GetThumbnailImageAbort myAbort = new Image.GetThumbnailImageAbort(ImageAbort);
                Image sourceImage = ReadImage(originFileName);//来源图片定义
                if (sourceImage == null)
                {
                    return false;
                }
                Image targetImage = sourceImage.GetThumbnailImage(intWidth, intHeight, myAbort, IntPtr.Zero);  //目的图片定义
                //将TargetFileNameStr的图片放宽为IntWidth，高为IntHeight 
                myOutput = new FileStream(desiredFilename, FileMode.Create, FileAccess.Write, FileShare.Write);
                targetImage.Save(myOutput, imageFormat);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                myOutput.Close();
            }
        }
        /// <summary>
        /// Images the abort.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool ImageAbort()
        {
            return false;
        }
        #endregion

        #region 文字水印
        /// <summary>
        /// 文字水印
        /// </summary>
        /// <param name="wtext">水印文字</param>
        /// <param name="source">原图片物理文件名</param>
        /// <param name="target">生成图片物理文件名</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ImageWaterText(string wtext, string source, string target)
        {
            bool resFlag = false;
            Image image = ReadImage(source);
            if (image == null) return false;
            Graphics graphics = Graphics.FromImage(image);
            try
            {
                graphics.DrawImage(image, 0, 0, image.Width, image.Height);
                Font font = new Font("Verdana", 60);
                Brush brush = new SolidBrush(Color.Green);
                graphics.DrawString(wtext, font, brush, 35, 35);
                image.Save(target);
                resFlag = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                graphics.Dispose();
                image.Dispose();
            }
            return resFlag;
        }
        #endregion

        #region 图片水印
        /// <summary>
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="source">原服务器图片路径</param>
        /// <param name="target">生成的带图片水印的图片路径</param>
        /// <param name="waterPicSource">水印图片路径</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ImageWaterPic(string source, string target, string waterPicSource)
        {
            bool resFlag = false;
            Image sourceimage = ReadImage(source);
            if (sourceimage == null) return false;
            Graphics sourcegraphics = Graphics.FromImage(sourceimage);
            Image waterPicSourceImage = ReadImage(waterPicSource);
            if (waterPicSourceImage == null) return false;
            try
            {
                sourcegraphics.DrawImage(waterPicSourceImage, new Rectangle(sourceimage.Width - waterPicSourceImage.Width, sourceimage.Height - waterPicSourceImage.Height, waterPicSourceImage.Width, waterPicSourceImage.Height), 0, 0, waterPicSourceImage.Width, waterPicSourceImage.Height, GraphicsUnit.Pixel);
                sourceimage.Save(target);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sourcegraphics.Dispose();
                sourceimage.Dispose();
                waterPicSourceImage.Dispose();
            }
            return resFlag;

        }

        #endregion
    }
}
