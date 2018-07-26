using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Flurl.Http;

namespace HM.MasterControl.WebApi
{
    public class TestController : ApiController
    {
        /// <summary>
        /// 测试token
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> GetTokenAsync()
        {
            //获得token
            var dict = new SortedDictionary<string, string>();
            dict.Add("client_id", "VankeService");
            dict.Add("client_secret", "Vanke123#");
            dict.Add("grant_type", "client_credentials");
            var data = await (@"http://" + Request.RequestUri.Authority + @"/token").PostUrlEncodedAsync(dict).ReceiveJson<Token>();
            var versionInfo = await (@"http://" + Request.RequestUri.Authority + @"/api/Info/GetVersion").WithOAuthBearerToken(data.access_token).GetAsync().ReceiveString();
            return Ok(new { data = versionInfo });
        }
    }
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
    }
}
