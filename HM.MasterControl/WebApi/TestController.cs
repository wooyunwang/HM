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

namespace HM.MasterControl.WebApi
{
    public class TestController : BaseTestApiController
    {
        //public TestController() : base()
        //{
        //}
#if DEBUG
        /// <summary>
        /// 测试token
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetTokenTest()
        {
            return Ok(_token);
        }


        public IHttpActionResult GetVersionTest()
        {
            Version result = _baseUrl
                .AppendPathSegment("api/Info/GetVersion")
                .WithOAuthBearerToken(_token.access_token)
                .GetJsonAsync<Version>().Result;

            return Ok(result);
        }


        public IHttpActionResult GetOSInfoTest()
        {
            var result = _baseUrl
               .AppendPathSegment("api/Info/GetOSInfo")
               .WithOAuthBearerToken(_token.access_token)
               .GetJsonAsync<object>().Result;

            return Ok(result);
        }


        public IHttpActionResult GetFileVersionInfoTest()
        {
            FileVersionInfo result = _baseUrl
               .AppendPathSegment("api/Info/GetFileVersionInfo")
               .WithOAuthBearerToken(_token.access_token)
               .GetJsonAsync<FileVersionInfo>().Result;

            return Ok(result);
        }


        public IHttpActionResult GetConfigTest()
        {
            var lst = new List<MasterControlConfigFileName>() {
                MasterControlConfigFileName.VoiceConfigInfo
            };
            Dictionary<MasterControlConfigFileName, string> result = _baseUrl
               .AppendPathSegment("api/Info/GetConfig")
               .SetQueryParams(new
               {
                   lstConfigName = lst
               })
               .WithOAuthBearerToken(_token.access_token)
               .GetJsonAsync<Dictionary<MasterControlConfigFileName, string>>().Result;

            return Ok(result);
        }

#endif
    }
}
