using HM.Common_.DTO;
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
        /// <summary>
        /// 传化为结果对象
        /// </summary>
        /// <returns></returns>
        public ActionResult ToActionResult()
        {
            ActionResult ar = new ActionResult()
            {
                IsSuccess = res_code_enum == ResponseCode._0000
            };
            ar.Add(res_msg);
            return ar;
        }
        /// <summary>
        /// 传化为结果对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ActionResult<T> ToActionResult<T>(T obj) where T : class
        {
            ActionResult<T> ar = new ActionResult<T>()
            {
                IsSuccess = res_code_enum == ResponseCode._0000
            };
            ar.Obj = obj;
            ar.Add(res_msg);
            return ar;
        }
    }
}
