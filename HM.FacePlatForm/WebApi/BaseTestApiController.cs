using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Flurl.Http;
using Flurl;


namespace HM.FacePlatform
{
    public class BaseTestApiController : ApiController
    {
        /// <summary>
        /// 主控程序WebAPI本地测试url
        /// </summary>
        protected readonly string _baseUrl = "http://localhost:9100";
        protected Token _token { get; set; }

        public BaseTestApiController()
        {
            string baseAddress = Utils_.Config_.GetString("WebAppBaseAddress");
            if (!string.IsNullOrWhiteSpace(baseAddress))
            {
                _baseUrl = baseAddress;
            }

            var dict = new SortedDictionary<string, string>
            {
                { "client_id", "VankeService" },
                { "client_secret", "Vanke123#" },
                { "grant_type", "client_credentials" }
            };
            _token = _baseUrl.AppendPathSegment("token").PostUrlEncodedAsync(dict).ReceiveJson<Token>().Result;
        }
    }

    public class Token
    {
        /// <summary>
        /// 
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string token_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expires_in { get; set; }
    }
}
