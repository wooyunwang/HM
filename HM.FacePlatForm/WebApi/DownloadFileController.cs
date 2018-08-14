using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Net.Http.Headers;
using HM.Enum_.ControlCenter;

namespace HM.FacePlatform.WebApi
{
    /// <summary>
    /// .Net WebAPI 高速下载文件接口实现
    /// </summary>
    public class DownloadFileController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public HttpResponseMessage GetFileResponse(string filePath, string fileName = null, string contentType = "application/octet-stream")
        {
            HttpResponseMessage response;
            IWriteStreamToResponse<string> ResponseStreamWriter;
            Action<Stream, HttpContent, TransportContext> sendMethod;

            ResponseStreamWriter = new StreamFromFileName() { Source = filePath };
            sendMethod = ResponseStreamWriter.WriteToStream;
            response = Request.CreateResponse();
            response.Content = new PushStreamContent(sendMethod);

            response.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = (fileName ?? Path.GetFileName(filePath));

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public HttpResponseMessage GetFileById(FileType fileType, string fileId)
        {
            return GetFileResponse(Path.Combine(Environment.CurrentDirectory, "App_Nginx", "ControlCenter", Utils_.EnumHelper.GetName(fileType), fileId + ".jpg"));
        }

        #region 辅助函数
        public interface IWriteStreamToResponse<T>
        {
            T Source { get; set; }
            void WriteToStream(Stream outputStream, HttpContent content, TransportContext context);
        }

        public class StreamFromFileName : IWriteStreamToResponse<string>
        {
            public string Source { get; set; }

            public async void WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
            {
                try
                {
                    var buffer = new byte[1024 * 1024 * 2];
                    using (var video = File.Open(Source, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        var length = (int)video.Length;
                        var bytesRead = 1;

                        while (length > 0 && bytesRead > 0)
                        {
                            bytesRead = video.Read(buffer, 0, Math.Min(length, buffer.Length));
                            await outputStream.WriteAsync(buffer, 0, bytesRead);
                            length -= bytesRead;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
                finally
                {
                    outputStream.Close();
                }
            }
        }

        public class StreamFromBytes : IWriteStreamToResponse<Stream>
        {
            public Stream Source { get; set; }

            public async void WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
            {
                try
                {
                    var buffer = new byte[1024 * 1024 * 2];
                    using (var video = Source)
                    {
                        var length = (int)video.Length;
                        var bytesRead = 1;

                        while (length > 0 && bytesRead > 0)
                        {
                            bytesRead = video.Read(buffer, 0, Math.Min(length, buffer.Length));
                            await outputStream.WriteAsync(buffer, 0, bytesRead);
                            length -= bytesRead;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
                finally
                {
                    Source.Close();
                    outputStream.Close();
                }
            }
        }
        #endregion

    }
}
