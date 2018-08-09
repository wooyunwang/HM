using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Utils_
{
    public class Exception_
    {
        /// <summary>获得深层次的错误
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception GetInnerException(Exception ex)
        {
            return (ex.InnerException == null) ? ex : GetInnerException(ex.InnerException);
        }
    }
}
