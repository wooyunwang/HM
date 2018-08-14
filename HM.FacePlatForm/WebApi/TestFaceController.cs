using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Flurl.Http;
using Flurl;

namespace HM.FacePlatform.WebApi
{
    public class ApiGetFacePassOutVO
    {
        public string face_id { get; set; }
        public string cid { get; set; }
        public string cardNo { get; set; }
        public DateTime passtime { get; set; }
        public string cNo { get; set; }
        public List<FacePassOutFace> face_obj { get; set; }
    }

    public class FacePassOutFace
    {
        public int face_id { get; set; }
        public string cat_image { get; set; }
        public double score { get; set; }
    }

    public class TestFaceController : ApiController
    {
        public String APP_ID = "98f1e4a39e964276af281a5ce49a9af4";
        public String APP_KEY = "55ba7c5759754a0fa315acf295fbda7a";

        /// <summary>
        /// 主控程序WebAPI本地测试url
        /// </summary>
        protected readonly string _baseUrl = "http://{0}:8080";
        protected Token _token { get; set; }

        public IHttpActionResult GetCurrentDetail()
        {
            List<string> lstIP = new List<string>() { "10.17.222.178", "10.17.222.175", "10.17.222.146", "10.17.222.36", "10.17.222.128", "10.17.222.176" };

            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var ip in lstIP)
            {
                var result = string.Format(_baseUrl, ip)
                .AppendPathSegment("/faceInterface/biovregister/current_detail")
                .PostJsonAsync(new
                {
                    app_id = APP_ID,
                    app_key = APP_KEY,
                    //crowd_name = "",
                    updateTime = DateTime.Now.AddYears(-2),
                    endtime = DateTime.Now,
                    pageSize = 500,
                    pageNumber = 1
                }).ReceiveJson<List<ApiGetFacePassOutVO>>().Result;

                int i = result.Count(it => it.face_obj == null);

                dic.Add(ip, result.Count);
            }
            return Ok(dic);
        }
    }
}
