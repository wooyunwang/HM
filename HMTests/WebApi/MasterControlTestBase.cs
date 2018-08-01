using Microsoft.VisualStudio.TestTools.UnitTesting;
using HM.MasterControl.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Testing;
using System.Net.Http;
using Flurl;

namespace HM.MasterControl.WebApi.Tests
{
    /// <summary>
    /// 参考
    /// https://flurl.io/
    /// https://flurl.io/docs/fluent-url/
    /// https://github.com/tmenier/Flurl
    /// </summary>
    public class MasterControlTestBase
    {
        /// <summary>
        /// 主控程序WebAPI本地测试url
        /// </summary>
        protected readonly string _baseUrl = "http://localhost:9000";
        protected Token _token { get; set; }


        public MasterControlTestBase()
        {
            var dict = new SortedDictionary<string, string>();
            dict.Add("client_id", "VankeService");
            dict.Add("client_secret", "Vanke123#");
            dict.Add("grant_type", "client_credentials");
            _token = _baseUrl.AppendPathSegment("token").PostUrlEncodedAsync(dict).ReceiveJson<Token>().Result;
        }
    }
}
