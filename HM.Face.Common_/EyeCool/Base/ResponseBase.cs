using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Face.Common_.EyeCool
{
    public class ResponseBase
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public string res_code { get; set; }
        /// <summary>
        /// 响应信息
        /// </summary>
        public string res_msg { get; set; }
        /// <summary>
        /// 返回码（枚举）
        /// </summary>
        [JsonIgnore]
        public ResponseCode? res_code_enum
        {
            get
            {
                ResponseCode responseCode;
                if (Enum.TryParse("_" + res_code, out responseCode))
                {
                    return responseCode;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
