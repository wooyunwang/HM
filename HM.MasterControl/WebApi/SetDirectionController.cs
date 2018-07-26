using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HM.MasterControl.WebApi
{
    /// <summary>
    /// 设置通行方向
    /// </summary>
    public class SetDirectionController : BaseApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "linezero", "owin linezero blog" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return string.Format("owin {0} by:linezero", id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
