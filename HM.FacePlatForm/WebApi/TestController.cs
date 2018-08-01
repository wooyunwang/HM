using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Flurl.Http;
using Flurl;
using System.Diagnostics;
using HM.Enum_;
using HM.Enum_.ControlCenter;
using System.IO;

namespace HM.FacePlatForm.WebApi
{
    public class TestController : BaseTestApiController
    {
#if DEBUG

        public IHttpActionResult GetFileByIdTest()
        {
            var dir = Path.Combine(Environment.CurrentDirectory, "TestDownFile");
            if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            var result = _baseUrl
               .AppendPathSegment("api/DownloadFile/GetFileResponse")
               .SetQueryParams(new
               {
                   fileType = FileType.Photo,
                   fileId = "00000000-0000-0000-0000-000000000001"
               })
               .WithOAuthBearerToken(_token.access_token)
               .DownloadFileAsync(dir, DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg").Result;

            return Ok(result);
        }

#endif
    }
}
