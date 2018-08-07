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

namespace HM.Cloud.Client.WebApi
{
    public class TestController : BaseTestApiController
    {
#if DEBUG
        public IHttpActionResult DemoTest()
        {
            var result = _baseUrl
               .AppendPathSegment("api/Controller/Action")
               .SetQueryParams(new
               {
                   param = ""
               })
               .WithOAuthBearerToken(_token.access_token)
               .GetAsync().Result;

            return Ok(result);
        }
#endif
    }
}
