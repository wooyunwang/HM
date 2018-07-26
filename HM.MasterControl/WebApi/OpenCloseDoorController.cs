using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace HM.MasterControl.WebApi
{
    /// <summary>
    /// 开关门
    /// </summary>
    public class OpenCloseDoorController : BaseApiController
    {
        public bool Get(string projectCode, int catCode, bool isADoor = true)
        {
            return true;
        }

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        public HttpResponseMessage Put([FromBody]OpenCloseDoorInput input)
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "未实现");
        }

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
    public enum DoorType
    {
        /// <summary>
        /// A门，又称闸机
        /// </summary>
        A = 0,
        /// <summary>
        /// B门，又称玻璃门
        /// </summary>
        B = 1
    }
    public class OpenCloseDoorInput
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// 猫编号
        /// </summary>
        public int CatCode { get; set; }
        /// <summary>
        /// 门类型
        /// </summary>
        public DoorType DoorType { get; set; }
        /// <summary>
        /// 是否开门
        /// </summary>
        public bool OpenOrClose { get; set; }
    }
}
