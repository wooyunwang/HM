using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Flurl.Http;
using Flurl;
using System.Threading.Tasks;

namespace HM.Face.Common_.EyeCool
{
    public partial class EyeCoolAPI
    {
        string APP_ID { get; set; }
        string APP_KEY { get; set; }
        public Uri ROOT_URL { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rootUrl"></param>
        public EyeCoolAPI(Uri rootUrl)
        {
            APP_ID = Constant.APP_ID;
            APP_KEY = Constant.APP_KEY;
            ROOT_URL = rootUrl;
        }

        public EyeCoolAPI(string ip, int port)
        {
            APP_ID = Constant.APP_ID;
            APP_KEY = Constant.APP_KEY;
            ROOT_URL = new Uri($"http://{ip}:{port}/");
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rootUrl"></param>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        public EyeCoolAPI(Uri rootUrl, string appId, string appKey)
        {
            this.APP_ID = appId;
            this.APP_KEY = appKey;
            this.ROOT_URL = rootUrl;
        }


        /// <summary>
        /// 填充id和key
        /// </summary>
        /// <param name="request"></param>
        private void FillIDAndKey(RequestBase request)
        {
            request.app_id = APP_ID;
            request.app_key = APP_KEY;
        }
    }
}
